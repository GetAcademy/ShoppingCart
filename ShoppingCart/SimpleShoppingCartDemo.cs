namespace ShoppingCart
{
    internal class SimpleShoppingCartDemo
    {
        public static void Run()
        {
            var productNames = new[] { "A", "B", "C" };
            var productPrices = new[] { 40, 70, 30 };
            var myShoppingCartProducts = new List<string>();
            var myShoppingCartCounts = new List<int>();
            ShowCart(productNames, productPrices, myShoppingCartProducts, myShoppingCartCounts);
            Buy("A", 1, myShoppingCartProducts, myShoppingCartCounts);
            ShowCart(productNames, productPrices, myShoppingCartProducts, myShoppingCartCounts);
            Buy("B", 3, myShoppingCartProducts, myShoppingCartCounts);
            ShowCart(productNames, productPrices, myShoppingCartProducts, myShoppingCartCounts);
            Buy("A", 4, myShoppingCartProducts, myShoppingCartCounts);
            ShowCart(productNames, productPrices, myShoppingCartProducts, myShoppingCartCounts);
        }

        private static void Buy(string productName, int count, List<string> myShoppingCartProducts, List<int> myShoppingCartCounts)
        {
            if (myShoppingCartProducts.Contains(productName))
            {
                var orderLineIndex = myShoppingCartProducts.IndexOf(productName);
                myShoppingCartCounts[orderLineIndex] += count;
            }
            else
            {
                myShoppingCartProducts.Add(productName);
                myShoppingCartCounts.Add(count);
            }

            Console.WriteLine($"Du kjøpte {count} stk. {productName}");
        }

        private static void ShowCart(string[] productNames, int[] productPrices, List<string> myShoppingCartProducts, List<int> myShoppingCartCounts)
        {
            if (myShoppingCartProducts.Count == 0)
            {
                Console.WriteLine("Handlekurven er tom.");
                return;
            }
            Console.WriteLine("Handlekurv:");
            var totalPrice = 0;
            for (int i = 0; i < myShoppingCartCounts.Count; i++)
            {
                var count = myShoppingCartCounts[i];
                var productName = myShoppingCartProducts[i];
                var price = PriceFromProductName(productNames, productPrices, productName);
                var orderLinePrice = price * count;
                Console.WriteLine($"  {count} stk. {productName} a kr {price} = {orderLinePrice}");
                totalPrice += orderLinePrice;
            }

            Console.WriteLine($"Totalpris: {totalPrice}");
        }

        private static int PriceFromProductName(string[] productNames, int[] productPrices, string productName)
        {
            var productIndex = Array.IndexOf(productNames, productName);
            var price = productPrices[productIndex];
            return price;
        }
    }
}
