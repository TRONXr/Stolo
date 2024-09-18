using Microsoft.AspNetCore.Mvc;

namespace STOLOVA.Pages
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(order);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Заказ успешно добавлен!";
                return RedirectToAction("Index"); // Поменяйте на нужное действие после создания
            }

            return View(order);
        }

    }
}
