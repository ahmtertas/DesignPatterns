using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorthm algorthm;

            Console.WriteLine("Mans");
            algorthm = new MenScoringAlgorithm();
            Console.WriteLine(algorthm.GenerateScore(10,new TimeSpan(0,2,34)));
          
            Console.WriteLine("Women");
            algorthm = new WomenScoringAlgorithm();
            Console.WriteLine(algorthm.GenerateScore(10, new TimeSpan(0, 2, 34)));


            Console.WriteLine("Children");
            algorthm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorthm.GenerateScore(10, new TimeSpan(0, 2, 34)));



            Console.ReadLine();

        }
    }

    abstract class ScoringAlgorthm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score,reduction);
        }

        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
        public abstract int CalculateOverallScore(int score, int reduction);
       
    }
    class MenScoringAlgorithm : ScoringAlgorthm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorthm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;

        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;

        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;

        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgorthm
    {
        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;

        }

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;

        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;

        }
    }
}
