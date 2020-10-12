using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace B3_OP01_TipCalulator
{
    [Activity(Label = "Tipcalculator", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText inputRekening;
        EditText inputTipPercentage;
        Button berekenButton;
        TextView outputTip;
        TextView outputTotaal;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Essentials.Platform.Init(this, bundle);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            inputRekening = FindViewById<EditText>(Resource.Id.inputRekening);
            inputTipPercentage = FindViewById<EditText>(Resource.Id.inputTipPercentage);
            outputTip = FindViewById<TextView>(Resource.Id.outputTip);
            outputTotaal = FindViewById<TextView>(Resource.Id.outputTotaal);
            berekenButton = FindViewById<Button>(Resource.Id.berekenButton);
            berekenButton.Click += OnBerekenClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        void OnBerekenClick(object sender, EventArgs e)
        {
            string text = inputRekening.Text;
            double rekening = 0;
            if (double.TryParse(text, out rekening))
            {
                var tip = rekening * 0.15;
                var totaal = rekening + tip;

                outputTip.Text = tip.ToString();
                outputTotaal.Text = totaal.ToString();
            }
        }
    }
}
