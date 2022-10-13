using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

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
        public MainWindow()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
        }

        private void login_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void parol_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void avtoriz_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=43p_rad_Sor_Man;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select COUNT(*) from Users", connection);
                int n = Convert.ToInt32(command.ExecuteScalar().ToString());
                for (int i = 1; i <= n; i++)
                {
                    SqlCommand command1 = new SqlCommand("SELECT [Login] FROM [dbo].[Users] WHERE [ID_User] = " + i + "", connection);
                    log = command1.ExecuteScalar().ToString();
                    if (log == login.Text)
                    {
                        int h = i;
                        SqlCommand command2 = new SqlCommand("SELECT [Password] FROM [dbo].[Users] WHERE [ID_User] = " + h + "", connection);
                        par = command2.ExecuteScalar().ToString();
                        if (par == parol.Text)
                        {
                            Glavnaya glavnaya = new Glavnaya();
                            glavnaya.Show();
                            Close();
                            break;

                        }
                    }
                    else
                    {
                        MessageBox.Show("Проверьте введенные данные");
                    }
                }
            }
        }

        public void registr_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            reg.Show();
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



