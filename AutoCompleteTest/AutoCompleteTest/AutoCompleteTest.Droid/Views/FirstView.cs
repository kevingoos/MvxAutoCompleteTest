using Android.App;
using Android.OS;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace AutoCompleteTest.Droid.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
        }
    }
}
