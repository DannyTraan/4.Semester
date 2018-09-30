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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

namespace MemoApp
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

        private void Button_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SoundPlayer deep = new SoundPlayer(MemoApp.Properties.Resources.Hallo);
                deep.Play();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Message" + exception.Message);
            }
            
        }

        private void Button1_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SoundPlayer deep1 = new SoundPlayer(MemoApp.Properties.Resources.Hjemad);
                deep1.Play();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Message" + exception.Message);
            }
        }

        private void Button2_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SoundPlayer deep2 = new SoundPlayer(MemoApp.Properties.Resources.Correct);
                deep2.Play();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Message" + exception.Message);
            }
        }

        private void Button3_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SoundPlayer deep3 = new SoundPlayer(MemoApp.Properties.Resources.Bro);
                deep3.Play();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Message" + exception.Message);
            }
        }

        private void Button4_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                SoundPlayer deep4 = new SoundPlayer(MemoApp.Properties.Resources.Alala);
                deep4.Play();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Error Message" + exception.Message);
            }
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
