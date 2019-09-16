using Castle.DynamicProxy;

namespace ProxyPerformance.ProxyTools
{
    public class BasicInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
