using System;
using System.ComponentModel.DataAnnotations;
using Ding;
using Ding.Datas.Queries;

namespace DCCRM.Service.Queries.dbo {
    /// <summary>
    /// 部门表查询参数
    /// </summary>
    public class DCSetBumenQuery : QueryParameter {
        /// <summary>
        /// 编号
        /// </summary>
        [Display( Name = "编号" )]
        public long? Id { get; set; }
        
        private string _gName = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        [Display( Name = "部门名称" )]
        public string GName {
            get => _gName == null ? string.Empty : _gName.Trim();
            set => _gName = value;
        }
        
        private string _gZhuGuan = string.Empty;
        /// <summary>
        /// 部门主管
        /// </summary>
        [Display( Name = "部门主管" )]
        public string GZhuGuan {
            get => _gZhuGuan == null ? string.Empty : _gZhuGuan.Trim();
            set => _gZhuGuan = value;
        }
        /// <summary>
        /// 提成
        /// </summary>
        [Display( Name = "提成" )]
        public decimal? GTiCheng { get; set; }
    }
}