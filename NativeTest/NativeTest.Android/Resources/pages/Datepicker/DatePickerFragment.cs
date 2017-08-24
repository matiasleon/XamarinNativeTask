using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace NativeTest.Droid.Resources.pages.Datepicker
{
    public class DatePickerFragment : DialogFragment, DatePickerDialog.IOnDateSetListener
    {
        public static readonly string TAG = "X:" + typeof(DatePickerFragment).Name.ToUpper();

        Action<DateTime> dateSelectedHandler = delegate { };

        public static DatePickerFragment NewInstance(Action<DateTime> onDateSelected)
        {
            var frag = new DatePickerFragment();
            frag.dateSelectedHandler = onDateSelected;
            return frag;
        }

        public override Dialog OnCreateDialog(Bundle savedInstanceState)
        {
            var today = DateTime.Now;
            var dialog = new DatePickerDialog(Activity, this, today.Year, today.Month, today.Day);

            return dialog;
        }

        public void OnDateSet(DatePicker view, int year, int month, int dayOfMonth)
        {
            // Note: monthOfYear is a value between 0 and 11, not 1 and 12!
            var selectedDate = new DateTime(year, month + 1, dayOfMonth);
            this.dateSelectedHandler(selectedDate);
        }
    }
}