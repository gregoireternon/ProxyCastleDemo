using Castle.DynamicProxy;
using ProxyPerformance.Extensions;
using ProxyPerformance.ProxyTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using Vegetables;

namespace ProxyPerformance
{
    class Program
    {
        static List<long> ticksGeneration = new List<long>();
        static List<long> ticksdejaGenere = new List<long>();
        static List<long> ticksNoProxy = new List<long>();

        static void Main(string[] args)
        {
            WriteSeparatorLine();
            Console.WriteLine("| Type        | Génération  | Déja généré | Sans Proxy  |");
            WriteSeparatorLine();
            
            int counter = 0;
            while (counter++ < 1000)
            {
                IVegetable target;

                // Ici j'évite le topimachin car mon programme ne digère pas :)
                do
                {
                    target = new VegatableFactory().Provide();
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

                Console.WriteLine("| {0, -11} " +
                    "| {1,11} | {2,11} | {3,11} |",
                    target.GetNom(),
                    swGeneration.Elapsed.Ticks.ToMilliseconds(),
                    swDejaGenere.Elapsed.Ticks.ToMilliseconds(),
                    swNoProxy.Elapsed.Ticks.ToMilliseconds());
                WriteSeparatorLine();

                ticksGeneration.Add(swGeneration.Elapsed.Ticks);
                ticksdejaGenere.Add(swDejaGenere.Elapsed.Ticks);
                ticksNoProxy.Add(swNoProxy.Elapsed.Ticks);

                Thread.Sleep(500);
            }


            Console.WriteLine();
            WriteSeparatorLine();
            Console.WriteLine("| Moyennes                                              |");
            WriteSeparatorLine();
            Console.WriteLine(" - Avec génération du proxy : {0,11}", ticksGeneration.Average().ToMilliseconds());
            Console.WriteLine(" - Avec un proxy généré     : {0,11}", ticksdejaGenere.Average().ToMilliseconds());
            Console.WriteLine(" - Sans proxy               : {0,11}", ticksNoProxy.Average().ToMilliseconds());
            Console.Read();
        }

        static void WriteSeparatorLine()
        {
            Console.WriteLine("---------------------------------------------------------");
        }
    }
}
