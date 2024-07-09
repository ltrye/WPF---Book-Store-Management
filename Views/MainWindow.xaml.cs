using Store_Management.ViewModels;
using Store_Management.ViewModels.Utils;
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

namespace Store_Management.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigationPanelVM navigationPanelVM = new NavigationPanelVM();
            this.DataContext = navigationPanelVM;
            Navigator.CreateInstance(navigationPanelVM, this);
        }
    }
}