using System.ComponentModel.DataAnnotations;
using backend.Models;

namespace backend.DtOs;

public record CreateStockMovementDto(
    [Required]
    MovementType Type,

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    int Quantity,

    [StringLength(200)]
    string? Reason
);
