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
using NativeTest.DataAccessLayer;

namespace NativeTest.Droid.Resources.pages
{
    [Activity(Label = "Detalle")]
    public class TaskDetailPage : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TaskDetailPage);
            var toolbar = FindViewById<Toolbar>(Resource.Id.ToolbarTask);
            SetActionBar(toolbar);
            ActionBar.Title = "Tareas";
            // Create your application here
            var taskId = Intent.GetIntExtra("TASK_ID", 0);
            //aca pegarle a dataAccess
            
            FindViewById<TextView>(Resource.Id.TaskName).Text = "hola";
            FindViewById<TextView>(Resource.Id.TaskDescription).Text = "matias";
        }
    }
}