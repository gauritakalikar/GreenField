using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart
{
    public interface ICartService
    {
        List<Item> GetItems();
        bool AddtoCart(Item item);
        bool RemovefromCart(Item item);
        bool Clear( );
    }
}
