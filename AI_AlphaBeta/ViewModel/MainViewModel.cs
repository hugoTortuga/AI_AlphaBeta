using AI_AlphaBeta.Model;
using AI_AlphaBeta.ViewModel;
using System;
using System.Windows;
using Telerik.Windows.Controls;

namespace AI_AlphaBeta
{
    public class MainViewModel : ViewModelBase
    {
        ////////////// Attributes /////////////////
        

        // the tree viewmodel 
        public TreeViewModel TreeViewModel { get; set; }
        
        public string SelectedFilePath { get; set; }

        // this boolean is the exploration direction of nodes
        private bool _IsRightToLeft;
        public bool IsRightToLeft
        {
            get
            {
                return _IsRightToLeft;
            }
            set
            {
                _IsRightToLeft = value;
                OnPropertyChanged("IsRightToLeft");
            }
        }

        // the data of nodes in a tree
        public Tree Tree { get; set; }

        // the result to be printed at the top of the window
        private string _Result;
        public string Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
                OnPropertyChanged("Result");
            }
        }

        // the message to be printed at the bottom of the window
        private string _Footer;
        public string Footer
        {
            get
            {
                return _Footer;
            }
            set
            {
                _Footer = value;
                OnPropertyChanged("Footer");
            }
        }

        private bool _IsRootMax;
        public bool IsRootMax
        {
            get
            {
                return _IsRootMax;
            }
            set
            {
                _IsRootMax = value;
                OnPropertyChanged("IsRootMax");
            }
        }

        public void ChangeRoot()
        {
            if (IsRootMax) IsRootMax = false;
            else IsRootMax = true;
        }

        // Used to change direction from righttoleft to lefttoright
        public void ChangeDirection()
        {
            if (IsRightToLeft)
            {
                IsRightToLeft = false;
                MessageBox.Show("From Left to Right direction", "Direction Changed", MessageBoxButton.OK, MessageBoxImage.Information);
            } else
            {
                IsRightToLeft = true;
                MessageBox.Show("From Right to Left direction", "Direction Changed", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        // the constructor
        public MainViewModel()
        {
            IsRightToLeft = true;
            IsRootMax = true;
            TreeViewModel = new TreeViewModel(null, IsRootMax);
        }

     
        ////////////// METHODS /////////////////
        

        // Choose the XML file containing the tree
        public void ChooseFile()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "XML Files (*.xml)|*.xml";

            var result = dlg.ShowDialog();

            // Get the selected file name
            if (result != null && result == true) SelectedFilePath = dlg.FileName;
            try
            {
                Tree = XMLConverter.ConvertXMLtoTree(SelectedFilePath);
                UpdateTree();
            } catch
            {
                MessageBox.Show("Wrong XML data ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }

        //Update the printing of the tree
        public void UpdateTree()
        {
            if (Tree != null && Tree.Root != null)
            {
                TreeViewModel.UpdateTree(Tree, IsRootMax);
                Result = "";
                Footer = "";
            }
        }

        // Fill the tree with alpha beta algorithm
        public void FillTree()
        {
            if(Tree != null && Tree.Root != null)
            {
                Tree = Core.AlphaBeta.FillTree(Tree, IsRightToLeft, IsRootMax);
                UpdateTree();
                // compute the pourcentage of visited nodes :
                decimal pourcentage = (decimal)((TreeViewModel.NbVisitedNode() * 1.0) / (TreeViewModel.Items.Count * 1.0) * 100);
                Result = TreeViewModel.NbVisitedNode() + " visited node on " + TreeViewModel.Items.Count + "\n" + pourcentage.ToString("#.##") + "% of all nodes explored";
                Footer = "Green nodes were visited, the grey ones were not";
            }
        }

        // Reload the raw tree, with no exploration
        public void EmptyTree()
        {
            Result = "";
            Footer = "";
            if (!string.IsNullOrWhiteSpace(SelectedFilePath))
            {
                try
                {
                    Tree = XMLConverter.ConvertXMLtoTree(SelectedFilePath);
                    TreeViewModel.UpdateTree(Tree, IsRootMax);
                } catch
                {
                    MessageBox.Show("Wrong XML data ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
