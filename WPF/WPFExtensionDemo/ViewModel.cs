using System;
using System.Data;

namespace WPFExtensionDemo
{
    public class ViewModel
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
