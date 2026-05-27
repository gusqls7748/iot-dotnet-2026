using System.Drawing;

namespace DotNet04ControlsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        // 폼 로드 이벤트 핸들러
        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // OS에 설치된 폰트리스트
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }

            TxtResult.Text = "현재 글씨체 / Fonts";
            PrgStatus.Value = 0; // 0으로 초기화
        }

        private void ChkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void ChkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFontStyle();
        }

        // 폰트 글자체, 굵게, 이탤릭 변경 메서드
        private void ChangeFontStyle()
        {
            if (CboFonts.SelectedIndex < 0)
            {
                return; // 콤보박스 아무것도 선택안됨
            }

            FontStyle style = FontStyle.Regular; // 처음에는 기본 글자

            if (ChkBold.Checked)
            {
                style |= FontStyle.Bold; // 볼드체 변경
            }

            if (ChkItalic.Checked)
            {
                style |= FontStyle.Italic; // 이태릭체 변경
            }
            TxtResult.Font = new Font(CboFonts.SelectedItem as string, 10, style);
        }

        // 모달버튼 클릭이벤트핸들러
        // 모달창이 닫히기전에 부모창을 제어할 수 없음
        private void BtnModal_Click(object sender, EventArgs e)
        {
            FrmSub frmSub = new FrmSub();
            frmSub.Text = "모달창"; // 런타임시 속성값 변경
            frmSub.BackColor = Color.OrangeRed;
            frmSub.StartPosition = FormStartPosition.CenterParent;
            frmSub.ShowDialog();    // 모달창 오픈
        }

        // 모달리스트 클릭이벤트 핸들러
        // 모달리스창과 관계없이 부모창을 제어할 수 있음
        private void BtnModaless_Click(object sender, EventArgs e)
        {
            FrmSub frmSub = new FrmSub();
            frmSub.Text = "모달리스창";
            frmSub.BackColor = Color.GreenYellow;
            //frmSub.StartPosition = FormStartPosition.Manual;
            frmSub.Location = new Point(
                this.Location.X + (this.Width - frmSub.Width) / 2,
                this.Location.Y + (this.Height - frmSub.Height) / 2
                );

            frmSub.Show(this);  // this -> frmMain
        }

        private void BtnMsgbox_Click(object sender, EventArgs e)
        {
            // 기본적인 메시지박스
            // 파라미터: 메시지, 타이틀, 버튼종류, 아이콘종류
            MessageBox.Show(TxtResult.Text, "메세지박스", MessageBoxButtons.CancelTryContinue,
                MessageBoxIcon.Warning
                );
        }

        // 다이얼로그창 띄우기
        private void BtnDialog_Click(object sender, EventArgs e)
        {
            //DlgOpenFile.ShowDialog(this); // 일반 오픈
            if (DlgOpenFile.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show($"선택한 파일은 {DlgOpenFile.FileName}입니다.");
            }
        }


        // 트랙바 스크롤변경 이벤트 핸들러
        private void TrkStatus_Scroll(object sender, EventArgs e)
        {
            PrgStatus.Value = TrkStatus.Value;
        }

        // 트리뷰 내용을 리스트뷰에 표현 메서드
        private void TreeToList()
        {
            LvwDummy.Items.Clear();
            foreach (TreeNode node in TvwDummy.Nodes)
            {
                TreeToList(node);
            }
        }

        private void TreeToList(TreeNode node)
        {
            LvwDummy.Items.Add(
                new ListViewItem(
                    new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }
                    )
                );

            foreach (TreeNode subNode in node.Nodes)
            {
                TreeToList(subNode);
            }
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            var random = new Random();
            TvwDummy.Nodes.Add(random.Next().ToString());
        }

        private void BtnAddNode_Click(object sender, EventArgs e)
        {
            if (TvwDummy.SelectedNode == null)
            {
                MessageBox.Show("노드를 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var random = new Random();
            TreeNode childNode = new TreeNode(random.Next().ToString());
            childNode.ImageIndex = 1;
            TvwDummy.SelectedNode.Nodes.Add(childNode);
            TvwDummy.ExpandAll();

            TreeToList();
        }

        private void BtnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "이미지 열기";
            dlg.Filter = "Image Files(*.bmp;*.png;*.jpg)|*.png;*.jpg";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                PicImage.Image = Bitmap.FromFile(dlg.FileName);
                PicImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // 픽쳐박스 컨트롤 클릭이벤트 핸들러
        private void PicImage_Click(object sender, EventArgs e)
        {
            if (PicImage.SizeMode == PictureBoxSizeMode.CenterImage)
            {
                PicImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                PicImage.SizeMode = PictureBoxSizeMode.CenterImage;
            }
        }
    }
}
