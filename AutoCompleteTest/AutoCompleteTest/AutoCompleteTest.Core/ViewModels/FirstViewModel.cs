using System.Collections.ObjectModel;
using AutoCompleteTest.Core.Models;
using MvvmCross.Core.ViewModels;

namespace AutoCompleteTest.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private ObservableCollection<ItemClass> _items;
        private ItemClass _item;
        private string _searchTerm;
        
        public ObservableCollection<ItemClass> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        public ItemClass Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }

        public string ItemSearchTerm
        {
            get => _searchTerm;
            set => SetProperty(ref _searchTerm, value);
        }

        public FirstViewModel()
        {
            Init();
        }

        private void Init()
        {
            Items = new ObservableCollection<ItemClass>
            {
                new ItemClass
                {
                    Name = "Test1",
                },
                new ItemClass
                {
                    Name = "Test2",
                },
                new ItemClass
                {
                    Name = "Test3",
                }
            };
        }
    }
}
