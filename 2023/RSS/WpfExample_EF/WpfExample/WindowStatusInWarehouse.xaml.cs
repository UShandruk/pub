using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
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
    /// Interaction logic for WindowStatusInWarehouse.xaml
    /// </summary>
    public partial class WindowStatusInWarehouse : Window
    {
        DBContextCodeFirst db = new DBContextCodeFirst();

        public WindowStatusInWarehouse()
        {
            InitializeComponent();

            DBContextCodeFirst db = new DBContextCodeFirst();
            db.Products.Load();
            dtgrdStatusInWarehouse.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.InWarehouse);
            this.Closing += OnWindowStatusInWarehouse_Closing;
            this.btnAdd.Click += OnBtnAdd_Click;
        }

        /// <summary>
        /// Клик на пункт "Продать" контекстного меню
        /// </summary>
        private void ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            int selectedProductId = ((Product)dtgrdStatusInWarehouse.SelectedItem).Id;

            db.Products.Load();
            Product selectedProduct = db.Products.Local.Where(p => p.Id == selectedProductId).FirstOrDefault();

            selectedProduct.StatusId = (int)EnumStatuses.SoldOut;

            db.SaveChanges();

            //dtgrdStatusInWarehouse.Items.Refresh(); // не работает
            dtgrdStatusInWarehouse.ItemsSource = null;
            dtgrdStatusInWarehouse.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.InWarehouse);
        }

        /// <summary>
        /// Клик на кнопку "Добавить"
        /// </summary>
        private void OnBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnWindowStatusInWarehouse_Activated;

            WindowAddingProduct wndAddingProduct = new WindowAddingProduct((int)EnumStatuses.InWarehouse);
            wndAddingProduct.ShowDialog();
        }

        private void OnWindowStatusInWarehouse_Activated(object sender, EventArgs e)
        {
            db.Products.Load();
            //dtgrdStatusInWarehouse.Items.Refresh(); // не работает
            dtgrdStatusInWarehouse.ItemsSource = null;
            dtgrdStatusInWarehouse.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.InWarehouse);

            this.Activated -= OnWindowStatusInWarehouse_Activated;
        }

        /// <summary>
        /// Закрытие окна "Склад"
        /// </summary>
        private void OnWindowStatusInWarehouse_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}