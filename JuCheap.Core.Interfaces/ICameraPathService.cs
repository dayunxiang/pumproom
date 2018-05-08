using JuCheap.Core.Infrastructure;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Core.Interfaces
{
     public interface ICameraPathService
    {
        //增
        Task<string> AddAsync(CameraPathDto dto);
        //该
        Task<bool> UpdateAsync(CameraPathDto dto);
        //查
        Task<CameraPathDto> FindAsync(string Id);
        //批量删除
        Task<bool> DeleteAsync(IEnumerable<string> ids);
        //分页搜索
        Task<PagedResult<CameraPathDto>> SearchAsync(CameraPathFilters filters);






    }
}
