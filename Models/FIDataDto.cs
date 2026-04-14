namespace MERSAP.Models;

public class FIDataDto
{
    public string PosCode { get; set; } = string.Empty;   
    public string POS { get; set; } = string.Empty;      
    public DateTime? BillDt { get; set; }                 
    public string GST { get; set; } = string.Empty;      
    public double Amount { get; set; }                    
    public double CGST { get; set; }                    
    public double SGST { get; set; }                    
    public double Total { get; set; }                   
    public string PayMode { get; set; } = string.Empty;  
}