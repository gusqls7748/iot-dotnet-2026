namespace DotNet04ControlsApp
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            groupBox1 = new GroupBox();
            ChkItalic = new CheckBox();
            BtnDialog = new Button();
            BtnMsgbox = new Button();
            BtnModaless = new Button();
            BtnModal = new Button();
            ChkBold = new CheckBox();
            TxtResult = new TextBox();
            CboFonts = new ComboBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            PrgStatus = new ProgressBar();
            TrkStatus = new TrackBar();
            groupBox3 = new GroupBox();
            BtnAddNode = new Button();
            LvwDummy = new ListView();
            BtnAddRoot = new Button();
            TvwDummy = new TreeView();
            ImgDummy = new ImageList(components);
            groupBox4 = new GroupBox();
            BtnLoadImg = new Button();
            PicImage = new PictureBox();
            groupBox5 = new GroupBox();
            BtnStop = new Button();
            BtnThread = new Button();
            BtnNoThread = new Button();
            PrgProcess = new ProgressBar();
            TxtLog = new TextBox();
            groupBox6 = new GroupBox();
            BtnFileSave = new Button();
            BtnFileLoad = new Button();
            RtbEditor = new RichTextBox();
            DlgOpenFile = new OpenFileDialog();
            WrkProcess = new System.ComponentModel.BackgroundWorker();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TrkStatus).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicImage).BeginInit();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(ChkItalic);
            groupBox1.Controls.Add(BtnDialog);
            groupBox1.Controls.Add(BtnMsgbox);
            groupBox1.Controls.Add(BtnModaless);
            groupBox1.Controls.Add(BtnModal);
            groupBox1.Controls.Add(ChkBold);
            groupBox1.Controls.Add(TxtResult);
            groupBox1.Controls.Add(CboFonts);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(386, 128);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "기본컨트롤";
            // 
            // ChkItalic
            // 
            ChkItalic.AutoSize = true;
            ChkItalic.Location = new Point(234, 21);
            ChkItalic.Name = "ChkItalic";
            ChkItalic.Size = new Size(62, 19);
            ChkItalic.TabIndex = 4;
            ChkItalic.Text = "이탤릭";
            ChkItalic.UseVisualStyleBackColor = true;
            ChkItalic.CheckedChanged += ChkItalic_CheckedChanged;
            // 
            // BtnDialog
            // 
            BtnDialog.Location = new Point(277, 93);
            BtnDialog.Name = "BtnDialog";
            BtnDialog.Size = new Size(75, 23);
            BtnDialog.TabIndex = 9;
            BtnDialog.Text = "...";
            BtnDialog.UseVisualStyleBackColor = true;
            BtnDialog.Click += BtnDialog_Click;
            // 
            // BtnMsgbox
            // 
            BtnMsgbox.Location = new Point(196, 93);
            BtnMsgbox.Name = "BtnMsgbox";
            BtnMsgbox.Size = new Size(75, 23);
            BtnMsgbox.TabIndex = 8;
            BtnMsgbox.Text = "메시지창";
            BtnMsgbox.UseVisualStyleBackColor = true;
            BtnMsgbox.Click += BtnMsgbox_Click;
            // 
            // BtnModaless
            // 
            BtnModaless.Location = new Point(115, 93);
            BtnModaless.Name = "BtnModaless";
            BtnModaless.Size = new Size(75, 23);
            BtnModaless.TabIndex = 7;
            BtnModaless.Text = "모달리스";
            BtnModaless.UseVisualStyleBackColor = true;
            BtnModaless.Click += BtnModaless_Click;
            // 
            // BtnModal
            // 
            BtnModal.Location = new Point(34, 93);
            BtnModal.Name = "BtnModal";
            BtnModal.Size = new Size(75, 23);
            BtnModal.TabIndex = 6;
            BtnModal.Text = "모달";
            BtnModal.UseVisualStyleBackColor = true;
            BtnModal.Click += BtnModal_Click;
            // 
            // ChkBold
            // 
            ChkBold.AutoSize = true;
            ChkBold.Location = new Point(178, 22);
            ChkBold.Name = "ChkBold";
            ChkBold.Size = new Size(50, 19);
            ChkBold.TabIndex = 3;
            ChkBold.Text = "굵게";
            ChkBold.UseVisualStyleBackColor = true;
            ChkBold.CheckedChanged += ChkBold_CheckedChanged;
            // 
            // TxtResult
            // 
            TxtResult.Location = new Point(6, 48);
            TxtResult.Name = "TxtResult";
            TxtResult.Size = new Size(374, 23);
            TxtResult.TabIndex = 5;
            // 
            // CboFonts
            // 
            CboFonts.FormattingEnabled = true;
            CboFonts.Location = new Point(51, 19);
            CboFonts.Name = "CboFonts";
            CboFonts.Size = new Size(121, 23);
            CboFonts.TabIndex = 2;
            CboFonts.SelectedIndexChanged += CboFonts_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 25);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 1;
            label1.Text = "폰트";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox2.Controls.Add(PrgStatus);
            groupBox2.Controls.Add(TrkStatus);
            groupBox2.Location = new Point(12, 146);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(386, 213);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "트랙바, 진행바";
            // 
            // PrgStatus
            // 
            PrgStatus.Location = new Point(6, 73);
            PrgStatus.Name = "PrgStatus";
            PrgStatus.Size = new Size(374, 63);
            PrgStatus.TabIndex = 1;
            // 
            // TrkStatus
            // 
            TrkStatus.Location = new Point(6, 22);
            TrkStatus.Maximum = 100;
            TrkStatus.Name = "TrkStatus";
            TrkStatus.Size = new Size(374, 45);
            TrkStatus.TabIndex = 0;
            TrkStatus.Scroll += TrkStatus_Scroll;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.Controls.Add(BtnAddNode);
            groupBox3.Controls.Add(LvwDummy);
            groupBox3.Controls.Add(BtnAddRoot);
            groupBox3.Controls.Add(TvwDummy);
            groupBox3.Location = new Point(12, 365);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(386, 164);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "트리, 리스트뷰";
            // 
            // BtnAddNode
            // 
            BtnAddNode.Location = new Point(277, 125);
            BtnAddNode.Name = "BtnAddNode";
            BtnAddNode.Size = new Size(75, 23);
            BtnAddNode.TabIndex = 5;
            BtnAddNode.Text = "노드추가";
            BtnAddNode.UseVisualStyleBackColor = true;
            BtnAddNode.Click += BtnAddNode_Click;
            // 
            // LvwDummy
            // 
            LvwDummy.Location = new Point(196, 22);
            LvwDummy.Name = "LvwDummy";
            LvwDummy.Size = new Size(184, 97);
            LvwDummy.TabIndex = 4;
            LvwDummy.UseCompatibleStateImageBehavior = false;
            // 
            // BtnAddRoot
            // 
            BtnAddRoot.Location = new Point(196, 125);
            BtnAddRoot.Name = "BtnAddRoot";
            BtnAddRoot.Size = new Size(75, 23);
            BtnAddRoot.TabIndex = 2;
            BtnAddRoot.Text = "루트추가";
            BtnAddRoot.UseVisualStyleBackColor = true;
            BtnAddRoot.Click += BtnAddRoot_Click;
            // 
            // TvwDummy
            // 
            TvwDummy.ImageIndex = 0;
            TvwDummy.ImageList = ImgDummy;
            TvwDummy.Location = new Point(6, 22);
            TvwDummy.Name = "TvwDummy";
            TvwDummy.SelectedImageIndex = 0;
            TvwDummy.Size = new Size(184, 97);
            TvwDummy.TabIndex = 0;
            // 
            // ImgDummy
            // 
            ImgDummy.ColorDepth = ColorDepth.Depth32Bit;
            ImgDummy.ImageStream = (ImageListStreamer)resources.GetObject("ImgDummy.ImageStream");
            ImgDummy.TransparentColor = Color.Transparent;
            ImgDummy.Images.SetKeyName(0, "folder.png");
            ImgDummy.Images.SetKeyName(1, "file.png");
            // 
            // groupBox4
            // 
            groupBox4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox4.Controls.Add(BtnLoadImg);
            groupBox4.Controls.Add(PicImage);
            groupBox4.Location = new Point(421, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(386, 234);
            groupBox4.TabIndex = 2;
            groupBox4.TabStop = false;
            groupBox4.Text = "픽쳐박스";
            // 
            // BtnLoadImg
            // 
            BtnLoadImg.Location = new Point(220, 191);
            BtnLoadImg.Name = "BtnLoadImg";
            BtnLoadImg.Size = new Size(75, 23);
            BtnLoadImg.TabIndex = 1;
            BtnLoadImg.Text = "이미지";
            BtnLoadImg.UseVisualStyleBackColor = true;
            BtnLoadImg.Click += BtnLoadImg_Click;
            // 
            // PicImage
            // 
            PicImage.Location = new Point(6, 19);
            PicImage.Name = "PicImage";
            PicImage.Size = new Size(374, 166);
            PicImage.TabIndex = 0;
            PicImage.TabStop = false;
            PicImage.Click += PicImage_Click;
            // 
            // groupBox5
            // 
            groupBox5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox5.Controls.Add(BtnStop);
            groupBox5.Controls.Add(BtnThread);
            groupBox5.Controls.Add(BtnNoThread);
            groupBox5.Controls.Add(PrgProcess);
            groupBox5.Controls.Add(TxtLog);
            groupBox5.Location = new Point(421, 252);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(386, 277);
            groupBox5.TabIndex = 2;
            groupBox5.TabStop = false;
            groupBox5.Text = "스레드";
            // 
            // BtnStop
            // 
            BtnStop.Location = new Point(305, 248);
            BtnStop.Name = "BtnStop";
            BtnStop.Size = new Size(75, 23);
            BtnStop.TabIndex = 4;
            BtnStop.Text = "중지";
            BtnStop.UseVisualStyleBackColor = true;
            BtnStop.Click += BtnStop_Click;
            // 
            // BtnThread
            // 
            BtnThread.Location = new Point(220, 248);
            BtnThread.Name = "BtnThread";
            BtnThread.Size = new Size(75, 23);
            BtnThread.TabIndex = 3;
            BtnThread.Text = "스레드";
            BtnThread.UseVisualStyleBackColor = true;
            BtnThread.Click += BtnThread_Click;
            // 
            // BtnNoThread
            // 
            BtnNoThread.Location = new Point(139, 248);
            BtnNoThread.Name = "BtnNoThread";
            BtnNoThread.Size = new Size(75, 23);
            BtnNoThread.TabIndex = 2;
            BtnNoThread.Text = "노스레드";
            BtnNoThread.UseVisualStyleBackColor = true;
            BtnNoThread.Click += BtnNoThread_Click;
            // 
            // PrgProcess
            // 
            PrgProcess.Location = new Point(6, 209);
            PrgProcess.Name = "PrgProcess";
            PrgProcess.Size = new Size(374, 23);
            PrgProcess.TabIndex = 1;
            // 
            // TxtLog
            // 
            TxtLog.BorderStyle = BorderStyle.FixedSingle;
            TxtLog.Location = new Point(6, 22);
            TxtLog.Multiline = true;
            TxtLog.Name = "TxtLog";
            TxtLog.ScrollBars = ScrollBars.Vertical;
            TxtLog.Size = new Size(374, 171);
            TxtLog.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            groupBox6.Controls.Add(BtnFileSave);
            groupBox6.Controls.Add(BtnFileLoad);
            groupBox6.Controls.Add(RtbEditor);
            groupBox6.Location = new Point(813, 12);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(360, 517);
            groupBox6.TabIndex = 2;
            groupBox6.TabStop = false;
            groupBox6.Text = "텍스트에디터";
            // 
            // BtnFileSave
            // 
            BtnFileSave.Location = new Point(279, 478);
            BtnFileSave.Name = "BtnFileSave";
            BtnFileSave.Size = new Size(75, 23);
            BtnFileSave.TabIndex = 2;
            BtnFileSave.Text = "파일세이브";
            BtnFileSave.UseVisualStyleBackColor = true;
            BtnFileSave.Click += BtnFileSave_Click;
            // 
            // BtnFileLoad
            // 
            BtnFileLoad.Location = new Point(198, 478);
            BtnFileLoad.Name = "BtnFileLoad";
            BtnFileLoad.Size = new Size(75, 23);
            BtnFileLoad.TabIndex = 1;
            BtnFileLoad.Text = "파일로드";
            BtnFileLoad.UseVisualStyleBackColor = true;
            BtnFileLoad.Click += BtnFileLoad_Click;
            // 
            // RtbEditor
            // 
            RtbEditor.BorderStyle = BorderStyle.None;
            RtbEditor.Location = new Point(6, 25);
            RtbEditor.Name = "RtbEditor";
            RtbEditor.Size = new Size(348, 447);
            RtbEditor.TabIndex = 0;
            RtbEditor.Text = "";
            // 
            // DlgOpenFile
            // 
            DlgOpenFile.FileName = "텍스트 파일을 선택하세요";
            DlgOpenFile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            DlgOpenFile.InitialDirectory = "C:\\SourceBank";
            DlgOpenFile.Title = "텍스트파일열";
            // 
            // WrkProcess
            // 
            WrkProcess.DoWork += WrkProcess_DoWork;
            WrkProcess.ProgressChanged += WrkProcess_ProgressChanged;
            WrkProcess.RunWorkerCompleted += WrkProcess_RunWorkerCompleted;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 541);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMain";
            Text = "컨트롤 예제";
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)TrkStatus).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PicImage).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox6.ResumeLayout(false);
            ResumeLayout(false);
        }







        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private CheckBox ChkBold;
        private TextBox TxtResult;
        private ComboBox CboFonts;
        private Label label1;
        private CheckBox ChkItalic;
        private Button BtnDialog;
        private Button BtnMsgbox;
        private Button BtnModaless;
        private Button BtnModal;
        private OpenFileDialog DlgOpenFile;
        private ProgressBar PrgStatus;
        private TrackBar TrkStatus;
        //private ListView listView1;
        private TreeView TvwDummy;

        //private Button button2;
        private Button BtnAddRoot;
        private ListView LvwDummy;
        private ImageList ImgDummy;
        private Button BtnAddNode;
        private Button BtnLoadImg;
        private PictureBox PicImage;
        private Button BtnStop;
        private Button BtnThread;
        private Button BtnNoThread;
        private ProgressBar PrgProcess;
        private TextBox TxtLog;
        private System.ComponentModel.BackgroundWorker WrkProcess;
        private RichTextBox RtbEditor;
        private Button BtnFileSave;
        private Button BtnFileLoad;
    }
}
