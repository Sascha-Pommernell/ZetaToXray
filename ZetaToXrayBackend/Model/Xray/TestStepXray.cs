namespace ZetaToXrayBackend.Model.Xray
{
    public class TestStepXray
    {
        private string tcid = "";
        private string testStepAction = "";
        private string testStepData = "";
        private string testStepResult = "";

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

        public string TestStepAction
        {
            get
            {
                return testStepAction;
            }
            set
            {
                if (value != null)
                {
                    testStepAction = value;
                }
                else
                {
                    testStepAction = "";
                }
            }
        }

        public string TestStepData
        {
            get
            {
                return testStepData;
            }
            set
            {
                if (value != null)
                {
                    testStepData = value;
                }
                else
                {
                    testStepData = "";
                }
            }
        }

        public string TestStepResult
        {
            get
            {
                return testStepResult;
            }
            set
            {
                if (value != null)
                {
                    testStepResult = value;
                }
                else
                {
                    testStepResult = "";
                }
            }
        }
    }
}