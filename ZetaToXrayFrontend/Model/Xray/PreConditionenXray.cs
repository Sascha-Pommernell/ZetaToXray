using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaToXrayFrontend.Model.Xray
{
    public class PreConditionenXray
    {
        public string Assigen { get; set; } = null!;
        public string Condition { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string IssueType { get; set; } = null!;
        public string Reporter { get; set; } = null!;
        public string Summary { get; set; } = null!;
        public string TestsAssociatedPreCondition{ get; set; } = null!;
        public string Type { get; set; } = null!;
    }
}
