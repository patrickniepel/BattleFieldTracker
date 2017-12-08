using System.Windows;
using BattleFieldTracker.ViewModels;
using MahApps.Metro.Controls;

namespace BattleFieldTracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelContainer();
        }
    }
}
