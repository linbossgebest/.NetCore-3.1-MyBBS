using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entity.Cms
{
	public partial class RolePermission
	{
		/// <summary>
		/// 主键
		/// </summary>
		[Key]
		public Int32 Id { get; set; }

		/// <summary>
		/// 角色主键
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 RoleId { get; set; }

		/// <summary>
		/// 菜单主键
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 MenuId { get; set; }

		/// <summary>
		/// 操作类型（功能权限）
		/// </summary>
		[MaxLength(128)]
		public String Permission { get; set; }


	}
}
