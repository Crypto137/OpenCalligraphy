namespace OpenCalligraphy.Core.GameData.Prototypes
{
    /// <summary>
    /// Contains a record of a <see cref="Prototypes.Prototype"/> managed by the <see cref="DataDirectory"/>.
    /// </summary>
    public class PrototypeDataRefRecord
    {
        public PrototypeId PrototypeId { get; set; }
        public PrototypeGuid PrototypeGuid { get; set; }
        public BlueprintId BlueprintId { get; set; }
        public PrototypeRecordFlags Flags { get; set; }
        public string RuntimeBinding { get; set; }
        public DataOrigin DataOrigin { get; set; }          // PrototypeDataRefRecord + 32
        public Blueprint Blueprint { get; set; }
        public Prototype Prototype { get; set; }            // PrototypeDataRefRecord + 48
        public ulong Crc { get; set; }                      // PrototypeDataRefRecord + 56
    }
}
