using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using System.Data.Entity.Validation;
//using WpfExample.Model;

namespace WpfExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DBContextCodeFirst db;

        public MainWindow()
        {
            InitializeComponent();

            db = new DBContextCodeFirst();
            db.Products.Load();
            dtgrdMain.ItemsSource = db.Products.Local.ToBindingList();
            
            this.Closing += OnMainWindow_Closing;
            this.btnSave.Click += OnBtnAdd_Click;
            this.btnChangeStatus.Click += OnBtnChangeStatus_Click;
            this.dtgrdMain.MouseRightButtonDown += OnDtgrdMain_RightClick;
            this.btnReport.Click += OnBtnReport_Click;

            this.btnShowWindowStatusTaken.Click += OnBtnShowWindowStatusTaken_Click;
            this.btnShowWindowStatusInWarehouse.Click += OnBtnShowWindowStatusInWarehouse_Click;
            this.btnShowWindowStatusSoldOut.Click += OnBtnShowWindowStatusSoldOut_Click;
        }

        private void OnBtnReport_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnBtnShowWindowStatusTaken_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnMainWindow_Activated;

            WindowStatusTaken wndStatusTaken = new WindowStatusTaken();
            wndStatusTaken.ShowDialog();
        }

        private void OnBtnShowWindowStatusInWarehouse_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnMainWindow_Activated;

            WindowStatusInWarehouse wndStatusInWarehouse = new WindowStatusInWarehouse();
            wndStatusInWarehouse.ShowDialog();
        }

        private void OnBtnShowWindowStatusSoldOut_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnMainWindow_Activated;

            WindowStatusSoldOut wndStatusSoldOut = new WindowStatusSoldOut();
            wndStatusSoldOut.ShowDialog();
        }


        private void OnMainWindow_Activated(object sender, EventArgs e)
        {
            db.Products.Load();
            //dtgrdMain.Items.Refresh(); // не работает
            dtgrdMain.ItemsSource = null;
            dtgrdMain.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.InWarehouse);

            this.Activated -= OnMainWindow_Activated;
        }

        /// <summary>
        /// Закрытие главного окна
        /// </summary>
        private void OnMainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }


        /// <summary>
        /// Нажатие на кнопку "Добавить товар", открытие окна
        /// </summary>
        private void OnBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnMainWindow_Activated;

            WindowAddingProduct wndAddingProduct = new WindowAddingProduct((int)EnumStatuses.Taken);
            wndAddingProduct.ShowDialog();
        }

        /// <summary>
        /// Нажатие на кнопку "Изменить статус", открытие окна
        /// </summary>
        private void OnBtnChangeStatus_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnMainWindow_Activated;

            Product selectedProduct = dtgrdMain.SelectedItem as Product;

            if (selectedProduct != null)
            {
                WindowChangingStatus windowChangingStatus = new WindowChangingStatus(selectedProduct.Id);
                windowChangingStatus.ShowDialog();
            }
            else
            {
                MessageBox.Show("Выберите товар, которого нужно изменить статус");
            }

        }

        /// <summary>
        /// Правый клик на грид, открытие окна
        /// </summary>
        private void OnDtgrdMain_RightClick(object sender, RoutedEventArgs e)
        {
            WindowChangingStatus windowChangingStatus = new WindowChangingStatus(null);
            windowChangingStatus.ShowDialog();
        }
    }
}
