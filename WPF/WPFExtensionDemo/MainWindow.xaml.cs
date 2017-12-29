using System.Data;
using System.Windows;

namespace WPFExtensionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModel vm = new ViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        //This is for the DataTable working with the FilterRow
        private void XamGrid_DataObjectRequested(object sender, Infragistics.Controls.Grids.DataObjectCreationEventArgs e)
        {
            if (vm.Data != null && e.ObjectType.Equals(typeof(DataRowView)))
            {
                e.NewObject = new DataView(vm.Data).AddNew();
            }
        }
    }
}
