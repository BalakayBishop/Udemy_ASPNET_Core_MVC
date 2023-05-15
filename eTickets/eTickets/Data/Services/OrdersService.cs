﻿using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;

        public OrdersService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrderByUserIDAsync(string userID)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Movie).Where(n => n.User_ID == userID).ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userID, string userEmailAddress)
        {
            var order = new Order()
            {
                User_ID = userID,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    Movie_ID = item.Movie.ID,
                    Order_ID = order.ID,
                    Price = item.Movie.Price
                };

                await _context.OrderItems.AddAsync(orderItem);
            }

            await _context.SaveChangesAsync();
        }
    }
}
