using MarketPlace.Application.ViewModels.System;
using MarketPlace.Ultilities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MarketPlace.Application.Interfaces
{
    public interface IRoleService
    {
        //Task<bool> AddAsync(AnnouncementViewModel announcement, List<AnnouncementUserViewModel> announcementUsers, AppRoleViewModel userVm);

        Task DeleteAsync(Guid id);

        Task<List<CusRoleViewModel>> GetAllAsync();

        PagedResult<CusRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize);

        Task<CusRoleViewModel> GetById(Guid id);


        Task UpdateAsync(CusRoleViewModel userVm);

        List<PermissionViewModel> GetListFunctionWithRole(Guid roleId);

        void SavePermission(List<PermissionViewModel> permissions, Guid roleId);

        Task<bool> CheckPermission(string functionId, string action, string[] roles);
    }
}
