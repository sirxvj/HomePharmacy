namespace HomePharmacy
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRegClick(object sender, EventArgs e)
        {
           
            await Navigation.PushAsync(new Register());
        }
        
    }

}
