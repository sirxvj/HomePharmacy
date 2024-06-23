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
            Routing.RegisterRoute("AddApteku",typeof(AddApteku));
            Routing.RegisterRoute("EditApteka",typeof(EditApteka));
            Routing.RegisterRoute("EditRecept", typeof(EditRecept));
            Routing.RegisterRoute("AddMedicine", typeof(AddMedicine));
            Routing.RegisterRoute("AddRecept", typeof(AddRecept));
            Routing.RegisterRoute("AptekaDetails", typeof(AptekaDetails));
            Routing.RegisterRoute("Recept", typeof(Recept));
            Routing.RegisterRoute("ReceptDetails", typeof(ReceptDetails));
        }
    }
}
