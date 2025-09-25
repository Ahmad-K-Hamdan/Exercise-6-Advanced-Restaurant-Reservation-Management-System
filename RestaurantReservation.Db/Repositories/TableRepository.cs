using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.Db.Repositories
{
    public class TableRepository
    {
        private readonly RestaurantReservationDbContext _context;

        public TableRepository(RestaurantReservationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Table>> GetAllAsync()
        {
            return await _context.Tables.ToListAsync();
        }

        public void Add(Table table)
        {
            _context.Tables.Add(table);
            _context.SaveChanges();
        }

        public Table? GetById(int TableId)
        {
            return _context.Tables.FirstOrDefault(t => t.TableId == TableId);
        }

        public void Update(Table table)
        {
            _context.Tables.Update(table);
            _context.SaveChanges();
        }

        public void Delete(Table table)
        {
            _context.Tables.Remove(table);
            _context.SaveChanges();
        }
    }
}
