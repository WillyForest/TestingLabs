using ConsoleLab1Test.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _ConsoleLab1Test_.UnitTests
{
    [TestFixture]
    public class ExceptionManagerTests
    {
        [Test]
        public void IsExceptionCritical_CriticalExceptions_ReturnsTrue()
        {
            ICriticalExceptionsManager criticalExceptionsManager = new FakeCriticalExceptionsManager(true);
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsManager);
            FileNotFoundException exception = new FileNotFoundException();

            bool result = exceptionManager.IsExceptionCritical(exception);

            Assert.True(result);
        }

        [Test]
        public void IsExceptionCritical_NonCriticalExceptions_ReturnsFalse()
        {
            ICriticalExceptionsManager criticalExceptionsManager = new FakeCriticalExceptionsManager(true);
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsManager);
            //ArithmeticException exception = new ArithmeticException(); 
            FileNotFoundException exception = new FileNotFoundException();

            bool result = exceptionManager.IsExceptionCritical(exception);

            Assert.False(result);
        }

        [Test]
        public void ProcessException_CriticalExceptions_ReturnsTrue()
        {
            ICriticalExceptionsManager criticalExceptionsManager = new FakeCriticalExceptionsManager(true);
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsManager);
            exceptionManager.SendExceptionService = new FakeSendExceptionService(true);
            FileNotFoundException exception = new FileNotFoundException();
            int before = exceptionManager.GetCriticalExceptionsCount();

            exceptionManager.ProcessException(exception);

            int after = exceptionManager.GetCriticalExceptionsCount();
            Assert.True(before != after);
        }

        [Test]
        public void ProcessException_NonCriticalExceptions_ReturnsTrue()
        {
            ICriticalExceptionsManager criticalExceptionsManager = new FakeCriticalExceptionsManager(true);
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsManager);
            exceptionManager.SendExceptionService = new FakeSendExceptionService(true);
            FileNotFoundException exception = new FileNotFoundException();
            int before = exceptionManager.GetNonCriticalExceptionsCount();

            exceptionManager.ProcessException(exception);

            int after = exceptionManager.GetNonCriticalExceptionsCount();
            Assert.True(before == after);
        }

        [Test]
        [TestCase(2, 3)]
        [TestCase(4, 6)]
        public void ProcessException_CriticalExceptionsCounterWorking_ReturnsTrue(int criticalCount, int normalCount)
        {
            ICriticalExceptionsManager criticalExceptionsManager = new FakeCriticalExceptionsManager(true);
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsManager);
            exceptionManager.SendExceptionService = new FakeSendExceptionService(true);
            FileNotFoundException criticalException = new FileNotFoundException();
            ArithmeticException normalException = new ArithmeticException();
            int before = exceptionManager.GetCriticalExceptionsCount();

            for (int i = 0; i < criticalCount; i++)
            {
                exceptionManager.ProcessException(criticalException);
            }
            for (int i = 0; i < normalCount; i++)
            {
                exceptionManager.ProcessException(normalException);
            }


            int after = exceptionManager.GetCriticalExceptionsCount();
            Assert.True((before + criticalCount) == after);
        }

    }

    //public class TestClass : ExceptionManager
    //{
    //    public ICriticalExceptionsManager _manager;

    //    public override ICriticalExceptionsManager getCriticalExceptionsManager()
    //    {
    //        return _manager;
    //    }
        
    //    public void IsExceptionCritical_CriticalExceptions_ReturnsTrue()
    //    {
    //        FileNotFoundException exception = new FileNotFoundException();

    //        bool result = _manager.IsExceptionCritical(exception);

    //        Assert.True(result);
    //    }
    //}

    public class FakeCriticalExceptionsManager : ICriticalExceptionsManager
    {
        bool _returnsTrue = true;
        public FakeCriticalExceptionsManager(bool returnsTrue = true)
        {
            _returnsTrue = returnsTrue;
        }

        public List<string> GetCriticalExceptions()
        {
            return new List<string>();
        }

        public bool IsExceptionCritical(Exception exception)
        {
            return _returnsTrue;
        }
    }

    public class FakeSendExceptionService : ISendExceptionService
    {
        bool _returnsTrue = true;
        public FakeSendExceptionService(bool returnsTrue = true)
        {
            _returnsTrue = returnsTrue;
        }

        public bool SendWarningToServer(Exception exception)
        {
            return _returnsTrue;
        }
    }
}
