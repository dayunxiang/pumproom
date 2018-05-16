using JuCheap.Core.Infrastructure;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Core.Interfaces
{
    public interface IGisProService
    {
        //增
        Task<string> AddAsync(GisProDto dto);
        //该
        Task<bool> UpdateAsync(GisProDto dto);
        //查
        Task<GisProDto> FindAsync(string Id);
        //批量删除
        Task<bool> DeleteAsync(IEnumerable<string> ids);
        //分页搜索
        Task<PagedResult<GisProDto>> SearchAsync(GisProFilters filters);

    }
}
