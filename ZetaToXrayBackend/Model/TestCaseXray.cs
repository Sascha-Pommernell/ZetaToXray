using System;
using System.Collections.Generic;

namespace ZetaToXrayBackend.Model
{
    public class TestCaseXray
    {
        private int tcid;
        private string testSummary = "";
        private string testPriority = "";
        private string discription = "";
        private string components = "";
        private string maxExecutions = "";

        public int TCID
        {
            get { return tcid; }
            set { tcid = value; }
        }
        public string TestSummary
        {
            get
            {
                return testSummary;
            }
            set
            {
                if (value != null)
                {
                    testSummary = value;
                }
                else
                {
                    testSummary = "";
                }
            }
        }

        public string TestPriority
        {     
            get
            {
                return testPriority;
            }
           
            set
            {
                if (value != null)
                {
                    testPriority = value;
                }
                else
                {
                    testPriority = "";
                }
            }
        }

        public string Discription
        {
            get
            {
                return discription;
            }
            set
            {
                if (value != null)
                {
                    discription = value;
                }
                else
                {
                    discription = "";
                }
            }
        }

        public string Components
        {
            get
            {
                return components;
            }
            set
            {
                if (value != null)
                {
                    components = value;
                }
                else
                {
                    components = "";
                }
            }
        }

        public List<TestStepXray>? TestCaseTestStepList { get; set; }
        
        public string MaxExecutions
        {
            get
            {
                return maxExecutions;
            }
            set
            {
                if (value != null)
                {
                    maxExecutions = value;
                }
                else
                {
                    maxExecutions = "";
                }
            }
        }
    }
}
