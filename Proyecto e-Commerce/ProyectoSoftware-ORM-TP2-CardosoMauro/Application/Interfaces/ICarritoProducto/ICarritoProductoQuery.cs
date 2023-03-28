﻿using Domain.Entities;

namespace Application.Interfaces.ICarritoProducto
{
    public interface ICarritoProductoQuery
    {
        Task<List<CarritoProducto>> GetListCarritoProductos();

        Task<CarritoProducto> GetCarritoProductoById(int carritoProductoId);
    }
}
