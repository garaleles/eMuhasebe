using eMuhasebeServer.Domain.Abstractions;

namespace eMuhasebeServer.Domain.Entities;

public sealed class ProductDetail: Entity
{
    public Guid ProductId { get; set; }
    public DateOnly Date { get; set; }
    public string Description { get; set; }=string.Empty;
    public decimal Price { get; set; }
    public decimal Deposit { get; set; }//Ürünün giriş miktarı
    public decimal Withdrawal { get; set; }//Ürünün çıkış miktarı
    public decimal BrutTotal { get; set; }//Ürünün toplam Brüt Tutarı
    public decimal DiscountTotal { get; set; }//Ürünün toplam İndirim Tutarı
    public decimal NetTotal { get; set; }//Ürünün toplam Net Tutarı
    public decimal VatTotal { get; set; }//Ürünün toplam KDV Tutarı
    public decimal GrandTotal { get; set; }//Ürünün toplam KDV + Net Tutarı
    public int VatRate { get; set; }//Ürünün KDV Oranı
    public int DiscountRate { get; set; }//Ürünün İndirim Oranı
    
    
    
}