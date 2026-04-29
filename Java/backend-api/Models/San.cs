using System;
using System.Collections.Generic;

namespace backend_api.Models;

public partial class San
{
    public int SanId { get; set; }

    public string TenSan { get; set; } = null!;

    public int? LoaiSanId { get; set; }

    public string? TrangThai { get; set; }

    public virtual ICollection<LichDatSan> LichDatSans { get; set; } = new List<LichDatSan>();

    public virtual LoaiSan? LoaiSan { get; set; }
}
