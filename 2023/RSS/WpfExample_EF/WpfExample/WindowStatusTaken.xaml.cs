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
    /// Interaction logic for WindowStatusTaken.xaml
    /// </summary>
    public partial class WindowStatusTaken : Window
    {
        DBContextCodeFirst db;

        public WindowStatusTaken()
        {
            InitializeComponent();

            db = new DBContextCodeFirst();
            db.Products.Load();
            dtgrdStatusTaken.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.Taken);

            this.Closing += OnWindowStatusTaken_Closing;
            this.btnAdd.Click += OnBtnAdd_Click;
        }

        private void OnBtnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.Activated += OnWindowStatusTaken_Activated;

            WindowAddingProduct wndAddingProduct = new WindowAddingProduct((int)EnumStatuses.Taken);
            wndAddingProduct.ShowDialog();
        }

        private void OnWindowStatusTaken_Activated(object sender, EventArgs e)
        {
            db.Products.Load();
            //dtgrdStatusTaken.Items.Refresh(); // не работает
            dtgrdStatusTaken.ItemsSource = null;
            dtgrdStatusTaken.ItemsSource = db.Products.Local.ToBindingList().Where(p => p.StatusId == (int)EnumStatuses.Taken);

            this.Activated -= OnWindowStatusTaken_Activated;
        }

        private void OnWindowStatusTaken_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }
    }
}
