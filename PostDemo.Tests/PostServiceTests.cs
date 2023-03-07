using NUnit.Framework;
using PostDemo.BL.Helpers;
using PostDemo.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace PostDemo.Tests {
    [TestFixture]
    public class PostServiceTests {
        private EmailService _emailService;
        private SMTPConfig _smtpConfig;
        private PostService _postService;

        [SetUp]
        public void Setup() {

        }


    }

}

