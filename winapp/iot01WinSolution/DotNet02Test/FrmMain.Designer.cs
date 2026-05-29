namespace DotNet02Test
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
            BtnPress = new Button();
            LblResult = new Label();
            SuspendLayout();
            // 
            // BtnPress
            // 
            BtnPress.Location = new Point(593, 389);
            BtnPress.Name = "BtnPress";
            BtnPress.Size = new Size(177, 72);
            BtnPress.TabIndex = 0;
            BtnPress.Text = "출력";
            BtnPress.UseVisualStyleBackColor = true;
            BtnPress.Click += BtnPress_Click;
            // 
            // LblResult
            // 
            LblResult.AutoSize = true;
            LblResult.Location = new Point(366, 241);
            LblResult.Name = "LblResult";
            LblResult.Size = new Size(49, 17);
            LblResult.TabIndex = 1;
            LblResult.Text = "결과 : ";
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 473);
            Controls.Add(LblResult);
            Controls.Add(BtnPress);
            Font = new Font("나눔고딕", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "첫번째 윈앱";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BtnPress;
        private Label LblResult;
    }
}
