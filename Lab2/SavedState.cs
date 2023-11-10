using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Android.Views.View;

namespace Lab2
{
    public class SavedState : BaseSavedState
    {
        public int ViewsCount { get; set; }

        public SavedState(Parcel State) : base(State)
        {
            ViewsCount = State.ReadInt();
        }

        public override void WriteToParcel(Parcel dest, [GeneratedEnum] ParcelableWriteFlags flags)
        {
            base.WriteToParcel(dest, flags); 
            dest.WriteInt(ViewsCount);
        }
    }
}