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

namespace BankSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void CalculateIncomeBtn_Click(object sender, RoutedEventArgs e)
        {
            DepositCalculatorPage depositCalculatorPage = new DepositCalculatorPage();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainFrame.Navigate(depositCalculatorPage);
                }
            }
        }
    }
}
