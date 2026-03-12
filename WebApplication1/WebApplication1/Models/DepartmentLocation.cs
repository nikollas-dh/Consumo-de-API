using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class DepartmentLocation
{
    public long Id { get; set; }

    public long DepartmentId { get; set; }

    public long LocationId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual ICollection<AssetTransferLog> AssetTransferLogFromDepartmentLocations { get; set; } = new List<AssetTransferLog>();

    public virtual ICollection<AssetTransferLog> AssetTransferLogToDepartmentLocations { get; set; } = new List<AssetTransferLog>();

    public virtual ICollection<Asset> Assets { get; set; } = new List<Asset>();

    public virtual Department Department { get; set; } = null!;

    public virtual Location Location { get; set; } = null!;
}
