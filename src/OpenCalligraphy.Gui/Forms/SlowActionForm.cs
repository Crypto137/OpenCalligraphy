using OpenCalligraphy.Core.Exceptions;

namespace OpenCalligraphy.Gui.Forms
{
    public partial class SlowActionForm : Form
    {
        private readonly ActionData[] _actionData;

        public SlowActionForm(ActionData[] actionData)
        {
            InitializeComponent();

            _actionData = actionData;
        }

        public static bool ExecuteActions(IWin32Window owner, params ActionData[] actionData)
        {
            SlowActionForm form = new(actionData);
            DialogResult result = form.ShowDialog(owner);
            return result == DialogResult.OK;
        }

        private void SlowActionForm_Shown(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            foreach (ActionData actionData in _actionData)
            {
                Text = actionData.Title;
                textLabel.Text = actionData.Text;
                Application.DoEvents();     // Process UI updates

                try
                {
                    actionData.Action();
                }
                catch (CalligraphyException calligraphyException)
                {
                    MessageBox.Show(calligraphyException.Message, "Calligraphy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    break;
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString(), "Generic Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DialogResult = DialogResult.Abort;
                    break;
                }
            }

            Close();
        }

        public class ActionData(string title, string text, Action action)
        {
            public readonly string Title = title;
            public readonly string Text = text;
            public readonly Action Action = action;
        }
    }
}
