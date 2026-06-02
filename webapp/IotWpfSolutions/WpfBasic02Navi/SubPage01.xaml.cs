using System;
using System.Collections.Generic;
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

namespace WpfBasic02Navi
{
    /// <summary>
    /// SubPage01.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class SubPage01 : Page
    {
        public SubPage01()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MediaPlayer.Source = new Uri(@".\sample_360p.mp4", UriKind.RelativeOrAbsolute);
            MediaPlayer.Play();
        }
    }
}
