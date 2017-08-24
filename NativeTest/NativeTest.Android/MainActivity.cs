using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using NativeTest.BusinessLayer;
using NativeTest.Droid.Adapters;
using NativeTest.Droid.Resources.pages;
using System.Collections.Generic;
using NativeTest.DataAccessLayer;
using System.IO;
using SQLite.Net.Platform.XamarinAndroid;


namespace NativeTest.Droid
{
	[Activity (Label = "Tareas", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
        private IList<Task> tasks;

        private ListView tasksListView;

        protected override async void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<Toolbar>(Resource.Id.ToolbarTask);
            SetActionBar(toolbar);
		    ActionBar.Title = "Tareas";

            // obtengo tareas
            await this.SetTasks();

            // Fullfil de adapte mas item click
            tasksListView = FindViewById<ListView>(Resource.Id.TaskList);
           
            var taskAdapter = new TaskListAdapter(this, tasks);
            tasksListView.Adapter = taskAdapter;
		    tasksListView.Clickable = true;
            tasksListView.ItemClick += TasksListViewOnItemClick;
		    
		}

	    public override bool OnCreateOptionsMenu(IMenu menu)
	    {
            MenuInflater.Inflate(Resource.Menu.Top_Menus, menu);
	        return base.OnCreateOptionsMenu(menu);
	    }

	    public override bool OnOptionsItemSelected(IMenuItem item)
	    {
	        if (item.ItemId.Equals(Resource.Id.menu_save))
	        {
	            this.GoToNewTaskPage();
	        }
	            
	        return base.OnOptionsItemSelected(item);
	    }

	    private void TasksListViewOnItemClick(object sender, AdapterView.ItemClickEventArgs itemClickEventArgs)
	    {
	        var taskDetailPageIntent = new Intent(this, typeof(TaskDetailPage));
	        StartActivity(taskDetailPageIntent);
	    }

        private async System.Threading.Tasks.Task SetTasks()
        {
            var repository = new TaskRepository(this.GetDbPath(), new SQLitePlatformAndroid());
            this.tasks = await repository.GetAll();
        }

        private void GoToNewTaskPage()
        {
            var taskNewPageIntent = new Intent(this, typeof(NewTaskPage));
            StartActivity(taskNewPageIntent);
        }

        private string GetDbPath()
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            return Path.Combine(documentsPath, "Todo.db3");
        }
    }
}


