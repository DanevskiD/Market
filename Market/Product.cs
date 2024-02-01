namespace Market
{
    internal class Product
    {
        public string Name { get; }
        public bool Domestic {  get; }
        public decimal Price { get; }
        public decimal? Weight { get; }
        public string Description { get; }
        public Product(string name, bool domestic, decimal price, decimal? weight, string description)
        {
            Name = name;
            Domestic = domestic;
            Price = price; 
            Weight = weight;
            Description = description.Remove(10);
        }

        public override string ToString()
        {
            return "..." + " " + Name +
                "\n" + "    " + "Price: $" + Price +
                "\n" + "    " + Description + "..." +
                "\n" + "    " + "Weight: " + ( Weight==null ? "N/A" : $"{Weight}g" );
        }
    }
}
