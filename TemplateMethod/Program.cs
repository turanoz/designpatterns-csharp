using System;

namespace TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;
            Console.WriteLine("Mans");
            algorithm = new MansScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8,new TimeSpan(0,2,34)));

            Console.WriteLine("Women");
            algorithm = new WomenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algorithm = new ChildrenScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(8, new TimeSpan(0, 2, 34)));
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits,TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverAllScore(score, reduction);
        }

        public abstract int CalculateOverAllScore(int score, int reduction);

        public abstract int CalculateReduction(TimeSpan time);

        public abstract int CalculateBaseScore(int hits);
    }

    class MansScoringAlgorithm:ScoringAlgorithm
    {
        public override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class WomenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 7;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class ChildrenScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverAllScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 9;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }
    }
}
