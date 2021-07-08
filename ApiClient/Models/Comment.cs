using System;
using System.Collections.Generic;

#nullable disable

namespace ApiClient.Models
{
    public partial class Comment
    {
        public int IdComment { get; set; }
        public int IdIssue { get; set; }
        public string Description { get; set; }
        public DateTime CommentTimestamp { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual Issue IdIssueNavigation { get; set; }
    }
}
