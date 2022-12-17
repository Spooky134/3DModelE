using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Math;

namespace KarbonHoldingRudovich
{
    internal class Model
    {
        private readonly Points[] _basement= new Points[24];
        private readonly Points[] _buffer = new Points[24];

        Rendering r = new Rendering();

        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double E { get; set; }
        public double F { get; set; }

        public Model(double a, double b, double c,double e, double f)
        {
            A = a;
            B = b;
            C = c;
            E = e;
            F = f;
        }

        public void Init()
        {
            _basement[0]= new Points(0, 0, 0);
            _basement[1] = new Points(B, 0, 0);
            _basement[2] = new Points(B, -A, 0);
            _basement[3] = new Points(B - F, -A, 0);
            _basement[4] = new Points(B - F, -(A + E), 0);
            _basement[5] = new Points(B, -(A + E), 0);
            _basement[6] = new Points(B, -((2 * A) + E), 0);
            _basement[7] = new Points(B - F, -((2 * A) + E), 0);
            _basement[8] = new Points(B - F, -((2 * A) + (2 * E)), 0);
            _basement[9] = new Points(B, -((2 * A) + (2 * E)), 0);
            _basement[10] = new Points(B, -((2 * A) + (2 * E) + A), 0);
            _basement[11] = new Points(0, -((2 * A) + (2 * E) + A), 0);
            _basement[12] = new Points(0, -((2 * A) + (2 * E) + A), C);
            _basement[13] = new Points(B, -((2 * A) + (2 * E) + A), C);
            _basement[14] = new Points(B, -((2 * A) + (2 * E)), C);
            _basement[15] = new Points(B - F, -((2 * A) + (2 * E)), C);
            _basement[16] = new Points(B - F, -((2 * A) + E), C);
            _basement[17] = new Points(B, -((2 * A) + E), C);
            _basement[18] = new Points(B, -(A + E), C);
            _basement[19] = new Points(B - F, -(A + E), C);
            _basement[20] = new Points(B - F, -A, C);
            _basement[21] = new Points(B, -A, C);
            _basement[22] = new Points(B, 0, C);
            _basement[23] = new Points(0, 0, C);
        }

        //преобразования
        public void Rotate(double alpha, double beta, double gama)
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _basement[i] = _basement[i].Rotate(alpha, beta, gama);
            }
        }
        public void Scale(double sx, double sy, double sz)
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _basement[i] = _basement[i].Scale(sx, sy, sz);
            }
        }
        public void Move(double dx, double dy, double dz)
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _basement[i] = _basement[i].Move(dx, dy, dz);
            }
        }

        //отрисовка
        public void RenderFigure(PictureBox picture)
        {
            Projection();
            Render(picture);
        }
        public void Render(PictureBox picture)
        { 
            r.Gener(picture);
            r.Render(_buffer[0], _buffer[1],Color.BlueViolet);
           r.Render(_buffer[1], _buffer[2], Color.BlueViolet);
           r.Render(_buffer[2], _buffer[3], Color.BlueViolet);
           r.Render(_buffer[3], _buffer[4], Color.BlueViolet);
           r.Render(_buffer[4], _buffer[5], Color.BlueViolet);
           r.Render(_buffer[5], _buffer[6], Color.BlueViolet);
           r.Render(_buffer[6], _buffer[7], Color.BlueViolet);
           r.Render(_buffer[7], _buffer[8], Color.BlueViolet);
           r.Render(_buffer[8], _buffer[9], Color.BlueViolet);
           r.Render(_buffer[9], _buffer[10], Color.BlueViolet);
           r.Render(_buffer[10], _buffer[11], Color.BlueViolet);
           r.Render(_buffer[11], _buffer[12], Color.BlueViolet);
           r.Render(_buffer[12], _buffer[13], Color.BlueViolet);
           r.Render(_buffer[13], _buffer[14], Color.BlueViolet);
           r.Render(_buffer[14], _buffer[15], Color.BlueViolet);
           r.Render(_buffer[15], _buffer[16], Color.BlueViolet);
           r.Render(_buffer[16], _buffer[17], Color.BlueViolet);
           r.Render(_buffer[17], _buffer[18], Color.BlueViolet);
           r.Render(_buffer[18], _buffer[19], Color.BlueViolet);
           r.Render(_buffer[19], _buffer[20], Color.BlueViolet);
           r.Render(_buffer[20], _buffer[21], Color.BlueViolet);
           r.Render(_buffer[21], _buffer[22], Color.BlueViolet);
           r.Render(_buffer[22], _buffer[23], Color.BlueViolet);
           r.Render(_buffer[23], _buffer[0], Color.BlueViolet);
           r.Render(_buffer[1], _buffer[22], Color.BlueViolet);
           r.Render(_buffer[2], _buffer[21], Color.BlueViolet);
           r.Render(_buffer[3], _buffer[20], Color.BlueViolet);
           r.Render(_buffer[4], _buffer[19], Color.BlueViolet);
           r.Render(_buffer[5], _buffer[18], Color.BlueViolet);
           r.Render(_buffer[6], _buffer[17], Color.BlueViolet);
           r.Render(_buffer[7], _buffer[16], Color.BlueViolet);
           r.Render(_buffer[8], _buffer[15], Color.BlueViolet);
           r.Render(_buffer[9], _buffer[14], Color.BlueViolet);
           r.Render(_buffer[10], _buffer[13], Color.BlueViolet);
           r.Render(_buffer[0], _buffer[11], Color.BlueViolet);
           r.Render(_buffer[23], _buffer[12], Color.BlueViolet);
        }

        public void Projection()
        {
            switch (Data.FProj)
            {
                case 1:
                    Array.Copy(_basement, _buffer, _basement.Length);
                    break;
                case 2:
                    Horizontal();
                    break;
                case 3:
                    Profile();
                    break;
                case 4:
                    Axonometric(Data.AxonometricPsi, Data.AxonometricFi);
                    break;
                case 5:
                    Oblique(Data.ObliqueL, Data.ObliqueAlpha);
                    break;
                case 6:
                    Perspective(Data.PerspectiveD, Data.PerspectiveTeta, Data.PerspectiveF, Data.PerspectiveRo);
                    break;
            };
        }
        public void Horizontal()
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _buffer[i] = _basement[i].HorizontalProjection();
            }
        }
        public void Profile()
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _buffer[i] = _basement[i].ProfileProjection();
            }
        }
        public void Axonometric(double psi, double fi)
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _buffer[i] = _basement[i].AxonometricProjection(psi, fi);
            }
        }
        public void Oblique(double l, double alpha)
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _buffer[i] = _basement[i].ObliqueProjection(l, alpha);
            }
        }
        public void Perspective(double d, double teta, double fi, double ro)
        {
            Species(teta, fi, ro);
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _buffer[i] = _buffer[i].PerspectiveProjection(d);
            }
        }
        public void Species(double teta, double fi, double ro)
        {
            for (var i = 0; i < _basement.GetLength(0); i++)
            {
                _buffer[i] = _basement[i].SpeciesTransformation(teta, fi, ro);
            }
        }
    }
}
