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
using System.IO;
using Microsoft.Win32;

using CefSharp;
using CefSharp.Wpf;

namespace DnD_CM_WPF_Lib
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private string __filepath;
        private string FilePath { get => __filepath; set => __filepath = value; }
        private void openjson(object sender, RoutedEventArgs e)
        {
            try
            {

                OpenFileDialog ofd = new();

                ofd.Filter = "Json Files (*.json)|*.json";
                ofd.InitialDirectory = @"D:\Projects\DnD_Creature_Maker\DnD_CM_WPF_Lib\Json";
                //ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                if (ofd.ShowDialog() == true)
                {
                    FilePath = ofd.FileName;
                    string browserstring = Statblock.OutputStatblock(Input.LoadData(FilePath));
                    browser.LoadHtml(browserstring, "http://rendering/");


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Cef.Shutdown();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Quit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new();
                sfd.Filter = "Image Files (*.png)|*.png";
                
                if (sfd.ShowDialog() == true)
                    Statblock.Screenshot(sfd.FileName, 0, FilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
