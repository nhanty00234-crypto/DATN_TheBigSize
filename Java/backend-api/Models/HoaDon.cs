using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class HoaDon
{
    public int HoaDonId { get; set; }

    public int? DatSanId { get; set; }

    public int? AccountIdKhachHang { get; set; }

    public int? AccountIdNhanVien { get; set; }

    public DateTime? NgayLap { get; set; }

    public decimal? TongTienSan { get; set; }

    public decimal? TongTienDichVu { get; set; }

    public decimal? GiamGia { get; set; }

    public decimal? TongThanhToan { get; set; }

    public string? PhuongThucThanhToan { get; set; }

    public string? TrangThaiThanhToan { get; set; }

    public virtual Account? AccountIdKhachHangNavigation { get; set; }

    public virtual Account? AccountIdNhanVienNavigation { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual LichDatSan? DatSan { get; set; }
}
