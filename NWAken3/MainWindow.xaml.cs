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

namespace NWAken3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NWEntities db = new NWEntities();
        public MainWindow()
        {
            InitializeComponent();
            InitializeDataGrid();

        }

        public void InitializeDataGrid()
        {
            Gridike.ItemsSource = db.Products
                .ToList();

            Gridike.AutoGeneratingColumn += Gridike_AutoGeneratingColumn;

        }

        private void Gridike_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        => e.Cancel = (e.PropertyType.FullName.Contains("NWA"));

        /* selline jupp oli enne
        //{
        //    //if (e.PropertyName == "Products")
        //    //{
        //    //    e.Cancel = true; // Tühistab veeru auto-generate
        //    //}

        //    // see alati ei aita
        //    if (e.PropertyType.FullName.Contains("NWA")) e.Cancel = true;  
        //}
        */


        private void Nupuke_Click(object sender, RoutedEventArgs e)
        {
            Boxike.Text = db.Customers.Find("ALFKI").CompanyName;
        }
    }
}
