using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaToXrayFrontend.Model.Xray
{
    public class TestCaseXray
    {
        public string tcid { get; set; } = null!;
        public string testSummary { get; set; } = null!;
        public string testPriority { get; set; } = null!;
        public string discription { get; set; } = null!;
        public string components { get; set; } = null!;
        public string action { get; set; } = null!;
        public string data { get; set; } = null!;
        public string result { get; set; } = null!;
        public string maxExecutions { get; set; } = null!;
    }
}
