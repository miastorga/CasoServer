namespace Caso.Controllers
{
  using Caso.Repositories;
  using Microsoft.AspNetCore.Mvc;

  [Route("api/ventas")]
  [ApiController]
  public class VentaController : ControllerBase
  {
    private readonly IVentaRepository _ventaRepo;

    public VentaController(IVentaRepository ventaRepository)
    {
      _ventaRepo = ventaRepository;
    }

    /// <summary>
    /// Devuelve todas las ventas
    /// </summary>
    /// <returns>Una lista de ventas</returns>
    [HttpGet]
    public async Task<IActionResult> GetVentas()
    {
      try
      {
        var ventas = await _ventaRepo.GetAllVentas();

        return Ok(ventas);
      }
      catch (Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    /// <summary>
    /// Obtiene una venta por su id.
    /// </summary>
    /// <param name="id">ID de la venta.</param>
    /// <returns>Una venta</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVentabyId(int id)
    {
      try
      {
        var venta = await _ventaRepo.GetVentaById(id);

        if (venta == null)
        {
          return NotFound();
        }

        return Ok(venta);
      }
      catch (Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    /// <summary>
    /// Crea una nueva venta.
    /// </summary>
    /// <param name="venta">Datos de la nueva venta.</param>
    /// <returns>Estado de la creación</returns>
    [HttpPost]
    public async Task<IActionResult> CreateVenta([FromBody] VentaDTO venta)
    {
      try
      {
        await _ventaRepo.CreateVenta(venta);

        return Ok();
      }
      catch (Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    /// <summary>
    /// Actualiza una venta existente.
    /// </summary>
    /// <param name="id">Id de la venta a actualizar</param>
    /// <param name="venta">Datos actualizados de la venta</param>
    /// <returns>Estado de la actualización.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenta(int id, [FromBody] VentaDTO venta)
    {
      try
      {
        var getVenta = await _ventaRepo.GetVentaById(id);

        if (getVenta is null)
        {
          return NotFound();
        }

        await _ventaRepo.UpdateVenta(id, venta);

        return NoContent();
      }
      catch (Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }

    /// <summary>
    /// Elimina una venta.
    /// </summary>
    /// <param name="id">Id de la venta a eliminar</param>
    /// <returns>Estado de la eliminación</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenta(int id)
    {
      try
      {
        var getVenta = await _ventaRepo.GetVentaById(id);

        if (getVenta is null)
        {
          return NotFound();
        }

        await _ventaRepo.DeleteVenta(id);

        return NoContent();
      }
      catch (Exception)
      {
        return StatusCode(500, "Internal server error");
      }
    }
  }
}