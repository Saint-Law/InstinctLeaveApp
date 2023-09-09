using InstinctLeaveApp.Contracts;
using InstinctLeaveApp.Data;
using Microsoft.EntityFrameworkCore;

namespace InstinctLeaveApp.Repository
{
    public class LeaveAllocationRepository : ILeaveAllocationRepository
    {
        public readonly AppDbContext _db;
        public LeaveAllocationRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<bool> Create(LeaveAllocation entity)
        {
            await _db.LeaveAllocations.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveAllocation>> FindAll()
        {
            var allocate = await _db.LeaveAllocations
                 .Include(r => r.LeaveType)
                 .ToListAsync();
            return allocate;
        }

        public async Task<LeaveAllocation> FindById(int id)
        {
           var allocate = await _db.LeaveAllocations
                .Include(r => r.LeaveType)
                .FirstOrDefaultAsync();
            return allocate;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = await _db.LeaveTypes.AnyAsync(x => x.Id== id);
            return exists;
        }

        public async Task<bool> Save()
        {
            var save = await _db.SaveChangesAsync();
            return save > 0;
        }

        public async Task<bool> Update(LeaveAllocation entity)
        {
            _db.LeaveAllocations.Update(entity);
            return await Save();
        }
    }
}
