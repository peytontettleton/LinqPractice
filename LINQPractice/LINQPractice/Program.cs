using System;
using System.Linq;

// https://docs.microsoft.com/en-us/dotnet/csharp/linq/return-a-query-from-a-method
// https://docs.microsoft.com/en-us/dotnet/csharp/linq/index
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/basic-linq-query-operations
// https://www.aspsnippets.com/Articles/SELECT-multiple-columns-from-DataTable-using-LINQ-in-C-and-VBNet.aspx
// https://social.msdn.microsoft.com/Forums/en-US/874f1cbe-7549-4fae-9769-3fc1656c18c4/how-can-i-grab-two-columns-from-a-table-in-linq?forum=linqtosql

namespace LINQPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Product[] products =
            {
                new Product(1252, ProductCategory.Computers, "Logitech M510 Wireless Computer Mouse", 18.49, 25),
                new Product(1343, ProductCategory.Computers, "Redragon K552 KUMARA LED Backlit Mechanical Gaming Keyboard", 29.99, 9),
                new Product(1542, ProductCategory.Computers, "Corsair Vengeance LPX 16GB (2x8GB) DDR4 DRAM 3000MHz", 139.99, 42),
                new Product(1721, ProductCategory.Computers, "USB 3.0 A to A Cable Type A Male to Male, 3 feet", 7.29, 112),
                new Product(2231, ProductCategory.Computers, "USB C to USB A", 10.99, 84),
                new Product(2405, ProductCategory.Computers, "EVGA GeForce GTX 1050 Ti Gaming Video Card, 4GB GDDR5", 169.99, 25),
                new Product(2502, ProductCategory.Computers, "ASUS ROG Strix Z370-E Motherboard LGA1151 ", 209.99, 8),
                new Product(3152, ProductCategory.Electronics, "Tascam DR05 Stereo Portable Digital Recorder", 92.99, 14),
                new Product(3178, ProductCategory.Electronics, "Toshiba 43LF621U19 43-inch 4K Ultra HD Smart LED TV HDR", 319.99, 23),
                new Product(3556, ProductCategory.Electronics, "Crown XLS1502 Two-channel, 525W at 4Ω Power Amplifier", 399.00, 17),
                new Product(4339, ProductCategory.Kitchen, "KitchenAid KSM150PSER Artisan Tilt-Head Stand Mixer", 278.63, 36),
                new Product(4411, ProductCategory.Kitchen, "Hamilton Beach 62682RZ Hand Mixer", 14.99, 67),
                new Product(4523, ProductCategory.Kitchen, "Tovolo Flex-Core All Silicone Spatula", 10.49, 98),
                new Product(5134, ProductCategory.Kitchen, "Circulon Symmetry Hard Anodized Nonstick Skillet", 49.95, 62),
                new Product(5216, ProductCategory.Pet, "Neater Feeder Express Pet Bowls", 22.99, 6),
                new Product(5678, ProductCategory.Pet, "Magic Roller Ball Dog Toy", 10.80, 9),
                new Product(6123, ProductCategory.Pet, "Pillow Pets Signature Cozy Cow Plush Toy", 19.99, 17),
                new Product(6732, ProductCategory.Pet, "Evriholder FURemover Broom with Squeegee ", 15.99, 21),
                new Product(7128, ProductCategory.Pet, "Fabreze Pet Oder Eliminator", 4.94, 33),
                new Product(7231, ProductCategory.Pet, "Professional Pet Slicker Rug Brush for Dogs", 7.59, 17)
            };

            /*-------------------------------------------------------*/
            /*  Practice Item ID: 1                                  */
            /*  Get a list of the products that have prices in range */
            /*  between $10.00 and $20.00 (inclusive of endpoints).  */
            /*-------------------------------------------------------*/
            Console.WriteLine("List of products with prices in range $10 to $20:");

            // The following is a non-functional LINQ statement.
            var productsWithPricesInRange10To20 = from product in products where product.Price >= 10.00 & product.Price <= 20.00 select product;
            // The following is a functional LINQ statement.
            var productsWithPricesInRange10To20Functional = products.Where(product => (product.Price >= 10.00 & product.Price <= 20.00));

            

            Console.WriteLine("Non-functional:");
            foreach (var product in productsWithPricesInRange10To20) {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var product in productsWithPricesInRange10To20Functional)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("----------------------------------------------------");

            //Ascending Prices
            Console.WriteLine("List of products with prices in range $10 to $20 ordered by price ascending:");
            var productsWithPricesInRange10To20OrderedByPriceAsc = from product in products where product.Price >= 10.00 & product.Price <= 20.00 select product;
            var productsWithPricesInRange10To20OrderedByPriceAscFunctional = products.Where(product => (product.Price >= 10.00 & product.Price <= 20.00)).OrderBy(product => product.Price);

            Console.WriteLine("Non-Functional:");
            foreach (var product in productsWithPricesInRange10To20OrderedByPriceAsc)
            {
                Console.WriteLine(product.ToString());
            
            }

            Console.WriteLine("Functional:");
            foreach (var product in productsWithPricesInRange10To20OrderedByPriceAscFunctional)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("----------------------------------------------------");

            //Alphabetically Ascending
            Console.WriteLine("List of titles for products with prices in range $10 to $20 ordered by title alphabetically ascending:");
            var TitlesForProductsWithPricesInRange10to20OrderedByTitleAsc = from product in products where product.Price >= 10.00 & product.Price <= 20.00 orderby product.Title select product.Title;
            var TitlesForProductsWithPricesInRange10to20OrderedbyTitleAscFunctional = products.Where(product => (product.Price >= 10.00 & product.Price <= 20.00)).OrderBy(product => product.Title).Select(product => product.Title);

            Console.WriteLine("Non-Functional:");
            foreach (var product in TitlesForProductsWithPricesInRange10to20OrderedByTitleAsc)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional:");
            foreach(var product in TitlesForProductsWithPricesInRange10to20OrderedbyTitleAscFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //Item ID Descending
            Console.WriteLine("List of Item ID's for prodcts with prices in range from $10 to $20 ordered by ID Descending");
            var IDForProductsWithPricesInRange10to20OrderedByIDDesc = from product in products where product.Price >= 10.00 & product.Price <= 20.00 orderby product.ID descending select product.ID;
            var IDForProductsWithPricesInRange10to20OrderedbyIDDescFunctional = products.Where(product => (product.Price >= 10.00 & product.Price <= 20.00)).OrderByDescending(product => product.ID).Select(product => product.ID);

            Console.WriteLine("Non-Functional:");
            foreach(var product in IDForProductsWithPricesInRange10to20OrderedByIDDesc)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional:");
            foreach(var product in IDForProductsWithPricesInRange10to20OrderedbyIDDescFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //Kitchen Products
            Console.WriteLine("Kitchen Products:");
            var KitchenProductsOrderedByCategory = from product in products where product.Category == ProductCategory.Kitchen select product;
            var KitchenProductsOrderedByCategoryFunctional = products.Where(product => (product.Category == ProductCategory.Kitchen));

            Console.WriteLine("Non-Functional");
            foreach(var product in KitchenProductsOrderedByCategory)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach(var product in KitchenProductsOrderedByCategoryFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //Descending Kitchen Products
            Console.WriteLine("Kitchen Products Ordered by Quanitiy in Stock Descending:");
            var KitchenProductsOrderedByStockQuantity = from product in products where product.Category == ProductCategory.Kitchen orderby product.StockedQuantity descending select product;
            var KitchenProductsOrderedByStockQuantityFunctional = products.Where(product => (product.Category == ProductCategory.Kitchen)).OrderByDescending(product => product.StockedQuantity);

            Console.WriteLine("Non-Functional");
            foreach (var product in KitchenProductsOrderedByStockQuantity)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in KitchenProductsOrderedByStockQuantityFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");
            
            //Computer Products Costing More than $100
            Console.WriteLine("Computer Products Costing More than $100:");
            var ComputerProducsCostingMoreThan100 = from product in products where product.Category == ProductCategory.Computers & product.Price > 100.00 select product;
            var ComputerProducsCostingMoreThan100Functional = products.Where(product => (product.Category == ProductCategory.Computers) & (product.Price > 100.00));

            Console.WriteLine("Non-Functional");
            foreach (var product in ComputerProducsCostingMoreThan100)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in ComputerProducsCostingMoreThan100Functional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //Specific ID 3152
            Console.WriteLine("Item ID 3152:");
            var productTitleWithID3152 = from product in products where product.ID == 3152 select product.Title;
            var productTitleWithID3152Functional = products.Where(product => product.ID == 3152).Select(product => product.Title);

            Console.WriteLine("Non-Functional");
            foreach (var product in productTitleWithID3152)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in productTitleWithID3152Functional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //List of products with titles longer than 50 characters:
            Console.WriteLine("List of products with titles longer than 50 characters:");
            var ProductTitleLongerThan50 = from product in products where product.Title.Length > 50 select product;
            var ProductTitleLongerThan50Functional = products.Where(product => product.Title.Length > 50);

            Console.WriteLine("Non-Functional");
            foreach (var product in ProductTitleLongerThan50)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in ProductTitleLongerThan50Functional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //List of Pet products ordered by price from lowest to highest:
            Console.WriteLine("List of Pet products ordered by price from lowest to highest:");
            var petProductsLowestToHighestPrice = from product in products where product.Category == ProductCategory.Pet orderby product.Price ascending select product;
            var petProductsLowestToHighestPriceFunctional = products.Where(product => product.Category == ProductCategory.Pet).OrderBy(product => product.Price);

            Console.WriteLine("Non-Functional");
            foreach (var product in petProductsLowestToHighestPrice)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in petProductsLowestToHighestPriceFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //List of products with IDs in range 2000 to 2999 ordered by ID:
            Console.WriteLine("List of products with IDs in range 2000 to 2999 ordered by ID:");
            var productsInIDRange2000To2999OrderedByID = from product in products where product.ID >= 2000 & product.ID <= 2999 select product;
            var productsInIDRange2000To2999OrderedByIDFunctional = products.Where(product => (product.ID >= 2000 & product.ID <= 2999));

            Console.WriteLine("Non-Functional");
            foreach (var product in productsInIDRange2000To2999OrderedByID)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in productsInIDRange2000To2999OrderedByIDFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            //List of titles for products with IDs in range 2000 to 2999 ordered by title length:
            Console.WriteLine("List of titles for products with IDs in range 2000 to 2999 ordered by title length:");
            var titlesForProductsInIDRange2000To2999OrderedByTitleLength = from product in products where product.ID >= 2000 & product.ID <= 2999 orderby product.Title.Length ascending select product.Title;
            var titlesForProductsInIDRange2000To2999OrderedByTitleLengthFunctional = products.Where(product => (product.ID >= 2000 & product.ID <= 2999)).OrderBy(product => product.Title.Length).Select(product => product.Title);

            Console.WriteLine("Non-Functional");
            foreach(var product in titlesForProductsInIDRange2000To2999OrderedByTitleLength)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach(var product in titlesForProductsInIDRange2000To2999OrderedByTitleLengthFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("Titles and stocked quantity for products with less than 20 in stock:");
            var lowStock = from product in products where product.StockedQuantity < 20 select new { Title = product.Title, StockedQuantity = product.StockedQuantity };
            var lowStockFunctional = products.Where(product => product.StockedQuantity < 20).Select(product => new { Title = product.Title, StockedQuantity = product.StockedQuantity });

            Console.WriteLine("Non-Functional");
            foreach (var product in lowStock)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("Functional");
            foreach (var product in lowStockFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");

            Console.WriteLine("Titles and stocked quantity for products with less than 20 in stock ordered by stock ascending:");
            var lowStockOrderedByStockedQuantity = from product in products where product.StockedQuantity < 20 orderby product.StockedQuantity select new { Title = product.Title, StockedQuantity = product.StockedQuantity };
            var lowStockOrderedByStockedQuantityFunctional = products.Where(product => product.StockedQuantity < 20).OrderBy(product => product.StockedQuantity).Select(product => new { Title = product.Title, StockedQuantity = product.StockedQuantity });

            Console.WriteLine("Non-Functional");
            foreach (var product in lowStock)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional");
            foreach (var product in lowStockFunctional)
            {
                Console.WriteLine(product.ToString());
            }
            Console.WriteLine("----------------------------------------------------");


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 2                                  */
            /*  Get a list of the products that have prices in range */
            /*  between $10.00 and $20.00 (inclusive of endpoints)   */
            /*  ordered by lowest to highest price.                  */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of products with prices in range $10 to $20 ordered by price ascending:");

            var productsWithPricesInRange10To20OrderedByPriceAsc = <write a non-functional LINQ statement here>;
            var productsWithPricesInRange10To20OrderedByPriceAscFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var product in productsWithPricesInRange10To20OrderedByPriceAsc)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var product in productsWithPricesInRange10To20OrderedByPriceAscFunctional)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 3                                  */
            /*  Get a list of the product titles for products that   */
            /*  have prices in range between $10.00 and $20.00       */
            /*  (inclusive of endpoints) ordered by lowest to        */
            /*  highest price.                                       */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of titles for products with prices in range $10 to $20 ordered by title alphabetically ascending:");

            var titlesForProductsWithPricesInRange10To20OrderedByTitleAsc = <write a non-functional LINQ statement here>;
            var titlesForProductsWithPricesInRange10To20OrderedByTitleAscFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var title in titlesForProductsWithPricesInRange10To20OrderedByTitleAsc)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("Functional:");
            foreach (var title in titlesForProductsWithPricesInRange10To20OrderedByTitleAscFunctional)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*
            /*-------------------------------------------------------*/
            /*  Practice Item ID: 4                                  */
            /*  Get a list of the products that have prices in range */
            /*  between $10.00 and $20.00 (inclusive of endpoints)   */
            /*  ordered by lowest to highest price.                  */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of IDs for products with prices in range $10 to $20 ordered by ID descending:");

            var idsForProductsWithPricesInRange10To20OrderedByIDDesc = <write a non-functional LINQ statement here>;
            var idsForProductsWithPricesInRange10To20OrderedByIDDescFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var id in idsForProductsWithPricesInRange10To20OrderedByIDDesc)
            {
                Console.WriteLine(id);
            }

            Console.WriteLine("Functional:");
            foreach (var id in idsForProductsWithPricesInRange10To20OrderedByIDDescFunctional)
            {
                Console.WriteLine(id);
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 5                                  */
            /*  Get a list of kitchen products.                      */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nKitchen products:");

            var kitchenProducts = <write a non-functional LINQ statement here>;
            var kitchenProductsFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var kitchenProduct in kitchenProducts)
            {
                Console.WriteLine(kitchenProduct.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var kitchenProduct in kitchenProductsFunctional)
            {
                Console.WriteLine(kitchenProduct.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 6                                  */
            /*  Get a list of kitchen products ordered by quantity   */
            /*  in stock descending.                                 */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nKitchen products ordered by quantity in stock descending:");

            var kitchenProductsOrderedByStockedQuantity = <write a non-functional LINQ statement here>;
            var kitchenProductsOrderedByStockedQuantityFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var kitchenProduct in kitchenProductsOrderedByStockedQuantity)
            {
                Console.WriteLine(kitchenProduct.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var kitchenProduct in kitchenProductsOrderedByStockedQuantityFunctional)
            {
                Console.WriteLine(kitchenProduct.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*
            /*-------------------------------------------------------*/
            /*  Practice Item ID: 7                                  */
            /*  Get a list of computer products that cost more       */
            /*  than $100.                                           */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nComputer products costing more than $100:");

            var computerProductsCostingMoreThan100 = <write a non-functional LINQ statement here>;
            var computerProductsCostingMoreThan100Functional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var computerProduct in computerProductsCostingMoreThan100)
            {
                Console.WriteLine(computerProduct.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var computerProduct in computerProductsCostingMoreThan100Functional)
            {
                Console.WriteLine(computerProduct.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 8                                  */
            /*  Get a list of computer products that cost more       */
            /*  than $100.                                           */
            /*                                                       */
            /*  Note: try to find a way to get one value rather than */
            /*  an array of values as a result.                      */
            /*-------------------------------------------------------*/
            // Ref: https://stackoverflow.com/questions/7809745/linq-code-to-select-one-item
            /*
            Console.WriteLine("\nTitle of product with an ID of 3152:");

            var productTitleWithID3152 = <write a non-functional LINQ statement here>;
            var productTitleWithID3152Functional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            Console.WriteLine(productTitleWithID3152);

            Console.WriteLine("Functional:");
            Console.WriteLine(productTitleWithID3152);

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 9                                  */
            /*  Get a list of products with titles that are longer   */
            /*  than 50 characters.                                  */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of products with titles longer than 50 characters:");

            var productsWithTitlesLongerThan50 = <write a non-functional LINQ statement here>;
            var productsWithTitlesLongerThan50Functional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var product in productsWithTitlesLongerThan50)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var product in productsWithTitlesLongerThan50Functional)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*
            /*-------------------------------------------------------*/
            /*  Practice Item ID: 10                                 */
            /*  Get a list of Pet products ordered by price from     */
            /*  lowest to highest.                                   */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of Pet products ordered by price from lowest to highest:");

            var petProductsLowestToHighestPrice = <write a non-functional LINQ statement here>;
            var petProductsLowestToHighestPriceFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var petProduct in petProductsLowestToHighestPrice)
            {
                Console.WriteLine(petProduct.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var petProduct in petProductsLowestToHighestPriceFunctional)
            {
                Console.WriteLine(petProduct.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 11                                 */
            /*  Get a list of products with product IDs in range of  */
            /*  2000 to 2999 (inclusive of endpoints) ordered by ID. */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of products with IDs in range 2000 to 2999 ordered by ID:");

            var productsInIDRange2000To2999OrderedByID = <write a non-functional LINQ statement here>;
            var productsInIDRange2000To2999OrderedByIDFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var product in productsInIDRange2000To2999OrderedByID)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("Functional:");
            foreach (var product in productsInIDRange2000To2999OrderedByIDFunctional)
            {
                Console.WriteLine(product.ToString());
            }

            Console.WriteLine("----------------------------------------------------");
            */



            /*-------------------------------------------------------*/
            /*  Practice Item ID: 12                                 */
            /*  Get a list of titles for products with IDs in range  */
            /*  of 2000 to 2999 (inclusive of endpoints) ordered by  */
            /*  title length.                                        */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nList of titles for products with IDs in range 2000 to 2999 ordered by title length:");

            var titlesForProductsInIDRange2000To2999OrderedByTitleLength = <write a non-functional LINQ statement here>;
            var titlesForProductsInIDRange2000To2999OrderedByTitleLengthFunctional = <write a functional LINQ statement here>;;

            Console.WriteLine("Non-functional:");
            foreach (var title in titlesForProductsInIDRange2000To2999OrderedByTitleLength)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("Functional:");
            foreach (var title in titlesForProductsInIDRange2000To2999OrderedByTitleLengthFunctional)
            {
                Console.WriteLine(title);
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 13                                 */
            /*  Get a list of product titles and stocked quantity    */
            /*  for products that have less than 20 in stock.        */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nTitles and stocked quantity for products with less than 20 in stock:");

            var lowStock = <write a non-functional LINQ statement here>;
            var lowStockFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var productInfo in lowStock)
            {
                Console.WriteLine(productInfo);
            }

            Console.WriteLine("Functional:");
            foreach (var productInfo in lowStockFunctional)
            {
                Console.WriteLine(productInfo);
            }

            Console.WriteLine("----------------------------------------------------");
            */


            /*-------------------------------------------------------*/
            /*  Practice Item ID: 14                                 */
            /*  Get a list of product titles and stocked quantity    */
            /*  for products that have less than 20 in stock ordered */
            /*  by stocked quantity ascending.                       */
            /*-------------------------------------------------------*/
            /*
            Console.WriteLine("\nTitles and stocked quantity for products with less than 20 in stock ordered by stock ascending:");

            var lowStockOrderedByStockedQuantity = <write a non-functional LINQ statement here>;
            var lowStockOrderedByStockedQuantityFunctional = <write a functional LINQ statement here>;

            Console.WriteLine("Non-functional:");
            foreach (var productInfo in lowStockOrderedByStockedQuantity)
            {
                Console.WriteLine(productInfo);
            }

            Console.WriteLine("Functional:");
            foreach (var productInfo in lowStockOrderedByStockedQuantityFunctional)
            {
                Console.WriteLine(productInfo);
            }

            Console.WriteLine("----------------------------------------------------");
            */
            // Keep the console window open in debug mode. Push key to exit.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
