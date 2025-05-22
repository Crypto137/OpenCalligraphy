using OpenCalligraphy.Core.GameData;
using OpenCalligraphy.Gui.Forms;

namespace OpenCalligraphy.Gui.UserControls
{
    public partial class CurveInspectorUserControl : UserControl
    {
        public MainForm MainForm { get; set; }

        public CurveInspectorUserControl()
        {
            InitializeComponent();
        }

        #region Curve Inspector

        public void InspectCurve(Curve curve)
        {
            // NOTE: null curve is valid input here to clear the inspector

            SetCurveMetadata(curve);
        }

        public void Clear()
        {
            InspectCurve(null);
        }

        private void SetCurveMetadata(Curve curve)
        {
            string name = string.Empty;

            if (curve != null)
            {
                CurveDirectory.CurveRecord record = CurveDirectory.Instance.GetCurveRecord(curve.Id);
                name = $"{curve.Id.GetName()} (id={curve.Id}, guid={record.Guid})";
            }

            curveNameTextBox.Text = name;
        }

        #endregion

        #region Event Handlers

        private void curveFindReferencesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not yet implemented");
        }

        #endregion
    }
}
