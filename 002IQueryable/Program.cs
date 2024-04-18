using System.Numerics;
using _001GroupBy.Data;

await using var dataContext = new DataContext();


Console.WriteLine("Good look  😊😊😊");


//1
//Получить все заказы клиента с id=1, отгруппированные по сумме заказа
//Get all customer orders with id=1, grouped by order amount

// var res = dataContext.Orders.Where(x => x.CustomerId == 1).Select(x => new
// {
//     orderId = x.Id,
//     total = x.OrderItems.Sum(x => x.Price)
// }).GroupBy(x=>x.total).AsQueryable();
// foreach (var r in res)
// {
//     Console.WriteLine(r.Key);
//     foreach (var re in r)
//     {
//         Console.WriteLine($"{re.orderId} {re.total}");
//     }
// }

//2
//Получите все заказы клиентов с ID = 1, сгруппированные по количеству товаров в заказе:
//Get all customer orders with ID = 1, grouped by the number of goods in the order

// var res3 = dataContext.Orders.Where(x => x.CustomerId == 1).Select(x => new
// {
//     orderId = x.Id,
//     Count = x.OrderItems.Count(x => x.OrderId == x.Id)
// }).GroupBy(x=>x.Count).AsQueryable();
// foreach (var r in res3)
// {
//     Console.WriteLine(r.Key);
//     foreach (var re in r)
//     {
//         Console.WriteLine($"{re.orderId} {re.Count}");
//     }
// }

//3
//Получить все заказы клиента с id=2, отгруппированные по данным
//Get all customer orders with id=2, grouped by data

var res4 = dataContext.Orders.Where(x => x.CustomerId == 2).GroupBy(x => x.CustomerId).Select(x=>new
{
    order = x.ToList(),
    customerId = x.Key
}).AsQueryable();
foreach (var r in res4)
{
    Console.WriteLine($"{r.customerId}");
    foreach (var or in r.order)
    {
        Console.WriteLine(or.Id);
        Console.WriteLine(or.OrderDate.ToShortDateString());
    }
}