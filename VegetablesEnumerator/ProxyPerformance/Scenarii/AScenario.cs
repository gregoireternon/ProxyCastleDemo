using System;
using System.Text;
using Vegetables;

namespace VegetablesEnumerator.Scenarii
{
    public abstract class AScenario
    {
        public AScenario()
        {
            WriteSeparatorLine();
            Console.WriteLine(GetHeader());
            WriteSeparatorLine();
        }

        public virtual void Run() { }

        public virtual void Run(IVegetable target) { }

        public virtual void DisplayAverageRunningTime() { }

        protected void WriteSeparatorLine()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append('-', GetHeader().Length);
            Console.WriteLine(sb.ToString());
        }

        protected virtual string GetHeader()
        {
            return "| Type        | Temps       |";
        }
    }
}
