using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DCCRM.Domain.Models;

namespace DCCRM.Data.Mappings.dbo.PgSql {
    /// <summary>
    /// 部门表映射配置
    /// </summary>
    public class DCSetBumenMap : Ding.Datas.Ef.PgSql.AggregateRootMap<DCSetBumen> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<DCSetBumen> builder ) {
            builder.ToTable( "DC_SetBumen", "dbo" );
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
