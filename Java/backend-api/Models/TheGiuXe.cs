using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class TheGiuXe
{
    public int TheId { get; set; }

    public string MaSoThe { get; set; } = null!;

    public string? LoaiXe { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<LichXeRaVao> LichXeRaVaos { get; set; } = new List<LichXeRaVao>();
}
