using System;
using System.Collections.Generic;

#nullable disable

namespace ApiClient.Models
{
    public partial class Client
    {
        public Client()
        {
            Issues = new HashSet<Issue>();
        }

        public int IdClient { get; set; }
        public string Name { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string SecondContact { get; set; }
        public string Email { get; set; }
        public DateTime? CreationDate { get; set; }
        public string CreationUser { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateUser { get; set; }

        public virtual ICollection<Issue> Issues { get; set; }
    }
}
