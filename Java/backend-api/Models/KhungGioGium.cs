using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class KhungGioGium
{
    public int KhungGioId { get; set; }

    public int? LoaiSanId { get; set; }

    public TimeOnly GioBatDau { get; set; }

    public TimeOnly GioKetThuc { get; set; }

    public string? NgayTrongTuan { get; set; }

    public decimal GiaApDung { get; set; }

    public virtual LoaiSan? LoaiSan { get; set; }
}
