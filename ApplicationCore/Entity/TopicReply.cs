using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Entity
{
    public class TopicReply:BaseEntity
    {
        /// <summary>
        /// 话题Id
        /// </summary>
        public int TopicId { get; set; }

        /// <summary>
        /// 回复用户Id
        /// </summary>
        public string ReplyUserId { get; set; }

        /// <summary>
        /// 回复邮箱
        /// </summary>
        public string ReplyEmail { get; set; }

        /// <summary>
        /// 回复内容
        /// </summary>
        public string ReplyContent { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateOn { get; set; }
    }
}
