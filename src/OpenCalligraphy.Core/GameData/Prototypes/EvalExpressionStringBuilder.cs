using System.Text;
using OpenCalligraphy.Core.GameData.Prototypes.FieldTypes;

namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public static class EvalExpressionStringBuilder
    {
        private static readonly HashSet<string> EvalPrototypes = [
            "EvalPrototype",
            "ExportErrorPrototype",
            "AssignPropPrototype",
            "SwapPropPrototype",
            "AssignPropEvalParamsPrototype",
            "HasPropPrototype",
            "LoadPropPrototype",
            "LoadPropContextParamsPrototype",
            "LoadPropEvalParamsPrototype",
            "LoadBoolPrototype",
            "LoadIntPrototype",
            "LoadFloatPrototype",
            "LoadCurvePrototype",
            "LoadAssetRefPrototype",
            "LoadProtoRefPrototype",
            "LoadContextIntPrototype",
            "LoadContextProtoRefPrototype",
            "AddPrototype",
            "SubPrototype",
            "MultPrototype",
            "DivPrototype",
            "ExponentPrototype",
            "ScopePrototype",
            "GreaterThanPrototype",
            "LessThanPrototype",
            "EqualsPrototype",
            "AndPrototype",
            "OrPrototype",
            "NotPrototype",
            "IsContextDataNullPrototype",
            "IfElsePrototype",
            "DifficultyTierRangePrototype",
            "MissionIsActivePrototype",
            "GetCombatLevelPrototype",
            "GetPowerRankPrototype",
            "CalcPowerRankPrototype",
            "GetDamageReductionPctPrototype",
            "GetDistanceToEntityPrototype",
            "HasEntityInInventoryPrototype",
            "IsInPartyPrototype",
            "IsDynamicCombatLevelEnabledPrototype",
            "MissionIsCompletePrototype",
            "MaxPrototype",
            "MinPrototype",
            "ModulusPrototype",
            "RandomFloatPrototype",
            "RandomIntPrototype",
            "ForPrototype",
            "ForEachConditionInContextPrototype",
            "ForEachProtoRefInContextRefListPrototype",
            "LoadEntityToContextVarPrototype",
            "LoadConditionCollectionToContextPrototype",
            "EntityHasKeywordPrototype",
            "EntityHasTalentPrototype",
        ];

        public static string TryBuildExpressionString(Prototype prototype)
        {
            PrototypeId protoRef = prototype.ParentDataRef != PrototypeId.Invalid ? prototype.ParentDataRef : prototype.DataRef;
            string runtimeBinding = DataDirectory.Instance.GetPrototypeRuntimeBinding(protoRef);
            if (EvalPrototypes.Contains(runtimeBinding) == false)
                return string.Empty;

            if (prototype.FieldGroups.Count == 0 && prototype.ParentDataRef != PrototypeId.Invalid)
                prototype = prototype.ParentDataRef.AsPrototype();

            return DataDirectory.Instance.GetPrototypeRuntimeBinding(protoRef) switch
            {
                "AssignPropPrototype"       => BuildAssignPropString(prototype),
                "LoadBoolPrototype"         => BuildLoadBoolString(prototype),
                "LoadIntPrototype"          => BuildLoadIntString(prototype),
                "LoadFloatPrototype"        => BuildLoadFloatString(prototype),
                "ScopePrototype"            => BuildScopeString(prototype),
                _                           => runtimeBinding,
            };
        }

        private static string BuildAssignPropString(Prototype prototype)
        {
            PrototypeRHStructField prop = prototype.GetField<PrototypeRHStructField>((StringId)724136433262596945);
            PrototypeRHStructField eval = prototype.GetField<PrototypeRHStructField>((StringId)4580320502963901240);

            string propertyName = prop.Value.ParentDataRef != PrototypeId.Invalid
                ? Path.GetFileNameWithoutExtension(prop.Value.ParentDataRef.GetName())
                : "!PropError!";

            return string.Format("{0} = {1}",
                string.IsNullOrWhiteSpace(propertyName) == false ? propertyName : "!PropError!",
                eval != null ? TryBuildExpressionString(eval.Value) : "NULL");
        }

        private static string BuildLoadBoolString(Prototype prototype)
        {
            PrototypeBooleanField value = prototype.GetField<PrototypeBooleanField>((StringId)15488643904777163331);
            return $"{value?.Value}";
        }

        private static string BuildLoadIntString(Prototype prototype)
        {
            PrototypeLongField value = prototype.GetField<PrototypeLongField>((StringId)11067393523320230370);
            return $"{value?.Value}";
        }

        private static string BuildLoadFloatString(Prototype prototype)
        {
            PrototypeDoubleField value = prototype.GetField<PrototypeDoubleField>((StringId)529678382596428461);
            return $"{value?.Value}";
        }

        private static string BuildScopeString(Prototype prototype)
        {
            PrototypeRHStructListField scope = prototype.GetField<PrototypeRHStructListField>((StringId)13019546289270755818);
            if (scope == null || scope.Values.Count == 0)
                return "{ ..Empty.. }";

            StringBuilder sb = new();
            sb.Append('{');
            foreach (Prototype scopeEval in scope.Values)
                sb.Append($" {TryBuildExpressionString(scopeEval)};");
            sb.Append(" }");
            return sb.ToString();
        }
    }
}
