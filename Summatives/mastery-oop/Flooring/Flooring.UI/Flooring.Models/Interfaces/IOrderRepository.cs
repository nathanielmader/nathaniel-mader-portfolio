using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(DateTime orderDate);
        void AddOrder(Order order);
        Order RetrieveSingleOrder(DateTime orderDate, int orderNumber);
        void RemoveOrder(Order order);
        Order UpdateOrder(Order order);//
    }
}
