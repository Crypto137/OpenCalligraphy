using System.Text;

namespace OpenCalligraphy.Gui.Helpers
{
    /// <summary>
    /// Implementation of <see cref="TextWriter"/> that outputs to a <see cref="StringBuilder"/>.
    /// </summary>
    public class StringBuilderTextWriter : TextWriter
    {
        private readonly StringBuilder _sb = new();

        public override Encoding Encoding { get => Encoding.UTF8; }

        public override string ToString()
        {
            return _sb.ToString();
        }

        public override void Write(char value)
        {
            _sb.Append(value);
        }
    }
}
