using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common
{
    public class Retry
    {
        private readonly Action _action;
        private readonly TimeSpan _timeout;
        private readonly string _timeoutMessage;
        private readonly List<Type> _ignoredExceptionTypes = new List<Type>();
        private readonly TimeSpan _interval;

        public Retry(Action action, TimeSpan timeout, string timeoutMessage)
        {
            _action = action;
            _timeout = timeout;
            _timeoutMessage = timeoutMessage;
        }

        public Retry(Action action, TimeSpan timeout, TimeSpan interval, string timeoutMessage)
            : this(action, timeout, timeoutMessage)
        {
            _interval = interval;
        }

        public void Until(Func<bool> condition)
        {
            var expirationTime = DateTime.Now + _timeout;
            var counter = 1;

            while (DateTime.Now < expirationTime)
            {
                try
                {
                    if (counter > 1)
                        Thread.Sleep(_interval);
                    _action();
                }
                catch (Exception ex)
                {
                    var dispatchInfo = ExceptionDispatchInfo.Capture(ex);

                    if (!_ignoredExceptionTypes.Contains(ex.GetType()))
                        dispatchInfo.Throw();
                }

                counter++;

                if (condition())
                    return;
            }

            throw new TimeoutException(_timeoutMessage);
        }

        public void While(Func<bool> func)
        {
            Until(() => !func());
        }

        public Retry Ignore<TException>()
            where TException : Exception
        {
            _ignoredExceptionTypes.Add(typeof(TException));
            return this;
        }
    }
}
