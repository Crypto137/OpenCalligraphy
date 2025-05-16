using System.Runtime.InteropServices;
using System.Text;
using OpenCalligraphy.Core.GameData.Prototypes.FieldTypes;

namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public enum PropertyParamType
    {
        Invalid = -1,
        Integer = 0,
        Asset = 1,
        Prototype = 2
    }

    public static class PropertyHelper
    {
        public const int MaxParamCount = 4;

        public static string BuildPropertyName(Prototype prototype)
        {
            StringBuilder sb = new();

            PrototypeId dataRef = prototype.ParentDataRef != PrototypeId.Invalid ? prototype.ParentDataRef : prototype.DataRef;
            sb.Append(dataRef.GetNameFormatted());

            Span<PropertyParamData> @params = stackalloc PropertyParamData[MaxParamCount];
            GetParams(prototype, @params);

            for (int i = 0; i < MaxParamCount; i++)
            {
                PropertyParamData paramData = @params[i];
                switch (paramData.Type)
                {
                    case PropertyParamType.Integer:
                        sb.Append($"[{paramData.IntegerValue}]");
                        break;

                    case PropertyParamType.Asset:
                        AssetId assetId = paramData.AssetValue;
                        string assetName = GameDatabase.GetAssetName(assetId);
                        sb.Append(assetName == string.Empty ? $"[{assetId}]" : $"[{assetName}]"); ;
                        break;

                    case PropertyParamType.Prototype:
                        sb.Append($"[{paramData.PrototypeValue.GetNameFormatted()}]");
                        break;
                }
            }

            return sb.ToString();
        }

        private static void GetParams(Prototype prototype, Span<PropertyParamData> @params)
        {
            @params.Fill(new());

            Stack<Prototype> prototypeStack = new();
            while (prototype != null)
            {
                prototypeStack.Push(prototype);
                prototype = GameDatabase.GetPrototype(prototype.ParentDataRef);
            }

            while (prototypeStack.Count > 0)
            {
                Prototype currentPrototype = prototypeStack.Pop();
                if (currentPrototype.FieldGroups.Count == 0)
                    continue;

                foreach (PrototypeField field in currentPrototype.FieldGroups[0].SimpleFields)
                {
                    int paramIndex = -1;

                    switch (field.GetBlueprintMember().FieldName)
                    {
                        case "Param":
                        case "Param0": paramIndex = 0; break;
                        case "Param1": paramIndex = 1; break;
                        case "Param2": paramIndex = 2; break;
                        case "Param3": paramIndex = 3; break;
                    }

                    if (paramIndex == -1)
                        continue;

                    switch (field)
                    {
                        case PrototypeLongField longField:
                            @params[paramIndex] = new(longField.Value);
                            break;

                        case PrototypeAssetField assetField:
                            @params[paramIndex] = new(assetField.Value);
                            break;

                        case PrototypePrototypeField prototypeField:
                            @params[paramIndex] = new(prototypeField.Value);
                            break;
                    }
                }
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        private readonly struct PropertyParamData
        {
            [FieldOffset(0)]
            public readonly PropertyParamType Type;

            [FieldOffset(4)]
            public readonly long IntegerValue;
            [FieldOffset(4)]
            public readonly AssetId AssetValue;
            [FieldOffset(4)]
            public readonly PrototypeId PrototypeValue;

            public PropertyParamData()
            {
                Type = PropertyParamType.Invalid;
                IntegerValue = 0;
            }

            public PropertyParamData(long value)
            {
                Type = PropertyParamType.Integer;
                IntegerValue = value;
            }

            public PropertyParamData(AssetId value)
            {
                Type = PropertyParamType.Asset;
                AssetValue = value;
            }

            public PropertyParamData(PrototypeId value)
            {
                Type = PropertyParamType.Prototype;
                PrototypeValue = value;
            }
        }
    }
}
