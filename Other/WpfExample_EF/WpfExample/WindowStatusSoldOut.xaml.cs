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
    /// Interaction logic for WindowStatusSoldOut.xaml
    /// </summary>
    public partial class WindowStatusSoldOut : Window
    {
        DBContextCodeFirst db;

        public WindowStatusSoldOut()
        {
            InitializeComponent();

            db = new DBContextCodeFirst();
            db.Products.Load();
            dtgrdStatusSoldOut.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.SoldOut);

            this.Closing += OnWindowStatusSoldOut_Closing;
            this.btnAdd.Click += OnBtnAdd_Click;
        }

        private void OnBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnWindowStatusSoldOut_Activated;

            WindowAddingProduct wndAddingProduct = new WindowAddingProduct((int)EnumStatuses.SoldOut);
            wndAddingProduct.ShowDialog();
        }

        private void OnWindowStatusSoldOut_Activated(object sender, EventArgs e)
        {
            db.Products.Load();
            //dtgrdStatusSoldOut.Items.Refresh(); // не работает
            dtgrdStatusSoldOut.ItemsSource = null;
            dtgrdStatusSoldOut.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.SoldOut);

            this.Activated -= OnWindowStatusSoldOut_Activated;
        }

        private void OnWindowStatusSoldOut_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
