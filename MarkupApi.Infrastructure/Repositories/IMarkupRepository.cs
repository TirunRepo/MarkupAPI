using MarkupApi.Infrastructure.Entities;

namespace MarkupApi.Infrastructure.Repositories
{
    public interface IMarkupRepository
    {
        Task<MarkupDetail> AddAsync(MarkupDetail entity);
        Task<MarkupDetail> UpdateAsync(MarkupDetail entity);
        Task DeleteAsync(int id);
        Task<List<MarkupDetail>> GetMarkupDetails();
        Task<MarkupDetail> GetByIdAsync(int id);
    }
}
