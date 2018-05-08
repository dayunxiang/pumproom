﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JuCheap.Core.Data;
using JuCheap.Core.Data.Entity;
using JuCheap.Core.Infrastructure;
using JuCheap.Core.Interfaces;
using JuCheap.Core.Models;
using JuCheap.Core.Models.Enum;
using JuCheap.Core.Models.Filters;
using JuCheap.Core.Infrastructure.Extentions;
using Microsoft.EntityFrameworkCore;
using System;

namespace JuCheap.Core.Services.AppServices
{
    /// <summary>
    /// 用户实现类
    /// </summary>
    public class UserService : IUserService
    {
        private readonly JuCheapContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public UserService(JuCheapContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<string> AddAsync(UserAddDto user)
        {
            var entity = _mapper.Map<UserAddDto, UserEntity>(user);
            entity.Init();
            //如果用户拥有角色，应该是外键了，另外的一个表中写入此用户的id，创建一条userroles的表然后添加一个userid，
            if (entity.UserRoles.AnyOne())
            {
                entity.UserRoles.ForEach(r => r.UserId = entity.Id);
            }
            //这里的密码进行了加密，我的就算了
            entity.Password = entity.Password.ToMd5();
            _context.Users.Add(entity);

            return await _context.SaveChangesAsync() > 0 ? entity.Id : string.Empty;
        }

        /// <summary>
        /// 更新菜单
        /// </summary>
        /// <param name="dto">菜单模型</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(UserUpdateDto dto)
        {
            var entity = _context.Users.FirstOrDefault(u => u.Id == dto.Id);
            entity.LoginName = dto.LoginName;
            entity.RealName = dto.RealName;
            entity.Email = dto.Email;
            entity.DepartmentId = dto.DepartmentId;
            if (dto.Password.IsNotBlank())
            {
                entity.Password = dto.Password.ToMd5();
            }
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 根据主键查询模型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public async Task<UserDto> FindAsync(string id)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            var dto = _mapper.Map<UserEntity, UserDto>(entity);
            return dto;
        }

        /// <summary>
        /// 批量逻辑删除
        /// </summary>
        /// <param name="ids">主键ID集合</param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(IEnumerable<string> ids)
        {
            var entities = _context.Users.Where(item => ids.Contains(item.Id));
            entities.ForEach(item => item.IsDeleted = true);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="dto">登录信息</param>
        /// <returns></returns>
        public async Task<UserLoginDto> LoginAsync(LoginDto dto)
        {
            var reslt = new UserLoginDto();
            var logDbSet = _context.LoginLogs;
            var loginName = dto.LoginName.Trim();
            var entity = await _context.Users.FirstOrDefaultAsync(item => item.LoginName == loginName);
            var loginLog = new LoginLogEntity
            {
                Id = Guid.NewGuid().ToString("N"),
                LoginName = dto.LoginName,
                IP = dto.LoginIP,
                CreateDateTime = DateTime.Now
            };
            if (entity == null)
            {
                reslt.Message = "Account not exists";
                reslt.Result = LoginResult.AccountNotExists;
                loginLog.UserId = string.Empty;
            }
            else
            {
                if (entity.Password == dto.Password.ToMd5())
                {
                    reslt.LoginSuccess = true;
                    reslt.Message = "Login success";
                    reslt.Result = LoginResult.Success;
                    reslt.User = _mapper.Map<UserEntity, UserDto>(entity);
                }
                else
                {
                    reslt.Message = "Wrong password";
                    reslt.Result = LoginResult.WrongPassword;
                }
                loginLog.UserId = entity.Id;
            }
            loginLog.Message = reslt.Message;
            logDbSet.Add(loginLog);
            await _context.SaveChangesAsync();
            return reslt;
        }

        /// <summary>
        /// 用户角色授权
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public async Task<bool> GiveAsync(string userId, string roleId)
        {
            if (await _context.UserRoles.AnyAsync(item => item.UserId == userId && item.RoleId == roleId))
                return true;
            _context.UserRoles.Add(new UserRoleEntity
            {
                Id = Guid.NewGuid().ToString("N"),
                UserId = userId,
                RoleId = roleId
            });
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 用户角色取消
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="roleId">角色ID</param>
        /// <returns></returns>
        public async Task<bool> CancelAsync(string userId, string roleId)
        {
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(item => item.UserId == userId && item.RoleId == roleId);
            _context.UserRoles.Remove(userRole);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 分页搜索
        /// </summary>
        /// <param name="filters">查询过滤参数</param>
        /// <returns></returns>
        public async Task<PagedResult<UserDto>> SearchAsync(UserFilters filters)
        {
            if (filters == null)
                return new PagedResult<UserDto>(1, 0);

            var query = _context.Users.Where(item => !item.IsDeleted);

            if (filters.keywords.IsNotBlank())
            {
                query = query.Where(x => x.LoginName.Contains(filters.keywords) || x.RealName.Contains(filters.keywords));
            }

            return await query.OrderByDescending(x => x.CreateDateTime)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    LoginName = x.LoginName,
                    RealName = x.RealName,
                    Email = x.Email,
                    DepartmentName = x.Department.FullName,
                    CreateDateTime = x.CreateDateTime
                }).PagingAsync(filters.page, filters.rows);
        }

        /// <summary>
        /// 是否拥有此权限
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <param name="url">url地址</param>
        /// <returns></returns>
        public async Task<bool> HasRightAsync(string userId, string url)
        {
            var menus = _context.Menus;
            var userRoles = _context.UserRoles;
            var roleMenus = _context.RoleMenus;
            var query = menus.Where(item => !item.IsDeleted);
            var roleIds = await userRoles.Where(item => item.UserId == userId)
                .Select(item => item.RoleId).ToListAsync();
            var menuIds = await roleMenus.Where(item => roleIds.Contains(item.RoleId))
                .Select(item => item.MenuId)
                .ToListAsync();
            return await query.AnyAsync(x => menuIds.Contains(x.Id) && url.StartsWith(x.Url));
        }

        /// <summary>
        /// 记录访问记录
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<bool> VisitAsync(VisitDto dto)
        {
            var entity = _mapper.Map<VisitDto, PageViewEntity>(dto);
            entity.Init();
            _context.PageViews.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 检测是否存在用户名
        /// </summary>
        /// <param name="userId">用户ID，可以为空</param>
        /// <param name="loginName">用户名</param>
        /// <returns></returns>
        public async Task<bool> ExistsLoginNameAsync(string userId, string loginName)
        {
            var query = _context.Users.Where(u => !u.IsDeleted && u.LoginName == loginName)
                .WhereIf(userId.IsNotBlank(), u => u.Id != userId);
            return await query.AnyAsync();
        }
    }
}
