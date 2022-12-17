using System;
using System.Collections.Generic;
using System.Text;

namespace KarbonHoldingRudovich
{
    class Points
    {
        public double[,] p = new double[1, 4] { { 0, 0, 0, 1 } };

        public double X
        {
            get => p[0, 0];
            set => p[0, 0] = value;
        }
        public double Y
        {
            get => p[0, 1];
            set => p[0, 1] = value;
        }
        public double Z
        {
            get => p[0, 2];
            set => p[0, 2] = value;
        }
        public Points(double x, double y, double z)
        {
            p = new double[1, 4] { { x, y, z, 1 } };
        }
        public Points()
        {
            //p = new double[1, 4] { { X, Y, Z, 1 } };
        }

        public static Points operator -(Points point)
        {
            return new Points(-point.X, -point.Y, -point.Z);
        }
        public static Points operator *(int sign, Points point)
        {
            return new Points(sign * point.X, sign * point.Y, sign * point.Z);
        }

        //умножение матриц
        public static Points MultiplicationMatrix(double[,] matrixA, double[,] matrixB)
        {
            if (matrixA.GetLength(1) != matrixB.GetLength(0)) { }
            var matrixC = new double[matrixA.GetLength(0), 4];
            for (var i = 0; i < matrixA.GetLength(0); i++)
            {
                for (var j = 0; j < matrixB.GetLength(1); j++)
                {
                    matrixC[i, j] = 0;

                    for (var k = 0; k < matrixA.GetLength(1); k++)
                    {
                        matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
                    }
                }
            }

            return new Points(matrixC[0, 0], matrixC[0, 1], matrixC[0, 2]);
        }
    }
}
