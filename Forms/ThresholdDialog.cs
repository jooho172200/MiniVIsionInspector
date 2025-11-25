using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniVisionInspector.Forms
{
    public partial class Threshold : Form
    {
        public Threshold(int initialThreshold, bool initialInvert = false)
        {
            InitializeComponent();
            SelectedThreshold = initialThreshold;
            BitInvert = initialInvert;
        }

        private void labelValue_Click(object sender, EventArgs e)
        {

        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            numericThreshold.Value = trackBarThreshold.Value;
        }

        private void numericThreshold_ValueChanged(object sender, EventArgs e)
        {
            trackBarThreshold.Value = (int)numericThreshold.Value;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Threshold_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxBitInverse_CheckedChanged(object sender, EventArgs e)
        {

        }

        public int SelectedThreshold
        {
            get => (int)numericThreshold.Value;
            set
            {
                if (value < numericThreshold.Minimum) value = (int)numericThreshold.Minimum;
                if (value > numericThreshold.Maximum) value = (int)numericThreshold.Maximum;

                numericThreshold.Value = value;
                trackBarThreshold.Value = value;
            }
        }

        public bool BitInvert
        {
            get => checkBoxBitInverse.Checked;
            set => checkBoxBitInverse.Checked = value;
        }
    }
}
