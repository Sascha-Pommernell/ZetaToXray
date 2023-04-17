using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZetaToXrayBackend.Model
{
    public class PreConditionXray
    {
        private string assigen = "";
        private string condition = "";
        private string description = "";
        private string issueType = "";
        private string reporter = "";
        private string summary = "";
        private string testsAssociatedPreCondition = "";
        private string type = "";

        public string Assigen
        {
            get
            {
                return assigen;
            }
            set
            {
                if (value != null)
                {
                    assigen = value;
                }
                else
                {
                    assigen = "";
                }
            }
        }

        public string Condition
        {
            get
            {
                return condition;
            }
            set
            {
                if (value != null)
                {
                    condition = value;
                }
                else
                {
                    condition = "";
                }
            }
        }

        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                if (value != null)
                {
                    description = value;
                }
                else
                {
                    description = "";
                }
            }
        }

        public string IssueType
        {
            get
            {
                return issueType;
            }
            set
            {
                if (value != null)
                {
                    issueType = value;
                }
                else
                {
                    issueType = "";
                }
            }
        }

        public string Reporter
        {
            get
            {
                return reporter;
            }
            set
            {
                if (value != null)
                {
                    reporter = value;
                }
                else
                {
                    reporter = "";
                }
            }
        }

        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                if (value != null)
                {
                    summary = value;
                }
                else
                {
                    summary = "";
                }
            }
        }

        public string TestsAssociatedPreCondition
        {
            get
            {
                return testsAssociatedPreCondition;
            }
            set
            {
                if (value != null)
                {
                    testsAssociatedPreCondition = value;
                }
                else
                {
                    testsAssociatedPreCondition = "";
                }
            }
        }

        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                if (value != null)
                {
                    type = value;
                }
                else
                {
                    type = "";
                }
            }
        }
    }
}
