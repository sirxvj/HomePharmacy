using Android.App;
using Android.Runtime;

namespace HomePharmacy
{
    [Application]
    [MetaData("com.google.android.maps.v2.API_KEY",
         Value = "AIzaSyD3bLtZkNPObtKxnT7aa74Mh4qbcBYj8rU")]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership ownership)
            : base(handle, ownership)
        {
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}
