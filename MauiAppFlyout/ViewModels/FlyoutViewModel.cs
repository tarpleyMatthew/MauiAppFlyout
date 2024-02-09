using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiAppFlyout.ViewModels
{
    public class FlyoutViewModel : INotifyPropertyChanged
    {
        
        public FlyoutViewModel()
        {
            stringList = new ObservableCollection<string>();
            hashMap = new Dictionary<int, string>
            {
                {1, "Pizza" },
                {2, "Wings" },
                {3, "HotDogs" }
            };
            stringList.Add("First Item");
            stringList.Add("Second Item");
            stringList.Add("Third Item");

            AddToArray = new Command(AddItem);
            AddToDictionary = new Command(AddToDict);
            UpdateHashList();
        }

        //properties
        private Dictionary<int, string> hashMap { get; set; }
        public Dictionary<int, string> HashMap
        {
            get { return hashMap; }
            set
            {
                hashMap = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> stringList { get; set; }
        public ObservableCollection<string> StringList
        {
            get => stringList;
            set
            {
                stringList = value;
                OnPropertyChanged();
            }
        }

        private string listEntry { get; set; }
        public string ListEntry
        {
            get => listEntry;
            set
            {
                listEntry = value;
                OnPropertyChanged();
            }
        }

        private string dictEntry { get; set; }
        public string DictEntry
        {
            get => dictEntry;
            set
            {
                dictEntry = value;
                OnPropertyChanged();
            }
        }


        private string hashList { get; set; }
        public string HashList
        {
            get => hashList;
            set
            {
                hashList = value;
                OnPropertyChanged();
            }
        }

        //commands

        public ICommand AddToArray { get; private set; }
        public ICommand AddToDictionary { get; private set; }

        //command method
        private void AddItem()
        {
            StringList.Add(ListEntry);
        }

        private void AddToDict()
        {
            int keyCount = HashMap.Count;

            HashMap.Add((keyCount + 1), DictEntry);
            UpdateHashList();
            OnPropertyChanged();
        }

        //utility method
        private void UpdateHashList()
        {
            string hashListContent = "";
            foreach (var item in HashMap)
            {
                hashListContent += item.Value.ToString() + "\n";
            }

            HashList = hashListContent;
            OnPropertyChanged();
        }

        //event handler stuff

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
