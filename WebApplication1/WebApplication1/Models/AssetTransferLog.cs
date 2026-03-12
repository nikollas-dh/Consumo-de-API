using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class AssetTransferLog
{
    public long Id { get; set; }

    public long AssetId { get; set; }

    public DateOnly TransferDate { get; set; }

    public string FromAssetSn { get; set; } = null!;

    public string ToAssetSn { get; set; } = null!;

    public long FromDepartmentLocationId { get; set; }

    public long ToDepartmentLocationId { get; set; }

    public virtual Asset Asset { get; set; } = null!;

    public virtual DepartmentLocation FromDepartmentLocation { get; set; } = null!;

    public virtual DepartmentLocation ToDepartmentLocation { get; set; } = null!;
}
