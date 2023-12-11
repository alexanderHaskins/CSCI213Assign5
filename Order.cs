using NuGet.Protocol.Plugins;

namespace ModernSoftwareDevelopmentAssignment5
{
    public class Order
    {
        public Order() { }

        List<Item> itemList;

        public void addItem(int id, int num)
        {
            //Attach price to database
            decimal price = 0;
            bool added = false;
            if(itemList.Count > 0)
            {
                foreach(Item i in itemList) {
                    if (i.getID() == id)
                    {
                        i.addAmount(num);
                        added = true;
                    }
                }
            }
            if(added)
            {
                Item temp = new Item(id, num, price);
                itemList.Add(temp);
            }
            
        }

        public void deleteItem(int id)
        {
            if(itemList.Count > 0)
            {
                foreach (Item i in itemList)
                {
                    if (i.getID() == id)
                    {
                        itemList.Remove(i);
                    }
                }
            }
        }

        public decimal getTotalPrice()
        {
            if(itemList.Count > 0)
            {
                decimal total = 0;
                foreach (Item i in itemList)
                {
                    total += i.getPrice();
                }
                return total;
            }
            return 0;
        }
    }
}
