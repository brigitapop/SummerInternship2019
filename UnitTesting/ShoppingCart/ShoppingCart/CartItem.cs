using System;

namespace ShoppingCart
{ 
    public class CartItem
    {
        private string _name;
        private int _quantity;
        private double _price;
        private double _subTotal;
        private bool _active;

        public CartItem(string name, int quantity, double price, bool active)
        {
            _name = name;
            _quantity = quantity;
            _price = price;
            _subTotal = Quantity * Price;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public double Price
        {
            get { return _price; }
        }

        public double SubTotal
        {
            get { return _quantity * _price; }

        }

    }
}
