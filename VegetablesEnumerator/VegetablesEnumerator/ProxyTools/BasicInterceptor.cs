using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetablesEnumerator.ProxyTools
{
    public class BasicInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {            
            invocation.Proceed();
        }
    }
}
