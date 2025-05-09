using K4os.Compression.LZ4;

namespace OpenCalligraphy.Core.Helpers
{
    public static class CompressionHelper
    {
        /// <summary>
        /// Decompresses the provided LZ4 buffer.
        /// </summary>
        public static void LZ4Decode(ReadOnlySpan<byte> source, Span<byte> target)
        {
            LZ4Codec.Decode(source, target);
        }
    }
}
