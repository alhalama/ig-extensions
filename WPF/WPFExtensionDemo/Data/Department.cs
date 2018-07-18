using System.ComponentModel;

namespace WPFExtensionDemo.Data
{
    public class Department : INotifyPropertyChanged
    {
        private int id;
        private string name;
        private Employees emps;

        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
                NotifyPropertyChanged("ID");
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public Employees Employees
        {
            get
            {
                return this.emps;
            }
            set
            {
                this.emps = value;
                NotifyPropertyChanged("Employees");
            }
        }

        public Department()
            : this(int.MinValue, string.Empty)
        {
        }

        public Department(int id, string name)
        {
            this.id = id;
            this.name = name;
            this.emps = new Employees();
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        #endregion
    }
}
