using System;
using Android.Views;
using Android.Widget;
using NativeTest.BusinessLayer;
using System.Collections.Generic;
using Android.App;
using NativeTest.Droid.Listeners;

namespace NativeTest.Droid.Adapters
{
    public class TaskListAdapter : BaseAdapter<Task>
    {
        private IList<Task> taskList;

        private Activity context;

        public TaskListAdapter(Activity context, IList<Task> taskList)
        {
            this.context = context;
            this.taskList = taskList;
        }

        public override Task this[int position]
        {
            get
            {
                return this.taskList[position];
            }
        }


        public override int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this.taskList[position];
            var view = convertView ?? context.LayoutInflater.Inflate(Resource.Layout.TaskItemList, null);
            view.FindViewById<TextView>(Resource.Id.TaskName).Text = item.Name;
            var checkbox = view.FindViewById<CheckBox>(Resource.Id.TaskStatus);
            checkbox.SetOnCheckedChangeListener(null);
            checkbox.SetOnCheckedChangeListener(new CheckedChangeListener(context));

            return view;
        }
    }
}