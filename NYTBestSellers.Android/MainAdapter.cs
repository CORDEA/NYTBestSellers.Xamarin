using System;
using System.Collections.Generic;
using Android.Content;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Object = Java.Lang.Object;

namespace NYTBestSellers.Android
{
    public class MainAdapter : RecyclerView.Adapter
    {
        private readonly Context _context;
        private IList<MainListItemModel> _models = new List<MainListItemModel>();

        public event EventHandler<ItemSelectedEventArgs> ItemSelected;

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
            viewHolder.Title.Text = item.Title;
            viewHolder.Description.Text = item.Description;
            viewHolder.AttachSelectedEvent(((sender, args) =>
            {
                ItemSelected?.Invoke(sender, new ItemSelectedEventArgs(position));
            }));
        }

        public override void OnViewRecycled(Object holder)
        {
            base.OnViewRecycled(holder);
            var viewHolder = holder as ViewHolder;
            viewHolder.DetachSelectedEvent();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            return new ViewHolder(LayoutInflater.From(_context)
                .Inflate(Resource.Layout.list_item_main, parent, false));
        }

        public override int ItemCount => _models.Count;

        public class ItemSelectedEventArgs : EventArgs
        {
            private readonly int _position;

            public ItemSelectedEventArgs(int position)
            {
                _position = position;
            }

            public int Position => _position;
        }

        class ViewHolder : RecyclerView.ViewHolder
        {
            private readonly View _root;
            private readonly TextView _title;
            private readonly TextView _description;
            private EventHandler _handler;

            public ViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
            {
            }

            public ViewHolder(View itemView) : base(itemView)
            {
                _root = itemView;
                _title = itemView.FindViewById<TextView>(Resource.Id.title);
                _description = itemView.FindViewById<TextView>(Resource.Id.description);
            }

            public void AttachSelectedEvent(EventHandler handler)
            {
                _handler = handler;
                _root.Click += _handler;
            }

            public void DetachSelectedEvent()
            {
                _root.Click -= _handler;
                _handler = null;
            }

            public TextView Title => _title;

            public TextView Description => _description;
        }
    }
}