using System;
using System.Collections.Generic;
using System.Linq;
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
using Telerik.Windows.Controls;

namespace AI_AlphaBeta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MainViewModel { get; set; }
        public MainWindow()
        {
            //we initialize the datacontext with the mainviewmodel
            MainViewModel = new MainViewModel();
            DataContext = MainViewModel;
            InitializeComponent();
        }

        //calls the FillTree methods of the mainviewmodel
        private void FillTree(object sender, RoutedEventArgs e)
        {
            MainViewModel.FillTree();
        }

        //calls the EmptyTree methods of the mainviewmodel
        private void EmptyTree(object sender, RoutedEventArgs e)
        {
            MainViewModel.EmptyTree();
        }

        //calls the ChangeDirection methods of the mainviewmodel
        private void ChangeDirection(object sender, RoutedEventArgs e)
        {
            MainViewModel.ChangeDirection();
        }

        private void ChangeRoot(object sender, RoutedEventArgs e)
        {
            MainViewModel.ChangeRoot();
        }

        //calls the ChooseFile methods of the mainviewmodel
        private void ChooseFile(object sender, RoutedEventArgs e)
        {
            MainViewModel.ChooseFile();
        }

    }
}
