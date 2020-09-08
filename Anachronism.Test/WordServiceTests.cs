using System;
using Xunit;

using Anachronism;

namespace Anachronism.Test
{
    public class WordServiceTests
    {
        [Fact]
        public void Test_WordService_t_Tender()
        {
            var ws = new WordService();
            Assert.Same(ws.GetWordBeginningWith('t'), "Tender");
        }
    }
}
