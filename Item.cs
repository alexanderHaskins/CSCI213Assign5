namespace ModernSoftwareDevelopmentAssignment5
{
    public class Item
    {
        public Item(int id, int num, decimal price)
        {
            this.id = id;
            ammount = num;
            unitPrice = price;
        }
        
        int id;
        int ammount;
        decimal unitPrice;

        public int getID() { return id; }

        public decimal getPrice()
        {
            return ammount * unitPrice;
        }

        public void addAmount(int num)
        {
            ammount += num;
        }
    }
}
