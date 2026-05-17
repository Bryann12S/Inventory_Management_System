using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using backend.Models;

namespace backend.DtOs;

public record CreateStockMovementDto(
    [Required]
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    MovementType Type,

    [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
    int Quantity,

    [StringLength(200)]
    string? Reason
);
