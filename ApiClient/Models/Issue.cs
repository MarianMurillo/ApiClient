using System;
using System.Collections.Generic;

#nullable disable

namespace ApiClient.Models
{
    public partial class Issue
    {
        public Issue()
        {
            Comments = new HashSet<Comment>();
        }

        public int IdIssue { get; set; }
        public int IdClient { get; set; }
        public string Description { get; set; }
        public DateTime RegisterTimestamp { get; set; }
        public string Address { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string Status { get; set; }
        public string SupportUserAssigned { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual Client IdClientNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
