namespace DotNet05AsyncApp
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            PrgProcess = new ProgressBar();
            BtnAsyncCopy = new Button();
            BtnSyncCopy = new Button();
            BtnTarget = new Button();
            BtnSource = new Button();
            TxtTarget = new TextBox();
            TxtSource = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(PrgProcess);
            groupBox1.Controls.Add(BtnAsyncCopy);
            groupBox1.Controls.Add(BtnSyncCopy);
            groupBox1.Controls.Add(BtnTarget);
            groupBox1.Controls.Add(BtnSource);
            groupBox1.Controls.Add(TxtTarget);
            groupBox1.Controls.Add(TxtSource);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(473, 189);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "비동기 처리";
            // 
            // PrgProcess
            // 
            PrgProcess.Location = new Point(28, 138);
            PrgProcess.Name = "PrgProcess";
            PrgProcess.Size = new Size(418, 29);
            PrgProcess.TabIndex = 9;
            // 
            // BtnAsyncCopy
            // 
            BtnAsyncCopy.Location = new Point(240, 103);
            BtnAsyncCopy.Name = "BtnAsyncCopy";
            BtnAsyncCopy.Size = new Size(130, 29);
            BtnAsyncCopy.TabIndex = 7;
            BtnAsyncCopy.Text = "비동기화 복사";
            BtnAsyncCopy.UseVisualStyleBackColor = true;
            BtnAsyncCopy.Click += BtnAsyncCopy_Click;
            // 
            // BtnSyncCopy
            // 
            BtnSyncCopy.Location = new Point(104, 103);
            BtnSyncCopy.Name = "BtnSyncCopy";
            BtnSyncCopy.Size = new Size(130, 29);
            BtnSyncCopy.TabIndex = 6;
            BtnSyncCopy.Text = "동기화 복사";
            BtnSyncCopy.UseVisualStyleBackColor = true;
            BtnSyncCopy.Click += BtnSyncCopy_Click;
            // 
            // BtnTarget
            // 
            BtnTarget.Location = new Point(406, 68);
            BtnTarget.Name = "BtnTarget";
            BtnTarget.Size = new Size(40, 27);
            BtnTarget.TabIndex = 5;
            BtnTarget.Text = "...";
            BtnTarget.UseVisualStyleBackColor = true;
            BtnTarget.Click += BtnTarget_Click;
            // 
            // BtnSource
            // 
            BtnSource.Location = new Point(406, 32);
            BtnSource.Name = "BtnSource";
            BtnSource.Size = new Size(40, 27);
            BtnSource.TabIndex = 4;
            BtnSource.Text = "...";
            BtnSource.UseVisualStyleBackColor = true;
            BtnSource.Click += BtnSource_Click;
            // 
            // TxtTarget
            // 
            TxtTarget.Location = new Point(84, 68);
            TxtTarget.Name = "TxtTarget";
            TxtTarget.ReadOnly = true;
            TxtTarget.Size = new Size(316, 27);
            TxtTarget.TabIndex = 3;
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(84, 32);
            TxtSource.Name = "TxtSource";
            TxtSource.ReadOnly = true;
            TxtSource.Size = new Size(316, 27);
            TxtSource.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(28, 71);
            label2.Name = "label2";
            label2.Size = new Size(39, 20);
            label2.TabIndex = 1;
            label2.Text = "타겟";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 35);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 0;
            label1.Text = "소스";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(497, 213);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmMain";
            Text = "비동기 파일복사";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private ProgressBar PrgProcess;
        private Button BtnAsyncCopy;
        private Button BtnSyncCopy;
        private Button BtnTarget;
        private Button BtnSource;
        private TextBox TxtTarget;
        private TextBox TxtSource;
        private Label label2;
    }
}
