using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetablesEnumerator.ProxyTools
{
    public class MaskInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            if ("GetNom".Equals(invocation.Method.Name))
            {
                invocation.Proceed();
                invocation.ReturnValue = invocation.ReturnValue + " masqué";
            }
        }
    }
}
