﻿namespace OpenCalligraphy.Core.GameData
{
    public sealed class ReplacementDirectory
    {
        private readonly Dictionary<ulong, ReplacementRecord> _replacementDict = new();

        public static ReplacementDirectory Instance { get; } = new();

        public int RecordCount { get => _replacementDict.Count; }

        private ReplacementDirectory() { }

        public void AddReplacementRecord(ulong oldGuid, ulong newGuid, string name)
        {
            ReplacementRecord record = new(oldGuid, newGuid, name);
            _replacementDict.Add(oldGuid, record);
        }

        public ReplacementRecord GetReplacementRecord(ulong guid)
        {
            if (_replacementDict.TryGetValue(guid, out ReplacementRecord record) == false)
                return null;

            return record;
        }

        public void Clear()
        {
            _replacementDict.Clear();
        }

        public class ReplacementRecord
        {
            public ulong OldGuid { get; }
            public ulong NewGuid { get; }
            public string Name { get; }

            public ReplacementRecord(ulong oldGuid, ulong newGuid, string name)
            {
                OldGuid = oldGuid;
                NewGuid = newGuid;
                Name = name;
            }
        }
    }
}
