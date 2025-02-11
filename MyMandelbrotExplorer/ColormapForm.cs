using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MathNet.Numerics;
using MathNet.Numerics.Interpolation;

namespace MandelbrotApp
{
    public partial class ColormapForm : Form
    {
        public ColormapForm(Form1 parent)
        {
            this.parent = parent;
            InitializeComponent();
        }

        private void get_colormap()
        {
            //for (int m = 0; m < colors.Length; m++)
            //    grad_img.SetPixel(m, 0, colors[m]);
            double[] aR = new double[8];
            double[] aG = new double[8];
            double[] aB = new double[8];
            aR[0] = picked_colors[0].R;
            aG[0] = picked_colors[0].G;
            aB[0] = picked_colors[0].B;
            for (int e = 0; e < 5; e++)
            {
                aR[e + 1] = picked_colors[e].R;
                aG[e + 1] = picked_colors[e].G;
                aB[e + 1] = picked_colors[e].B;
            }
            aR[6] = aR[0];
            aG[6] = aG[0];
            aB[6] = aB[0];
            aR[7] = aR[0];
            aG[7] = aG[0];
            aB[7] = aB[0];
            var csR = CubicSpline.InterpolatePchip(xo, aR);
            var csG = CubicSpline.InterpolatePchip(xo, aG);
            var csB = CubicSpline.InterpolatePchip(xo, aB);
            Color[] new_colormap = new Color[767];
            int n = 0;
            for (int e = 110; e < 877; e++)
            {
                new_colormap[n] = Color.FromArgb((int)csR.Interpolate(x[e]), (int)csG.Interpolate(x[e]), (int)csB.Interpolate(x[e]));
                grad_img.SetPixel(n, 0, new_colormap[n]);
                n++;
            }
            set_show_img();
        }

        private void set_show_img()
        {
            Bitmap show_img = new Bitmap(colormapPictureBox.Width, colormapPictureBox.Height);
            using (Graphics grD = Graphics.FromImage(show_img))
            {
                for (int e = 0; e < show_img.Height; e++)
                    grD.DrawImage(grad_img, 0, e);
            }
            this.colormapPictureBox.Image = show_img;
        }

        private void open_colormap()
        {
            grad_img = (Bitmap)Bitmap.FromFile(starting_colormap_fname);
            set_show_img();
            for (int e = 0; e < 5; e++)
                picked_colors[e] = grad_img.GetPixel(col_arr_idx[e], 0);
        }

        public void set_current(string fname)
        {
            starting_colormap_fname = fname;
        }

        private void load_colormap(string fname)
        {
            this.parent.add_colormap(fname);
        }

        private void set_PickColorButtons() 
        { 
                Pick1Button.BackColor = picked_colors[0];
                Pick2Button.BackColor = picked_colors[1];
                Pick3Button.BackColor = picked_colors[2];
                Pick4Button.BackColor = picked_colors[3];
                Pick5Button.BackColor = picked_colors[4];
        }

        Form1 parent;
        ColorDialog colorDialog = new ColorDialog();
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        Bitmap grad_img = new Bitmap(767, 1);
        static Color def_color = Color.White;
        Color[] picked_colors = new Color[] {def_color, def_color, def_color, def_color, Color.Black};
        string starting_colormap_fname = "";
        static double[] xo = new double[] { -0.1425, 0, 0.16, 0.42, 0.6425, 0.8575, 1, 1.16 };
        static double[] x = Generate.LinearSpaced(1000, xo[0], xo[7]);
        int[] col_arr_idx = new int[] { 0, 123, 317, 491, 656 };

        private void ColormapForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void ColormapForm_Load(object sender, EventArgs e)
        {
            saveFileDialog.Filter = "PNG Image|*.png";
            saveFileDialog.Title = "Save Colormap";
            saveFileDialog.InitialDirectory = this.parent.colormap_path;
            if (starting_colormap_fname != "")
            {
                open_colormap();
                set_PickColorButtons();
            }
            else
            {
                set_PickColorButtons();
                get_colormap();
            }
        }

        private void get_color(int n)
        {
            DialogResult res = colorDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                picked_colors[n] = colorDialog.Color;
            }
            get_colormap();
        }

        private void Pick1Button_Click(object sender, EventArgs e)
        {
            get_color(0);
            Pick1Button.BackColor = picked_colors[0];
        }

        private void Pick2Button_Click(object sender, EventArgs e)
        {
            get_color(1);
            Pick2Button.BackColor = picked_colors[1];
        }

        private void Pick3Button_Click(object sender, EventArgs e)
        {
            get_color(2);
            Pick3Button.BackColor = picked_colors[2];
        }

        private void Pick4Button_Click(object sender, EventArgs e)
        {
            get_color(3);
            Pick4Button.BackColor = picked_colors[3];
        }

        private void Pick5Button_Click(object sender, EventArgs e)
        {
            get_color(4);
            Pick5Button.BackColor = picked_colors[4];
        }

        private void saveLoadButton_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
            if (saveFileDialog.FileName != "")
            {
                grad_img.Save(saveFileDialog.FileName);
                load_colormap(saveFileDialog.FileName);
                this.Close();
            }
        }

        private void confirmLoadButton_Click(object sender, EventArgs e)
        {

        }
    }
}
