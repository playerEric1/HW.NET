namespace ApplicationCore;

public class Shipper
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string EmailId { get; set; }
    public string Phone { get; set; }
    public string ContactPerson { get; set; }
    public List<ShipperRegion> ShipperRegions { get; set; }
}

public class Region
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<ShipperRegion> ShipperRegions { get; set; }
}

public class ShipperRegion
{
    public int RegionId { get; set; }
    public int ShipperId { get; set; }
    public Region Region { get; set; }
    public Shipper Shipper { get; set; }
}