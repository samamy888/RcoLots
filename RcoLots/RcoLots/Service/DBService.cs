using Microsoft.EntityFrameworkCore;
using RcoLots.Models;
using System.Security.Principal;

namespace RcoLots.Service
{
    public class DBService
    {
        private readonly RcoLotsContext _dbContext;
        private readonly ILogger<DBService> _logger;

        public DBService(RcoLotsContext dbContext, ILogger<DBService> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<List<Member>> GetMember()
        {
            return await _dbContext.Members.ToListAsync();
        }
        public async Task<int> AddMember(string name)
        {
            try
            {
                _logger.LogWarning("add {0}", name);
                Member member = new();
                member.Name = name;
                await _dbContext.Members.AddAsync(member);
                return await _dbContext.SaveChangesAsync();
            }catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return 0;
            }

        }
        public async Task<int> RemoveMember(string id)
        {
            _dbContext.Members.Where(x => x.Id == Int32.Parse(id)).DeleteFromQuery();
            return await _dbContext.SaveChangesAsync();
        }
    }
}
