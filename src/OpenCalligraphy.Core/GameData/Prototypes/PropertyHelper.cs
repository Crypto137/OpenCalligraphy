namespace OpenCalligraphy.Core.GameData.Prototypes
{
    public static class PropertyHelper
    {
        public static string BuildPropertyName(Prototype prototype)
        {
            // TODO: Params
            PrototypeId dataRef = prototype.ParentDataRef != PrototypeId.Invalid ? prototype.ParentDataRef : prototype.DataRef;
            string name = dataRef.GetName();
            return Path.GetFileNameWithoutExtension(name);
        }
    }
}
