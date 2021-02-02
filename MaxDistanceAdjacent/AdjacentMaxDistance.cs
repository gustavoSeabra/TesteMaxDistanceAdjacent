using System;
using System.Collections.Generic;
using System.Linq;

namespace MaxDistanceAdjacent
{
    public class AdjacentMaxDistance
    {
        private List<(int, int, int)> tuplas;

        public AdjacentMaxDistance()
        {
            this.tuplas = new List<(int, int, int)>();
        }

        private void EncontrarTuplas(List<int> mat)
        {
            for (int i = 0; i < mat.Count; i++)
            {
                for (int j = i + 1; j < mat.Count; j++)
                {
                    var inicio = mat[i];
                    var fim = mat[j];

                    var existe = mat.FindAll(m => (m > inicio && m < fim) || (m < inicio && m > fim));

                    if (!existe.Any())
                        this.tuplas.Add((i, j, Math.Abs(mat[i] - mat[j])));
                }
            }
        }

        public int Solucao(List<int> mat, int index1, int index2)
        {
            this.EncontrarTuplas(mat);
            var valorAdjacente = this.tuplas.FirstOrDefault(f => f.Item1.Equals(index1) && f.Item2.Equals(index2));

            if (valorAdjacente != default((int, int, int)))
                return valorAdjacente.Item3;
            else
                return -2;
        }
    }
}
