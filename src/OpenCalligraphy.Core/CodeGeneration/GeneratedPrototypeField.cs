﻿using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Core.Logging;

namespace OpenCalligraphy.Core.CodeGeneration
{
    public class GeneratedPrototypeField
    {
        private static readonly Logger Logger = LogManager.CreateLogger();

        private readonly GeneratedPrototypeClass _prototypeClass;

        public string Name { get; }
        public CalligraphyBaseType BaseType { get; }
        public CalligraphyStructureType StructureType { get; }
        public ulong Subtype { get; }

        public GeneratedPrototypeField(GeneratedPrototypeClass prototypeClass, string name, CalligraphyBaseType baseType, CalligraphyStructureType structureType, ulong subtype)
        {
            _prototypeClass = prototypeClass;

            Name = name;
            BaseType = baseType;
            StructureType = structureType;
            Subtype = subtype;
        }

        public string GenerateCode()
        {
            string typeName;

            if (BaseType == CalligraphyBaseType.RHStruct)
            {
                Blueprint blueprint = GameDatabase.GetBlueprint((BlueprintId)Subtype);

                if (blueprint == null)
                {
                    // HACK: This seems to be happening only for EvalPrototype fields, so we'll just fall back to it
                    Logger.Warn($"Invalid subtype {Subtype} for RHStruct field {Name} in {_prototypeClass.Name}, falling back to EvalPrototype");
                    typeName = "EvalPrototype";
                }
                else
                {
                    typeName = blueprint.RuntimeBinding;

                    // Replace mixin property prototypes with PropertyId
                    if (typeName == "PropertyPrototype")
                        typeName = "PropertyId";
                }
            }
            else
            {
                typeName = BaseType switch
                {
                    CalligraphyBaseType.Asset => "AssetId",
                    CalligraphyBaseType.Boolean => "bool",
                    CalligraphyBaseType.Curve => "CurveId",
                    CalligraphyBaseType.Double => "double",
                    CalligraphyBaseType.Long => "long",
                    CalligraphyBaseType.Prototype => "PrototypeId",
                    CalligraphyBaseType.String => "LocaleStringId",
                    CalligraphyBaseType.Type => "AssetTypeId",
                    _ => throw new()
                };
            }

            string typeSuffix = StructureType == CalligraphyStructureType.List ? "[]" : string.Empty;

            // Special handling for property list (appears in ModPrototype only)
            if (typeName == "PropertyId" && StructureType == CalligraphyStructureType.List)
            {
                typeName = "PrototypePropertyCollection";
                typeSuffix = string.Empty;
            }

            return $"public {typeName}{typeSuffix} {Name} {{ get; protected set; }}";
        }
    }
}
