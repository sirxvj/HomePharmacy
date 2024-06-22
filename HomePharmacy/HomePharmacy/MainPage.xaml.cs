namespace HomePharmacy
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private async void OnRegClick(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("Register");
           
           // await Shell.Current.GoTosync("//Sign/Register");
            //await Navigation.PushAsync(new Register());
        }
        private async void OnLogClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            {
                await Shell.Current.DisplayAlert("Ошибка", "Введите корректные данные!", "ОК");
                return;
            }
            await Shell.Current.GoToAsync("Apteka");
            Shell.SetTabBarIsVisible(Application.Current.MainPage, true);
            // await Shell.Current.GoTosync("//Sign/Register");
            //await Navigation.PushAsync(new Register());
        }


    }

}
