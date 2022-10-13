using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Add_vibros.xaml
    /// </summary>
    public partial class Del_istochnik : Window
    {
        public Del_istochnik()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

       

        private void Delist_Click(object sender, RoutedEventArgs e)
        {
            int nomer_istoc= Convert.ToInt32(nomer_ist.Text);

            DataTable dt2 = Select("DELETE FROM Istochniki WHERE ID_Source ='" + nomer_istoc + "'");
            Glavnaya glavnaya = new Glavnaya();
            glavnaya.Show();
            Close();
        }

        private void otmist_Click(object sender, RoutedEventArgs e)
        {
            Glavnaya glavnaya = new Glavnaya();
            glavnaya.Show();
            Close();
        }
        public DataTable Select(string selectSQL) // функция подключения к базе данных и обработка запросов
        {
            DataTable dataTable = new DataTable("dataBase"); // создаём таблицу в приложении
                                                             // подключаемся к базе данных
            SqlConnection sqlConnection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=43p_rad_Sor_Man;User=33П;PWD=12357");
            sqlConnection.Open(); // открываем базу данных
            SqlCommand sqlCommand = sqlConnection.CreateCommand(); // создаём команду
            sqlCommand.CommandText = selectSQL; // присваиваем команде текст
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand); // создаём обработчик
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close(); // возращаем таблицу с результатом
            return dataTable;
        }

        private void nomer_ist_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
