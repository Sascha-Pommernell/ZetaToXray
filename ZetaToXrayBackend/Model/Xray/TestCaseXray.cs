namespace ZetaToXrayBackend.Model.Xray
{
    public class TestCaseXray
    {
        private string tcid = "";
        private string testSummary = "";
        private string testPriority = "";
        private string discription = "";
        private string components = "";
        private string action = "";
        private string data = "";
        private string result = "";
        private string maxExecutions = "";

        public string TCID
        {
            get
            {
                return tcid;
            }
            set
            {
                if (value != null)
                {
                    tcid = value;
                }
                else
                {
                    tcid = "";
                }
            }
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

        public string Action
        {
            get
            {
                return action;
            }
            set
            {
                if (value != null)
                {
                    action = value;
                }
                else
                {
                    action = "";
                }
            }
        }

        public string Data
        {
            get
            {
                return data;
            }
            set
            {
                if (value != null)
                {
                    data = value;
                }
                else
                {
                    data = "";
                }
            }
        }

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                if (value != null)
                {
                    result = value;
                }
                else
                {
                    result = "";
                }
            }
        }

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
