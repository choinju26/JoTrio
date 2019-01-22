using Rg.Plugins.Popup.Services;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace JOINJU
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MatchRecordList : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public MatchRecordList()
        {
            InitializeComponent();

            BindingContext = new ListViewModel();

          

          //  MyListView.ItemsSource = Items;
        }

        private RecordListDetail popup;

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            popup = new RecordListDetail();
            await PopupNavigation.Instance.PushAsync(popup);


            ((ListView)sender).SelectedItem = null;





        }
    }
}