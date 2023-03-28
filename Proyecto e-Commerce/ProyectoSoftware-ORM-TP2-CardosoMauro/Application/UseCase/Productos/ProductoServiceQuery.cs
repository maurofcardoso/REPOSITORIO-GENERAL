using Application.Interfaces.IProducto;
using Domain.Entities;

namespace Application.UseCase.Productos
{
    public class ProductoServiceQuery : IProductoServiceQuery
    {
        private readonly IProductoQuery _query;

        public ProductoServiceQuery(IProductoQuery query)
        {
            _query = query;
        }

        public async Task<Producto> GetProductoById(int productoId)
        {
            if (productoId < 1)
            {
                return null;
            }
            Producto producto = await _query.GetProducto(productoId);
            return producto;
        }

        public async Task<List<Producto>> GetProductos()
        {
            var productos = await _query.GetListProductos();
            return productos;
        }

        public async Task<List<Producto>> GetProductoByName(string? name, bool? sort)
        {
            List<Producto> productos = await _query.GetListProductos();
            List<Producto> seleccionados = new List<Producto>();
            if(productos.Count == 0)
            {
                return null;
            }
            if (sort == null)
            {
                sort = true;
            }
            if ((bool) sort && name != null)
            {
                var productosByName = from producto in productos
                                      where producto.Nombre.ToLower().Contains(name.ToLower())
                                      orderby producto.Precio ascending
                                      select producto;
                foreach (Producto producto in productosByName)
                {
                    seleccionados.Add(producto);
                }
                if (seleccionados.Count == 0)
                {
                    return null;
                }
                return seleccionados;
            }
            else if (!(bool)sort && name != null)
            {
                var productosByName = from producto in productos
                                      where producto.Nombre.ToLower().Contains(name.ToLower())
                                      orderby producto.Precio descending
                                      select producto;
                foreach (Producto producto in productosByName)
                {
                    seleccionados.Add(producto);
                }
                if (seleccionados.Count == 0)
                {
                    return null;
                }
                return seleccionados;
            }
            else if (!(bool)sort && name == null)
            {
                var productosByName = from producto in productos
                                      orderby producto.Precio descending
                                      select producto;
                foreach (Producto producto in productosByName)
                {
                    seleccionados.Add(producto);
                }
                if (seleccionados.Count == 0)
                {
                    return null;
                }
                return seleccionados;
            }
            else if ((bool)sort && name == null)
            {
                var productosByName = from producto in productos
                                      orderby producto.Precio ascending
                                      select producto;
                foreach (Producto producto in productosByName)
                {
                    seleccionados.Add(producto);
                }
                if (seleccionados.Count == 0)
                {
                    return null;
                }
                return seleccionados;
            }
            return null;
        }
    }
}
