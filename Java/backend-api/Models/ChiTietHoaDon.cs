using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class ChiTietHoaDon
{
    public int ChiTietId { get; set; }

    public int? HoaDonId { get; set; }

    public int? DichVuId { get; set; }

    public int SoLuong { get; set; }

    public decimal? DonGiaTaiThoiDiemBan { get; set; }

    public decimal? ThanhTien { get; set; }

    public virtual DichVu? DichVu { get; set; }

    public virtual HoaDon? HoaDon { get; set; }
}
