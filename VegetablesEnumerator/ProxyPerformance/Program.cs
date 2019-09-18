using System;
using System.Collections.Generic;
using Vegetables;
using VegetablesEnumerator.Scenarii;

namespace ProxyPerformance
{
    class Program
    {
        static List<long> ticksGeneration = new List<long>();
        static List<long> ticksdejaGenere = new List<long>();
        static List<long> ticksNoProxy = new List<long>();

        static void Main(string[] args)
        {
            // Génératin du proxy à chaque appel
            AScenario scenario = new Scenario1();

            // Utilisation d'un proxy généré
            //AScenario scenario = new Scenario2();

            // Aucune utilisation de proxy
            //AScenario scenario = new Scenario3();

            // Comparatif des 3 scenarii
            //AScenario scenario = new ScenarioMix();
            
            int counter = 0;
            while (counter++ < 1000)
            {
                IVegetable target;

                // Ici j'évite le topimachin et l'indigestion :)
                do
                {
                    target = new VegetableFactory().Provide();
                }
                while (target is Topinambour);

                scenario.Run(target);
                
                //Thread.Sleep(100);
            }

            scenario.DisplayAverageRunningTime();

            Console.Read();
        }
    }
}
