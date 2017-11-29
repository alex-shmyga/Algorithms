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
                {
                    q = Math.Max(q, p[i] + MemoizedCutRodAux(p, n - i - 1, r));
                }
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
    }
}
