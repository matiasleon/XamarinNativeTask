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
using Java.Lang;
using NativeTest.BusinessLayer;

namespace NativeTest.Droid.Adapters
{
    public class SearchTasksAdapter : ArrayAdapter<Task>, IFilterable
    {
        private readonly IList<Task> taskList;

        private readonly int textViewResourceId;

        private readonly Context context;

        public SearchTasksAdapter(Context context, int textViewResourceId, IList<Task> objects) : base(context, textViewResourceId, objects)
        {
            this.taskList = objects;
            this.textViewResourceId = textViewResourceId;
            this.context = context;
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
            var layoutService = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            var view = convertView ?? layoutService.Inflate(Resource.Id.SuggestedTaskName, null);
            view.FindViewById<TextView>(Resource.Id.SuggestedTaskName).Text = item.Name;

            return view;
        }
    }
}