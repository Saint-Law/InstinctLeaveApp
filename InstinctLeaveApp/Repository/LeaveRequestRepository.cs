using InstinctLeaveApp.Contracts;
using InstinctLeaveApp.Data;
using Microsoft.EntityFrameworkCore;

namespace InstinctLeaveApp.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        public readonly AppDbContext _db;
        public LeaveRequestRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(LeaveRequest entity)
        {
            await _db.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<LeaveRequest>> FindAll()
        {
            var request = await _db.LeaveRequests
                .Include(t => t.LeaveType)
                .ToListAsync();
            return request;
        }

        public async Task<LeaveRequest> FindById(int id)
        {
            var request = await _db.LeaveRequests
                .Include(t => t.LeaveType)
                .FirstOrDefaultAsync();
            return request;
        }

        public async Task<bool> isExist(int id)
        {
            var exists = _db.LeaveTypes.AnyAsync(x => x.Id == id);
            return await exists;
        }

        public async Task<bool> Save()
        {
            var change = _db.SaveChangesAsync();
            return await change > 0;
        }

        public async Task<bool> Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return await Save();
        }
    }
}
