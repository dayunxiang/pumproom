using AutoMapper;
using JuCheap.Core.Data;
using JuCheap.Core.Data.Entity;
using JuCheap.Core.Infrastructure;
using JuCheap.Core.Infrastructure.Extentions;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Core.Services.AppServices
{
    public class StationService:IStationService
    {
        private readonly JuCheapContext _context;
        private readonly IMapper _mapper;
        
        public StationService(JuCheapContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        /// <summary>
        /// 增
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<string> AddAsync(StationDto dto)
        {
            var entity = _mapper.Map<StationDto, StationEntity>(dto);
            entity.Init();
            _context.Stations.Add(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;
        }
        /// <summary>
        /// 删
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(IEnumerable<string> ids)
        {
            var dbset = _context.Stations;
            var entities = dbset.Where(item => ids.Contains(item.Id));
            entities.ForEach(item => item.IsDeleted = true);
            return await _context.SaveChangesAsync() > 0;
        }
        /// <summary>
        /// 查
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<StationDto> FindAsync(string id)
        {
            var dbset = _context.Stations;
            var entity = await dbset.FirstOrDefaultAsync(r => r.Id == id);
            var dto = _mapper.Map<StationEntity, StationDto>(entity);
            return dto;
        }
        /// <summary>
        /// 分页结果
        /// </summary>
        /// <param name="filters"></param>
        /// <returns></returns>
        public async Task<PagedResult<StationDto>> SearchAsync(StationFilters filters)
        {
            if (filters == null)
                return new PagedResult<StationDto>(0, 0);
            var dbset = _context.Stations;
            var query = dbset.Where(item => !item.IsDeleted);
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => item.站点名称.Contains(filters.keywords));
            return await query.OrderByDescending(item => item.分区名称)
                .Select(item => new StationDto
                {
                    Id = item.Id,
                    分区名称 = item.分区名称,
                    分区类型 = item.分区类型,
                    站点名称 = item.站点名称,
                    站点编号 = item.站点编号,
                    编号 = item.编号,
                    站点全名 = item.站点全名,
                    站点类型 = item.站点类型,
                    分区内排序 = item.分区内排序

                }).PagingAsync(filters.page, filters.rows);

        }

        public async Task<bool> UpdateAsync(StationDto dto)
        {
            var entity = _context.Stations.FirstOrDefault(u => u.Id == dto.Id);
            _mapper.Map(dto, entity);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
