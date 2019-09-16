using Castle.DynamicProxy;
using ProxyPerformance.ProxyTools;
using System;
using System.Diagnostics;
using System.Threading;
using Vegetables;

namespace ProxyPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IVegetable target;

                // Ici j'évite le topimachin car mon programme ne digère pas :)
                do
                {
                    target = new VegetableFactory().Provide();
                }
                while (target is Topinambour);

                // Exécution avec génération du proxy
                var swGeneration = new Stopwatch();
                swGeneration.Start();

                var pg = new ProxyGenerator();
                var proxy = pg.CreateInterfaceProxyWithTarget<IVegetable>(target, new BasicInterceptor());
                proxy.GetNom();

                swGeneration.Stop();
                // ----------------------------------

                // Exécution avec proxy déjà généré
                var swDejaGenere = new Stopwatch();
                swDejaGenere.Start();

                proxy.GetNom();

                swDejaGenere.Stop();
                // ----------------------------------

                // Exécution sans proxy
                var swNoProxy = new Stopwatch();
                swNoProxy.Start();

                target.GetNom();

                swNoProxy.Stop();
                // ----------------------------------

                Console.WriteLine($"{swGeneration.Elapsed} - {swDejaGenere.Elapsed} - {swNoProxy.Elapsed} - {target.GetNom()}");
                Thread.Sleep(2000);
            }
        }
    }
}
