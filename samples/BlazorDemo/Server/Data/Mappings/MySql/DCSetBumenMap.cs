using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DCCRM.Domain.Models;

namespace DCCRM.Data.Mappings.MySql {
    /// <summary>
    /// 部门表映射配置
    /// </summary>
    public class DCSetBumenMap : Ding.Datas.Ef.MySql.AggregateRootMap<DCSetBumen> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<DCSetBumen> builder ) {
            builder.ToTable( "DC_SetBumen" );
        }
        
        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<DCSetBumen> builder ) {
            //编号
            builder.Property(t => t.Id)
                .HasColumnName("Id")
                ;
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
