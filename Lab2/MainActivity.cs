using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Lab2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private ViewsContainer container;
        private int viewsCount = 0;

        private void Button_Click(object sender, EventArgs e)
        {
            container.IncrementViews();
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            SetContentView(Resource.Layout.activity_main);
            Button button = FindViewById<Button>(Resource.Id.myButton);
            button.Click += Button_Click;
            container = FindViewById<ViewsContainer>(Resource.Id.container);
        }

        protected override void OnStart()
        {
            base.OnStart();
            Log.Info("APP", "OnStart");
        }
        
        protected override void OnResume()
        {
            base.OnResume();
            Log.Info("APP", "OnResume");
        }
        
        protected override void OnPause()
        {
            base.OnPause();
            Log.Info("APP", "OnPause");
        }
        
        protected override void OnStop()
        {
            base.OnStop();
            Log.Info("APP", "OnStop");
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            Log.Info("APP", "OnDestroy");
        }
        
        protected override void OnSaveInstanceState(Bundle outState)
        {
            Log.Info("APP", " OnSaveInstanceState");
            base.OnSaveInstanceState(outState);
            outState.PutInt("viewsCount", viewsCount);
        }

    }
}