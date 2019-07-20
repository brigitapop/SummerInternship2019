using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingCart
{
    public class Cart
    {
        private DateTime _dateCreated;
        private DateTime _lastUpdate;
        private double _total;
        private List<CartItem> _items;
        private ITimeService _timeService;

        public double Total
        {
            get
            {
                if (_items == null)
                    return 0;

                return _items.Sum(x => x.SubTotal);
            }
        }

        public List<CartItem> Items
        {
            get { return _items; }
        }

        public DateTime LastUpdate
        {
            get { return _lastUpdate; }
        }



        public Cart(ITimeService timeService)
        {
            _timeService = timeService;
            if (this._items == null)
            {
                this._items = new List<CartItem>();
                this._dateCreated = timeService.Now();
            }
        }

        public void AddItem(CartItem item)
        {
            if(item.Quantity < 1)
                throw new Exception("Quantity should be at least one!");

            //if (item.Price < 1 && item.Quantity < 2)
            //    throw new Exception("For items that cost less then $1 you should buy 2;");

            _items.Add(item);
            _lastUpdate = _timeService.Now();
        }

        public void DeleteItem(string name)
        {
            _items.Remove(_items.First(i => i.Name == name));
           // _lastUpdate = _timeService.Now();
        }

        public void UpdateItem(CartItem item, int quantity)
        {
            item.Quantity = quantity;
            _lastUpdate = _timeService.Now();
        }

        public void Checkout()
        {
            if (Items.Count < 1)
                throw new Exception("Cart is empty");

            //Checkout 
        }
    }
}
