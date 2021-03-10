using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace X_0
{
    public partial class WinBox : Window
    {
        private static string winnerName;
        MainWindow task1 = new MainWindow();
        public WinBox()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
                WinName.Content = winnerName;
        }

        internal void nameSet(string Name)
        {
            winnerName = Name;
        }
    }
}
