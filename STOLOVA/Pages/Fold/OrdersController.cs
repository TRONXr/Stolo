using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace STOLOVA.Pages.Fold
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerName,TotalAmount,DishName")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // Перенаправляем на страницу индекса (или на другую страницу по вашему выбору)
            }
            return View(order);
        }

        // Для отображения списка заказов, чтобы подтвердить, что данные добавлены
        public async Task<IActionResult> Index()
        {
            return View(await _context.Orders.ToListAsync());
        }
    }
}
