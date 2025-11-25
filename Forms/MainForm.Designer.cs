namespace MiniVisionInspector
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            btnThresh = new Button();
            btnGray = new Button();
            btnReset = new Button();
            btnOpen = new Button();
            pictureBoxOriginal = new PictureBox();
            pictureBox2 = new PictureBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabelInfo = new ToolStripStatusLabel();
            pictureBoxProcessed = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(btnThresh);
            panel1.Controls.Add(btnGray);
            panel1.Controls.Add(btnReset);
            panel1.Controls.Add(btnOpen);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1132, 32);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // btnThresh
            // 
            btnThresh.Location = new Point(255, 6);
            btnThresh.Name = "btnThresh";
            btnThresh.Size = new Size(75, 23);
            btnThresh.TabIndex = 3;
            btnThresh.Text = "Binary";
            btnThresh.UseVisualStyleBackColor = true;
            btnThresh.Click += btnThresh_Click;
            // 
            // btnGray
            // 
            btnGray.Location = new Point(174, 6);
            btnGray.Name = "btnGray";
            btnGray.Size = new Size(75, 23);
            btnGray.TabIndex = 2;
            btnGray.Text = "Gray";
            btnGray.UseVisualStyleBackColor = true;
            btnGray.Click += btnGray_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(93, 6);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(75, 23);
            btnReset.TabIndex = 1;
            btnReset.Text = "Reset";
            btnReset.UseVisualStyleBackColor = true;
            btnReset.Click += btnReset_Click;
            // 
            // btnOpen
            // 
            btnOpen.Location = new Point(12, 6);
            btnOpen.Name = "btnOpen";
            btnOpen.Size = new Size(75, 23);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open\r\n";
            btnOpen.UseVisualStyleBackColor = true;
            btnOpen.Click += btnOpen_Click;
            // 
            // pictureBoxOriginal
            // 
            pictureBoxOriginal.Dock = DockStyle.Left;
            pictureBoxOriginal.Location = new Point(0, 32);
            pictureBoxOriginal.Name = "pictureBoxOriginal";
            pictureBoxOriginal.Size = new Size(566, 578);
            pictureBoxOriginal.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxOriginal.TabIndex = 1;
            pictureBoxOriginal.TabStop = false;
            pictureBoxOriginal.Click += pictureBoxOriginal_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(635, 63);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(0, 0);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelInfo });
            statusStrip1.Location = new Point(0, 610);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1132, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelInfo
            // 
            toolStripStatusLabelInfo.Name = "toolStripStatusLabelInfo";
            toolStripStatusLabelInfo.Size = new Size(135, 17);
            toolStripStatusLabelInfo.Text = "toolStripStatusLabelInfo";
            // 
            // pictureBoxProcessed
            // 
            pictureBoxProcessed.Dock = DockStyle.Right;
            pictureBoxProcessed.Location = new Point(566, 32);
            pictureBoxProcessed.Name = "pictureBoxProcessed";
            pictureBoxProcessed.Size = new Size(566, 578);
            pictureBoxProcessed.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxProcessed.TabIndex = 4;
            pictureBoxProcessed.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 632);
            Controls.Add(pictureBoxProcessed);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBoxOriginal);
            Controls.Add(panel1);
            Controls.Add(statusStrip1);
            Name = "MainForm";
            Text = "Form1";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBoxOriginal).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxProcessed).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Button btnReset;
        private Button btnOpen;
        private Button btnThresh;
        private Button btnGray;
        private PictureBox pictureBoxOriginal;
        private PictureBox pictureBox2;
        private StatusStrip statusStrip1;
        private PictureBox pictureBoxProcessed;
        private ToolStripStatusLabel toolStripStatusLabelInfo;
    }
}
