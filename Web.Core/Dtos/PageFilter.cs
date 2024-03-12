using System.ComponentModel.DataAnnotations;

namespace Web.Core.Dtos;

public sealed record PageFilter([Range(1, double.MaxValue)] int Page, [Range(1, double.MaxValue)] int Size);