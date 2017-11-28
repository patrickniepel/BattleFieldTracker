using System.Windows;
using BattleFieldTracker.ViewModels;

namespace BattleFieldTracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        private readonly ViewModelContainer _viewModelContainer;

        public MainWindow()
        {
            InitializeComponent();
            _viewModelContainer = new ViewModelContainer();
            DataContext = _viewModelContainer;
        }

        private void SearchButton_OnClick(object sender, RoutedEventArgs e)
        {
            _viewModelContainer.StartDownload();
        }
    }
}
