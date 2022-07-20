using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnAfter(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            bool success = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
                var task = invocation.ReturnValue as Task;
                if (task != null)
                    if (task.IsFaulted)
                    {
                        OnException(invocation, task.Exception);
                        success = false;
                    }
            }
            catch (System.Exception e)
            {
                OnException(invocation, e);
                success = false;
            }
            finally
            {
                if (success)
                    OnSuccess(invocation);
            }
            OnAfter(invocation);
        }
    }
}
