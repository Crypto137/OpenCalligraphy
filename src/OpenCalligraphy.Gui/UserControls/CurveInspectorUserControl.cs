using System.Reflection;
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

            // Enable double buffering for DataGridView for smoother performance
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                null, curveDataGridView, [true]);
        }

        #region Curve Inspector

        public void InspectCurve(Curve curve)
        {
            // NOTE: null curve is valid input here to clear the inspector

            EnableCurveControls(curve);

            SetCurveMetadata(curve);

            PopulateCurveDataGridView(curve);
        }

        public void Clear()
        {
            InspectCurve(null);
        }

        private void EnableCurveControls(Curve curve)
        {
            bool hasCurve = curve != null;

            curveFindReferencesButton.Enabled = hasCurve;
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

        private void PopulateCurveDataGridView(Curve curve)
        {
            curveDataGridView.Rows.Clear();

            if (curve != null)
            {
                for (int i = curve.MinPosition; i <= curve.MaxPosition; i++)
                    curveDataGridView.Rows.Add(i, curve.GetAt(i));
            }

            curveDataGridView.Tag = curve;
        }

        #endregion

        #region Event Handlers

        private void curveFindReferencesButton_Click(object sender, EventArgs e)
        {
            if (curveDataGridView.Tag is not Curve curve)
                return;

            MainForm?.SearchReferences(curve.Id);
        }

        #endregion
    }
}
