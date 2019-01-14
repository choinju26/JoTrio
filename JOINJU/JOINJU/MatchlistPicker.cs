using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace JOINJU
{
    public class MatchlistPicker : INotifyPropertyChanged
    {
        public List<Sports>  SportsList { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string _myCity;
        public string MyCity
        {
            get { return _myCity; }
            set
            {
                if (_myCity != value)
                {
                    _myCity = value;
                    OnPropertyChanged();
                }
            }
        }

        private Sports _selectedCity { get; set; }
        public Sports SelectedCity
        {
            get { return _selectedCity; }
            set
            {
                if (_selectedCity != value)
                {
                    _selectedCity = value;
                    // Do whatever functionality you want...When a selectedItem is changed..
                    // write code here..
                    MyCity = "Selected City : " + _selectedCity.Value;
                }
            }
        }

        public MatchlistPicker()
        {
            SportsList = GetSports().OrderBy(t => t.Value).ToList();
            MyCity = "Selected City : ";
        }

        public List<Sports> GetSports()
        {
            var sports = new List<Sports>()
            {
                new Sports(){Key = 1, Value = "배드민턴"},
                new Sports(){Key = 2, Value = "탁구"},
                new Sports(){Key = 3, Value = "테니스"},
                new Sports(){Key = 4, Value = "축구"}
            };

            return sports;
        }
    }

    public class Sports
    {
        public int Key { get; set; }
        public string Value { get; set; }

    }
}
