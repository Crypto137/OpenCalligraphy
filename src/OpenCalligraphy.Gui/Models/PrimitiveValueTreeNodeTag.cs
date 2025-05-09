namespace OpenCalligraphy.Gui.Models
{
    public class PrimitiveValueTreeNodeTag
    {
        private readonly object _value;

        public PrimitiveValueTreeNodeTag(object value)
        {
            _value = value;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
    }
}
