using System.Windows;
using BattleFieldTracker.ViewModels;

namespace BattleFieldTracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelContainer();
        }
    }
}
