using System;

namespace ShoppingCart
{
    public class TimeServiceStub : ITimeService
    {
        public DateTime Now()
        {
            return new DateTime(2019, 7, 22);
        }
    }
}
