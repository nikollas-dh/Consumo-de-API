using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class AssetPhoto
{
    public long Id { get; set; }

    public long AssetId { get; set; }

    public byte[] AssetPhoto1 { get; set; } = null!;

    public virtual Asset Asset { get; set; } = null!;
}
