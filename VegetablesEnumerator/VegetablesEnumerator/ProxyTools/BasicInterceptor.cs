using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vegetables;

namespace VegetablesEnumerator.ProxyTools
{
    public class BasicInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Type de l'objet appelé: " + invocation.TargetType);
            Console.WriteLine("Méthode appelée: " + invocation.Method.Name);
            Console.WriteLine("paramètres: " );
            invocation.Arguments.ToList().ForEach(a => Console.WriteLine("\t" + a.ToString()));
            try {
                invocation.Proceed();
            }
            catch (VegetableException e)
            {
                Console.WriteLine("Ah, là il y a eu une erreur...");
            }
        }
    }
}
