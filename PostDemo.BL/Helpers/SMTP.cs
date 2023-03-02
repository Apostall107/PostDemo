using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDemo.BL.Helpers
{
    public class SMTP : IDisposable
    {
        private bool isDisposed;

        public void Dispose()
        {
            isDisposed = true;
        }

        public void Send()
        {
            Console.WriteLine("Done");
        }
    }
}
