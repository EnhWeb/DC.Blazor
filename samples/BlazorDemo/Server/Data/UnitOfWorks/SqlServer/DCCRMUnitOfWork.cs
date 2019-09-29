﻿using Microsoft.EntityFrameworkCore;
using System;

namespace DCCRM.Data.SqlServer
{
    /// <summary>
    /// 工作单元
    /// </summary>
    public class DCCRMUnitOfWork : Ding.Datas.Ef.SqlServer.UnitOfWork, IDCCRMUnitOfWork
    {
        /// <summary>
        /// 初始化工作单元
        /// </summary>
        /// <param name="options">配置项</param>
        /// <param name="serviceProvider">服务提供器</param>
        public DCCRMUnitOfWork(DbContextOptions<DCCRMUnitOfWork> options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
