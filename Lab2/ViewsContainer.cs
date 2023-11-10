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
    public class ViewsContainer : LinearLayout
    {
        private int viewsCount = 0;

        public ViewsContainer(Context context) : base(context)
        {
        }

        public void IncrementViews()
        {
            TextView textView = new TextView(Context); 
            textView.SetText(viewsCount.ToString(),
                TextView.BufferType.Normal); 
            viewsCount++; 
            AddView(textView);
        }

        protected override IParcelable OnSaveInstanceState()
        {
            SavedState state = (SavedState)base.OnSaveInstanceState(); state.ViewsCount = viewsCount;
            base.OnRestoreInstanceState(state);
            return state;
        }

        protected override void OnRestoreInstanceState(IParcelable state)
        {
            if (!(state is SavedState))
            {
                base.OnRestoreInstanceState(state);
                return;
            }
                
            SavedState s = (SavedState)state;
            base.OnRestoreInstanceState(state);

            for (int i = 0; i < s.ViewsCount; i++) 
                IncrementViews();
        }
    }
}