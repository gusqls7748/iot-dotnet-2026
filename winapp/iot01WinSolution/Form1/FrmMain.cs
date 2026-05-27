namespace Form1
{
    public partial class LblResult : Form
    {
        public LblResult()
        {
            InitializeComponent();
        }

        private void BtnPress_click(object sender, EventArgs e)
        {
            MessageBox.Show("버튼클릭", "테스트", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           // LblResult.Text = "결과 : 컴퓨터터짐!";
        }
    }
}
