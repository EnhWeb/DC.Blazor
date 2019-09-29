using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Ding.Applications.Dtos;

namespace DCCRM.Service.Dtos.dbo {
    /// <summary>
    /// 部门表数据传输对象
    /// </summary>
    public class DCSetBumenDto : DtoBase {
        /// <summary>
        /// 部门名称
        /// </summary>
        [Required(ErrorMessage = "部门名称不能为空")]
        [StringLength( 255, ErrorMessage = "部门名称输入过长，不能超过255位" )]
        [Column( "GName" )]
        [Display( Name = "部门名称" )]
        public string GName { get; set; }
        /// <summary>
        /// 部门主管
        /// </summary>
        [StringLength( 255, ErrorMessage = "部门主管输入过长，不能超过255位" )]
        [Column( "GZhuGuan" )]
        [Display( Name = "部门主管" )]
        public string GZhuGuan { get; set; }
        /// <summary>
        /// 提成
        /// </summary>
        [Column( "GTiCheng" )]
        [Display( Name = "提成" )]
        public decimal? GTiCheng { get; set; }
        /// <summary>
        /// 软删除，数据不会被物理删除
        /// </summary>
        [Column( "IsDeleted" )]
        [Display( Name = "软删除，数据不会被物理删除" )]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 处理并发问题
        /// </summary>
        [Column( "Version" )]
        [Display( Name = "处理并发问题" )]
        public Byte[] Version { get; set; }
    }
}