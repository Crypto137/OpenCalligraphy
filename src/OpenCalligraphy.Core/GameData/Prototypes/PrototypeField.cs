using OpenCalligraphy.Core.GameData.Prototypes.FieldTypes;

namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public abstract class PrototypeField
    {
        public BlueprintId DeclaringBlueprintId { get; }
        public StringId FieldId { get; }

        public virtual CalligraphyBaseType BaseType { get; }
        public virtual CalligraphyStructureType StructureType { get; }

        protected PrototypeField(BlueprintId declaringBlueprintId, StringId fieldId)
        {
            DeclaringBlueprintId = declaringBlueprintId;
            FieldId = fieldId;
        }

        public BlueprintMember GetBlueprintMember()
        {
            Blueprint blueprint = DeclaringBlueprintId.AsBlueprint();
            return blueprint.GetMember(FieldId);
        }

        public static PrototypeField CreateInstance(BlueprintId declaringBlueprintId, StringId fieldId,
            CalligraphyBaseType baseType, CalligraphyStructureType structureType)
        {
            switch (structureType)
            {
                case CalligraphyStructureType.Simple:
                    switch (baseType)
                    {
                        case CalligraphyBaseType.Asset:     return new PrototypeAssetField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Boolean:   return new PrototypeBooleanField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Curve:     return new PrototypeCurveField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Double:    return new PrototypeDoubleField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Long:      return new PrototypeLongField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Prototype: return new PrototypePrototypeField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.RHStruct:  return new PrototypeRHStructField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.String:    return new PrototypeStringField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Type:      return new PrototypeTypeField(declaringBlueprintId, fieldId);
                        default:                            return null;
                    }

                case CalligraphyStructureType.List:
                    switch (baseType)
                    {
                        case CalligraphyBaseType.Asset:     return new PrototypeAssetListField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Prototype: return new PrototypePrototypeListField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.RHStruct:  return new PrototypeRHStructListField(declaringBlueprintId, fieldId);
                        case CalligraphyBaseType.Type:      return new PrototypeTypeListField(declaringBlueprintId, fieldId);
                        default:                            return null;
                    }
            }

            return null;
        }

        public abstract void ParseFrom(BinaryReader reader);
    }

    public abstract class PrototypeSimpleField : PrototypeField
    {
        public override CalligraphyStructureType StructureType { get => CalligraphyStructureType.Simple; }

        public PrototypeSimpleField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        { 
        }
    }

    public abstract class PrototypeListField : PrototypeField
    {
        public override CalligraphyStructureType StructureType { get => CalligraphyStructureType.List; }

        public PrototypeListField(BlueprintId declaringBlueprintId, StringId fieldId) : base(declaringBlueprintId, fieldId)
        {
        }
    }
}
