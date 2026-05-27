namespace DontNet03GuessNum
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
            LblDisplay = new Label();
            this.TxtGuess = new TextBox();
            this.BtnStart = new Button();
            BtnCheck = new Button();
            SuspendLayout();
            // 
            // LblDisplay
            // 
            LblDisplay.Dock = DockStyle.Top;
            LblDisplay.Font = new Font("맑은 고딕", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblDisplay.Location = new Point(0, 0);
            LblDisplay.Name = "LblDisplay";
            LblDisplay.Size = new Size(377, 46);
            LblDisplay.TabIndex = 1;
            LblDisplay.Text = "게임을 시작합니다";
            LblDisplay.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TxtGuess
            // 
            this.TxtGuess.Font = new Font("맑은 고딕", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.TxtGuess.Location = new Point(67, 49);
            this.TxtGuess.Name = "TxtGuess";
            this.TxtGuess.Size = new Size(196, 29);
            this.TxtGuess.TabIndex = 3;
            // 
            // BtnStart
            // 
            this.BtnStart.Dock = DockStyle.Bottom;
            this.BtnStart.Font = new Font("맑은 고딕", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.BtnStart.Location = new Point(0, 110);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new Size(377, 46);
            this.BtnStart.TabIndex = 4;
            this.BtnStart.Text = "게임시작";
            this.BtnStart.UseVisualStyleBackColor = true;
            this.BtnStart.Click += this.BtnStart_Click;
            // 
            // BtnCheck
            // 
            BtnCheck.Location = new Point(269, 49);
            BtnCheck.Name = "BtnCheck";
            BtnCheck.Size = new Size(80, 29);
            BtnCheck.TabIndex = 5;
            BtnCheck.Text = "확인";
            BtnCheck.UseVisualStyleBackColor = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 156);
            Controls.Add(BtnCheck);
            Controls.Add(this.BtnStart);
            Controls.Add(this.TxtGuess);
            Controls.Add(LblDisplay);
            Name = "FrmMain";
            Text = "숫자맞추기";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label LblDisplay;
        private Button button2;
        private TextBox textGuess;
        private Button Btn1;
        private Button BtnCheck;
    }
}
