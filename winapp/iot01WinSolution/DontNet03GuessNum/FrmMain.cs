using System;
using System.Windows.Forms;

namespace DontNet03GuessNum
{
    public partial class FrmMain : Form
    {
        private int findNumber = 0; // 맞힐 정답 숫자
        private int chance = 0;     // 남은 기회 횟수

        public FrmMain()
        {
            InitializeComponent();
        }

        // 폼이 처음 켜질 때 실행되는 세팅 로직
        private void FrmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            findNumber = rand.Next(1, 31);  // 1 ~ 30 사이의 랜덤 정수 생성
            chance = 10;                    // 기회 10번 부여

            LblDisplay.Text = "1부터 30 사이의 숫자를 맞춰보세요! (남은 기회: 10회)";
        }
    }
}