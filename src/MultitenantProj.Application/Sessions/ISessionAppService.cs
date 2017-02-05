using System.Threading.Tasks;
using Abp.Application.Services;
using MultitenantProj.Sessions.Dto;

namespace MultitenantProj.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
