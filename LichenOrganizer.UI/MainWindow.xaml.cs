using LichenOrganizer.UI.ViewModels;
using System.Windows;
using System.Threading.Tasks;

namespace LichenOrganizer.UI
{

    public partial class MainWindow : Window
    {
        private MainViewModel _viewModel;
        public MainWindow(MainViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = viewModel;
            Loaded += MainWindow_Loaded;
        }

        //We don't want to call the viewmodel's 'Load' method from the constructor.  Instead, we will call it from the 
        //Window's 'Loaded' Event below, then subscribe to it inside the constructor. 
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await _viewModel.LoadAsync();
        }
    }
}
