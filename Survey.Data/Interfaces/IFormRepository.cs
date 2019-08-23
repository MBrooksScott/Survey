using System.Collections.Generic;
using System.Threading.Tasks;
using Survey.Models;

namespace Survey.Data.Interfaces
{
    public interface IFormRepository
    {
        Task<IEnumerable<OutlineItem>> GetOutlineItems(int? FormId = null);
    }
}