using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class LoaiSan
{
    public int LoaiSanId { get; set; }

    public string TenLoai { get; set; } = null!;

    public decimal GiaGocTheoGio { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<KhungGioGium> KhungGioGia { get; set; } = new List<KhungGioGium>();

    public virtual ICollection<San> Sans { get; set; } = new List<San>();
}
