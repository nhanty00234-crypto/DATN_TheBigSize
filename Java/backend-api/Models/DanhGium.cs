using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class DanhGium
{
    public int DanhGiaId { get; set; }

    public int? DatSanId { get; set; }

    public int? AccountIdNguoiDanhGia { get; set; }

    public int? AccountIdNguoiBiDanhGia { get; set; }

    public int? SoSao { get; set; }

    public string? BinhLuan { get; set; }

    public DateTime? NgayDanhGia { get; set; }

    public virtual Account? AccountIdNguoiBiDanhGiaNavigation { get; set; }

    public virtual Account? AccountIdNguoiDanhGiaNavigation { get; set; }

    public virtual LichDatSan? DatSan { get; set; }
}
