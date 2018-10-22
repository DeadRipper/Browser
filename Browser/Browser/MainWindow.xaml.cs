﻿using System;
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
using System.Text.RegularExpressions;
using System.Windows.Media.Animation;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Browser
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    [Serializable]
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            wbProg.Navigate("http://www.google.com");
        }

        public void Conn(string str)
        {
            str = txtUrl.Text.ToString();
            var date = DateTime.Now;
            string ConnectionString = "Server=127.0.0.1;Port=3306;Uid=root;Password=1234;Database=story_list;";
            MySqlConnectionStringBuilder connectionStringBuilder = new MySqlConnectionStringBuilder();
            MySqlConnection conn = new MySqlConnection(ConnectionString);
            using (MySqlCommand cmd = new MySqlCommand(ConnectionString, conn))
            {
                conn.Open();
                cmd.ExecuteReader();
                cmd.CommandText = string.Format("insert into story_list.story(name,time) values('{0}','{1}')", str, date);
            }
            conn.Close();
        }

        private bool IsUrlValid(string url)
        {
            url = txtUrl.Text.ToString();
            string reg = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$^[.com|.ua|.ru]";
            Regex regex = new Regex(reg, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return regex.IsMatch(url);
        }

        public void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            History wHistory = new History();
            if (e.Key == Key.Enter)
            {
                if (IsUrlValid(txtUrl.Text) == true)
                {
                    wbProg.Navigate(txtUrl.Text);
                    txtUrlcombo.Items.Add(txtUrl.Text);
                    wHistory.listbox.Items.Add(txtUrl.Text);
                    Conn(txtUrl.Text.ToString());
                }
                else
                {
                    wbProg.Navigate("http://" + txtUrl.Text + ".com");
                    txtUrlcombo.Items.Add(txtUrl.Text);
                    wHistory.listbox.Items.Add(txtUrl.Text);
                    Conn(txtUrl.Text.ToString());
                }
            }

        }

        private void wbProg_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            txtUrl.Text = e.Uri.OriginalString;
        }

        private void BrowseBack_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbProg != null) && (wbProg.CanGoBack));
        }

        private void BrowseBack_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbProg.GoBack();
        }

        private void BrowseForward_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ((wbProg != null) && (wbProg.CanGoForward));
        }

        private void BrowseForward_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbProg.GoForward();
        }

        private void GoToPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void GoToPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            wbProg.Navigate(txtUrl.Text);
        }

        private void story_button_Click(object sender, RoutedEventArgs e)
        {
            History wHistory = new History();
            wHistory.Show();
        }
    }
}
