using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Ding;
using Ding.Domains;
using Ding.Domains.Auditing;
using Ding.Domains.Tenants;

namespace DCCRM.Domain.Models {
    /// <summary>
    /// 部门表
    /// </summary>
    [DisplayName( "部门表" )]
    public partial class DCSetBumen : AggregateRoot<DCSetBumen,long>,IDelete {
        /// <summary>
        /// 初始化部门表
        /// </summary>
        public DCSetBumen() : this( 0 ) {
        }

        /// <summary>
        /// 初始化部门表
        /// </summary>
        /// <param name="id">部门表标识</param>
        public DCSetBumen( long id ) : base( id ) {
        }

        /// <summary>
        /// 部门名称
        /// </summary>
        [DisplayName( "部门名称" )]
        [Required(ErrorMessage = "部门名称不能为空")]
        [StringLength( 255, ErrorMessage = "部门名称输入过长，不能超过255位" )]
        [Column( "GName" )]
        public string GName { get; set; }
        /// <summary>
        /// 部门主管
        /// </summary>
        [DisplayName( "部门主管" )]
        [StringLength( 255, ErrorMessage = "部门主管输入过长，不能超过255位" )]
        [Column( "GZhuGuan" )]
        public string GZhuGuan { get; set; }
        /// <summary>
        /// 提成
        /// </summary>
        [DisplayName( "提成" )]
        [Column( "GTiCheng" )]
        public decimal? GTiCheng { get; set; }
        /// <summary>
        /// 软删除，数据不会被物理删除
        /// </summary>
        [DisplayName( "软删除，数据不会被物理删除" )]
        [Column( "IsDeleted" )]
        public bool IsDeleted { get; set; }
        
        /// <summary>
        /// 添加描述
        /// </summary>
        protected override void AddDescriptions() {
            AddDescription( t => t.Id );
            AddDescription( t => t.GName );
            AddDescription( t => t.GZhuGuan );
            AddDescription( t => t.GTiCheng );
        }
        
        /// <summary>
        /// 添加变更列表
        /// </summary>
        protected override void AddChanges( DCSetBumen other ) {
            AddChange( t => t.Id, other.Id );
            AddChange( t => t.GName, other.GName );
            AddChange( t => t.GZhuGuan, other.GZhuGuan );
            AddChange( t => t.GTiCheng, other.GTiCheng );
        }
    }
}