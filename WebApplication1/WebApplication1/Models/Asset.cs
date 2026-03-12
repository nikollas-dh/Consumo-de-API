using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class Asset
{
    public long Id { get; set; }

    public string AssetSn { get; set; } = null!;

    public string AssetName { get; set; } = null!;

    public long DepartmentLocationId { get; set; }

    public long EmployeeId { get; set; }

    public long AssetGroupId { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? WarrantyDate { get; set; }

    public virtual AssetGroup AssetGroup { get; set; } = null!;

    public virtual ICollection<AssetPhoto> AssetPhotos { get; set; } = new List<AssetPhoto>();

    public virtual ICollection<AssetTransferLog> AssetTransferLogs { get; set; } = new List<AssetTransferLog>();

    public virtual DepartmentLocation DepartmentLocation { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
