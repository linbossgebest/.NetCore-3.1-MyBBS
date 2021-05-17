﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApplicationCore.Entity.Cms
{
	public partial class ManagerLog
	{
		/// <summary>
		///  
		/// </summary>
		[Key]
		public Int32 Id { get; set; }

		/// <summary>
		/// 操作类型
		/// </summary>
		[MaxLength(32)]
		public String ActionType { get; set; }

		/// <summary>
		/// 主键
		/// </summary>
		[Required]
		[MaxLength(10)]
		public Int32 AddManageId { get; set; }

		/// <summary>
		/// 操作人名称
		/// </summary>
		[MaxLength(64)]
		public String AddManagerNickName { get; set; }

		/// <summary>
		/// 操作时间
		/// </summary>
		[Required]
		[MaxLength(23)]
		public DateTime AddTime { get; set; }

		/// <summary>
		/// 操作IP
		/// </summary>
		[MaxLength(64)]
		public String AddIp { get; set; }

		/// <summary>
		/// 备注
		/// </summary>
		[MaxLength(256)]
		public String Remark { get; set; }


	}
}
