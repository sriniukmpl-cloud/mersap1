namespace MERSAP.Models;

public class DataDto
{
    public int SNo { get; set; }
    public  string ItemCode  { get; set; } = string.Empty;
    public  string ItemDescription { get; set; } = string.Empty;
    public  string ShopID { get; set; } = string.Empty;
    public  string ShopDescription { get; set; } = string.Empty;
    public string BillDate { get; init; } = string.Empty;
    //public  DateTime BillDate { get; set; } 
    public  string  BillTime { get; set; } = string.Empty;
    //public  DateTime AuditDateTime { get; set; } = DateTime.MinValue;
    public  string  Ibatch  { get; set; } = string.Empty;
    public decimal Quantity { get; set; }
   
    public decimal TotalSales { get; set; }
  
    public decimal COGS { get; set; }  
    
    public decimal CostPrice { get; set; }
      

}
