using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Glavnaya.xaml
    /// </summary>
    public partial class Glavnaya : Window
    {
        public Glavnaya()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=43p_rad_Sor_Man;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select max(ID_Emission) from Vibrosi", connection);
                int n = Convert.ToInt32(command.ExecuteScalar().ToString());
                int[] id=new int[n];
                float[] count=new float[n];
                string[] text = new string[n];
                string[] Date = new string[n];

                for (int i = 1; i <= n; i++)
                {
                    SqlCommand command1 = new SqlCommand("select ID_Souce FROM Vibrosi WHERE ID_Emission=" + i + "", connection);
                    if (command1.ExecuteScalar() is null)
                    {
                   
                    }
                    else
                    {
                        id[i - 1] = Convert.ToInt32(command1.ExecuteScalar().ToString());
                        SqlCommand command2 = new SqlCommand("select Count FROM Vibrosi WHERE ID_Emission=" + i + "", connection);
                        count[i - 1] = float.Parse(command2.ExecuteScalar().ToString());
                        SqlCommand command3 = new SqlCommand("select Text FROM Vibrosi WHERE ID_Emission=" + i + "", connection);
                        text[i - 1] = Convert.ToString(command3.ExecuteScalar().ToString());
                        SqlCommand command4 = new SqlCommand("select date FROM Vibrosi WHERE ID_Emission=" + i + "", connection);
                        Date[i - 1] = Convert.ToString(command4.ExecuteScalar().ToString());
                    }
                }
                List<Vibros> vibrosList = new List<Vibros>
                {

                };
                for (int i = 1; i <= n; i++)
                {
                        if (Date[i - 1]==null)
                        {

                        }
                        else
                        {
                            vibrosList.Add(new Vibros { ID_Emission = i, ID_Souce = id[i-1], Count = count[i-1], Text = text[i-1], date = Date[i-1] });
                        }                    
                }
                
                table_1.ItemsSource = vibrosList;
            }
            using (SqlConnection connection = new SqlConnection("server=ngknn.ru;Trusted_Connection=No;DataBase=43p_rad_Sor_Man;User=33П;PWD=12357"))
            {
                connection.Open();
                SqlCommand commandd = new SqlCommand("select max(ID_Source) from Istochniki", connection);
                int n = Convert.ToInt32(commandd.ExecuteScalar().ToString());
                string[] name = new string[n];
                string[] adress = new string[n];

                for (int i = 1; i <= n; i++)
                {
                    SqlCommand commandd1 = new SqlCommand("select Name FROM Istochniki WHERE ID_Source=" + i + "", connection);
                    if (commandd1.ExecuteScalar() is null)
                    {

                    }
                    else
                    {
                        
                        name[i - 1] = Convert.ToString(commandd1.ExecuteScalar().ToString());
                        SqlCommand commandd2 = new SqlCommand("select Adress FROM Istochniki WHERE ID_Source=" + i + "", connection);
                        adress[i - 1] = Convert.ToString(commandd2.ExecuteScalar().ToString());
                    }
                }
                List<Istochniki> istochnikList = new List<Istochniki>
                {

                };
                for (int i = 1; i <= n; i++)
                {
                    if (name[i - 1] == null)
                    {

                    }
                    else
                    {
                        istochnikList.Add(new Istochniki { ID_Souce = i, Name = name[i-1], Adress = adress[i-1] });
                    }
                }
                table_2.ItemsSource = istochnikList;
            }

        }

        private void table_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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

        private void addIstochnik_Click(object sender, RoutedEventArgs e)
        {
            Add_vibros vibr = new Add_vibros();
            vibr.Show();
            Close();
        }

        private void delIstochnik_Click(object sender, RoutedEventArgs e)
        {
            Del_vibros Dvibr = new Del_vibros();
            Dvibr.Show();
            Close();
        }


        private void addvibros_Click(object sender, RoutedEventArgs e)
        {
            Add_istochnik ist = new Add_istochnik();
            ist.Show();
            Close();
        }

        private void delvibros_Click(object sender, RoutedEventArgs e)
        {
            Del_istochnik dist = new Del_istochnik();
            dist.Show();
            Close();
        }


        private void redactvibros_Click_2(object sender, RoutedEventArgs e)
        {
            Red_vibros Rvibr = new Red_vibros();
            Rvibr.Show();
            Close();

        }

        private void redactIstochnik_Click(object sender, RoutedEventArgs e)
        {
            Red_istochnik Rist = new Red_istochnik();
            Rist.Show();
            Close();
        }

        private void maxvibros_Click(object sender, RoutedEventArgs e)
        {
            maxVibr max = new maxVibr();
            max.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }

    internal class Vibros
    {
        public int ID_Emission { get; set; }
        public int ID_Souce { get; set; }
        public float Count { get; set; }
        public string Text { get; set; }
        public string date { get; set; }

    }
    internal class Istochniki
    {
        public int ID_Souce { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

    }

}

