namespace TOD
{
    public class Build
    {
        public string TenBanh { get; set; }
        public string TpPhu { get; set; }
        public string Size { get; set; }
        public string DeBanh { get; set; }
        public string VienBanh { get; set; }
        public string ThucUong { get; set; }
        public double TongTien { get; set; }

        public Build (string tenBanh, string tpPhu, string size, string deBanh, string vienBanh, string thucUong, double tongTien)
        {
            TenBanh = tenBanh;
            TpPhu = tpPhu;
            Size = size;
            DeBanh = deBanh;
            VienBanh = vienBanh;
            ThucUong = thucUong;
            TongTien = tongTien;
        }
    }
}
