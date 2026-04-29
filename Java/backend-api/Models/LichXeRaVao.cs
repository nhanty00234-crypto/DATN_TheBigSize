using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class LichXeRaVao
{
    public int LichXeId { get; set; }

    public int? TheId { get; set; }

    public string? BienSoXe { get; set; }

    public DateTime? GioVao { get; set; }

    public DateTime? GioRa { get; set; }

    public decimal? PhiGuiXe { get; set; }

    public int? AccountIdNhanVien { get; set; }

    public virtual Account? AccountIdNhanVienNavigation { get; set; }

    public virtual TheGiuXe? The { get; set; }
}
