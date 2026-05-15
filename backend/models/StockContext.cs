using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace backend.Models;

public enum MovementType
{
    Inbound,  //Enter / buy
    Outbound  //Exit / sale
}

public class StockMovement
{
    [Key]
    public int id {get; set;}
    
    [Required]
    public int ProductId {get; set;}

    public Product? Product {get; set;} //connect with movement of product

    [Required]
    public MovementType type {get; set;}

    public int Quantity {get; set;}

    public DateTime TimeStamp {get; set;} = DateTime.UtcNow;
}