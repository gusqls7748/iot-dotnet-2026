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
            BtnSource = new Button();
            BtnAsyncCopy = new Button();
            BtnTarget = new Button();
            TxtTarget = new TextBox();
            PrgProcess = new ProgressBar();
            BtnSyncCopy = new Button();
            TxtSource = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(BtnSource);
            groupBox1.Controls.Add(BtnAsyncCopy);
            groupBox1.Controls.Add(BtnTarget);
            groupBox1.Controls.Add(TxtTarget);
            groupBox1.Controls.Add(PrgProcess);
            groupBox1.Controls.Add(BtnSyncCopy);
            groupBox1.Controls.Add(TxtSource);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(677, 324);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "비동기 처리";
            // 
            // BtnSource
            // 
            BtnSource.Location = new Point(463, 36);
            BtnSource.Name = "BtnSource";
            BtnSource.Size = new Size(75, 23);
            BtnSource.TabIndex = 13;
            BtnSource.Text = "...";
            BtnSource.UseVisualStyleBackColor = true;
            BtnSource.Click += BtnSource_Click;
            // 
            // BtnAsyncCopy
            // 
            BtnAsyncCopy.Location = new Point(236, 125);
            BtnAsyncCopy.Name = "BtnAsyncCopy";
            BtnAsyncCopy.Size = new Size(75, 23);
            BtnAsyncCopy.TabIndex = 12;
            BtnAsyncCopy.Text = "비동기화";
            BtnAsyncCopy.UseVisualStyleBackColor = true;
            // 
            // BtnTarget
            // 
            BtnTarget.Location = new Point(463, 87);
            BtnTarget.Name = "BtnTarget";
            BtnTarget.Size = new Size(75, 23);
            BtnTarget.TabIndex = 11;
            BtnTarget.Text = "...";
            BtnTarget.UseVisualStyleBackColor = true;
            BtnTarget.Click += BtnTarget_Click;
            // 
            // TxtTarget
            // 
            TxtTarget.Location = new Point(87, 87);
            TxtTarget.Name = "TxtTarget";
            TxtTarget.ReadOnly = true;
            TxtTarget.Size = new Size(370, 23);
            TxtTarget.TabIndex = 10;
            // 
            // PrgProcess
            // 
            PrgProcess.Location = new Point(87, 169);
            PrgProcess.Name = "PrgProcess";
            PrgProcess.Size = new Size(370, 23);
            PrgProcess.TabIndex = 9;
            // 
            // BtnSyncCopy
            // 
            BtnSyncCopy.Location = new Point(87, 125);
            BtnSyncCopy.Name = "BtnSyncCopy";
            BtnSyncCopy.Size = new Size(75, 23);
            BtnSyncCopy.TabIndex = 6;
            BtnSyncCopy.Text = "동기화";
            BtnSyncCopy.UseVisualStyleBackColor = true;
            BtnSyncCopy.Click += BtnSyncCopy_Click;
            // 
            // TxtSource
            // 
            TxtSource.Location = new Point(87, 37);
            TxtSource.Name = "TxtSource";
            TxtSource.ReadOnly = true;
            TxtSource.Size = new Size(370, 23);
            TxtSource.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(42, 87);
            label2.Name = "label2";
            label2.Size = new Size(31, 15);
            label2.TabIndex = 1;
            label2.Text = "타겟";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 40);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 0;
            label1.Text = "소스";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(704, 358);
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
        private Label label2;
        private Label label1;
        private Button button4;
        private Button BtnSyncCopy;
        private Button button2;
        private Button BtnSource;
        private TextBox textBox2;
        private TextBox TxtSource;
        private ProgressBar PrgProcess;
        private Button BtnAsyncCopy;
        private Button BtnTarget;
        private TextBox TxtTarget;
    }
}
