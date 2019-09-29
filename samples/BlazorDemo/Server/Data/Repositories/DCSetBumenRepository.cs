using DCCRM.Domain.Models;
using DCCRM.Domain.Repositories;
using Ding.Datas.Ef.Core;

namespace DCCRM.Data.Repositories.dbo {
    /// <summary>
    /// 部门表仓储
    /// </summary>
    public class DCSetBumenRepository : RepositoryBase<DCSetBumen,long>, IDCSetBumenRepository {
        /// <summary>
        /// 初始化部门表仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DCSetBumenRepository( IDCCRMUnitOfWork unitOfWork ) : base( unitOfWork ) {
        }
    }
}