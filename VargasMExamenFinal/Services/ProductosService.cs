using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VargasMExamenFinal.Models;

namespace VargasMExamenFinal.Services
{
    public class ProductosService
    {
        private readonly SQLite.SQLiteAsyncConnection _connection;

        public ProductosService(string dbPath)
        {
            _connection = new SQLite.SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<Models.Producto>().Wait();
        }

        public Task<List<Producto>> GetProductoAsync()
        {
            return _connection.Table<Producto>().ToListAsync();
        }

        public Task<int> SaveProdcutoAsync(Producto producto)
        {
            if (producto.Id != 0)
            {
                return _connection.UpdateAsync(producto);
            }
            else
            {
                return _connection.InsertAsync(producto);
            }
        }
    }
}
