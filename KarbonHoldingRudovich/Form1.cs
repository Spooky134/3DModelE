using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KarbonHoldingRudovich
{
    public partial class KarbonHolding : Form
    {
        private Model _model;
        public KarbonHolding() { InitializeComponent(); }
        private void KarbonHolding_Load(object sender, EventArgs e) { }
        
        private void Button_Click(object sender, EventArgs e)
        {
            DataUpdate();
            var button = (ButtonBase)sender;
            switch (button.Text)
            {
                case "Render":
                    _model = new Model(Data.A, Data.B, Data.C, Data.E,Data.F);
                    _model.Init();
                    _model.RenderFigure(picture);
                    break;
                case "Update":
                    _model.RenderFigure(picture);
                    break;
                case "Rotate":
                    _model.Rotate(Data.Alpha, Data.Beta, Data.Gama);
                    _model.RenderFigure(picture);
                    break;
                case "Move":
                    _model.Move(Data.Dx, Data.Dy, Data.Dz);
                    _model.RenderFigure(picture);
                    break;
                case "Scale":
                    _model.Scale(Data.Sx, Data.Sy, Data.Sz);
                    _model.RenderFigure(picture);
                    break;
                case "Frontal":
                    Data.FProj = 1;
                    break;
                case "Horizontal":
                    Data.FProj = 2;
                    break;
                case "Profile":
                    Data.FProj = 3;
                    break;
                case "Axonometric":
                    Data.FProj = 4;
                    break;
                case "Oblique":
                    Data.FProj = 5;
                    break;
                case "Perspective":
                    Data.FProj = 6;
                    break;
            };
        }
        private void DataUpdate()
        {
            Data.A = double.Parse(parametrA.Text);
            Data.B = double.Parse(parametrB.Text);
            Data.C = double.Parse(parametrC.Text);
            Data.E = double.Parse(parametrE.Text);
            Data.F = double.Parse(parametrF.Text);
            Data.Alpha = double.Parse(angelX.Text);
            Data.Beta = double.Parse(angelY.Text);
            Data.Gama = double.Parse(angelZ.Text);
            Data.Dx = double.Parse(Dx.Text);
            Data.Dy = double.Parse(Dy.Text);
            Data.Dz = double.Parse(Dz.Text);
            Data.Sx = double.Parse(Sx.Text);
            Data.Sy = double.Parse(Sy.Text);
            Data.Sz = double.Parse(Sz.Text);
            Data.AxonometricPsi = double.Parse(Psi.Text);
            Data.AxonometricFi = double.Parse(Phi.Text);
            Data.ObliqueL = double.Parse(L.Text);
            Data.ObliqueAlpha = double.Parse(Alpha.Text);
            Data.PerspectiveD = double.Parse(D.Text);
            Data.PerspectiveTeta = double.Parse(Teta.Text);
            Data.PerspectiveF = double.Parse(Fi.Text);
            Data.PerspectiveRo = double.Parse(Ro.Text);
        }
    }
}
