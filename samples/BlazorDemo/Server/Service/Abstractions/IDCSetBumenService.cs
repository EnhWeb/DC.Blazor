using Ding.Applications;
using DCCRM.Service.Dtos.dbo;
using DCCRM.Service.Queries.dbo;

namespace DCCRM.Service.Abstractions.dbo {
    /// <summary>
    /// 部门表服务
    /// </summary>
    public interface IDCSetBumenService : ICrudService<DCSetBumenDto, DCSetBumenQuery> {
    }
}