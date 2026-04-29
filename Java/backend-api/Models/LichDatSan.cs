using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class LichDatSan
{
    public int DatSanId { get; set; }

    public int? AccountId { get; set; }

    public int? SanId { get; set; }

    public DateOnly NgayDat { get; set; }

    public TimeOnly GioBatDau { get; set; }

    public TimeOnly GioKetThuc { get; set; }

    public double? HeSoGia { get; set; }

    public decimal? TongTienDuKien { get; set; }

    public string? TrangThai { get; set; }

    public string? GhiChu { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<DanhGium> DanhGia { get; set; } = new List<DanhGium>();

    public virtual ICollection<GhepKeo> GhepKeos { get; set; } = new List<GhepKeo>();

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual San? San { get; set; }
}
