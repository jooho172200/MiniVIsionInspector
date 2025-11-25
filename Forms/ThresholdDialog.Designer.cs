namespace MiniVisionInspector.Forms
{
    partial class Threshold
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            trackBarThreshold = new TrackBar();
            labelValue = new Label();
            btnOk = new Button();
            btnCancel = new Button();
            numericThreshold = new NumericUpDown();
            checkBoxBitInverse = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)trackBarThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericThreshold).BeginInit();
            SuspendLayout();
            // 
            // trackBarThreshold
            // 
            trackBarThreshold.Location = new Point(182, 100);
            trackBarThreshold.Maximum = 255;
            trackBarThreshold.Name = "trackBarThreshold";
            trackBarThreshold.Size = new Size(272, 45);
            trackBarThreshold.TabIndex = 0;
            trackBarThreshold.TickFrequency = 16;
            trackBarThreshold.Value = 127;
            trackBarThreshold.Scroll += trackBarThreshold_Scroll;
            // 
            // labelValue
            // 
            labelValue.AutoSize = true;
            labelValue.Location = new Point(114, 102);
            labelValue.Name = "labelValue";
            labelValue.Size = new Size(62, 15);
            labelValue.TabIndex = 1;
            labelValue.Text = "Threshold:";
            labelValue.Click += labelValue_Click;
            // 
            // btnOk
            // 
            btnOk.DialogResult = DialogResult.OK;
            btnOk.Location = new Point(225, 197);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(79, 27);
            btnOk.TabIndex = 3;
            btnOk.Text = "OK";
            btnOk.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(330, 197);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(79, 27);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // numericThreshold
            // 
            numericThreshold.Location = new Point(460, 100);
            numericThreshold.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericThreshold.Name = "numericThreshold";
            numericThreshold.Size = new Size(81, 23);
            numericThreshold.TabIndex = 5;
            numericThreshold.Value = new decimal(new int[] { 127, 0, 0, 0 });
            numericThreshold.ValueChanged += numericThreshold_ValueChanged;
            // 
            // checkBoxBitInverse
            // 
            checkBoxBitInverse.AutoSize = true;
            checkBoxBitInverse.Location = new Point(114, 151);
            checkBoxBitInverse.Name = "checkBoxBitInverse";
            checkBoxBitInverse.Size = new Size(81, 19);
            checkBoxBitInverse.TabIndex = 6;
            checkBoxBitInverse.Text = "Bit Inverse";
            checkBoxBitInverse.UseVisualStyleBackColor = true;
            checkBoxBitInverse.CheckedChanged += checkBoxBitInverse_CheckedChanged;
            // 
            // Threshold
            // 
            AcceptButton = btnOk;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancel;
            ClientSize = new Size(657, 262);
            Controls.Add(checkBoxBitInverse);
            Controls.Add(numericThreshold);
            Controls.Add(btnCancel);
            Controls.Add(btnOk);
            Controls.Add(labelValue);
            Controls.Add(trackBarThreshold);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Threshold";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Threshold";
            Load += Threshold_Load;
            ((System.ComponentModel.ISupportInitialize)trackBarThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericThreshold).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TrackBar trackBarThreshold;
        private Label labelValue;
        private Button btnOk;
        private Button btnCancel;
        private NumericUpDown numericThreshold;
        private CheckBox checkBoxBitInverse;
    }
}