using Castle.DynamicProxy;

namespace ProxyPerformance.ProxyTools
{
    public class PerfInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }
}
