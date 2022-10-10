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
    public partial class Add_vibros : Window
    {
        public Add_vibros()
        {
            InitializeComponent();
        }

        private void nomer_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void count_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void comment_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void date_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void addVibr_Click(object sender, RoutedEventArgs e)
        {
            int nomer_ist = Convert.ToInt32(nomer.Text);
            int kol = Convert.ToInt32(count.Text);
            string com = comment.Text;
            string date_ist = date.Text;
            int a;
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=43p_rad_Sor_Man;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand commands = new SqlCommand("select max(ID_Emission) from Vibrosi", connection);
                a=Convert.ToInt32(commands.ExecuteScalar().ToString());
                a++;
            }
                DataTable dt = Select("insert into Vibrosi (ID_Emission, ID_Souce, Count, Text, date) values ('"+a+"','" + nomer_ist + "','" + kol + "','"+com+"','"+date_ist+"');");
            Glavnaya glavnaya = new Glavnaya();
            glavnaya.Show();
            Close();
        }

        private void otmVibr_Click(object sender, RoutedEventArgs e)
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
    }
}
