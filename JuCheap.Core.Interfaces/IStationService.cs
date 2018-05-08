using JuCheap.Core.Infrastructure;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Core.Interfaces
{
    public interface IStationService
    {
        //增
        Task<string> AddAsync(StationDto dto);
        //改
        Task<bool> UpdateAsync(StationDto dto);
        //查
        Task<StationDto> FindAsync(string Id);
        //批量删除
        Task<bool> DeleteAsync(IEnumerable<string> ids);
        //分页搜索
        Task<PagedResult<StationDto>> SearchAsync(StationFilters filters);

    }
}
