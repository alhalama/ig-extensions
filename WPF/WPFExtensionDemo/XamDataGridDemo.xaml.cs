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
using System.Windows.Shapes;
using WPFExtensionDemo.Data;

namespace WPFExtensionDemo
{
    /// <summary>
    /// Interaction logic for XamDataGridDemo.xaml
    /// </summary>
    public partial class XamDataGridDemo : Window
    {
        public XamDataGridDemo()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
        private class MainViewModel
        {
            public MainViewModel()
            {
                Items = new Departments(15, 5);
            }

            public Departments Items { get; set; }
        }
    }
}
