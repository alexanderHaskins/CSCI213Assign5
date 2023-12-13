using NuGet.Protocol.Plugins;

namespace ModernSoftwareDevelopmentAssignment5
{
    public class Order
    {
        public Order() { }

        List<Item> itemList = new List<Item>();

        public void addItem(int id, int num, decimal price)
        {

            bool added = false;
            if (itemList.Count > 0)
            {
                foreach (Item i in itemList)
                {
                    if (i.getID() == id)
                    {
                        i.addAmount(num);
                        added = true;
                    }
                }
            }
            if (added == false)
            {
                Item temp = new Item(id, num, price);
                itemList.Add(temp);
            }

        }

        public void deleteItem(int id)
        {
            if (itemList.Count > 0)
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

        public void deleteAll()
        {
            foreach (Item i in itemList)
            {
                itemList.Remove(i);
            }
        }

        public decimal getTotalPrice()
        {
            if (itemList.Count > 0)
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
