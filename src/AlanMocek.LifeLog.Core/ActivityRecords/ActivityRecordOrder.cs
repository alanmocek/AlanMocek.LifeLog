using AlanMocek.LifeLog.Infrastructure.Types;
using System;

namespace AlanMocek.LifeLog.Core.ActivityRecords
{
    public record ActivityRecordOrder : IComparable
    {
        public int Order { get; init; }


        public ActivityRecordOrder(int order)
        {
            if(order <= 0)
            {
                throw new CoreException("Order can not be less or equal to zero.");
            }

            Order = order;
        }


        public ActivityRecordOrder Smaller()
        {
            return this with { Order = Order - 1 };
        }

        public ActivityRecordOrder Greater()
        {
            return this with { Order = Order + 1 };
        }


        public int CompareTo(object obj)
        {
            if ((obj is ActivityRecordOrder) == false)
                throw new ArgumentException(nameof(obj));

            var otherOrder = obj as ActivityRecordOrder;

            if (this > otherOrder)
                return 1;

            if (this == otherOrder)
                return 0;

            if (this < otherOrder)
                return -1;

            throw new Exception();
        }


        public static bool operator >(ActivityRecordOrder left, ActivityRecordOrder right)
             => left.Order > right.Order;

        public static bool operator <(ActivityRecordOrder left, ActivityRecordOrder right)
             => left.Order < right.Order;

        public static bool operator >=(ActivityRecordOrder left, ActivityRecordOrder right)
             => left.Order >= right.Order;

        public static bool operator <=(ActivityRecordOrder left, ActivityRecordOrder right)
             => left.Order <= right.Order;
    }
}
