using Rewinery.Server.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rewinery.Server.Core.Models.Topics
{
    #pragma warning disable CS8618
    public class Topic : BaseEntity
    {
        public ApplicationUser User { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<Answer>? Answers { get; set; }

        public DateTime? Created { get; set; } = DateTime.Now;
    }
}
