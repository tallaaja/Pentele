using System.Collections.Generic;


public class Datum
{
    public double price { get; set; }
    public double item_id { get; set; }
    public string owner_id { get; set; }
}

public class RootObject
{
    public int statusCode { get; set; }
    public List<Datum> data { get; set; }
}

