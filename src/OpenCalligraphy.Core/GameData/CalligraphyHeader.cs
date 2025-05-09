﻿using OpenCalligraphy.Core.Extensions;

namespace OpenCalligraphy.Core.GameData
{
    public readonly struct CalligraphyHeader
    {
        public string Magic { get; }    // File signature
        public byte Version { get; }    // 10 for versions 1.9-1.17, 11 for 1.18+

        public CalligraphyHeader(BinaryReader reader)
        {
            Magic = reader.ReadBytesAsUtf8String(3);
            Version = reader.ReadByte();
        }
    }
}
