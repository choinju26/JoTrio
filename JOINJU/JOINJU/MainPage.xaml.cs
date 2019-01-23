using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Windows.Input;

namespace JOINJU
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            NavigateCommand = new Command<Type>(async (Type pageType) =>
            {
                Page page = (Page)Activator.CreateInstance(pageType);
                await Navigation.PushAsync(page);
            });

            BindingContext = this;
        }

        public ICommand NavigateCommand { private set; get; }

        private void RowDefinition_SizeChanged(object sender, EventArgs e)
        {

        }
        private async void ScoreBoard_Click(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ScoreBoard());
        }
    }
}
