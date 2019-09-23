using Castle.DynamicProxy;
using ProxyPerformance.Extensions;
using ProxyPerformance.ProxyTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Vegetables;

namespace VegetablesEnumerator.Scenarii
{
    public class Scenario1 : AScenario
    {
        private ProxyGenerator _proxyGenerator = new ProxyGenerator();
        private List<long> _ticks = new List<long>();

        public Scenario1() : base() { }

        public override void Run(IVegetable target)
        {
            var sw = new Stopwatch();
            sw.Start();

            var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget<IVegetable>(target, new PerfInterceptor());
            proxy.GetNom();

            sw.Stop();

            Console.WriteLine("| {0, -11} | {1,11} |",
                    target.GetNom(),
                    sw.ElapsedTicks.ToMilliseconds());
            WriteSeparatorLine();

            _ticks.Add(sw.ElapsedTicks);
        }

        public override void DisplayAverageRunningTime()
        {
            Console.WriteLine();
            WriteSeparatorLine();
            Console.WriteLine("| Moyenne                   |");
            Console.WriteLine(" - Avec génération du proxy : {0,11}", _ticks.Average().ToMilliseconds());
        }
    }
}
