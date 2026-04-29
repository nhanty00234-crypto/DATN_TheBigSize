using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class ChiTietGhepKeo
{
    public int ChiTietKeoId { get; set; }

    public int? KeoId { get; set; }

    public int? AccountIdNguoiThamGia { get; set; }

    public string? TrangThaiThamGia { get; set; }

    public virtual Account? AccountIdNguoiThamGiaNavigation { get; set; }

    public virtual GhepKeo? Keo { get; set; }
}
