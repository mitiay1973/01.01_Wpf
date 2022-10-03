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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public string log;
        public string par;
        public string log1;
        public string par1;
        Registration reg = new Registration();
        public MainWindow(string l, string p)
        {
            InitializeComponent();
            log1 = l;
            par1 = p;
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void parol_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void avtoriz_Click(object sender, RoutedEventArgs e)
        {
            log = login.Text;
            par = parol.Text;
            if (log == log1)
            {
                if (par == par1)
                {
                    Glavnaya glavnaya = new Glavnaya();
                    glavnaya.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Проверьте введенные данные");
                }
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные");
            }
        }

        public void registr_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            reg.Show();
        }
    }
}
