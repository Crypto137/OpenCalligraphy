﻿using System.Text;
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
            if (prototype == null)
                return string.Empty;

            PrototypeId protoRef = prototype.ParentDataRef != PrototypeId.Invalid ? prototype.ParentDataRef : prototype.DataRef;
            string runtimeBinding = DataDirectory.Instance.GetPrototypeRuntimeBinding(protoRef);
            if (EvalPrototypes.Contains(runtimeBinding) == false)
                return string.Empty;

            if (prototype.FieldGroups.Count == 0 && prototype.ParentDataRef != PrototypeId.Invalid)
                prototype = prototype.ParentDataRef.AsPrototype();

            return DataDirectory.Instance.GetPrototypeRuntimeBinding(protoRef) switch
            {
                "ExportErrorPrototype"          => BuildExportErrorString(prototype),
                "AssignPropPrototype"           => BuildAssignPropString(prototype),
                "SwapPropPrototype"             => BuildSwapPropString(prototype),
                "AssignPropEvalParamsPrototype" => BuildAssignPropEvalParamsString(prototype),
                "HasPropPrototype"              => BuildHasPropString(prototype),
                "LoadPropPrototype"             => BuildLoadPropString(prototype),
                "LoadPropContextParamsPrototype"=> BuildLoadPropContextParamsString(prototype),
                "LoadPropEvalParamsPrototype"   => BuildLoadPropEvalParamsString(prototype),
                "LoadBoolPrototype"             => BuildLoadBoolString(prototype),
                "LoadIntPrototype"              => BuildLoadIntString(prototype),
                "LoadFloatPrototype"            => BuildLoadFloatString(prototype),
                "LoadCurvePrototype"            => BuildLoadCurveString(prototype),
                "LoadAssetRefPrototype"         => BuildLoadAssetRefString(prototype),
                "LoadProtoRefPrototype"         => BuildLoadProtoRefString(prototype),
                "LoadContextIntPrototype"       => BuildLoadContextIntString(prototype),
                "LoadContextProtoRefPrototype"  => BuildLoadContextProtoRefString(prototype),
                "AddPrototype"                  => BuildAddString(prototype),
                "SubPrototype"                  => BuildSubString(prototype),
                "MultPrototype"                 => BuildMultString(prototype),
                "DivPrototype"                  => BuildDivString(prototype),
                "ExponentPrototype"             => BuildExponentString(prototype),
                "ScopePrototype"                => BuildScopeString(prototype),
                "GreaterThanPrototype"          => BuildGreaterThanString(prototype),
                "LessThanPrototype"             => BuildLessThanString(prototype),
                "EqualsPrototype"               => BuildEqualsString(prototype),
                "AndPrototype"                  => BuildAndString(prototype),
                "OrPrototype"                   => BuildOrString(prototype),
                "NotPrototype"                  => BuildNotString(prototype),
                "IsContextDataNullPrototype"    => BuildIsContextDataNullString(prototype),
                "IfElsePrototype"               => BuildIfElseString(prototype),
                "DifficultyTierRangePrototype"  => BuildDifficultyTierRangeString(prototype),
                "MissionIsActivePrototype"      => BuildMissionIsActiveString(prototype),
                "GetCombatLevelPrototype"       => BuildGetCombatLevelString(prototype),
                "GetPowerRankPrototype"         => BuildGetPowerRankString(prototype),
                "CalcPowerRankPrototype"        => BuildCalcPowerRankString(prototype),
                "GetDamageReductionPctPrototype"=> BuildGetDamageReductionPctString(prototype),
                "GetDistanceToEntityPrototype"  => BuildGetDistanceToEntityString(prototype),
                "HasEntityInInventoryPrototype" => BuildHasEntityInInventoryString(prototype),
                "IsInPartyPrototype"            => BuildIsInPartyString(prototype),
                "IsDynamicCombatLevelEnabledPrototype" => BuildIsDynamicCombatLevelEnabledString(prototype),
                "MissionIsCompletePrototype"    => BuildMissionIsCompleteString(prototype),
                "MaxPrototype"                  => BuildMaxString(prototype),
                "MinPrototype"                  => BuildMinString(prototype),
                "ModulusPrototype"              => BuildModulusString(prototype),
                "RandomFloatPrototype"          => BuildRandomFloatString(prototype),
                "RandomIntPrototype"            => BuildRandomIntString(prototype),
                "ForPrototype"                  => BuildForString(prototype),
                "ForEachConditionInContextPrototype"        => BuildForEachConditionInContextString(prototype),
                "ForEachProtoRefInContextRefListPrototype"  => BuildForEachProtoRefInContextRefListString(prototype),
                "LoadEntityToContextVarPrototype"           => BuildLoadEntityToContextVarString(prototype),
                "LoadConditionCollectionToContextPrototype" => BuildLoadConditionCollectionToContextString(prototype),
                "EntityHasKeywordPrototype"     => BuildEntityHasKeywordString(prototype),
                "EntityHasTalentPrototype"      => BuildEntityHasTalentString(prototype),
                _                               => runtimeBinding,
            };
        }

        private static string BuildExportErrorString(Prototype prototype)
        {
            return "ExportError";
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

        private static string BuildSwapPropString(Prototype prototype)
        {
            PrototypeAssetField leftContext = prototype.GetField<PrototypeAssetField>((StringId)7366053580165617014);
            PrototypeRHStructField prop = prototype.GetField<PrototypeRHStructField>((StringId)13518078678604190343);
            PrototypeAssetField rightContext = prototype.GetField<PrototypeAssetField>((StringId)3171819579921274345);

            if (prop.IsNull)
                return "!PropError!";

            return $"SwapProp(LeftContext=[{leftContext.Value.GetName()}], RightContext=[{rightContext.Value.GetName()}], Prop={{{PropertyHelper.BuildPropertyName(prop.Value)}}}";
        }

        private static string BuildAssignPropEvalParamsString(Prototype prototype)
        {
            PrototypeRHStructField param0 = prototype.GetField<PrototypeRHStructField>((StringId)1279800786586638333);
            PrototypeRHStructField param1 = prototype.GetField<PrototypeRHStructField>((StringId)15954217832305858558);
            PrototypeRHStructField param2 = prototype.GetField<PrototypeRHStructField>((StringId)6046015935869032447);
            PrototypeRHStructField param3 = prototype.GetField<PrototypeRHStructField>((StringId)11479046443144779776);
            PrototypePrototypeField prop = prototype.GetField<PrototypePrototypeField>((StringId)2442776993551423357);
            PrototypeRHStructField eval = prototype.GetField<PrototypeRHStructField>((StringId)1475575110373087076);

            if (prop.Value == PrototypeId.Invalid)
                return $"!PropError! = {(eval?.IsNull == false ? TryBuildExpressionString(eval.Value) : "NULL")}";

            return string.Format("{0}({1},{2},{3},{4}) = {5}",
                prop?.Value.GetNameFormatted(),
                param0?.IsNull == false ? TryBuildExpressionString(param0.Value) : "",
                param1?.IsNull == false ? TryBuildExpressionString(param1.Value) : "",
                param2?.IsNull == false ? TryBuildExpressionString(param2.Value) : "",
                param3?.IsNull == false ? TryBuildExpressionString(param3.Value) : "",
                eval?.IsNull == false ? TryBuildExpressionString(eval.Value) : "NULL");
        }

        private static string BuildHasPropString(Prototype prototype)
        {
            PrototypeRHStructField prop = prototype.GetField<PrototypeRHStructField>((StringId)27003814968955400);

            if (prop.IsNull)
                return "!PropError!";

            return PropertyHelper.BuildPropertyName(prop.Value);
        }

        private static string BuildLoadPropString(Prototype prototype)
        {
            PrototypeRHStructField prop = prototype.GetField<PrototypeRHStructField>((StringId)5836910736336360044);

            if (prop.IsNull)
                return "!PropError!";

            return PropertyHelper.BuildPropertyName(prop.Value);
        }

        private static string BuildLoadPropContextParamsString(Prototype prototype)
        {
            PrototypeAssetField propertyCollectionContext = prototype.GetField<PrototypeAssetField>((StringId)12241138694009921770);
            PrototypeRHStructField prop = prototype.GetField<PrototypeRHStructField>((StringId)11493498445115496437);
            PrototypeAssetField propertyIdContext = prototype.GetField<PrototypeAssetField>((StringId)17065615538570403211);

            if (prop?.IsNull != false)
                return "!PropError!";

            return $"{PropertyHelper.BuildPropertyName(prop.Value)}(<PropColContext[{propertyCollectionContext.Value.GetName()}], PropIdContext[{propertyIdContext.Value.GetName()}]>)";
        }

        private static string BuildLoadPropEvalParamsString(Prototype prototype)
        {
            PrototypeRHStructField param0 = prototype.GetField<PrototypeRHStructField>((StringId)5181251555885324056);
            PrototypeRHStructField param1 = prototype.GetField<PrototypeRHStructField>((StringId)10037820194166150937);
            PrototypeRHStructField param2 = prototype.GetField<PrototypeRHStructField>((StringId)415043287142635290);
            PrototypeRHStructField param3 = prototype.GetField<PrototypeRHStructField>((StringId)14512998463866935067);
            PrototypePrototypeField prop = prototype.GetField<PrototypePrototypeField>((StringId)12156279659329492632);

            if (prop.Value == PrototypeId.Invalid)
                return "!PropError!";

            return string.Format("{0}({1},{2},{3},{4})",
                prop?.Value.GetNameFormatted(),
                param0?.IsNull == false ? TryBuildExpressionString(param0.Value) : "",
                param1?.IsNull == false ? TryBuildExpressionString(param1.Value) : "",
                param2?.IsNull == false ? TryBuildExpressionString(param2.Value) : "",
                param3?.IsNull == false ? TryBuildExpressionString(param3.Value) : "");
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

        private static string BuildLoadCurveString(Prototype prototype)
        {
            // CurveRef evals use different blueprints, so we can't use field id here
            PrototypeCurveField curve = null;
            PrototypeRHStructField index = null;

            foreach (Prototype currentPrototype in prototype.IterateHierarchy())
            {
                if (currentPrototype.FieldGroups.Count == 0)
                    continue;

                foreach (PrototypeField field in currentPrototype.FieldGroups[0].SimpleFields)
                {
                    if (field is PrototypeCurveField curveField)
                        curve = curveField;
                    else if (field is PrototypeRHStructField rhStructField)
                        index = rhStructField;
                }
            }

            return string.Format("( {0}[{1}] )",
                curve?.Value.GetName(),
                index?.IsNull == false ? TryBuildExpressionString(index.Value) : "NULL");
        }

        private static string BuildLoadAssetRefString(Prototype prototype)
        {
            // AssetRef evals use different blueprints, so we can't use field id here
            PrototypeAssetField value = null;
            if (prototype.FieldGroups.Count > 0)
            {
                PrototypeFieldGroup fieldGroup = prototype.FieldGroups[0];
                if (fieldGroup.SimpleFields.Count > 0)
                    value = fieldGroup.SimpleFields[0] as PrototypeAssetField;
            }

            return $"({value?.Value.GetName()})";
        }

        private static string BuildLoadProtoRefString(Prototype prototype)
        {
            // ProtoRef evals use different blueprints, so we can't use field id here
            PrototypePrototypeField value = null;
            if (prototype.FieldGroups.Count > 0)
            {
                PrototypeFieldGroup fieldGroup = prototype.FieldGroups[0];
                if (fieldGroup.SimpleFields.Count > 0)
                    value = fieldGroup.SimpleFields[0] as PrototypePrototypeField;
            }

            return $"({value?.Value.GetName()})";
        }

        private static string BuildLoadContextIntString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)15292182156351116751);
            return $"(context<int>[{context.Value.GetName()}])";
        }

        private static string BuildLoadContextProtoRefString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)14584050640904525813);
            return $"(context<protoref>[{context.Value.GetName()}])";
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

        private static string BuildGreaterThanString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)11273703554902987780);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)1367750975788749829);

            return string.Format("( {0} > {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildLessThanString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)16237043773489681105);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)8059920147828839122);

            return string.Format("( {0} < {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildEqualsString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)15791870850691043834);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)6172457332557025787);

            return string.Format("( {0} == {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildAndString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)10609521103735034018);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)2140213507217100963);

            return string.Format("( {0} && {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildOrString(Prototype prototype)
        {
            PrototypeRHStructField arg1 = prototype.GetField<PrototypeRHStructField>((StringId)5475568539328319568);
            PrototypeRHStructField arg2 = prototype.GetField<PrototypeRHStructField>((StringId)14227477536450809937);

            return string.Format("( {0} || {1} )",
                arg1.IsNull == false ? TryBuildExpressionString(arg1.Value) : "NULL",
                arg2.IsNull == false ? TryBuildExpressionString(arg2.Value) : "NULL");
        }

        private static string BuildNotString(Prototype prototype)
        {
            PrototypeRHStructField arg = prototype.GetField<PrototypeRHStructField>((StringId)14474736566046494863);
            return $"!({(arg.IsNull == false ? TryBuildExpressionString(arg.Value) : "NULL")})";
        }

        private static string BuildIsContextDataNullString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)9049147607101872191);
            return $"IsNULL({context.Value.GetName()})";
        }

        private static string BuildIfElseString(Prototype prototype)
        {
            PrototypeRHStructField conditional = prototype.GetField<PrototypeRHStructField>((StringId)13051207476210046146);
            PrototypeRHStructField evalIf = prototype.GetField<PrototypeRHStructField>((StringId)14714292053604897445);
            PrototypeRHStructField evalElse = prototype.GetField<PrototypeRHStructField>((StringId)13038506646993245055);

            return string.Format("( {0} ? {1} : {2} )",
                conditional?.IsNull == false ? TryBuildExpressionString(conditional.Value) : "NULL",
                evalIf?.IsNull == false ? TryBuildExpressionString(evalIf.Value) : "NULL",
                evalElse?.IsNull == false ? TryBuildExpressionString(evalElse.Value) : "NULL");
        }

        private static string BuildDifficultyTierRangeString(Prototype prototype)
        {
            PrototypePrototypeField min = prototype.GetField<PrototypePrototypeField>((StringId)15616826765656332092);
            PrototypePrototypeField max = prototype.GetField<PrototypePrototypeField>((StringId)15687875368797738814);

            return string.Format("DifficultyTier( {0},{1} )",
                GameDatabase.GetPrototypeName(min.Value),
                GameDatabase.GetPrototypeName(max.Value));
        }

        private static string BuildMissionIsActiveString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)12081102133055133539);
            PrototypePrototypeField mission = prototype.GetField<PrototypePrototypeField>((StringId)5241103067609110368);

            return $"MissionIsActive(Context=[{context.Value.GetName()}], Mission=[{mission.Value.GetName()}])";
        }

        private static string BuildGetCombatLevelString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)6818686758998709234);

            return $"GetCombatLevel(Context=[{context.Value.GetName()}])";
        }

        private static string BuildGetPowerRankString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)6015239222172848957);
            PrototypePrototypeField power = prototype.GetField<PrototypePrototypeField>((StringId)18217021394257252965);

            return $"GetPowerRank(Context=[{context.Value.GetName()}], Power=[{power.Value.GetName()}]))";
        }

        private static string BuildCalcPowerRankString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)1503743095844377488);
            PrototypePrototypeField power = prototype.GetField<PrototypePrototypeField>((StringId)7866794245806559928);

            return $"CalcPowerRank(Context=[{context.Value.GetName()}], Power=[{power.Value.GetName()}])";
        }

        private static string BuildGetDamageReductionPctString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)3313504581961848535);
            PrototypeAssetField vsDamageType = prototype.GetField<PrototypeAssetField>((StringId)17517379456729684188);

            return $"GetDamageReductionPct(Context=[{context.Value.GetName()}], VsDamageType=[{vsDamageType.Value.GetName()}])";
        }

        private static string BuildGetDistanceToEntityString(Prototype prototype)
        {
            PrototypeAssetField sourceEntity = prototype.GetField<PrototypeAssetField>((StringId)3496010323655989336);
            PrototypeAssetField targetEntity = prototype.GetField<PrototypeAssetField>((StringId)449336544503863374);
            PrototypeBooleanField edgeToEdge = prototype.GetField<PrototypeBooleanField>((StringId)2969600873078789943);

            return $"GetDistanceToEntity(SourceEntity=[{sourceEntity.Value.GetName()}], TargetEntity=[{targetEntity.Value.GetName()}], EdgeToEdge=[{edgeToEdge.Value}])";
        }

        private static string BuildHasEntityInInventoryString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)12301922136390703527);
            PrototypePrototypeField entity = prototype.GetField<PrototypePrototypeField>((StringId)6560550995882481983);
            PrototypeAssetField inventory = prototype.GetField<PrototypeAssetField>((StringId)5061914273438833296);

            return $"HasEntityInInventory(Context=[{context.Value.GetName()}], Entity=[{entity.Value.GetName()}], Inventory=[{inventory.Value.GetName()}])";
        }

        private static string BuildIsInPartyString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)4289541947466584583);

            return $"IsInParty(Context=[{context?.Value.GetName()}])";
        }

        private static string BuildIsDynamicCombatLevelEnabledString(Prototype prototype)
        {
            return "IsDynamicCombatLevelEnabled";
        }

        private static string BuildMissionIsCompleteString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)5539123959986526272);
            PrototypePrototypeField mission = prototype.GetField<PrototypePrototypeField>((StringId)11802381004313729085);

            return $"MissionIsComplete(Context=[{context?.Value.GetName()}], Mission=[{mission?.Value.GetName()}])";
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

        private static string BuildRandomFloatString(Prototype prototype)
        {
            PrototypeDoubleField max = prototype.GetField<PrototypeDoubleField>((StringId)1361918609779724635);
            PrototypeDoubleField min = prototype.GetField<PrototypeDoubleField>((StringId)1434989627120423257);

            return $"RandFloat( {min?.Value}:{max?.Value} )";
        }

        private static string BuildRandomIntString(Prototype prototype)
        {
            PrototypeLongField max = prototype.GetField<PrototypeLongField>((StringId)14128613522519560336);
            PrototypeLongField min = prototype.GetField<PrototypeLongField>((StringId)14203915139715371150);

            return $"RandInt( {min?.Value}:{max?.Value} )";
        }

        private static string BuildForString(Prototype prototype)
        {
            PrototypeRHStructField loopAdvance = prototype.GetField<PrototypeRHStructField>((StringId)464918372468069257);
            PrototypeRHStructField loopCondition = prototype.GetField<PrototypeRHStructField>((StringId)16347999830862337150);
            PrototypeRHStructField loopVarInt = prototype.GetField<PrototypeRHStructField>((StringId)16347999830862337150);
            PrototypeRHStructField postLoop = prototype.GetField<PrototypeRHStructField>((StringId)18002664979617878653);
            PrototypeRHStructField preLoop = prototype.GetField<PrototypeRHStructField>((StringId)16968961987179647486);
            PrototypeRHStructListField scopeLoopBody = prototype.GetField<PrototypeRHStructListField>((StringId)9845531091176854655);

            StringBuilder sb = new();
            if (scopeLoopBody != null)
            {
                foreach (Prototype evalProto in scopeLoopBody.Values)
                    sb.Append($" {TryBuildExpressionString(evalProto)};");
            }

            return string.Format("{{ Pre({0}) For ({1}; {2}; {3}) {{{4}}} Post({5}) }}",
                TryBuildExpressionString(preLoop?.Value),
                TryBuildExpressionString(loopVarInt?.Value),
                TryBuildExpressionString(loopCondition?.Value),
                TryBuildExpressionString(loopAdvance?.Value),
                sb.ToString(),
                TryBuildExpressionString(postLoop?.Value));
        }

        private static string BuildForEachConditionInContextString(Prototype prototype)
        {
            PrototypeRHStructField postLoop = prototype.GetField<PrototypeRHStructField>((StringId)942252983869053873);
            PrototypeRHStructField preLoop = prototype.GetField<PrototypeRHStructField>((StringId)18020870319133367090);
            PrototypeRHStructListField scopeLoopBody = prototype.GetField<PrototypeRHStructListField>((StringId)3066765847814020531);
            PrototypeRHStructField loopConditionPreScope = prototype.GetField<PrototypeRHStructField>((StringId)16379843999176401171);
            PrototypeRHStructField loopConditionPostScope = prototype.GetField<PrototypeRHStructField>((StringId)17173466570655474066);
            PrototypeAssetField conditionCollectionContext = prototype.GetField<PrototypeAssetField>((StringId)17264143460089471785);

            StringBuilder sb = new();
            if (scopeLoopBody != null)
            {
                foreach (Prototype evalProto in scopeLoopBody.Values)
                    sb.Append($" {TryBuildExpressionString(evalProto)};");
            }

            return string.Format("{{ Pre({0}) Foreach (Condition in context [{1}], LoopCondition={{{2}}}) {{{3} if(LoopConditionPostScope{{{4}}}){{break}}}} Post({5}) }}",
                TryBuildExpressionString(preLoop?.Value),
                conditionCollectionContext?.Value.GetName(),
                TryBuildExpressionString(loopConditionPreScope?.Value),
                sb.ToString(),
                TryBuildExpressionString(loopConditionPostScope?.Value),
                TryBuildExpressionString(postLoop?.Value));
        }

        private static string BuildForEachProtoRefInContextRefListString(Prototype prototype)
        {
            PrototypeRHStructField postLoop = prototype.GetField<PrototypeRHStructField>((StringId)2898157917894286932);
            PrototypeRHStructField preLoop = prototype.GetField<PrototypeRHStructField>((StringId)13697983732985765333);
            PrototypeRHStructListField scopeLoopBody = prototype.GetField<PrototypeRHStructListField>((StringId)16346171716582645846);
            PrototypeRHStructField loopCondition = prototype.GetField<PrototypeRHStructField>((StringId)9846238725589901397);
            PrototypeAssetField protoRefListContext = prototype.GetField<PrototypeAssetField>((StringId)7876936674123064070);

            StringBuilder sb = new();
            if (scopeLoopBody != null)
            {
                foreach (Prototype evalProto in scopeLoopBody.Values)
                    sb.Append($" {TryBuildExpressionString(evalProto)};");
            }

            return string.Format("{{ Pre({0}) Foreach (ProtoRef in context [{1}], LoopCondition={{{2}}}) {{{3}}} Post({4}) }}",
                TryBuildExpressionString(preLoop?.Value),
                protoRefListContext?.Value.GetName(),
                TryBuildExpressionString(loopCondition?.Value),
                sb.ToString(),
                TryBuildExpressionString(postLoop?.Value));
        }

        private static string BuildLoadEntityToContextVarString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)5086034854013376402);
            PrototypeRHStructField entityId = prototype.GetField<PrototypeRHStructField>((StringId)12794225760199710711);

            return $"LoadEntityToContextVar(Context=[{context.Value.GetName()}], EntityId={{{(entityId?.IsNull == false ? TryBuildExpressionString(entityId.Value) : "!NULL Eval!")}}})";
        }

        private static string BuildLoadConditionCollectionToContextString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)5997074086943529887);
            PrototypeRHStructField entityId = prototype.GetField<PrototypeRHStructField>((StringId)11572737069862558724);

            return $"LoadConditionCollectionToContext(Context=[{context.Value.GetName()}], EntityId={{{(entityId?.IsNull == false ? TryBuildExpressionString(entityId.Value) : "!NULL Eval!")}}})";
        }

        private static string BuildEntityHasKeywordString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)1819350896079410434);
            PrototypePrototypeField keyword = prototype.GetField<PrototypePrototypeField>((StringId)1147453762849936642);

            PrototypeId keywordProtoRef = keyword != null ? keyword.Value : PrototypeId.Invalid;

            return $"EntityHasKeyword(Context=[{context.Value.GetName()}], Keyword={{{(keywordProtoRef != PrototypeId.Invalid ? keywordProtoRef.GetName() : "!NONE!")}}})";
        }

        private static string BuildEntityHasTalentString(Prototype prototype)
        {
            PrototypeAssetField context = prototype.GetField<PrototypeAssetField>((StringId)2600775360028611717);
            PrototypePrototypeField talent = prototype.GetField<PrototypePrototypeField>((StringId)18228789889448023048);

            PrototypeId talentProtoRef = talent != null ? talent.Value : PrototypeId.Invalid;

            return $"EntityHasTalent(Context=[{context.Value.GetName()}], Talent={{{(talentProtoRef != PrototypeId.Invalid ? talentProtoRef.GetName() : "!NONE!")}}})";
        }
    }
}
