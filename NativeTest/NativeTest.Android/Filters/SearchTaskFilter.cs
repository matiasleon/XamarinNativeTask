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
using NativeTest.Droid.Adapters;

namespace NativeTest.Droid.Filters
{
    public class SearchTaskFilter: Filter
    {
        public SearchTasksAdapter adapter;

        public IList<Task> originalData;

        public SearchTaskFilter(IList<Task> originalData)
        {
            this.originalData = originalData;
        }

        protected override FilterResults PerformFiltering(ICharSequence constraint)
        {
            var results = new FilterResults();

            if(constraint == null || constraint.Length() == 0)
            {
                return results;
            }

            var actualResults = new string[this.originalData.Count];
            var filteredTasks = this.originalData.Where(x => x.Name.ToUpper().Contains(constraint.ToString().ToUpper()));
            var names = filteredTasks.Select(x => x.Name).ToArray();

            results.Values = names;
            results.Count = names.Length;

            return results;
        }

        protected override void PublishResults(ICharSequence constraint, FilterResults results)
        {
            if (results.Count == 0)
            {
                adapter.NotifyDataSetInvalidated();
            }
            else
            {
                
                adapter.NotifyDataSetChanged();
            }
        }
    }
}