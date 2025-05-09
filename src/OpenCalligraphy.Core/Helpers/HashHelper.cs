namespace OpenCalligraphy.Core.Helpers
{
    public static class HashHelper
    {
        /// <summary>
        /// Hashes a <see cref="byte"/> array using the djb2 algorithm.
        /// </summary>
        public static uint Djb2(byte[] data)
        {
            uint hash = 5381;
            for (int i = 0; i < data.Length; i++)
                hash = (hash << 5) + hash + data[i];
            return hash;
        }
    }
}
