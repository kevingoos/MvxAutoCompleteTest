using System.ComponentModel;

namespace AutoCompleteTest.Core.Models
{
    public class ItemClass : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private int _age;
        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                RaisePropertyChanged("Age");
            }
        }

        public override string ToString()
        {
            return Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = this.PropertyChanged;
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
