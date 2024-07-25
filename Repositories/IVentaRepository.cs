
namespace Caso.Repositories
{
  public interface IVentaRepository
  {
    Task<IEnumerable<VentaModel>> GetAllVentas();
    Task<VentaModel> GetVentaById(int id);
    Task CreateVenta(VentaDTO venta);
    Task UpdateVenta(int id, VentaDTO venta);
    Task DeleteVenta(int id);
  }
}