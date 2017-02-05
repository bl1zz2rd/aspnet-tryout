using System.Threading.Tasks;
using Abp.Application.Services;
using MultitenantProj.Roles.Dto;

namespace MultitenantProj.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}
