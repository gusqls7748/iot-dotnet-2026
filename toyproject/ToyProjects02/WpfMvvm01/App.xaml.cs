using System.Configuration;
using System.Data;
using System.Windows;
using WpfMvvm01.ViewModels;
using WpfMvvm01.Views;

namespace WpfMvvm01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            MainView view = new MainView();
            view.DataContext = new MainViewModel();
            view.Show();
        }
    }

}
