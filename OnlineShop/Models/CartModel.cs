namespace OnlineShop.Models
{
    public class CartModel
    {
        private List<Item> _items = new List<Item>();
        public string CartId { get; set; }
        public decimal Total { get; set; }
        public decimal getTotal()
        {
            decimal t = 0;
            foreach (var it in _items)
            {
                t = t + it.lineTotal;
            }
            return t;
        }

        public decimal getTotalMoney()
        {
            decimal t = 0;
            foreach(var it in _items)
            {
                t = t + it.totalMoney;
            }
            return t;
        }
        public int addItem(Item item)
        {
            foreach (var it in _items)
            {
                if (it.Id == item.Id)
                {
                    it.Quantity += item.Quantity;
                    it.lineTotal = it.Quantity * it.Price;
                    it.totalMoney += item.lineTotal;
                    return _items.Count;
                }
            }
            _items.Add(item);

            //total
            Total = 0;
            foreach (var it in _items)
            {
                Total += it.lineTotal;
                Total += it.totalMoney;
            }
            return _items.Count;
        }

        public int removeItem(Item item)
        {
            foreach (var it in _items)
            {
                if (it.Id == item.Id)
                {
                    _items.Remove(item);
                }
            }
            return _items.Count;
        }

        public void UpdateQuantity(string id, int qty, string btnCmd)
        {
            foreach (Item it in _items)
            {
                if (it.Id == id)
                {
                    if (btnCmd == "1")
                    {
                        it.Quantity += qty;
                        it.lineTotal = it.Quantity * it.Price;
                    }
                    else
                    {
                        it.Quantity -= qty;
                        it.lineTotal = it.Quantity * it.Price;
                    }

                }
            }
            Total = 0;
            foreach (var it in _items)
            {
                Total += it.lineTotal;
            }
        }
        public List<Item> getAllItems()
        {
            return _items;
        }
        public void setAllItems(List<Item> items)
        {
            _items = items;
        }
    }
}

