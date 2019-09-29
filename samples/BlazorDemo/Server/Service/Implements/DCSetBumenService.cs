using Ding;
using Ding.Maps;
using Ding.Domains.Repositories;
using Ding.Datas.Queries;
using Ding.Applications;
using DCCRM.Data;
using DCCRM.Domain.Models;
using DCCRM.Domain.Repositories;
using DCCRM.Service.Dtos.dbo;
using DCCRM.Service.Queries.dbo;
using DCCRM.Service.Abstractions.dbo;
using System.Threading.Tasks;
using DCCRM.Service.Dtos.dbo.Extensions;

namespace DCCRM.Service.Implements.dbo {
    /// <summary>
    /// 部门表服务
    /// </summary>
    public class DCSetBumenService : CrudServiceBase<DCSetBumen, DCSetBumenDto, DCSetBumenQuery,long>, IDCSetBumenService {
        /// <summary>
        /// 初始化部门表服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="dCSetBumenRepository">部门表仓储</param>
        public DCSetBumenService( IDCCRMUnitOfWork unitOfWork, IDCSetBumenRepository dCSetBumenRepository )
            : base( unitOfWork, dCSetBumenRepository ) {
            DCSetBumenRepository = dCSetBumenRepository;
        }
        
        /// <summary>
        /// 部门表仓储
        /// </summary>
        public IDCSetBumenRepository DCSetBumenRepository { get; set; }
        
        /// <summary>
        /// 创建查询对象
        /// </summary>
        /// <param name="param">查询参数</param>
        protected override IQueryBase<DCSetBumen> CreateQuery( DCSetBumenQuery param ) {
            return new Query<DCSetBumen,long>( param );
        }
    }
}