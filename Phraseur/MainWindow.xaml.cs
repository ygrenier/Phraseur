using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Phraseur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ViewModels.AppViewModel();

            ViewModel.LoadThemes();
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddCurrentPhrase();
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Focus();
            txtResult.SelectAll();
        }

        private void btnCopyAll_Click(object sender, RoutedEventArgs e)
        {
            txtResult.Focus();
            txtResult.SelectAll();
            Clipboard.SetDataObject(txtResult.Text);
        }

        public ViewModels.AppViewModel ViewModel => DataContext as ViewModels.AppViewModel;

    }
}
