using OpenCalligraphy.Core.GameData;

namespace OpenCalligraphy.Gui.Models
{
    internal class DataRefTreeNodeTag
    {
        public CalligraphyBaseType Type { get; }
        public ulong DataRef { get; }

        public DataRefTreeNodeTag(AssetId assetRef)
        {
            Type = CalligraphyBaseType.Asset;
            DataRef = (ulong)assetRef;
        }

        public DataRefTreeNodeTag(CurveId curveRef)
        {
            Type = CalligraphyBaseType.Curve;
            DataRef = (ulong)curveRef;
        }

        public DataRefTreeNodeTag(PrototypeId protoRef)
        {
            Type = CalligraphyBaseType.Prototype;
            DataRef = (ulong)protoRef;
        }

        public DataRefTreeNodeTag(AssetTypeId typeRef)
        {
            Type = CalligraphyBaseType.Type;
            DataRef = (ulong)typeRef;
        }

        public string GetNameString()
        {
            return Type switch
            {
                CalligraphyBaseType.Asset       => ((AssetId)DataRef).GetName(),
                CalligraphyBaseType.Curve       => ((CurveId)DataRef).GetName(),
                CalligraphyBaseType.Prototype   => ((PrototypeId)DataRef).GetName(),
                CalligraphyBaseType.Type        => ((AssetTypeId)DataRef).GetName(),
                _                               => string.Empty,
            };
        }

        public string GetValueString()
        {
            return DataRef.ToString();
        }

        public object GetData()
        {
            // TODO: Add curves and assets
            return Type switch
            {
                CalligraphyBaseType.Prototype   => ((PrototypeId)DataRef).AsPrototype(),
                _                               => null,
            };
        }
    }
}
