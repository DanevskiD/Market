using System.Net.Http.Json;

namespace Market
{
    class Program
    {
        public static readonly HttpClient client = new HttpClient();
        public static async Task<IEnumerable<Product>> GetProducts()
        {
            IEnumerable<Product>? products = new List<Product>();
            try
            {
                HttpResponseMessage response = await client.GetAsync("https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1");
                products = await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();
            }
            catch (Exception )
            {
                Console.WriteLine("An error occurred, please contact support.");
            };
            return products;
        }
       public static async Task Main()
        {
            IEnumerable<Product> products = new List<Product>();
            products = await GetProducts();
            products = products.OrderBy(x => x.Name);
            List<Product> domestic = new List<Product>();
            List<Product> imported = new List<Product>();
            foreach (var item in products)
            {
                if (item.Domestic == true)
                {
                    domestic.Add(item);
                }
                else
                {
                    imported.Add(item);
                }
            }

            Console.WriteLine(". Domestic");
            foreach (var item in domestic)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(". Imported");
            foreach (var item in imported)
            {
                Console.WriteLine(item);
            }

            decimal sumDomestic = domestic.Sum(x => x.Price);
            decimal sumImported = imported.Sum(x => x.Price);
            Console.WriteLine("Domestic cost: $" + sumDomestic);
            Console.WriteLine("Imported cost: $" + sumImported);
            Console.WriteLine("Domestic count: " + domestic.Count);
            Console.WriteLine("Imported count: " + imported.Count);

        }
    }
}