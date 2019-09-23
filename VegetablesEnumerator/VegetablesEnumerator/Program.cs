using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;
using Vegetables;
using VegetablesEnumerator.ProxyTools;

namespace VegetablesEnumerator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var EntryAssembly = Assembly.Load("Crucifere");
    
            VegetableFactory factory = new VegetableFactory();
            ProxyGenerator proxyGenerator = new ProxyGenerator();

            while (true)
            {
                try
                {
                    IVegetable legume =  factory.Provide();

                    //Exemple avec Classe
                    //legume = proxyGenerator.CreateClassProxy(legume.GetType(), new BasicInterceptor()) as IVegetable;
                    //legume = proxyGenerator.CreateInterfaceProxyWithTarget(legume, new MaskInterceptor()) as IVegetable;

                    //Exemple avec interface seule
                    //legume = proxyGenerator.CreateInterfaceProxyWithoutTarget(typeof(IVegetable),new BasicInterceptor()) as IVegetable;

                    Console.WriteLine("Legume:" + legume.GetNom());
                    legume.Prix= 12;

                    Console.WriteLine("\n");
                }
                catch (Exception e)
                {
                    Console.WriteLine("GROSS ERROR:" + e.Message);
                    Console.WriteLine(e.ToString());
                }
                Thread.Sleep(2000);
            }
        }










    }
}
