namespace Form1
{
    partial class LblResult
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
            button1 = new Button();
            BtnPress = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("나눔고딕코딩", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(684, 496);
            button1.Name = "button1";
            button1.Size = new Size(127, 38);
            button1.TabIndex = 0;
            button1.Text = "출력";
            button1.UseVisualStyleBackColor = true;
            // 
            // BtnPress
            // 
            BtnPress.AutoSize = true;
            BtnPress.Location = new Point(375, 266);
            BtnPress.Name = "BtnPress";
            BtnPress.Size = new Size(31, 15);
            BtnPress.TabIndex = 1;
            BtnPress.Text = "결과";
            // 
            // LblResult
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 546);
            Controls.Add(BtnPress);
            Controls.Add(button1);
            Name = "LblResult";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label BtnPress;
    }
}