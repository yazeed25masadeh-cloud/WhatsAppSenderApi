namespace WhatsAppSenderApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        // اسم الزبون
        public string Name { get; set; } = string.Empty;
        
        // رقم هاتف الزبون
        public string PhoneNumber { get; set; } = string.Empty;
        
        // تاريخ إضافة الزبون للنظام
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsVIP { get; set; }
    }
}