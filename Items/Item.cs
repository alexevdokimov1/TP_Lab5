using System.Text;

namespace Items
{
    public class Item
    {
        public int Articul { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public double Cost { get; set; }
        public string Supplier { get; set; }
        public DateOnly ProductionDate { get; set; }


        public Item(int articul, string name, string color, double cost, string supplier, DateOnly prodDate) { 
            this.Articul = articul;
            this.Name = name;
            this.Color = color;
            this.Cost = cost;
            this.Supplier = supplier;
            this.ProductionDate = prodDate;
        }

        public override string ToString()
        {
            StringBuilder st = new();
            st.Append("Артикул: " + this.Articul + "\n");
            st.Append("Имя: " + this.Name + "\n");
            st.Append("Цвет: " + this.Color + "\n");
            st.Append("Цена: " + this.Cost + "\n");
            st.Append("Поставщик: " + this.Supplier + "\n");
            st.Append("Дата производства: " + this.ProductionDate + "\n");
            return st.ToString();
        }
    }
}
