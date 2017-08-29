﻿using System;
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
using NativeTest.Droid.Filters;

namespace NativeTest.Droid.Adapters
{
    public class SearchTasksAdapter : ArrayAdapter<Task>
    {
        public readonly IList<Task> taskList;

        private readonly int textViewResourceId;

        private readonly Context context;

        public SearchTasksAdapter(Context context, int textViewResourceId, IList<Task> objects) : base(context, textViewResourceId, objects)
        {
            this.taskList = objects;
            this.textViewResourceId = textViewResourceId;
            this.context = context;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = this.taskList[position];
            var layoutService = (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            var view = convertView ?? layoutService.Inflate(textViewResourceId, null);
            view.FindViewById<TextView>(Resource.Id.SuggestedTaskName).Text = item.Name;

            return view;
        }

        public override Filter Filter
        {
            get
            {
                return new SearchTaskFilter(this.taskList)
                {
                    adapter = this
                };
            }
        }
    }
}