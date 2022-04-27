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

namespace BankSystem.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepositCalculatorPage.xaml
    /// </summary>
    public partial class DepositCalculatorPage : Page
    {
        public DepositCalculatorPage()
        {
            InitializeComponent();
            StableIncomeLB.Content = 1000;
            OptimalIncomeLB.Content = 30;
            StandartIncomeLB.Content = 0;
        }

        private void CompareParmsBTN_Click(object sender, RoutedEventArgs e)
        {
            ComparisonOfDepositsPage comparisonOfDepositsPage = new ComparisonOfDepositsPage();
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).MainFrame.Navigate(comparisonOfDepositsPage);
                }
            }
        }

        private void SumTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StableIncomeLB.Content = SumTB.Text;
        }

        private void SumSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SumSlider.Value == 1E+7)
                StableIncomeLB.Content = 10000000;
            else
                StableIncomeLB.Content = ((float)(SumSlider.Value));
        }

        private void TermTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            OptimalIncomeLB.Content = TermTB.Text;
        }

        private void TermSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OptimalIncomeLB.Content = (int)(TermSlider.Value);
        }

        private void MonthlyRepleminshlerTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            StandartIncomeLB.Content = MonthlyRepleminshlerTB.Text;
        }

        private void MonthlyRepleminshlerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            StandartIncomeLB.Content = (double)((float)(MonthlyRepleminshlerSlider.Value));
        }
    }
}
