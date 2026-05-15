using System.ComponentModel.DataAnnotations;

namespace backend.DTOs;

//DTO POST PRODUCT

public record CreateProductDto(
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    string Name,
    
    [Required(ErrorMessage = "La SKU es obligatorio.")]
    [StringLength(50)]
    String SKU,

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [StringLength(50)]
    String Category,

    [Range(0, int.MaxValue, ErrorMessage ="El Stock no puede ser negativo.")]
    int QuantityStock,

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    decimal UnitPrice
);

//DTO update products

public record UpdateProductDto(
    [Required]
    int Id,

    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [StringLength(100)]
    string Name,
    
    [Required(ErrorMessage = "La SKU es obligatorio.")]
    [StringLength(50)]
    String SKU,

    [Required(ErrorMessage = "La categoría es obligatoria.")]
    [StringLength(50)]
    String Category,

    [Range(0, int.MaxValue, ErrorMessage ="El Stock no puede ser negativo.")]
    int QuantityStock,

    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    decimal UnitPrice
);

