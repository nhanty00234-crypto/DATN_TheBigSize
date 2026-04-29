using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class GhepKeo
{
    public int KeoId { get; set; }

    public int? DatSanId { get; set; }

    public int? AccountIdNguoiTao { get; set; }

    public string? MoTa { get; set; }

    public string? TrinhDo { get; set; }

    public int? SoNguoiThieu { get; set; }

    public string? TrangThai { get; set; }

    public virtual Account? AccountIdNguoiTaoNavigation { get; set; }

    public virtual ICollection<ChiTietGhepKeo> ChiTietGhepKeos { get; set; } = new List<ChiTietGhepKeo>();

    public virtual LichDatSan? DatSan { get; set; }
}
