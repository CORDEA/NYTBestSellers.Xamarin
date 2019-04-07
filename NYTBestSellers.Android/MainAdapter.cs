using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;

namespace NYTBestSellers.Android
{
    public class MainAdapter : RecyclerView.Adapter
    {
        private readonly Context _context;
        private IList<MainListItemModel> _models;

        public MainAdapter(Context context)
        {
            _context = context;
        }

        public void Update(IList<MainListItemModel> models)
        {
            _models = models;
            NotifyDataSetChanged();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var item = _models[position];
            var viewHolder = holder as ViewHolder;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new ViewHolder(LayoutInflater.From(_context)
                .Inflate(Resource.Layout.list_item_main, parent, false));
        }

        public override int ItemCount => _models.Count;

        class ViewHolder : RecyclerView.ViewHolder
        {
            public ViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
            {
            }

            public ViewHolder(View itemView) : base(itemView)
            {
            }
        }
    }
}