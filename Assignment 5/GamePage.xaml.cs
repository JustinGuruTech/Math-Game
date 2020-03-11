using System;
using System.Collections.Generic;
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

namespace Assignment_5 {
    /// <summary>
    /// Interaction logic for GamePage.xaml
    /// </summary>
    public partial class GamePage : Page {

        MainWindow main;
        public GamePage(MainWindow main) {
            InitializeComponent();
            this.main = main;
        }

        private void BackToMenu_Click(Object sender, RoutedEventArgs e) {
            main.Main.Content = new StartPage(main);
        }
    }
}
