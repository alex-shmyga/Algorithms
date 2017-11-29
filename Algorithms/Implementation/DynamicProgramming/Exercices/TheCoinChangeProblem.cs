namespace Implementation.DynamicProgramming.Exercices
{
    /// <summary>
    /// https://www.hackerrank.com/challenges/coin-change/problem
    /// </summary>
    public class TheCoinChangeProblem
    {
        public static long GetWays(int n, long[] p)
        {
            long[] memo = new long[n + 1];
            memo[0] = 1;

            for (long j = 0; j < p.Length; j++)
                for (long i = p[j]; i <= n; i++)
                    memo[i] += memo[i - p[j]];

            return memo[n];
        }
    }
}
