using AutoMapper;
using JuCheap.Core.Data;
using JuCheap.Core.Data.Entity;
using JuCheap.Core.Infrastructure;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JuCheap.Core.Infrastructure.Extentions;

namespace JuCheap.Core.Services.AppServices
{
    public class CameraPathService:ICameraPathService
    {
        private readonly JuCheapContext _context;
        private readonly IMapper _mapper;

        public CameraPathService(JuCheapContext context,IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        //增
        public async Task<string> AddAsync(CameraPathDto dto)
        {
            var entity = _mapper.Map<CameraPathDto, CameraPathEntity>(dto);
            entity.Init();
            _context.CameraPaths.Add(entity);
            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;

        }
        //删
        public async Task<bool> DeleteAsync(IEnumerable<string> ids)
        {

            var dbset = _context.CameraPaths;
            var entities = dbset.Where(item => ids.Contains(item.Id));  
            entities.ForEach(item => item.IsDeleted = true);
            return await _context.SaveChangesAsync() > 0;
            //throw new NotImplementedException();
        }
        //查
        public async Task<CameraPathDto> FindAsync(string id)
        {
            var dbSet = _context.CameraPaths;
            var entity = await dbSet.FirstOrDefaultAsync(r => r.Id == id);
            var dto = _mapper.Map<CameraPathEntity,CameraPathDto>(entity);
            return dto;
        }
        //分页搜索
        public async Task<PagedResult<CameraPathDto>> SearchAsync(CameraPathFilters filters)
        {
            //throw new NotImplementedException();
            if (filters == null)
                return new PagedResult<CameraPathDto>(0, 0);
            var dbset = _context.CameraPaths;
            var query = dbset.Where(item => !item.IsDeleted);
            if (filters.keywords.IsNotBlank())
                query = query.Where(item => item.PumpRoomName.Contains(filters.keywords));
            return await query.OrderByDescending(item => item.CreateDateTime)
                .Select(item => new CameraPathDto
                {
                    Id = item.Id,
                    Ip = item.Ip,
                    Port = item.Port,
                    Pwd = item.Pwd,
                    LoginName = item.LoginName,
                    info = item.info,
                    PumpRoomId = item.PumpRoomId,
                    PumpRoomName = item.PumpRoomName
                }).PagingAsync(filters.page, filters.rows);


        }

        //改
        public async Task<bool> UpdateAsync(CameraPathDto dto)
        {
            //这一句话使用了linq
            var entity = _context.CameraPaths.FirstOrDefault(u => u.Id == dto.Id);
            _mapper.Map(dto, entity);
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
