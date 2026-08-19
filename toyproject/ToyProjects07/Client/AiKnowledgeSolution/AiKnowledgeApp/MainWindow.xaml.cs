using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AiKnowledgeApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void BtnSelfPdf_Click(object sender, RoutedEventArgs e) {
            // FileOpenDialog 추가
            OpenFileDialog dialog = new OpenFileDialog();
            // 필터 PDF만 선택
            dialog.Filter = "PDF 파일 (*.pdf)|*.pdf";
            dialog.Multiselect = false; //파일 하나만

            if (dialog.ShowDialog() == true) {
                TxtPdfPath.Text = dialog.FileName;
            }
        }
    }
}