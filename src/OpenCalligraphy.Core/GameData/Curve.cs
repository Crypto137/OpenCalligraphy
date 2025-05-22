using OpenCalligraphy.Core.Logging;

namespace OpenCalligraphy.Core.GameData
{
    public class Curve
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        private readonly double[] _values;

        public double this[int index] { get => _values[index]; }

        public CurveId Id { get; }
        public int MinPosition { get; }    // m_startPosition
        public int MaxPosition { get; }    // m_endPosition

        public bool IsCurveZero { get; private set; } = true;

        /// <summary>
        /// Deserializes a new <see cref="Curve"/> instance from a <see cref="Stream"/>.
        /// </summary>
        public Curve(Stream stream, CurveId curveId)
        {
            Id = curveId;

            using BinaryReader reader = new(stream);

            CalligraphyHeader header = new(reader);

            MinPosition = reader.ReadInt32();
            MaxPosition = reader.ReadInt32();

            _values = new double[MaxPosition - MinPosition + 1];
            for (int i = 0; i < _values.Length; i++)
            {
                double value = reader.ReadDouble();
                _values[i] = value;
                IsCurveZero &= value == 0;
            }
        }

        public override string ToString()
        {
            return GameDatabase.GetCurveName(Id);
        }

        /// <summary>
        /// Returns the value at the specified position as <see cref="double"/>.
        /// </summary>
        public double GetAt(int position)
        {
            if (position < MinPosition)
                Logger.Warn($"GetAt(): Curve position {position} below min of {MinPosition}, curve {this}");
            else if (position > MaxPosition)
                Logger.Warn($"GetAt(): Curve position {position} above max of {MaxPosition}, curve {this}");

            position = Math.Clamp(position, MinPosition, MaxPosition);
            int index = position - MinPosition;
            return _values[index];
        }
    }
}
