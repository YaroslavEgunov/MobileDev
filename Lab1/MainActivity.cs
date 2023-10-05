using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace Lab1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            Button AddButton = FindViewById<Button>(Resource.Id.AddButton);
            AddButton.Click += AddButton_Click;
            Button SubButton = FindViewById<Button>(Resource.Id.SubButton);
            SubButton.Click += SubButton_Click;
            Button MultButton = FindViewById<Button>(Resource.Id.MultButton);
            MultButton.Click += MultButton_Click;
            Button DivButton = FindViewById<Button>(Resource.Id.DivButton);
            DivButton.Click += DivButton_Click;
            Button SqrtButton = FindViewById<Button>(Resource.Id.SqrtButton);
            SqrtButton.Click += SqrtButton_Click;
            Button PercButton = FindViewById<Button>(Resource.Id.PercButton);
            PercButton.Click += PercButton_Click;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            EditText num1 = FindViewById<EditText>(Resource.Id.etNum1);
            EditText num2 = FindViewById<EditText>(Resource.Id.etNum2);
            TextView res = FindViewById<TextView>(Resource.Id.resultTextView);
            double n1 = double.Parse(num1.Text);
            double n2 = double.Parse(num2.Text);
            res.Text = "Результат сложения: " + (n1 + n2).ToString();
        }
        
        private void SubButton_Click(object sender, EventArgs e)
        {
            EditText num1 = FindViewById<EditText>(Resource.Id.etNum1);
            EditText num2 = FindViewById<EditText>(Resource.Id.etNum2);
            TextView res = FindViewById<TextView>(Resource.Id.resultTextView);
            double n1 = double.Parse(num1.Text);
            double n2 = double.Parse(num2.Text);
            res.Text = "Результат вычитания: " + (n1 - n2).ToString();
        }
        
        private void MultButton_Click(object sender, EventArgs e)
        {
            EditText num1 = FindViewById<EditText>(Resource.Id.etNum1);
            EditText num2 = FindViewById<EditText>(Resource.Id.etNum2);
            TextView res = FindViewById<TextView>(Resource.Id.resultTextView);
            double n1 = double.Parse(num1.Text);
            double n2 = double.Parse(num2.Text);
            res.Text = "Результат умножения: " + (n1 * n2).ToString();
        }
        
        private void DivButton_Click(object sender, EventArgs e)
        {
            EditText num1 = FindViewById<EditText>(Resource.Id.etNum1);
            EditText num2 = FindViewById<EditText>(Resource.Id.etNum2);
            TextView res = FindViewById<TextView>(Resource.Id.resultTextView);
            double n1 = double.Parse(num1.Text);
            double n2 = double.Parse(num2.Text);
            res.Text = "Результат деления: " + (n1 / n2).ToString();
        }
        
        private void SqrtButton_Click(object sender, EventArgs e)
        {
            EditText num1 = FindViewById<EditText>(Resource.Id.etNum1);
            EditText num2 = FindViewById<EditText>(Resource.Id.etNum2);
            TextView res = FindViewById<TextView>(Resource.Id.resultTextView);
            double n1 = double.Parse(num1.Text);
            double n2 = double.Parse(num2.Text);
            res.Text = "Результат корня: " + (Math.Pow(n1,1/n2)).ToString();
        }

        private void PercButton_Click(object sender, EventArgs e)
        {
            EditText num1 = FindViewById<EditText>(Resource.Id.etNum1);
            EditText num2 = FindViewById<EditText>(Resource.Id.etNum2);
            TextView res = FindViewById<TextView>(Resource.Id.resultTextView);
            double n1 = double.Parse(num1.Text);
            double n2 = double.Parse(num2.Text);
            res.Text = "Результат процентовки: " + (Math.Round((double)(n1*n2/100)).ToString());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}