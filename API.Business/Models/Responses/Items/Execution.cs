using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Business.Models.Responses.Items
{
    public class Execution
    {
        public string Owner { get; set; }
        public string Description { get; set; }
        public int Id { get; set; }
        public string Uuid { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public long StartTime { get; set; }
        public long EndTime { get; set; }
        public long LastModified { get; set; }
        public string Status { get; set; }
        public Statistics Statistics { get; set; }
        public List<Attribute> Attributes { get; set; }
        public string Mode { get; set; }
        public List<object> Analysing { get; set; }
        public double ApproximateDuration { get; set; }
        public bool HasRetries { get; set; }
        public bool Rerun { get; set; }
        public Metadata Metadata { get; set; }
    }
}
