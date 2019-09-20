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
    public class ScenarioMix : AScenario
    {
        private ProxyGenerator _proxyGenerator = new ProxyGenerator();
        private List<long> _ticksGeneration = new List<long>();
        private List<long> _ticksdejaGenere = new List<long>();
        private List<long> _ticksNoProxy = new List<long>();

        public ScenarioMix() : base() { }

        protected override string GetHeader()
        {
            return "| Type        | Génération  | Déja généré | Sans Proxy  |";
        }

        public override void Run(IVegetable target)
        {
            // Exécution avec génération du proxy
            var swGeneration = new Stopwatch();
            swGeneration.Start();

            var proxy = _proxyGenerator.CreateInterfaceProxyWithTarget<IVegetable>(target, new BasicInterceptor());
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

            _ticksGeneration.Add(swGeneration.Elapsed.Ticks);
            _ticksdejaGenere.Add(swDejaGenere.Elapsed.Ticks);
            _ticksNoProxy.Add(swNoProxy.Elapsed.Ticks);
        }

        public override void DisplayAverageRunningTime()
        {
            Console.WriteLine();
            WriteSeparatorLine();
            Console.WriteLine("| Moyennes                                              |");
            WriteSeparatorLine();
            Console.WriteLine(" - Avec génération du proxy : {0,11}", _ticksGeneration.Average().ToMilliseconds());
            Console.WriteLine(" - Avec un proxy généré     : {0,11}", _ticksdejaGenere.Average().ToMilliseconds());
            Console.WriteLine(" - Sans proxy               : {0,11}", _ticksNoProxy.Average().ToMilliseconds());
        }
    }
}
