using System;

namespace Implementation.DynamicProgramming
{
    public class Solutions
    {
        public static int CutRod(int[] p, int n)
        {
            if (n <= 0)
                return 0;

            int q = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                q = Math.Max(q, p[i] + CutRod(p, n - i - 1));
            }

            return q;
        }

        public static int MemoizedCutRod(int[] p, int n)
        {
            int[] r = new int[n + 1];
            for (int i = 0; i <= n; i++)
                r[i] = int.MinValue;

            return MemoizedCutRodAux(p, n, r);
        }

        private static int MemoizedCutRodAux(int[] p, int n, int[] r)
        {
            if (r[n] >= 0)
                return r[n];

            int q;
            if (n <= 0)
                q = 0;
            else
            {
                q = int.MinValue;
                for (int i = 0; i < n; i++)
                    q = Math.Max(q, p[i] + MemoizedCutRodAux(p, n - i - 1, r));
            }

            r[n] = q;
            return q;
        }

        public static int BottomUpCutRod(int[] p, int n)
        {
            int[] r = new int[n + 1];
            r[0] = 0;

            for (int j = 1; j <= n; j++)
            {
                int q = int.MinValue;
                for (int i = 0; i < j; i++)
                    q = Math.Max(q, p[i] + r[j - i - 1]);
                r[j] = q;
            }

            return r[n];
        }

        public static void PrintCutRodSolution(int[] p, int n, Action<int> func)
        {
            var result = ExtendedBottomUpCutRod(p, n);
            var s = result[1];

            while (n > 0)
            {
                if (s[n] == 0)
                {
                    n--;
                    continue;
                }
                func(s[n]);
                n = n - s[n];
            }
        }

        private static int[][] ExtendedBottomUpCutRod(int[] p, int n)
        {
            int[] r = new int[n + 1];
            int[] s = new int[n + 1];

            for (int j = 1; j <= n; j++)
            {
                int q = int.MinValue;
                for (int i = 0; i < j; i++)
                    if (q < p[i] + r[j - i - 1])
                    {
                        q = p[i] + r[j - i - 1];
                        s[j] = i + 1;
                    }
                r[j] = q;
            }

            return new int[][] { r, s };
        }

        public static int GetFibonacciNumber(int n)
        {
            if (n == 0 || n == 1)
                return n;

            int[] memo = new int[n+1];
            memo[0] = 0;
            memo[1] = 1;

            for(int i = 2; i <= n; i++)
                memo[i] = memo[i - 1] + memo[i - 2];

            return memo[n];
        }
    }
}
