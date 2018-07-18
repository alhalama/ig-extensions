using System;
using System.Data;
using System.Windows;

namespace WPFExtensionDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class XamGridDemo : Window
    {
        ViewModel vm = new ViewModel();
        public XamGridDemo()
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

        private class ViewModel
        {
            public DataTable Data { get; set; }

            Random r = new Random();
            public ViewModel()
            {
                Data = new DataTable();
                for (int i = 0; i < 6; i++)
                {
                    Data.Columns.Add("Column" + i.ToString(), typeof(int));
                }

                for (int i = 0; i < 1000; i++)
                {
                    DataRow row = Data.NewRow();
                    for (int j = 0; j < 6; j++)
                    {
                        row[j] = r.Next(1000);
                    }

                    Data.Rows.Add(row);
                }
            }
        }
    }
}
