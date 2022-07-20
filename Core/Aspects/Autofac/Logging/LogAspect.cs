using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net;
using Core.Exceptions;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Logging
{
    public class LogAspect : MethodInterception
    {
        private readonly LoggerServiceBase _loggingType;
        public LogAspect(Type loggingType)
        {
            if (typeof(LoggerServiceBase).IsAssignableFrom(loggingType) == false)
            {
                throw new WrongLoggingTypeException();
            }
            _loggingType = (LoggerServiceBase)Activator.CreateInstance(loggingType);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggingType.Info(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
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
            return new LogDetail
            {
                MethodName = invocation.Method.Name,
                Parameters = parameters
            };
        }
    }
}
