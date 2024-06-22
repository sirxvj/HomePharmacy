namespace HomePharmacy
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("Register", typeof(Register));
            Routing.RegisterRoute("Apteka", typeof(Apteka));
        }
    }
}
