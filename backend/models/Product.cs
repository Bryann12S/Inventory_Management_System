using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace backend.Models;

public class Product
{
    [Key]
    public int id {get; set;}

     [Required]
    public string name {get; set;} = String.Empty;

    [Required]
    public string SKU {get; set;} = String.Empty;

    [Required]
    public string category {get; set;} = String.Empty;
    public int QuantyInStock {get; set;}
   
    [Column(TypeName = "decimal(18,2)")]
    public decimal UnitPrice {get; set;} 
 
    public DateTime CreatedAt {get; set;} = DateTime.UtcNow;

}