using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AutoCompleteTest.Core.Models;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.Platform;

namespace AutoCompleteTest.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private static ObservableCollection<ItemClass> _autoCompleteList;

        private List<ItemClass> _items = new List<ItemClass>();
        public List<ItemClass> Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<ItemClass>();
                }
                return _items;
            }
            set { _items = value; RaisePropertyChanged(nameof(Items)); }
        }

        private ItemClass _selectedObject;
        public ItemClass SelectedObject
        {
            get => _selectedObject;
            private set
            {
                _selectedObject = new ItemClass { Name = value.Name, Age = value.Age };
                RaisePropertyChanged(nameof(SelectedObject));
            }
        }

        private string _currentTextHint;
        public string CurrentTextHint
        {
            get => _currentTextHint;
            set
            {
                MvxTrace.Trace("Partial Text Value Sent {0}", value);
                //Setting _currentTextHint to null if an empty string gets passed here
                //is extremely important.
                if (value == "")
                {
                    _currentTextHint = null;
                    SetSuggestionsEmpty();
                    return;
                }
                else
                {
                    _currentTextHint = value;
                }

                if (_currentTextHint.Trim().Length < 2)
                {
                    SetSuggestionsEmpty();
                    return;
                }

                var list = _autoCompleteList.Where(i => (i.Name.ToString() ?? "").ToUpper().Contains(_currentTextHint.ToUpper())).ToList();
                if (list.Any())
                {
                    Items = list;
                }
                else
                {
                    SetSuggestionsEmpty();
                }
            }
        }

        public FirstViewModel()
        {
            _autoCompleteList = new ObservableCollection<ItemClass>()
            {
                new ItemClass
                {
                    Name = "Test1",
                    Age = 11
                },
                new ItemClass
                {
                    Name = "Test2",
                    Age = 12
                },
                new ItemClass
                {
                    Name = "Test3",
                    Age = 13
                }
            };
        }

        private void SetSuggestionsEmpty()
        {
            Items = new List<ItemClass>();
        }
    }
}
