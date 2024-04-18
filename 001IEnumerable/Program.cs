using _001GroupBy.Data;

await using var dataContext = new DataContext();

//1
//Получить все заказы клиента с id=1, отгруппированные по сумме заказа
//Get all customer orders with id=1, grouped by order amount

// var res = dataContext.Orders.Where(x => x.CustomerId == 1)
//     .Select(order => new
//     {
//         Customer = order.Customer,
//         TotalOrder = order.OrderItems.Sum(x => x.Price)
//     }).OrderBy(x => x.TotalOrder).ToList().AsEnumerable();
//
// foreach (var r in res)
// {
//     Console.WriteLine(r.Customer);
//     Console.WriteLine(r.TotalOrder);
// }

//2
//Получите все заказы клиентов с ID = 1, сгруппированные по количеству товаров в заказе:
//Get all customer orders with ID = 1, grouped by the number of goods in the order

// var res2 = dataContext.Orders.Where(x => x.CustomerId == 1)
//     .Select(r => new
//     {
//         orderId = r.Id,
//         Count = r.OrderItems.Count(x => x.OrderId == r.Id)
//     });
// var group = res2.GroupBy(x => x.Count).AsEnumerable();
//
// foreach (var r in group)
// {
//     Console.WriteLine(r.Key);
//     foreach (var res in r)
//     {
//         Console.WriteLine("Order Id: " + res.orderId);
//         Console.WriteLine("Count: " + res.Count);
//     }
// }

//3
//Получить все заказы клиента с id=2, отгруппированные по данным
//Get all customer orders with id=2, grouped by data

var res3 = dataContext.Orders.Where(x => x.CustomerId == 2).GroupBy(x => x.CustomerId).Select(x=>new
{
    order = x.ToList(),
    customerId = x.Key
}).AsEnumerable();
foreach (var r in res3)
{
    Console.WriteLine($"{r.customerId}");
    foreach (var or in r.order)
    {
        Console.WriteLine(or.Id);
        Console.WriteLine(or.OrderDate.ToShortDateString());
    }
}




