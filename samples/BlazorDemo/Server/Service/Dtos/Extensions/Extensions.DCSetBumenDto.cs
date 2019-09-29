using Ding;
using Ding.Maps;
using DCCRM.Domain.Models;

namespace DCCRM.Service.Dtos.dbo.Extensions {
    /// <summary>
    /// 部门表数据传输对象扩展
    /// </summary>
    public static class DCSetBumenDtoExtension {
        /// <summary>
        /// 转换为部门表实体
        /// </summary>
        /// <param name="dto">部门表数据传输对象</param>
        public static DCSetBumen ToEntity( this DCSetBumenDto dto ) {
            if ( dto == null )
                return new DCSetBumen();
            return dto.MapTo( new DCSetBumen( dto.Id.ToLong() ) );
        }
        
        /// <summary>
        /// 转换为部门表实体
        /// </summary>
        /// <param name="dto">部门表数据传输对象</param>
        public static DCSetBumen ToEntity2( this DCSetBumenDto dto ) {
            if( dto == null )
                return new DCSetBumen();
            return new DCSetBumen( dto.Id.ToLong() ) {
                GName = dto.GName,
                GZhuGuan = dto.GZhuGuan,
                GTiCheng = dto.GTiCheng,
                    IsDeleted = dto.IsDeleted.SafeValue(),
                Version = dto.Version,
            };
        }
        
        ///// <summary>
        ///// 转换为部门表实体
        ///// </summary>
        ///// <param name="dto">部门表数据传输对象</param>
        //public static DCSetBumen ToEntity3( this DCSetBumenDto dto ) {
        //    if( dto == null )
        //        return new DCSetBumen();
        //    return DCSetBumenFactory.Create(
        //        
        //        
        //        id : dto.Id.ToLong(),
        //        
        //        
        //        gName : dto.GName,
        //        
        //        
        //        gZhuGuan : dto.GZhuGuan,
        //        
        //        
        //        gTiCheng : dto.GTiCheng,
        //        
        //        
        //        isDeleted : dto.IsDeleted,
        //        
        //        
        //        version : dto.Version
        //        
        //    );
        //}
        
        /// <summary>
        /// 转换为部门表数据传输对象
        /// </summary>
        /// <param name="entity">部门表实体</param>
        public static DCSetBumenDto ToDto(this DCSetBumen entity) {
            if( entity == null )
                return new DCSetBumenDto();
            return entity.MapTo<DCSetBumenDto>();
        }

        ///// <summary>
        ///// 转换为部门表数据传输对象
        ///// </summary>
        ///// <param name="entity">部门表实体</param>
        //public static DCSetBumenDto ToDto2( this DCSetBumen entity ) {
        //    if( entity == null )
        //        return new DCSetBumenDto();
        //    return new DCSetBumenDto {
        //        
        //        
        //        Id = entity.Id,
        //        
        //        
        //        GName = entity.GName,
        //        
        //        
        //        GZhuGuan = entity.GZhuGuan,
        //        
        //        
        //        GTiCheng = entity.GTiCheng,
        //        
        //        
        //        IsDeleted = entity.IsDeleted,
        //        
        //        
        //        Version = entity.Version,
        //        
        //    };
        //}
    }
}