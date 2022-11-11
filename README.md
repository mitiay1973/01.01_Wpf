# 01.01_Wpf 
Графический интерфейс для работы с базой данных.
___
## Начало работы
Для начала работы с приложением вам необходимо скачать и распаковать архив с программой. 
___
### Необходимые условия
* Для запуска программы необходим компьютер на ОС **Windows 7** или новее.
  * Пакет Net Framework 4.8 или выше.
* Подключение к интернету.
___
### Установка

После распаковки нужно запустить .exe файл по пути ***"01.01_Wpf\WpfApp1\bin\Debug\WpfApp1.exe"***.
___
### Работа с программой
После запуска приложения появится окно авторизации.

![Авторизация](https://sun9-north.userapi.com/sun9-85/s/v1/ig2/dzHogOD1vkVKNnzRDyvcE4Pqbyy87v-g4NjmNB6Akz_evMo41venUrYK2Ddm5_gjElaA3pdP-SMJ53xCD8yeR5mz.jpg?size=565x447&quality=96&type=album)

При первом запуске необходимо перейти на окно регистрации и зарегистрировать новый аккаунт.

![Регистрация](https://sun9-north.userapi.com/sun9-77/s/v1/ig2/qFOu6S_f3lZro9nMWy8qwmi8kE30cdMiXn6dbwk-WUn8_XLGN20Iye0Mn3iR3-9seIMcd6pVZjcU-MBxI1XVvSpb.jpg?size=786x414&quality=96&type=album)

После чего вы вернетесь на страницу автонризации, где сможете войти в свой аккаунт.
При успешной авторизации вы попадете на главную страницу программы, где можно увидеть 2 таблицы с данными, кнопки для добавления, изменения и удаления данных, а также просмотр минимальных, максимальных и средних выбросов.

![Главная](https://sun9-west.userapi.com/sun9-66/s/v1/ig2/NfQAXzWhbWPh88PskNBKkkkHQGj608m6NSdE6uiCxLF3hUS9rUI83zb7Qo41cD5bLSNrDnJlRC3IAuBAvsR9zPLI.jpg?size=806x515&quality=96&type=album)

Пример вывода выбросов:
![выбросы](https://sun9-east.userapi.com/sun9-28/s/v1/ig2/l_HHZKS4OfdDTpk0XcxelxGK_6g8TyAuxfnafRbFWAa2QgyDnbBFTIq5uAJjbNj2iv9vUHtYpJ1zdW4wVeAgOPrB.jpg?size=782x415&quality=96&type=album)

Чтобы добавить элемент в таблицу нужно нажать на кнопку добавить справа от нее. Пример окан добавления:

![Добавление](https://sun9-west.userapi.com/sun9-53/s/v1/ig2/1cKa9ZPUpZBVRf_xqA4O1JRvpzaZ8eyoSBJLk7hZDL6JpICK9x8fOnVURzG4zpDOvkSaqVjagVVJeJ5bjySUTVYa.jpg?size=328x364&quality=96&type=album)

Удаление и изменения работают аналогично.
___

### Код работы вывода таблиц


Данный код при необходимости можно оптимизировать для увеличения быстродействия программы.

~~~c#
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
~~~

Такая же ситуация и с кодом для второй таблицы

~~~ c#
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
~~~
___
## Авторы

* **Сорокин Дмитрий** - *Основная работа* - [**Ссылка на гит**](https://github.com/mitiay1973)

* [Ссылка на соавтора](https://github.com/KirillManakow)
___
![logo](https://sun9-west.userapi.com/sun9-53/s/v1/ig2/8bn8peYapfZ-zLXtIX5M7mVBoZkFUG4I6kR4hJTl_Q74xAFDPPPiLiq0gvKXcgGrnmL4fGdAnur6e0JA4m8RHL42.jpg?size=206x82&quality=96&type=album)<br>
### Ссылка на проект: [**01.01_Wpf**](https://github.com/mitiay1973/01.01_Wpf/tree/master)
___