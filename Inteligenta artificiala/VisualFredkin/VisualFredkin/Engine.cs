﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisualFredkin
{
    public static class Engine
    {
        public static PictureBox display;
        public static PictureBox[,] pbMatrix;
        public static int[,] matrix, temp;
        public static int n, length;

        public static void Init(PictureBox p)
        {
            //modificati valoarea lui n pentru rezultate diferite.
            n = 21;
            length = p.Width / n;
            display = p;

            pbMatrix = new PictureBox[n, n];
            matrix = new int[n + 2, n + 2];
            temp = new int[n + 2, n + 2];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    pbMatrix[i, j] = new PictureBox();
                    pbMatrix[i, j].Parent = display;
                    pbMatrix[i, j].Size = new Size(length, length);
                    pbMatrix[i, j].Location = new Point(i * length, j * length);
                }

            //puteti modifica si valorile initiale ale acestei matrice pentru rezultate diferite
            matrix[n / 2 + 1, n / 2 + 1] = 1;
            matrix[n / 2, n / 2] = 1;
            matrix[n / 2 + 2, n / 2] = 1;
            matrix[n / 2, n / 2 + 2] = 1;
            matrix[n / 2 + 2, n / 2 + 2] = 1;

            Afisare();
        }

        public static void Step()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    //tema: modificati legea fiecarui pas pentru rezultate cat mai impresionante.
                    //trebuie modificat doar intre acoladele astea, eventual si n mai sus.
                    //primele 5 cele mai frumoase modele obtinute primesc un punct in plus la examen.
                    int s = matrix[i - 1, j];
                    s += matrix[i, j - 1];
                    s += matrix[i + 1, j];
                    s += matrix[i, j + 1];

                    if (s % 2 == 0)
                        temp[i, j] = 0;
                    else
                        temp[i, j] = 1;
                }
            for (int i = 0; i < n + 2; i++)
                for (int j = 0; j < n + 2; j++)
                {
                    matrix[i, j] = temp[i, j];
                    temp[i, j] = 0;
                }
            Afisare();
        }

        public static void Afisare()
        {
            for (int i = 1; i <= n; i++)
                for (int j = 1; j <= n; j++)
                {
                    if (matrix[i, j] == 1)
                        pbMatrix[i - 1, j - 1].BackColor = Color.Purple;
                    else
                        pbMatrix[i - 1, j - 1].BackColor = Color.White;
                }
        }
    }
}
