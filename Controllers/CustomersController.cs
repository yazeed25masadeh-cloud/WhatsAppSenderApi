using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatsAppSenderApi.Models;

namespace WhatsAppSenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // 1. أمر لجلب كل الزبائن من قاعدة البيانات
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _context.Customers.ToListAsync();
            return Ok(customers);
        }

        // 2. أمر لإضافة زبون جديد لقاعدة البيانات
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            
            // نرجع الزبون الجديد مع رقمه (Id) الذي تم إنشاؤه في الداتابيز
            return Ok(customer); 
        }

        // 3. أمر لحذف زبون
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(); // إذا الـ ID مش موجود أصلاً
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent(); // بنرجع رد "لا يوجد محتوى" كدليل على النجاح
        }

        // 4. أمر لتعديل بيانات زبون
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound(); // إذا الزبون مش موجود
            }

            // تحديث البيانات
            customer.Name = updatedCustomer.Name;
            customer.PhoneNumber = updatedCustomer.PhoneNumber;
            
            await _context.SaveChangesAsync();

            return Ok(customer); // نرجع الزبون بعد التحديث
        }
    } // <--- هذا القوس بيسكر الكلاس (CustomersController)
} // <--- هذا القوس بيسكر الـ (namespace)