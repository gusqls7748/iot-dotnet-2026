using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfMvvm02.ViewModels
{
    internal partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        public MainViewModel()
        {
            title = "BookRentalShop";
        }
    }
}
