using System;
using System.Collections.ObjectModel;

namespace WPFExtensionDemo.Data
{
    public class Departments : ObservableCollection<Department>
    {
        #region Constructors
        public Departments() { }

        public Departments(int sampleDataCount) : this(sampleDataCount, 0) { }

        public Departments(int sampleDataCount, int sampleEmployeeCount)
        {
            this.LoadSampleData(sampleDataCount, sampleEmployeeCount);
        }
        #endregion Constructors

        public void LoadSampleData()
        {
            LoadSampleData(24);
        }

        public void LoadSampleData(int count)
        {
            LoadSampleData(count, 0);
        }

        public void LoadSampleData(int count, int employeeCount)
        {
            this.Clear();
            for (int i = 0; i < count; i++)
            {
                Department d = new Department(i, String.Format("Department {0}", i));
                this.Add(d);
                for (int j = 0; j < employeeCount; j++)
                {
                    d.Employees.LoadSampleData(employeeCount);
                }
            }
        }
    }
}
