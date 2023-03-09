using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL.Helpers
{
    public class SMTPConfig : ISMTPConfig {
        private bool _isConfigured;
        public bool IsConfigured {
            get { return _isConfigured; }
            set { _isConfigured = value; }
        }
    }
}
