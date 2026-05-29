using System.Drawing;
using System.ComponentModel;
using System.Text;  // 인코딩용

namespace DotNet04ControlsApp
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // 폼로드 이벤트핸들러
        private void FrmMain_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families;  // OS에 설치된 폰트리스트
            foreach (var font in Fonts)
            {
                CboFonts.Items.Add(font.Name);
            }

            TxtResult.Text = "현재 글씨체 / Fonts";
            PrgStatus.Value = 0; // 0으로 초기화

            BtnStop.Enabled = false;  // 최초실행시는 중지버튼 비활성화
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
                style |= FontStyle.Bold;   // 볼드체 변경
            }

            if (ChkItalic.Checked)
            {
                style |= FontStyle.Italic;  // 이탤릭체 변경
            }

            TxtResult.Font = new Font(CboFonts.SelectedItem as string, 10, style);
        }

        // 모달버튼 클릭이벤트핸들러
        // 모달창이 닫히기전엔 부모창을 제어할 수 없음
        private void BtnModal_Click(object sender, EventArgs e)
        {
            FrmSub frmSub = new FrmSub();
            frmSub.Text = "모달창";  // 런타임시 속성값 변경
            frmSub.BackColor = Color.OrangeRed;
            frmSub.StartPosition = FormStartPosition.CenterParent;
            frmSub.ShowDialog();  // 모달창으로 오픈
        }

        // 모달리스버튼 클릭이벤트핸들러
        // 모달리스창과 관계없이 부모창을 제어할 수 있음
        private void BtnModaless_Click(object sender, EventArgs e)
        {
            FrmSub frmSub = new FrmSub();
            frmSub.Text = "모달리스창";
            frmSub.BackColor = Color.GreenYellow;
            //frmSub.StartPosition = FormStartPosition.CenterParent; // 적용안됨
            // 모달리스창은 위치를 직접 계산
            frmSub.StartPosition = FormStartPosition.Manual;
            frmSub.Location = new Point(
                this.Location.X + (this.Width - frmSub.Width) / 2,
                this.Location.Y + (this.Height - frmSub.Height) / 2
             );

            frmSub.Show(this);  // this -> FrmMain
        }

        private void BtnMsgbox_Click(object sender, EventArgs e)
        {
            // 기본적인 메시지박스 
            // 파라미터: 메시지, 타이틀, 버튼종류, 아이콘종류
            MessageBox.Show(TxtResult.Text, "메시지박스",
                MessageBoxButtons.CancelTryContinue,
                MessageBoxIcon.Error);
        }

        // 다이얼로그창 띄우기
        private void BtnDialog_Click(object sender, EventArgs e)
        {
            // DlgOpenFile.ShowDialog(this); // 일반 오픈
            if (DlgOpenFile.ShowDialog(this) == DialogResult.OK)
            {
                MessageBox.Show($"선택한 파일은 {DlgOpenFile.FileName} 입니다.");
            }
        }

        // 트랙바 스크롤변경 이벤트핸들러
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
                    new String[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }, 1
                    )
                );

            foreach (TreeNode subNode in node.Nodes)
            {
                TreeToList(subNode); // 재귀호출
            }
        }

        private void BtnAddRoot_Click(object sender, EventArgs e)
        {
            var random = new Random();

            TvwDummy.Nodes.Add(random.Next().ToString());

            TreeToList();
        }

        private void BtnAddNode_Click(object sender, EventArgs e)
        {
            if (TvwDummy.SelectedNode == null)
            {
                MessageBox.Show("노드를 선택하세요", "경고", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // 메서드 탈출
            }

            var random = new Random();
            TreeNode childNode = new TreeNode(random.Next().ToString());
            childNode.ImageIndex = 1;
            TvwDummy.SelectedNode.Nodes.Add(childNode);
            TvwDummy.ExpandAll(); // 하위노드 전부 확장

            TreeToList();
        }

        private void BtnLoadImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "이미지 열기";
            dlg.Filter = "Image Files(*.bmp;*.png;*.jpg)|*.bmp;*.png;*.jpg";

            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                PicImage.Image = Bitmap.FromFile(dlg.FileName);
                PicImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        // 픽쳐박스 컨트롤 클릭이벤트핸들러
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

        // 스레드 없이 진행
        private void BtnNoThread_Click(object sender, EventArgs e)
        {
            // 진행바 초기화
            var maximum = 100;
            var minimun = 0;
            var currValue = 0;
            TxtLog.Clear();
            PrgProcess.Minimum = minimun;
            PrgProcess.Maximum = maximum;
            PrgProcess.Value = 0;

            BtnThread.Enabled = false;
            BtnNoThread.Enabled = false;
            BtnStop.Enabled = true;

            // 프로세스 진행 더미로 실행
            for (int i = 0; i <= maximum; i++)
            {
                // 내부적으로 복잡하고 시간이 많이 소요되는 작업
                currValue = i;
                PrgProcess.Value = currValue;
                // 윈도우의 경우 \n만으로 기능 안됨. \r\n 둘다 사용필요
                TxtLog.AppendText($"진행사항 : {currValue}\r\n");
                Thread.Sleep(500);  // 500ms 동안 딜레이. 실제로는 업무로직이 들어감
            }

            BtnNoThread.Enabled = BtnThread.Enabled = true;
            BtnStop.Enabled = false;
        }

        // 스레드로 진행
        private void BtnThread_Click(object sender, EventArgs e)
        {
            // 진행바 초기화
            var maximum = 100;
            var minimun = 0;
            var currValue = 0;
            TxtLog.Clear();
            PrgProcess.Minimum = minimun;
            PrgProcess.Maximum = maximum;
            PrgProcess.Value = 0;

            BtnThread.Enabled = false;
            BtnNoThread.Enabled = false;
            BtnStop.Enabled = true;

            // 내부처리 작업을 백그라운드워커에 이벤트로 분리해야 함
            WrkProcess.WorkerReportsProgress = true;   // 진행사항 리포트 활성화
            WrkProcess.WorkerSupportsCancellation = true;  // 백그라운드워커 중간 취소 활성화
            WrkProcess.RunWorkerAsync(null);  // 백그라운드 워커 실행! (DoWork)
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            // 백그라운드워커의 Canceled 속성값을 true로 변경
            WrkProcess.CancelAsync();  // Async 비동기로 취소처리
        }

        #region `백그라운드워커 이벤트핸들러`

        // 1. 백그라운드워커 첫 시작점
        private void WrkProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            var maximum = 100;
            var currValue = 0.0;  // 실수형

            for (int i = 0; i <= maximum; i++)
            {
                if (WrkProcess.CancellationPending)
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    currValue = i;
                    Thread.Sleep(100);  // ms 단위
                    // 진행사항은 ProgressChanged 이벤트핸들러에 작성
                    WrkProcess.ReportProgress((int)((currValue / maximum) * 100));
                }
            }
        }

        // 2. 프로세스 변경사항 UI로 전달
        private void WrkProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // UI 스레드에 넘길값들만 실행!
            PrgProcess.Value = e.ProgressPercentage;
            TxtLog.AppendText($"진행률 : {PrgProcess.Value}\r\n");
        }


        // 3. 프로세스가 끝난 뒤 처리
        private void WrkProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                TxtLog.AppendText("작업 취소!\r\n");
            }
            else
            {
                TxtLog.AppendText("작업 완료!\r\n");
            }

            BtnNoThread.Enabled = BtnThread.Enabled = true;
            BtnStop.Enabled = false;
        }

        #endregion


        #region `텍스트파일 읽고쓰기`

        private void BtnFileLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;   // 여러파일 선택여부
            // 다이얼로그 필터작업
            dlg.Filter = "Text files(*.txt;*.cs;*.py;*.sql)|*.txt;*.cs;*.py;*.sql|RichText file(*.rtf)|*.rtf";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // 확장자가 rtf면
                // UTF-8 한글깨짐. EUC-KR, UTF-8(BOM) 문제없음
                // RtbEditor.LoadFile(dlg.FileName, RichTextBoxStreamType.PlainText);
                // RichTextbox 포맷으로 변경
                string fileContent = File.ReadAllText(dlg.FileName, Encoding.UTF8);
                RtbEditor.Text = fileContent;
            }
        }

        private void BtnFileSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "RichText file(*.rtf)|*.rtf";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {

                RtbEditor.SaveFile(dlg.FileName, RichTextBoxStreamType.RichNoOleObjs);
            }
        }

        #endregion

        /// <summary>
        /// 폼종료할 때 종료여부 체크
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            var res = MessageBox.Show("정말 종료하시겠습니까?", "종료여부",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                e.Cancel = true;  // 종료가 취소됨
            }
        }
    }
}
