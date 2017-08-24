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

namespace NativeTest.Droid.Resources.pages
{
    [Activity(Label = "NewTaskPage")]
    public class NewTaskPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewTaskPage);
            var toolbar = FindViewById<Toolbar>(Resource.Id.ToolbarTask2);
            SetActionBar(toolbar);
            ActionBar.Title = "Nueva Tarea";
            // Create your application here
        }
    }
}