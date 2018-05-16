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
    public class GisProService : IGisProService
    {
        private readonly JuCheapContext _context;
        private readonly IMapper _mapper;
        public GisProService(JuCheapContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        //增
        public async Task<string> AddAsync(GisProDto dto)
        {
            var entity = _mapper.Map<GisProDto, GisProEntity>(dto);
            entity.Init();
            _context.GisPros.Add(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;
        }
        //删
        public async Task<bool> DeleteAsync(IEnumerable<string> ids)
        {
            var dbset = _context.GisPros;
            var entities = dbset.Where(item => ids.Contains(item.Id));
            entities.ForEach(item => item.IsDeleted = true);
            return await _context.SaveChangesAsync() > 0;

        }

        //分页搜索
        public async Task<PagedResult<GisProDto>> SearchAsync(GisProFilters filters)
        {
            if (filters == null)
                return new PagedResult<GisProDto>(0, 0);
            var dbset = _context.GisPros;
            var query = dbset.Where(item => !item.IsDeleted);
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => item.站点名称.Contains(filters.keywords));
            return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new GisProDto
                {
                    Id = item.Id,
                    站点名称 = item.站点名称,
                    分区名称 = item.分区名称,
                    泵个数name = item.泵个数name,
                    泵个数 = item.泵个数,
                    状态信息name = item.状态信息name,
                    状态信息 = item.状态信息,
                    报警信息name = item.报警信息name,
                    报警信息 = item.报警信息,
                    坐标 = item.坐标,
                    泵表编号 = item.泵表编号,
                    备用1 = item.备用1,
                    备用2 = item.备用2,
                    备用3 = item.备用3,
                    备用4 = item.备用4
                }).PagingAsync(filters.page, filters.rows);
        }


        //改
        public  async Task<bool> UpdateAsync(GisProDto dto)
        {
            var entity = _context.GisPros.FirstOrDefault(u => u.Id == dto.Id);
            _mapper.Map(dto, entity);
            return await _context.SaveChangesAsync() > 0;
        }

        //查

        public async Task<GisProDto> FindAsync(string id )
        {
            var dbSet = _context.GisPros;
            var entity = await dbSet.FirstOrDefaultAsync(r => r.Id == id);
            var dto = _mapper.Map<GisProEntity, GisProDto>(entity);
            return dto;
        }
    }
}
