using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entity
{
    /// <summary>
    /// 话题节点
    /// </summary>
    public class TopicNode:BaseEntity
    {
        public int ParentId { get; set; }

        /// <summary>
        /// 节点名称
        /// </summary>
        public string NodeName { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }

    }
}
