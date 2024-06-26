using CsvHelper.Configuration;
using Transaction_Service.Models;

public class TransactionMap : ClassMap<Transactions>
{
    public TransactionMap()
    {
        Map(m => m.ReferenceNumber).Name("Reference Number");
        Map(m => m.Quantity).Name("Quantity");
        Map(m => m.Amount).Name("Amount");
        Map(m => m.Name).Name("Name");
        Map(m => m.TransactionDate).Name("Transaction Date").TypeConverterOption.Format("dd/MM/yyyy HH:mm:ss");
        Map(m => m.Symbol).Name("Symbol");
        Map(m => m.OrderSide).Name("Order Side");
        Map(m => m.OrderStatus).Name("Order Status");
    }
}
