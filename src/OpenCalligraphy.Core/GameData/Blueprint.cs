using OpenCalligraphy.Core.Extensions;

namespace OpenCalligraphy.Core.GameData
{
    public class Blueprint
    {
        private Dictionary<StringId, BlueprintMember> _memberDict;                  // Field definitions for prototypes that use this blueprint  

        public BlueprintId Id { get; }
        public BlueprintGuid Guid { get; }

        public string RuntimeBinding { get; }
        public PrototypeId DefaultPrototypeId { get; }                              // .defaults prototype file id
        public BlueprintReference[] Parents { get; }
        public BlueprintReference[] ContributingBlueprints { get; }

        public bool IsPropertyMixin { get; }

        public IReadOnlyCollection<BlueprintMember> Members { get => _memberDict.Values; }

        /// <summary>
        /// Deserializes a new <see cref="Blueprint"/> instance from a <see cref="Stream"/>.
        /// </summary>
        public Blueprint(Stream stream, BlueprintId id, BlueprintGuid guid)
        {
            Id = id;
            Guid = guid;

            // Deserialize
            using BinaryReader reader = new(stream);

            CalligraphyHeader header = new(reader);

            RuntimeBinding = reader.ReadFixedString16();

            DefaultPrototypeId = (PrototypeId)reader.ReadUInt64();

            Parents = new BlueprintReference[reader.ReadInt16()];
            for (int i = 0; i < Parents.Length; i++)
                Parents[i] = new(reader);

            ContributingBlueprints = new BlueprintReference[reader.ReadInt16()];
            for (int i = 0; i < ContributingBlueprints.Length; i++)
                ContributingBlueprints[i] = new(reader);

            // Deserialize members
            int numMembers = reader.ReadInt16();
            _memberDict = new(numMembers);
            for (int i = 0; i < numMembers; i++)
            {
                BlueprintMember member = new(reader);
                _memberDict.Add(member.FieldId, member);
            }

            // HACK: Mark this as a property mixin based on its path
            IsPropertyMixin = Id.GetName().StartsWith("Property/Mixin/", StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return Id.GetName();
        }

        public BlueprintMember GetMember(StringId id)
        {
            if (_memberDict.TryGetValue(id, out BlueprintMember member) == false)
                return null;

            return member;
        }
    }

    /// <summary>
    /// Contains a reference to another blueprint.
    /// </summary>
    public readonly struct BlueprintReference
    {
        public BlueprintId BlueprintId { get; }
        public byte NumOfCopies { get; }

        /// <summary>
        /// Deserializes a <see cref="BlueprintReference"/>.
        /// </summary>
        public BlueprintReference(BinaryReader reader)
        {
            BlueprintId = (BlueprintId)reader.ReadUInt64();
            NumOfCopies = reader.ReadByte();
        }
    }

    /// <summary>
    /// Defines a field in a Calligraphy prototype.
    /// </summary>
    public class BlueprintMember
    {
        public StringId FieldId { get; }
        public string FieldName { get; }
        public CalligraphyBaseType BaseType { get; }
        public CalligraphyStructureType StructureType { get; }
        public ulong Subtype { get; }

        /// <summary>
        /// Deserializes a new <see cref="BlueprintMember"/> instance.
        /// </summary>
        public BlueprintMember(BinaryReader reader)
        {
            FieldId = (StringId)reader.ReadUInt64();
            FieldName = reader.ReadFixedString16();
            BaseType = (CalligraphyBaseType)reader.ReadByte();
            StructureType = (CalligraphyStructureType)reader.ReadByte();

            switch (BaseType)
            {
                // Only these base types have subtypes
                case CalligraphyBaseType.Asset:
                case CalligraphyBaseType.Curve:
                case CalligraphyBaseType.Prototype:
                case CalligraphyBaseType.RHStruct:
                    Subtype = reader.ReadUInt64();
                    break;
            }

            GameDatabase.StringRefManager.AddDataRef(FieldId, FieldName);
        }
    }
}
