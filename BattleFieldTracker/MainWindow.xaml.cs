using BattleFieldTracker.ViewModels;

namespace BattleFieldTracker
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelContainer();
        }
    }
}
