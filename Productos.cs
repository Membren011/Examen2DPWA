namespace Examen2DPWA
{
    public record Productos
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public int Cantidad { get; set; }

        public decimal Precio { get; set; }
    }

    public class ProductsData
    {
        private static List<Productos> _productos = new List<Productos>()
        {
            new Productos { Id = 1, Nombre ="Coca Cola", Cantidad = 4, Precio = 3.25m},
            new Productos { Id = 2, Nombre ="Sopa Maruchan", Cantidad = 10, Precio = 0.75m},
            new Productos { Id = 3, Nombre ="Jugo del Valle", Cantidad = 20, Precio = 2.50m},
            new Productos { Id = 4, Nombre ="Papel Higienico", Cantidad = 35, Precio = 0.50m}
        };

        public static List<Productos> GetProducts()
        {
            return _productos;
        }

        public static Productos? GetProductsId(int id)
        {
            return _productos.SingleOrDefault(x =>  x.Id == id);
        }

        public static Productos CreateProducts(Productos productos)
        {
            _productos.Add(productos);
            return productos;
        }

        public static Productos UpdateProducts(Productos update)
        {
            _productos = _productos.Select(products =>
            {
                if(products.Id == update.Id)
                {
                    products.Nombre = update.Nombre;
                    products.Cantidad = update.Cantidad;
                    products.Precio = update.Precio;
                }

                return products;
            }).ToList();

            return update;
        }

        public static void DeleteProducts(int id)
        {
            _productos = _productos.FindAll(x => x.Id != id).ToList();
        }

    }
}
