using System.ComponentModel.DataAnnotations.Schema;

public class VentaModel
{
  [Column("id")]
  public int Id { get; set; }
  [Column("Compania")]
  public string Compania { get; set; }
  [Column("Producto")]
  public string Producto { get; set; }
  [Column("Fecha")]
  public DateTime Fecha { get; set; }
  [Column("Cantidad")]
  public int Cantidad { get; set; }
  [Column("Precio")]
  public int Precio { get; set; }
}