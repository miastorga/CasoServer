using System.Data;
using Dapper;

namespace Caso.Repositories
{
  public class VentaRepository : IVentaRepository
  {
    private readonly DapperContext _context;

    public VentaRepository(DapperContext context)
    {
      _context = context;
    }

    public async Task CreateVenta(VentaDTO venta)
    {
      var query = "INSERT INTO VENTAS (id, Compania, Producto, Fecha, Cantidad, Precio) Values (@id, @Compania, @Producto, @Fecha, @Cantidad, @Precio)";

      var parameters = new DynamicParameters();

      Random random = new();
      int id = random.Next(1, 10000);

      parameters.Add("id", id, DbType.Int32);
      parameters.Add("Compania", venta.Compania, DbType.String);
      parameters.Add("Producto", venta.Producto, DbType.String);
      parameters.Add("Fecha", DateTime.Now.ToString("yyyy-MM-dd"), DbType.String);
      parameters.Add("Cantidad", venta.Cantidad, DbType.Int32);
      parameters.Add("Precio", venta.Precio, DbType.Int32);

      using (var connection = _context.CreateConnection())
      {
        await connection.ExecuteAsync(query, parameters);
      }
    }

    public async Task DeleteVenta(int id)
    {
      var query = "DELETE FROM VENTAS WHERE id = @id";

      using (var connection = _context.CreateConnection())
      {
        await connection.ExecuteAsync(query, new { id });
      }
    }

    public async Task<IEnumerable<VentaModel>> GetAllVentas()
    {
      var query = "SELECT * FROM VENTAS";
      using (var connection = _context.CreateConnection())
      {
        var ventas = await connection.QueryAsync<VentaModel>(query);
        return ventas.ToList();
      }
    }

    public async Task<VentaModel> GetVentaById(int id)
    {
      var query = "SELECT * FROM VENTAS WHERE id = @id";
      using (var connection = _context.CreateConnection())
      {
        return await connection.QuerySingleOrDefaultAsync<VentaModel>(query, new { id });
      }
    }

    public async Task UpdateVenta(int id, VentaDTO venta)
    {
      var query = "UPDATE VENTAS SET Compania = @Compania, Producto = @Producto, Cantidad = @Cantidad, Precio = @Precio WHERE id = @id";

      var parameters = new DynamicParameters();
      parameters.Add("id", id, DbType.String);
      parameters.Add("Compania", venta.Compania, DbType.String);
      parameters.Add("Producto", venta.Producto, DbType.String);
      parameters.Add("Cantidad", venta.Cantidad, DbType.Int32);
      parameters.Add("Precio", venta.Precio, DbType.Int32);

      using (var connection = _context.CreateConnection())
      {
        await connection.ExecuteAsync(query, parameters);
      }
    }
  }
}