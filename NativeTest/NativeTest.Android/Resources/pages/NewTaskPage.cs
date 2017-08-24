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
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;
using NativeTest.DataAccessLayer;
using NativeTest.Droid.Resources.pages.Datepicker;

namespace NativeTest.Droid.Resources.pages
{
    [Activity(Label = "NewTaskPage")]
    public class NewTaskPage : Activity
    {

        private TextView datetimeTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NewTaskPage);

            // toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.ToolbarTask2);
            SetActionBar(toolbar);
            ActionBar.Title = "Nueva Tarea";

            // add button
            var addButton = FindViewById<Button>(Resource.Id.Add_task);
            addButton.Click += AddButton_Click;

            // datepicker
            var datetimePickerButton = FindViewById<ImageButton>(Resource.Id.DatetimePickerButton);
            datetimePickerButton.Click += DatetimePickerButton_Click;
            this.datetimeTextView = FindViewById<TextView>(Resource.Id.NewTaskDatetime);

        }

        private void DatetimePickerButton_Click(object sender, EventArgs e)
        {
            var datetimeFragment = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                this.datetimeTextView.Text = time.ToLongDateString();
            });
            datetimeFragment.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            var name = FindViewById<EditText>(Resource.Id.NewTaskName).Text;
            var description = FindViewById<EditText>(Resource.Id.NewTaskDescription).Text;

            var repo = new TaskRepository(this.GetDbPath(), new SQLitePlatformAndroid());
            var newTask = new BusinessLayer.Task() { Name = name, Description = description };

            await repo.Save(newTask);

            Finish();
            Toast.MakeText(this, "Tarea creada!!", ToastLength.Short).Show();
        }

        private string GetDbPath()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "Todo.db3");
        }
    }
}