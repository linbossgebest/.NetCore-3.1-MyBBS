using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entity.Cms
{
	public partial class ManagerRole
	{
		/// <summary>
		/// 主键
		/// </summary>
		[Key]
		public Int32 Id { get; set; }

		/// <summary>
		/// 角色名称
		/// </summary>
		[Required]
		[MaxLength(64)]
		public String RoleName { get; set; }

		/// <summary>
		/// 角色类型1超管2系管
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 RoleType { get; set; }

		/// <summary>
		/// 是否系统默认
		/// </summary>
		[Required]
		[MaxLength(1)]
		public Boolean IsSystem { get; set; }

		/// <summary>
		/// 添加人
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 AddManagerId { get; set; }

		/// <summary>
		/// 添加时间
		/// </summary>
		[Required]
		[MaxLength(23)]
		public DateTime AddTime { get; set; }

		/// <summary>
		/// 修改人
		/// </summary>
		[MaxLength(10)]
		public Int32? ModifyManagerId { get; set; }

		/// <summary>
		/// 修改时间
		/// </summary>
		[MaxLength(23)]
		public DateTime? ModifyTime { get; set; }

		/// <summary>
		/// 是否删除
		/// </summary>
		[Required]
		[MaxLength(1)]
		public Boolean IsDelete { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[MaxLength(128)]
		public String Remark { get; set; }

	}
}
