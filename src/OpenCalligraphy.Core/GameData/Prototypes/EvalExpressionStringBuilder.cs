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
                "AddPrototype"              => BuildAddString(prototype),
                "SubPrototype"              => BuildSubString(prototype),
                "MultPrototype"             => BuildMultString(prototype),
                "DivPrototype"              => BuildDivString(prototype),
                "ExponentPrototype"         => BuildExponentString(prototype),
                "ScopePrototype"            => BuildScopeString(prototype),
                "MaxPrototype"              => BuildMaxString(prototype),
                "MinPrototype"              => BuildMinString(prototype),
                "ModulusPrototype"          => BuildModulusString(prototype),
                _                           => runtimeBinding,
            };
        }

        private static string BuildAssignPropString(Prototype prototype)
        {
            PrototypeRHStructField prop = prototype.GetField<PrototypeRHStructField>((StringId)724136433262596945);
            PrototypeRHStructField eval = prototype.GetField<PrototypeRHStructField>((StringId)4580320502963901240);

            string propertyName = prop.IsNull == false
                ? PropertyHelper.BuildPropertyName(prop.Value)
                : "!PropError!";

            return string.Format("{0} = {1}",
                string.IsNullOrWhiteSpace(propertyName) == false ? propertyName : "!PropError!",
                eval.IsNull == false ? TryBuildExpressionString(eval.Value) : "NULL");
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

        private static string BuildAddString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)3495376335162641723);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)13694625831420497212);

            return string.Format("( {0} + {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildSubString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)16967165442422017372);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)7347760170625207645);

            return string.Format("( {0} - {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildMultString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)2987240927944314324);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)12104488527688437205);

            return string.Format("( {0} * {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildDivString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)13294163033536204117);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)3959048029383036246);

            return string.Format("( {0} / {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildExponentString(Prototype prototype)
        {
            PrototypeRHStructField baseArg = prototype.GetField<PrototypeRHStructField>((StringId)14830563409780674797);
            PrototypeRHStructField expArg = prototype.GetField<PrototypeRHStructField>((StringId)13148633132407001247);

            return string.Format("( {0}^{1} )",
                baseArg.IsNull == false ? TryBuildExpressionString(baseArg.Value) : "NULL",
                expArg.IsNull == false ? TryBuildExpressionString(expArg.Value) : "NULL");
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

        private static string BuildMaxString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)1044928077854739800);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)9227685901745065305);

            return string.Format("Max({0}, {1})",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildMinString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)3473854232610147670);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)13743468633344904535);

            return string.Format("Min({0}, {1})",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildModulusString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)722946436704440091);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)9549720381698281244);

            return string.Format("Modulus({0}, {1})",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }
    }
}
