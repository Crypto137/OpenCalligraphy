using OpenCalligraphy.Core.Logging;
using System.Collections;

namespace OpenCalligraphy.Core.GameData
{
    public class CurveDirectory : IEnumerable<Curve>
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        private readonly Dictionary<CurveId, CurveRecord> _curveRecordDict = new();

        public static CurveDirectory Instance { get; } = new();

        public int RecordCount { get => _curveRecordDict.Count; }

        private CurveDirectory() { }

        public CurveRecord CreateCurveRecord(CurveId id, CurveGuid guid, CurveRecordFlags flags)
        {
            CurveRecord record = new() { Guid = guid, Flags = flags };
            _curveRecordDict.Add(id, record);
            return record;
        }

        public CurveRecord GetCurveRecord(CurveId id)
        {
            if (_curveRecordDict.TryGetValue(id, out CurveRecord record) == false)
                return null;

            return record;
        }

        public Curve GetCurve(CurveId id)
        {
            if (id == CurveId.Invalid)
                return null;

            // Look for a record for the specified id
            if (_curveRecordDict.TryGetValue(id, out CurveRecord record) == false)
                return Logger.WarnReturn<Curve>(null, $"GetCurve(): Failed to get curve id {id}");

            // Load the curve if needed
            if (record.Curve == null)
            {
                string filePath = $"Calligraphy/{GameDatabase.GetCurveName(id)}";
                using (Stream stream = DataDirectory.Instance.LoadPakDataFile(filePath))
                    record.Curve = new(stream, id);
            }

            return record.Curve;
        }

        public void Clear()
        {
            _curveRecordDict.Clear();
        }

        public IEnumerator<Curve> GetEnumerator()
        {
            foreach (CurveRecord record in _curveRecordDict.Values)
                yield return record.Curve;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class CurveRecord
        {
            public Curve Curve { get; set; }
            public CurveGuid Guid { get; set; }
            public CurveRecordFlags Flags { get; set; }
        }
    }
}
