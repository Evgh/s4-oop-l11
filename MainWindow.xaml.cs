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
using System.Data.Entity;

namespace s4_oop_l11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SodaContext sodaDataBase;
        UnitOfWork unit;

        public MainWindow()
        {
            InitializeComponent();
            sodaDataBase = new SodaContext();
            unit = new UnitOfWork();

            sodaDataBase.Sodas.Load();
            sodaDataBase.Companies.Load();

            sodaGrid.ItemsSource = unit.GetSodas();
            companiesGrid.ItemsSource = unit.GetCompanies();
            CompaniexComboBoxColumn.ItemsSource = unit.GetCompanies();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            unit.SaveChanges();
        }

    
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            int caloriesValue;
            if (int.TryParse(caloriesTexBox.Text, out caloriesValue))
            {
                var sodas = from soda in sodaDataBase.Sodas
                            where soda.Calories < caloriesValue
                            where soda.Name == nameTextBox.Text
                            select soda;


                 searchGrid.ItemsSource = sodas.ToList();
            }

        }
    }
}
