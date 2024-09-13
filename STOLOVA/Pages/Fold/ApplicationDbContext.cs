using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Order> Orders { get; set; }
    public DbSet<MenuItem> MenuItems { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderItem>()
            .HasKey(oi => oi.OrderItemId); // Устанавливаем первичный ключ

        // Дополнительные конфигурации
    }
}

public class Order
{
    public int ID { get; set; }
    [Required(ErrorMessage = "Имя клиента обязательно для заполнения.")]
    [RegularExpression(@"^[a-zA-Zа-яА-Я\s]+$", ErrorMessage = "Имя клиента может содержать только буквы и пробелы.")]
    public string CustomerName { get; set; }
    [Required(ErrorMessage = "Сумма обязательна для заполнения.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Введите корректную сумму.")]
    public decimal TotalAmount { get; set; }
   
    public string Status { get; set; }
    [Required(ErrorMessage = "Список блюд обязателен.")]
    [RegularExpression(@"^[a-zA-Zа-яА-Я\s,]+$", ErrorMessage = "Список блюд может содержать только буквы, пробелы и запятые.")]
    public string DishName { get; set; }
    
}

public class MenuItem
{
    public int ID { get; set; }
    [Key]

    public string DishName { get; set; }
    public decimal Price { get; set; }
    
}

public class OrderItem
{
    [Key]
    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    [Key]

    public Order Order { get; set; }
    public int MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }
    public int Quantity { get; set; }
    
}
