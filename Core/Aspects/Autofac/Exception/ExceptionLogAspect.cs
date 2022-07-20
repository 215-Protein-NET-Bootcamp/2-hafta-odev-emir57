using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Exceptions;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Exception
{
    public class ExceptionLogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggingService;
        public ExceptionLogAspect(Type loggingType)
        {
            if (typeof(LoggerServiceBase).IsAssignableFrom(loggingType) == false)
            {
                throw new WrongLoggingTypeException();
            }
            _loggingService = (LoggerServiceBase)Activator.CreateInstance(loggingType);
        }

        protected override void OnException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = new LogDetailWithException();
            logDetailWithException.ExceptionMessage = e.Message;
            logDetailWithException.MethodName = invocation.Method.Name;
            _loggingService.Error(GetLogDetail(logDetailWithException, invocation));
        }

        private LogDetailWithException GetLogDetail(LogDetailWithException logDetailWithException, IInvocation invocation)
        {
            var parameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                parameters.Add(new LogParameter
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Type = invocation.Arguments[i].GetType().ToString(),
                    Value = invocation.Arguments[i]
                });
            }
            logDetailWithException.Parameters = parameters;
            return logDetailWithException;
        }
    }
}
