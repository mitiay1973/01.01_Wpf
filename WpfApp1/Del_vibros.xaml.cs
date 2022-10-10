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
    public partial class Del_vibros : Window
    {
        public Del_vibros()
        {
            InitializeComponent();
        }

       

        private void DelVibr_Click(object sender, RoutedEventArgs e)
        {
            int nomer_vibs= Convert.ToInt32(nomer_vibrs.Text);

            DataTable dt2 = Select("DELETE FROM Vibrosi WHERE ID_Emission =" + nomer_vibs + "");
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

        private void nomer_vibr_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void nomer_vibrs_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
