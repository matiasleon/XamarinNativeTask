using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace NativeTest.Droid.Listeners
{
    public class CheckedChangeListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
    {
        private Activity activity;

        public CheckedChangeListener(Activity activity)
        {
            this.activity = activity;
        }

        public void OnCheckedChanged(CompoundButton buttonView, bool isChecked)
        {
            if (isChecked)
            {
                string name = (string)buttonView.Tag;
                string text = string.Format("{0} Checked.", name);
                Toast.MakeText(this.activity, text, ToastLength.Short).Show();
            }
        }
    }
}