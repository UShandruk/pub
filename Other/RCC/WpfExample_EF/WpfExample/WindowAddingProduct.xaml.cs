using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
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

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for WindowAddingProduct.xaml
    /// </summary>
    public partial class WindowAddingProduct : Window
    {
        DBContextCodeFirst db;
        private int _statusId;

        public WindowAddingProduct(int statusId)
        {
            InitializeComponent();

            _statusId = statusId;

            db = new DBContextCodeFirst();
            db.Products.Load();

            //this.Loaded += MainWindow_Loaded;
            this.btnAddProduct.Click += BtnAddProduct_Click;
            this.Closing += OnWindowAddingProduct_Closing;
        }



        private void BtnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            string productName = this.tbProductName.Text;
            DateTime dateTime = DateTime.Now;
            int id = db.Products.AsEnumerable().Count() == 0 ? 1 : db.Products.AsEnumerable().Last().Id + 1;

            if (productName != null && productName != "")
            {
                Product newProduct = new Product();
                newProduct.Name = productName;
                newProduct.Id = id;
                newProduct.StatusId = _statusId;
                newProduct.DateOfChange = DateTime.Now;
                db.Products.Add(newProduct);
                db.SaveChanges();
            }

            this.Close();
        }

        private void OnWindowAddingProduct_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}