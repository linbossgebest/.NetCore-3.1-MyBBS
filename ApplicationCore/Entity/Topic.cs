using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entity
{
    /// <summary>
    /// 话题
    /// </summary>
    public class Topic:BaseEntity
    {
        /// <summary>
        /// 节点Id
        /// </summary>
        public int NodeId { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public String Email { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// 置顶权重
        /// </summary>
        public int Top { get; set; }

        /// <summary>
        /// 话题类型
        /// </summary>
        public TopicType Type { get; set; }

        /// <summary>
        /// 浏览总数
        /// </summary>
        public int ViewCount { get; set; }

        /// <summary>
        /// 回复总数
        /// </summary>
        public int ReplayCount { get; set; }

        /// <summary>
        /// 最后回复用户Id
        /// </summary>
        public string LastReplyUserId { get; set; }

        /// <summary>
        /// 最后回复时间
        /// </summary>
        public DateTime LastReplayTime { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }
    }

    public enum TopicType
    {
        Delete = 0,
        Normal = 1,
        Top = 2,
        Good = 3,
        Hot = 4
    }
}
