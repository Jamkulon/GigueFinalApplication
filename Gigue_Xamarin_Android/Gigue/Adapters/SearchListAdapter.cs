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
using Gigue.ViewModels;

namespace Gigue.Adapters
{
    class SearchListAdapter : BaseAdapter<vmMusicianResult>
    {

        Activity context;
        List<vmMusicianResult> list;

        public SearchListAdapter(Activity _context, List<vmMusicianResult> _list)
        {
            this.context = _context;
            this.list = _list;
        }

        public override int Count
        {
            get { return list.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override vmMusicianResult this[int index]
        {
            get { return list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            //SearchListAdapterViewHolder holder = null;

            // re-use an existing view, if one is available
            // otherwise create a new one
            if (row == null)
            {
                row = context.LayoutInflater.Inflate(Resource.Layout.ListItemRow, parent, false);
            }
                
            vmMusicianResult item = this[position];
            row.FindViewById<TextView>(Resource.Id.txtFirstName).Text = item.FirstName;
            row.FindViewById<TextView>(Resource.Id.txtLastName).Text = item.LastName;
            row.FindViewById<TextView>(Resource.Id.txtPrimaryInst).Text = item.PrimeInstrument;
            row.FindViewById<TextView>(Resource.Id.txtCity).Text = item.City;
           

            return row;


            //if (view != null)
            //    holder = view.Tag as SearchListAdapterViewHolder;

            //if (holder == null)
            //{
            //    holder = new SearchListAdapterViewHolder();
            //    var inflater = context.GetSystemService(Context.LayoutInflaterService).JavaCast<LayoutInflater>();
            //    //replace with your item and your holder items
            //    //comment back in
            //    //view = inflater.Inflate(Resource.Layout.item, parent, false);
            //    //holder.Title = view.FindViewById<TextView>(Resource.Id.text);
            //    view.Tag = holder;
            //}


            //fill in your items
            //holder.Title.Text = "new text here";

            //return view;
        }

        //Fill in cound here, currently 0
        //public override int Count
        //{
        //    get
        //    {
        //        return 0;
        //    }
        //}

    }

    class SearchListAdapterViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}