using System;
using System.ComponentModel;

namespace WPFExtensionDemo.Data
{
    public class Employee : INotifyPropertyChanged
    {
        private int employeeID;
        private string name;
        private bool onSite;
        private DateTime dateOfHire;
        private int department;
        private string site;

        public int EmployeeID
        {
            get { return this.employeeID; }
            set
            {
                this.employeeID = value;
                NotifyPropertyChanged("EmployeeID");
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                this.name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public bool OnSite
        {
            get { return this.onSite; }
            set
            {
                this.onSite = value;
                NotifyPropertyChanged("OnSite");
            }
        }

        public DateTime DateOfHire
        {
            get { return this.dateOfHire; }
            set
            {
                this.dateOfHire = value;
                NotifyPropertyChanged("DateOfHire");
            }
        }

        public int Department
        {
            get { return this.department; }
            set
            {
                this.department = value;
                NotifyPropertyChanged("Department");
            }
        }
        public string Site
        {
            get { return this.site; }
            set
            {
                this.site = value;
                NotifyPropertyChanged("Site");
            }
        }


        public Employee()
        {
            this.employeeID = int.MinValue;
            this.name = string.Empty;
            this.onSite = false;
            this.dateOfHire = DateTime.MinValue;
            this.department = int.MinValue;
            this.site = String.Empty;
        }
        public Employee(int employeeID, string name, bool onSite, DateTime dateOfHire, int department, string site)
        {
            this.employeeID = employeeID;
            this.name = name;
            this.onSite = onSite;
            this.dateOfHire = dateOfHire;
            this.department = department;
            this.site = site;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
