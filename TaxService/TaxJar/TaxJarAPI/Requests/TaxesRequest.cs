namespace TaxJar.TaxJarAPI.Requests
{
    internal class TaxesRequest
    {
        public string from_country { get; set; }
        public string from_zip { get; set; }
        public string from_state { get; set; }
        public string from_city { get; set; }
        public string from_street { get; set; }
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public string to_city { get; set; }
        public string to_street { get; set; }
        public float amount { get; set; }
        public float shipping { get; set; }
        public Nexus_Addresses[] nexus_addresses { get; set; }
        public Line_Items[] line_items { get; set; }
    }

    internal class Nexus_Addresses
    {
        public string id { get; set; }
        public string country { get; set; }
        public string zip { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string street { get; set; }
    }

    internal class Line_Items
    {
        public string id { get; set; }
        public int quantity { get; set; }
        public string product_tax_code { get; set; }
        public int unit_price { get; set; }
        public int discount { get; set; }
    }
}
