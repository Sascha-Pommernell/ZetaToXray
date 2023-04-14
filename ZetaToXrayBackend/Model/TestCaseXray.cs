using System;
using System.Collections.Generic;

namespace ZetaToXrayBackend.Model
{
    public class TestCaseXray
    {
        public int TCID {get; set;}
        public string? TestSummary { get; set;}
        public string? TestPriority { get; set; }
        public string? Discription { get; set;}
        public string? Components { get; set;}
        public List<TestStepXray>? TestCaseTestStepList { get; set; }
        public string? MaxExecutions { get; set; }
    }
}
