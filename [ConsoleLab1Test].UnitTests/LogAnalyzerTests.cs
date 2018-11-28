using ConsoleLab1Test.Helpers;
using NUnit.Framework;

namespace ConsoleLab1Test.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        [Test]
        public void IsValidFileName_BadExtensions_ReturnsFalse()
        {
            LogAnalyzer logAnalyzer = new LogAnalyzer();

            bool result = logAnalyzer.IsValidLogFileName("filewithbadextension.foo");

            Assert.False(result);

        }
    }
}
