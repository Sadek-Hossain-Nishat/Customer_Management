using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject
{
    class SelectionItemDescription
    {
        private String item, price, quantity, total;
        

        public SelectionItemDescription(String item, String price, String quantity, String total)
        {
            this.item = item;
            this.price = price;
            this.quantity = quantity;
            this.total = total;
            
        }

        public string Item
        {
            get { return item; }
            set { item = value; }
        }

        public string Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Total
        {
            get { return total; }
            set { total = value; }
        }
        
        

    }
}
