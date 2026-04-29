using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string? FullName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public int? RoleId { get; set; }

    public string? ZaloId { get; set; }

    public string? MessengerId { get; set; }

    public int? DiemUyTin { get; set; }

    public int? DiemTrinhDo { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<ChiTietGhepKeo> ChiTietGhepKeos { get; set; } = new List<ChiTietGhepKeo>();

    public virtual ICollection<DanhGium> DanhGiumAccountIdNguoiBiDanhGiaNavigations { get; set; } = new List<DanhGium>();

    public virtual ICollection<DanhGium> DanhGiumAccountIdNguoiDanhGiaNavigations { get; set; } = new List<DanhGium>();

    public virtual ICollection<GhepKeo> GhepKeos { get; set; } = new List<GhepKeo>();

    public virtual ICollection<HoaDon> HoaDonAccountIdKhachHangNavigations { get; set; } = new List<HoaDon>();

    public virtual ICollection<HoaDon> HoaDonAccountIdNhanVienNavigations { get; set; } = new List<HoaDon>();

    public virtual ICollection<LichDatSan> LichDatSans { get; set; } = new List<LichDatSan>();

    public virtual ICollection<LichXeRaVao> LichXeRaVaos { get; set; } = new List<LichXeRaVao>();

    public virtual Role? Role { get; set; }
}
