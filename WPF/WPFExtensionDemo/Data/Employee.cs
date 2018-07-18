using System;
using System.Collections.ObjectModel;

namespace WPFExtensionDemo.Data
{
    public class Employees : ObservableCollection<Employee>
    {
        public Employees()
        {
        }

        public Employees(int sampleDataCount)
        {
            this.LoadSampleData(sampleDataCount);
        }

        public void LoadSampleData()
        {
            LoadSampleData(24);
        }
        public void LoadSampleData(int count)
        {
            this.Clear();
            for (int i = 0; i < count; i++)
            {
                this.Add(new Employee(i, String.Format("Name {0}", i), (i % 2 == 0), DateTime.Now, i % 4, "Here"));
            }
        }
    }
}
