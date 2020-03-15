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
    /// Interaction logic for WindowChangingStatus.xaml
    /// </summary>
    public partial class WindowChangingStatus : Window
    {
        DBContextCodeFirst db;
        int? _selectedStatusId;
        int? _selectedProductId;

        public WindowChangingStatus(int? selectedProductId)
        {
            InitializeComponent();

            db = new DBContextCodeFirst();
            db.Products.Load();

            this.Closing += OnWindowShangingStatus_Closing;

            this.btnSaveStatus.Click += OnBtnSaveStatus_Click;
            this.lstbStatuses.SelectionChanged += OnLstbStatuses_SelectionChanged;

            db.Statuses.Load();
            lstbStatuses.ItemsSource = db.Statuses.Local.ToBindingList().Select(s => s.Name);

            this.lstbStatuses.MouseDown += OnLstbStatuses_Click;

            _selectedProductId = selectedProductId;
        }



        private void OnLstbStatuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedStatusId = (sender as ListBox).SelectedIndex +1; // нумерация статусов в коллекции начинается с нуля, а в проекте и в БД - с единицы
        }

        private void OnBtnSaveStatus_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = db.Products.Local.Where(p => p.Id == _selectedProductId).FirstOrDefault();
            selectedProduct.StatusId = (int)_selectedStatusId;

            db.SaveChanges();
            this.Close();
            
        }

        private void OnLstbStatuses_Click(object sender, MouseButtonEventArgs e)
        {
            var t = sender;
        }

        private void OnWindowShangingStatus_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
