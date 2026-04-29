using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class DichVu
{
    public int DichVuId { get; set; }

    public string TenDichVu { get; set; } = null!;

    public decimal DonGia { get; set; }

    public string? DonViTinh { get; set; }

    public int? SoLuongTon { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
}
