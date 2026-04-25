using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMBUS.Domain.Entities
{
    public class EmailSetting
    {
        public string SmtpServer { get; set; } = string.Empty;
        public int Port { get; set; }
        public string SenderEmail { get; set; } = string.Empty;
        public string SenderName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
