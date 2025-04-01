using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RST_Algoritmi_ProgVaje2025
{
    public class DynamicProgramming
    {
        /// <summary>
        /// Izračun binomskega simbola s Pascalovo identiteto v
        /// običajni rekurzivni funkciji.
        /// </summary>
        public static long PascalovaIdentiteta(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            return PascalovaIdentiteta(n - 1, k - 1) + PascalovaIdentiteta(n - 1, k);
        }

        /// <summary>
        /// Izračun binomskega simbola s Pascalovo identiteto v
        /// rekurzivni funkciji z memoizacijo.
        /// </summary>
        public static long PascalovaIdentitetaMemo(int n, int k, Dictionary<(int N, int K), long> dicStore)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            if (!dicStore.ContainsKey((n - 1, k - 1)))
            {
                dicStore[(n - 1, k - 1)] = PascalovaIdentitetaMemo(n - 1, k - 1, dicStore);
            }
            if (!dicStore.ContainsKey((n - 1, k)))
            {
                dicStore[(n - 1, k)] = PascalovaIdentitetaMemo(n - 1, k, dicStore);
            }

            return dicStore[(n - 1, k - 1)] + dicStore[(n - 1, k)];
        }

        /// <summary>
        /// Izračun binomskega simbola s Pascalovo identiteto s tabulacijo.
        /// </summary>
        public static long PascalovaIdentitetaTabu(int n, int k)
        {
            if (k == 0 || k == n)
            {
                return 1;
            }

            Dictionary<(int, int), long> dicStore = new Dictionary<(int, int), long>();
            dicStore[(1, 1)] = 1;

            // Vrednosti n
            for (int i = 2; i <= n; i++)
            {
                // Diagonalne elemente zapišemo ločeno
                dicStore[(i, i)] = 1;
                // Elemente prve vrstice tudi
                dicStore[(i, 1)] = i;

                // Vrednosti k
                for (int j = 2; j <= Math.Min(i - 1, k); j++)
                {
                    dicStore[(i, j)] = dicStore[(i - 1, j - 1)] + dicStore[(i - 1, j)];
                }
            }

            return dicStore[(n, k)];
        }
    }
}
