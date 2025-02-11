using FFMediaToolkit.Encoding;
using FFMediaToolkit.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MandelbrotApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        uint get_mandelbrot_iterations(double c_real, double c_imag, ushort IT)
        {
            double real = c_real, imag = c_imag, real_sq, imag_sq;
            for (uint n = 0; n < IT; n++)
            {
                real_sq = real * real;
                imag_sq = imag * imag;
                if (real_sq + imag_sq > 4)
                    return n;
                imag = 2 * real * imag + c_imag;
                real = real_sq - imag_sq + c_real;
            }
            return IT;
        }

        uint get_julia_iterations(double c_real, double c_imag, ushort IT)
        {
            double real = c_real, imag = c_imag, real_sq, imag_sq;
            double j_real = julia_real, j_imag = julia_imag;
            for (uint n = 0; n < IT; n++)
            {
                real_sq = real * real;
                imag_sq = imag * imag;
                if (real_sq + imag_sq > 4)
                    return n;
                imag = 2 * real * imag + j_imag;
                real = real_sq - imag_sq + j_real;
            }
            return IT;
        }

        void getMandelbrotSet_chunk(ushort max_iter, int chunk) //orizontal slices
        {
            //Bitmap img = render_images[chunk];
            double oriz_step = rect.w / WIDTH;
            double vert_step = rect.h / HEIGHT;
            double left = rect.left;
            double real, imag = rect.top + vert_step - vert_step * chunk * HEIGHT / thread_count;
            int max = ((chunk + 1) * HEIGHT / thread_count) * WIDTH;
            for (int y = chunk * HEIGHT / thread_count * WIDTH; y < max; y += WIDTH)
            {
                real = left;
                imag -= vert_step;
                for (int x = 0; x < WIDTH; x++)
                {
                    real += oriz_step;
                    //img.SetPixel(x, y, colormap[((int)(Math.Sqrt(get_mandelbrot_iterations(real, imag, max_iter) + 10) * 256)) % 767]);
                    int idx = ((int)(Math.Sqrt(get_mandelbrot_iterations(real, imag, max_iter) + 10) * 256)) * 3 % 2301;
                    int i = 3 * (x + y);
                    mand_data[i++] = ll_colormap[idx++];
                    mand_data[i++] = ll_colormap[idx++];
                    mand_data[i] = ll_colormap[idx];
                }
            }
            //render_images[chunk] = img;
        }

        void getJuliaSet_chunk(ushort max_iter, int chunk) //orizontal slices
        {
            //Bitmap img = render_images[chunk];
            double oriz_step = rect.w / WIDTH;
            double vert_step = rect.h / HEIGHT;
            double left = rect.left;
            double real, imag = rect.top + vert_step - vert_step * chunk * HEIGHT / thread_count;
            int max = ((chunk + 1) * HEIGHT / thread_count) * WIDTH;
            for (int y = chunk * HEIGHT / thread_count * WIDTH; y < max; y += WIDTH)
            {
                real = left;
                imag -= vert_step;
                for (int x = 0; x < WIDTH; x++)
                {
                    real += oriz_step;
                    //img.SetPixel(x, y, colormap[((int)(Math.Sqrt(get_julia_iterations(real, imag, max_iter) + 10) * 256)) % 767]);
                    int idx = ((int)(Math.Sqrt(get_julia_iterations(real, imag, max_iter) + 10) * 256)) * 3 % 2301;
                    //int idx = ((int)(Math.Sqrt(get_mandelbrot_iterations(real, imag, max_iter) + 10) * 256)) * 3 % 2301;
                    int i = 3 * (x + y);
                    mand_data[i++] = ll_colormap[idx++];
                    mand_data[i++] = ll_colormap[idx++];
                    mand_data[i] = ll_colormap[idx];
                }
            }
            //render_images[chunk] = img;
        }

        private int get_decimal_places(string num)
        {
            if (num.Contains(","))
                return num.Length - num.IndexOf(",") - 1;
            else
                return 0;
        }

        private void post_to_textbox(string message)
        {
            this.richTextBox1.Text += message;
            this.richTextBox1.SelectionStart = richTextBox1.Text.Length;
            this.richTextBox1.ScrollToCaret();
        }

        private void setZoomLabels()
        {
            zoomLabel.Text = rect.zoom_value.ToString();
            ZoomUpDown.ValueChanged -= new EventHandler(this.ZoomUpDown_ValueChanged);
            ZoomUpDown.Value = (decimal)rect.zoom_value;
            ZoomUpDown.ValueChanged += new EventHandler(this.ZoomUpDown_ValueChanged);
            ZoomUpDown.DecimalPlaces = get_decimal_places(ZoomUpDown.Value.ToString());
            if (rect.zoom_value > 3e-12)
                underflowAlertLabel.Text = "";
            else
                underflowAlertLabel.Text = "Underflow Alert!!";
        }

        private void set_centerXY()
        {
            XUpDown.ValueChanged -= new EventHandler(this.XUpDown_ValueChanged);
            XUpDown.Value = (decimal)rect.center_real;
            XUpDown.ValueChanged += new EventHandler(this.XUpDown_ValueChanged);
            XUpDown.DecimalPlaces = get_decimal_places(XUpDown.Value.ToString());

            YUpDown.ValueChanged -= new EventHandler(this.YUpDown_ValueChanged);
            YUpDown.Value = (decimal)rect.center_imag;
            YUpDown.ValueChanged += new EventHandler(this.YUpDown_ValueChanged);
            YUpDown.DecimalPlaces = get_decimal_places(YUpDown.Value.ToString());
        }

        private Bitmap crop_image(Bitmap b, int new_width, int new_height, int left, int top)
        {
            Bitmap nb = new Bitmap(new_width, new_height);
            using (Graphics g = Graphics.FromImage(nb))
            {
                g.DrawImage(b, left, top);
                return nb;
            }
        }

        private void zoom_animate(Point pos, int direction)
        {
            return; // zoom anim disabled
            // cmap not working: normal array (bgr,bgr,bgr,bgr,...) required, not array of colors

            double factor_zoom_step = -direction * zoom_animation_factor_step;
            double factor = 1 + factor_zoom_step;
            //Bitmap orig_img = new Bitmap(WIDTH, HEIGHT);
            //Bitmap orig_img = current_image.Clone(new Rectangle(0,0,WIDTH,HEIGHT), PixelFormat.Format24bppRgb);
            mand_data.CopyTo(mand_data_2, 0);
            Bitmap orig_img = new Bitmap(WIDTH, HEIGHT, WIDTH * 3,
                PixelFormat.Format24bppRgb,
                System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(mand_data_2, 0));

            using (Graphics g = Graphics.FromImage(orig_img))
            {
                g.DrawImage(this.pictureBox1.Image, draw_rect);
            }
            int width = orig_img.Width, height = orig_img.Height;
            if (direction > 0)
            {
                while (factor >= rect.zoom_factor_in)
                {
                    double new_width = (int)(width * factor);
                    double new_height = (int)(height * factor);
                    int left = (int)Math.Round(pos.X - (pos.X * new_width / width));
                    int top = (int)Math.Round(pos.Y - (pos.Y * new_height / height));
                    this.pictureBox1.Image = crop_image(orig_img, (int)new_width, (int)new_height, -left, -top);
                    this.pictureBox1.Refresh();
                    factor += factor_zoom_step;
                }
            }
            else
            {
                while (factor <= rect.zoom_factor_out)
                {
                    double new_width = (int)(width * factor);
                    double new_height = (int)(height * factor);
                    int left = (int)Math.Round(pos.X - (pos.X * new_width / width));
                    int top = (int)Math.Round(pos.Y - (pos.Y * new_height / height));
                    this.pictureBox1.Image = crop_image(orig_img, (int)new_width, (int)new_height, -left, -top);
                    this.pictureBox1.Refresh();
                    factor += factor_zoom_step;
                }
            }
        }

        private void reset_draw_rect()
        {
            draw_rect.X = 0;
            draw_rect.Y = 0;
        }

        private void wait_for_render()
        {
            for (int c = 0; c < thread_count; c++)
                thread_array[c].Join();
            sw.Stop(); //timer stop
            //using (Graphics g = Graphics.FromImage(current_image))
            //{
            //    for (int c = 0; c < thread_count; c++)
            //        g.DrawImage(render_images[c], 0, c * HEIGHT / thread_count);
            //}
            //current_image = new Bitmap(WIDTH, HEIGHT, WIDTH * 3,
            //    PixelFormat.Format24bppRgb,
            //    System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(mand_data, 0));

            post_to_textbox(Math.Round(sw.Elapsed.TotalSeconds, 3).ToString()); //post time
        }

        private void start_render(string message)
        {
            for (int e = 0; e < thread_count; e++)
            {
                int chunk = e;
                if (mandelbrot)
                    thread_array[e] = new Thread(() => this.getMandelbrotSet_chunk(max_iterations, chunk));
                else
                    thread_array[e] = new Thread(() => this.getJuliaSet_chunk(max_iterations, chunk));
            }
            sw.Restart(); //timer start
            for (int e = 0; e < thread_count; e++)
            {
                thread_array[e].IsBackground = true;
                thread_array[e].Start();
            }
            post_to_textbox(message);
        }

        private void render(string message = "\nRendering...")
        {
            start_render(message);
            wait_for_render();
            this.pictureBox1.Image = current_image;
        }

        private void init_chunk_array()
        {
            for (int e = 0; e < thread_count; e++)
                render_images[e] = new Bitmap(WIDTH, HEIGHT / thread_count);
        }

        private static ImageData FrameToImageData(Bitmap bitmap)
        {
            Rectangle rect = new Rectangle(Point.Empty, bitmap.Size);
            BitmapData bitLock = bitmap.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            ImageData bitmapImageData = ImageData.FromPointer(bitLock.Scan0, ImagePixelFormat.Bgra32, bitmap.Size);
            bitmap.UnlockBits(bitLock);
            return bitmapImageData;
        }

        private void make_video()
        {
            var settings = new VideoEncoderSettings(width: WIDTH, height: HEIGHT, framerate: 30, codec: VideoCodec.H264);
            settings.EncoderPreset = EncoderPreset.Fast;
            settings.CRF = 17;
            var file = MediaBuilder.CreateContainer(screenshots_path + @"\video_render.mp4").WithVideo(settings).Create();
            double dest_zoom = (double)DestZoomUpDown.Value;
            int initial_frames = 10, final_frames = 14;
            int n = 0;
            render("\nStarting...");
            for (int e = 0; e < initial_frames; e++)
            {
                file.Video.AddFrame(FrameToImageData(current_image));
                post_to_textbox("\nFrame" + n.ToString() + "...0,0");
                n++;
            }
            while (rect.zoom_value * 0.95 > dest_zoom)
            {
                rect.zoom_on_center(0.95);
                setZoomLabels();
                render("\nFrame" + n.ToString() + "...");
                file.Video.AddFrame(FrameToImageData(current_image));
                n++;
            }
            for (int e = 0; e < final_frames - 1; e++)
            {
                file.Video.AddFrame(FrameToImageData(current_image));
                post_to_textbox("\nFrame" + n.ToString() + "...0,0");
                n++;
            }
            file.Dispose();
            post_to_textbox("\nFinished!");
        }

        private void load_colormaps()
        {
            string[] files = System.IO.Directory.GetFiles(colormap_path, "*.png");
            colormaps = new List<Color[]>(files.Length);
            Bitmap tmp_img;
            for (int e = 0; e < files.Length; e++)
            {
                tmp_img = (Bitmap)Bitmap.FromFile(files[e]);
                Color[] col_arr = new Color[767];
                for (int m = 0; m < 767; m++)
                    col_arr[m] = tmp_img.GetPixel(m, 0);
                colormaps.Add(col_arr);
                string[] path_spl = files[e].Split("\\");
                colormapChooser.Items.Add(path_spl[path_spl.Length-1]);
                if (e == 0)
                    set_show_img(files[e]);
            }
            colormap = colormaps[0];
            colormapChooser.SelectedIndexChanged -= new EventHandler(colormapChooser_SelectedIndexChanged);
            colormapChooser.SelectedIndex = 0;
            colormapChooser.SelectedIndexChanged += new EventHandler(colormapChooser_SelectedIndexChanged);
        }

        public void add_colormap(string fname)
        {
            Bitmap tmp_img = (Bitmap)Bitmap.FromFile(fname);
            Color[] col_arr = new Color[767];
            for (int m = 0; m < 767; m++)
                col_arr[m] = tmp_img.GetPixel(m, 0);
            colormaps.Add(col_arr);
            string[] path_spl = fname.Split("\\");
            colormapChooser.Items.Add(path_spl[path_spl.Length - 1]);
            colormapChooser.SelectedItem = path_spl[path_spl.Length - 1];
            set_show_img(fname);
        }

        private void set_show_img(string fname)
        {
            Bitmap show_img = new Bitmap(767, 20);
            Bitmap grad_img = (Bitmap)Bitmap.FromFile(fname);
            using (Graphics grD = Graphics.FromImage(show_img))
            {
                for (int e = 0; e < show_img.Height; e++)
                    grD.DrawImage(grad_img, 0, e);
            }
            this.gradientPictureBox.Image = show_img;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mand_data = new byte[WIDTH * HEIGHT * 3];
            mand_data_2 = new byte[WIDTH * HEIGHT * 3];
            ll_colormap = new byte[] { 100, 7, 0, 100, 7, 0, 100, 7, 0, 100, 7, 0, 100, 7, 0, 100, 7, 0, 100, 7, 0, 100, 7, 0, 101, 7, 0, 101, 8, 0, 101, 8, 0, 102, 8, 0, 102, 9, 0, 103, 9, 0, 103, 9, 0, 103, 10, 0, 104, 10, 0, 104, 10, 0, 105, 11, 1, 106, 11, 1, 106, 12, 1, 107, 12, 1, 107, 13, 1, 108, 13, 1, 109, 14, 1, 109, 15, 1, 110, 15, 2, 111, 16, 2, 112, 16, 2, 112, 17, 2, 113, 18, 2, 114, 18, 2, 115, 19, 3, 116, 20, 3, 117, 20, 3, 118, 21, 3, 118, 22, 3, 119, 23, 4, 120, 24, 4, 121, 24, 4, 122, 25, 4, 123, 26, 4, 124, 27, 5, 125, 28, 5, 126, 29, 5, 127, 29, 5, 128, 30, 6, 129, 31, 6, 130, 32, 6, 132, 33, 6, 133, 34, 6, 134, 35, 7, 135, 36, 7, 136, 37, 7, 137, 38, 8, 138, 39, 8, 139, 40, 8, 140, 41, 8, 142, 42, 9, 143, 43, 9, 144, 44, 9, 145, 45, 10, 146, 46, 10, 147, 47, 10, 149, 48, 10, 150, 49, 11, 151, 50, 11, 152, 51, 11, 153, 52, 12, 154, 53, 12, 156, 54, 12, 157, 55, 13, 158, 57, 13, 159, 58, 13, 160, 59, 14, 161, 60, 14, 162, 61, 14, 164, 62, 15, 165, 63, 15, 166, 64, 15, 167, 65, 16, 168, 66, 16, 169, 67, 16, 170, 68, 17, 171, 70, 17, 173, 71, 17, 174, 72, 18, 175, 73, 18, 176, 74, 18, 177, 75, 19, 178, 76, 19, 179, 77, 20, 180, 78, 20, 181, 79, 20, 182, 80, 21, 183, 81, 21, 184, 82, 21, 185, 83, 22, 186, 84, 22, 187, 85, 23, 188, 86, 23, 188, 87, 23, 189, 88, 24, 190, 89, 24, 191, 90, 24, 192, 91, 25, 193, 92, 25, 193, 93, 26, 194, 94, 26, 195, 95, 26, 196, 96, 27, 196, 97, 27, 197, 98, 28, 198, 99, 28, 198, 100, 28, 199, 101, 29, 200, 102, 29, 200, 102, 30, 201, 103, 30, 201, 104, 30, 202, 105, 31, 202, 106, 31, 202, 106, 31, 203, 107, 32, 203, 108, 32, 204, 109, 33, 204, 110, 33, 205, 110, 34, 205, 111, 34, 205, 112, 35, 206, 113, 35, 206, 114, 36, 207, 115, 36, 207, 115, 37, 207, 116, 38, 208, 117, 38, 208, 118, 39, 209, 119, 40, 209, 120, 40, 209, 121, 41, 210, 122, 42, 210, 122, 43, 211, 123, 43, 211, 124, 44, 211, 125, 45, 212, 126, 46, 212, 127, 47, 213, 128, 47, 213, 129, 48, 213, 130, 49, 214, 131, 50, 214, 131, 51, 215, 132, 52, 215, 133, 53, 215, 134, 54, 216, 135, 55, 216, 136, 56, 217, 137, 57, 217, 138, 58, 217, 139, 59, 218, 140, 60, 218, 141, 61, 219, 142, 62, 219, 143, 63, 219, 144, 64, 220, 145, 65, 220, 146, 66, 220, 147, 67, 221, 148, 68, 221, 149, 70, 222, 150, 71, 222, 151, 72, 222, 152, 73, 223, 153, 74, 223, 154, 75, 223, 155, 77, 224, 156, 78, 224, 157, 79, 225, 158, 80, 225, 159, 82, 225, 160, 83, 226, 160, 84, 226, 161, 85, 226, 162, 87, 227, 163, 88, 227, 164, 89, 227, 165, 90, 228, 166, 92, 228, 167, 93, 228, 168, 94, 229, 169, 96, 229, 170, 97, 229, 171, 98, 230, 172, 100, 230, 173, 101, 230, 174, 102, 231, 175, 104, 231, 176, 105, 231, 177, 106, 232, 178, 108, 232, 179, 109, 232, 180, 110, 233, 181, 112, 233, 182, 113, 233, 183, 115, 234, 184, 116, 234, 185, 117, 234, 186, 119, 235, 187, 120, 235, 188, 121, 235, 189, 123, 236, 190, 124, 236, 191, 126, 236, 192, 127, 237, 193, 128, 237, 194, 130, 237, 195, 131, 237, 196, 133, 238, 196, 134, 238, 197, 135, 238, 198, 137, 239, 199, 138, 239, 200, 140, 239, 201, 141, 239, 202, 142, 240, 203, 144, 240, 204, 145, 240, 205, 147, 241, 206, 148, 241, 207, 149, 241, 207, 151, 241, 208, 152, 242, 209, 153, 242, 210, 155, 242, 211, 156, 242, 212, 158, 243, 213, 159, 243, 213, 160, 243, 214, 162, 243, 215, 163, 244, 216, 164, 244, 217, 166, 244, 218, 167, 244, 218, 168, 245, 219, 170, 245, 220, 171, 245, 221, 172, 245, 222, 174, 246, 222, 175, 246, 223, 176, 246, 224, 177, 246, 225, 179, 247, 225, 180, 247, 226, 181, 247, 227, 182, 247, 228, 184, 247, 228, 185, 248, 229, 186, 248, 230, 187, 248, 231, 189, 248, 231, 190, 248, 232, 191, 249, 233, 192, 249, 233, 193, 249, 234, 195, 249, 235, 196, 249, 235, 197, 249, 236, 198, 250, 236, 199, 250, 237, 200, 250, 238, 201, 250, 238, 202, 250, 239, 203, 250, 239, 204, 251, 240, 205, 251, 241, 207, 251, 241, 208, 251, 242, 209, 251, 242, 210, 251, 243, 211, 252, 243, 211, 252, 244, 212, 252, 244, 213, 252, 245, 214, 252, 245, 215, 252, 246, 216, 252, 246, 217, 252, 247, 218, 253, 247, 219, 253, 247, 219, 253, 248, 220, 253, 248, 221, 253, 249, 222, 253, 249, 223, 253, 249, 223, 253, 250, 224, 253, 250, 225, 253, 250, 226, 254, 251, 226, 254, 251, 227, 254, 251, 228, 254, 252, 228, 254, 252, 229, 254, 252, 229, 254, 252, 230, 254, 253, 230, 254, 253, 231, 254, 253, 231, 254, 253, 232, 254, 253, 232, 254, 254, 233, 254, 254, 233, 254, 254, 234, 254, 254, 234, 254, 254, 234, 254, 254, 235, 254, 254, 235, 254, 254, 235, 254, 254, 236, 254, 254, 236, 254, 254, 236, 254, 254, 236, 254, 254, 237, 254, 254, 237, 254, 254, 237, 254, 254, 237, 254, 254, 237, 254, 254, 238, 253, 254, 238, 253, 254, 238, 253, 254, 238, 252, 254, 238, 252, 254, 238, 251, 254, 239, 251, 254, 239, 250, 254, 239, 249, 254, 239, 249, 253, 239, 248, 253, 240, 247, 253, 240, 246, 253, 240, 245, 253, 240, 244, 253, 240, 243, 252, 240, 242, 252, 241, 241, 252, 241, 240, 252, 241, 239, 252, 241, 238, 251, 241, 237, 251, 241, 235, 251, 242, 234, 251, 242, 233, 250, 242, 232, 250, 242, 230, 250, 242, 229, 249, 242, 227, 249, 243, 226, 249, 243, 224, 249, 243, 223, 248, 243, 221, 248, 243, 220, 248, 243, 218, 247, 243, 216, 247, 244, 215, 247, 244, 213, 246, 244, 211, 246, 244, 210, 246, 244, 208, 245, 244, 206, 245, 245, 204, 244, 245, 202, 244, 245, 201, 244, 245, 199, 243, 245, 197, 243, 245, 195, 242, 245, 193, 242, 246, 191, 242, 246, 189, 241, 246, 187, 241, 246, 185, 240, 246, 183, 240, 246, 181, 239, 246, 179, 239, 247, 177, 238, 247, 175, 238, 247, 173, 237, 247, 170, 237, 247, 168, 236, 247, 166, 236, 247, 164, 235, 247, 162, 235, 248, 160, 234, 248, 158, 234, 248, 155, 233, 248, 153, 233, 248, 151, 232, 248, 149, 232, 248, 147, 231, 248, 144, 231, 249, 142, 230, 249, 140, 230, 249, 138, 229, 249, 135, 228, 249, 133, 228, 249, 131, 227, 249, 129, 227, 249, 126, 226, 250, 124, 226, 250, 122, 225, 250, 120, 224, 250, 117, 224, 250, 115, 223, 250, 113, 223, 250, 111, 222, 250, 109, 221, 250, 106, 221, 250, 104, 220, 251, 102, 220, 251, 100, 219, 251, 98, 218, 251, 95, 218, 251, 93, 217, 251, 91, 216, 251, 89, 216, 251, 87, 215, 251, 85, 215, 251, 82, 214, 252, 80, 213, 252, 78, 213, 252, 76, 212, 252, 74, 211, 252, 72, 211, 252, 70, 210, 252, 68, 209, 252, 66, 209, 252, 64, 208, 252, 62, 207, 252, 60, 207, 252, 58, 206, 252, 56, 205, 253, 54, 205, 253, 52, 204, 253, 51, 203, 253, 49, 203, 253, 47, 202, 253, 45, 201, 253, 43, 201, 253, 42, 200, 253, 40, 199, 253, 38, 198, 253, 37, 198, 253, 35, 197, 253, 34, 196, 253, 32, 196, 253, 30, 195, 254, 29, 194, 254, 27, 194, 254, 26, 193, 254, 25, 192, 254, 23, 192, 254, 22, 191, 254, 20, 190, 254, 19, 189, 254, 18, 189, 254, 17, 188, 254, 16, 187, 254, 14, 187, 254, 13, 186, 254, 12, 185, 254, 11, 185, 254, 10, 184, 254, 9, 183, 254, 8, 183, 254, 7, 182, 254, 7, 181, 254, 6, 180, 254, 5, 180, 254, 4, 179, 254, 4, 178, 254, 3, 178, 254, 3, 177, 254, 2, 176, 254, 2, 176, 254, 1, 175, 254, 1, 174, 254, 0, 174, 254, 0, 173, 254, 0, 172, 254, 0, 172, 254, 0, 171, 254, 0, 170, 254, 0, 170, 254, 0, 169, 254, 0, 168, 254, 0, 167, 254, 0, 167, 254, 0, 166, 254, 0, 165, 254, 0, 164, 253, 0, 164, 253, 0, 163, 252, 0, 162, 252, 0, 161, 251, 0, 160, 251, 0, 159, 250, 0, 158, 249, 0, 157, 249, 0, 156, 248, 0, 155, 247, 0, 154, 246, 0, 153, 245, 0, 152, 244, 0, 151, 243, 0, 150, 242, 0, 149, 241, 0, 148, 240, 0, 147, 239, 0, 146, 238, 0, 145, 236, 0, 144, 235, 0, 143, 234, 0, 141, 232, 0, 140, 231, 0, 139, 230, 0, 138, 228, 0, 137, 227, 0, 136, 225, 0, 134, 223, 0, 133, 222, 0, 132, 220, 0, 131, 219, 0, 129, 217, 0, 128, 215, 0, 127, 213, 0, 126, 212, 0, 124, 210, 0, 123, 208, 0, 122, 206, 0, 120, 204, 0, 119, 202, 0, 118, 200, 0, 116, 199, 0, 115, 197, 0, 114, 195, 0, 112, 193, 0, 111, 191, 0, 110, 188, 0, 108, 186, 0, 107, 184, 0, 106, 182, 0, 104, 180, 0, 103, 178, 0, 101, 176, 0, 100, 174, 0, 99, 171, 0, 97, 169, 0, 96, 167, 0, 95, 165, 0, 93, 163, 0, 92, 160, 0, 90, 158, 0, 89, 156, 0, 88, 154, 0, 86, 151, 0, 85, 149, 0, 83, 147, 0, 82, 144, 0, 81, 142, 0, 79, 140, 0, 78, 138, 0, 77, 135, 0, 75, 133, 0, 74, 131, 0, 72, 128, 0, 71, 126, 0, 70, 124, 0, 68, 121, 0, 67, 119, 0, 66, 117, 0, 64, 114, 0, 63, 112, 0, 62, 110, 0, 60, 107, 0, 59, 105, 0, 58, 103, 0, 56, 101, 0, 55, 98, 0, 54, 96, 0, 53, 94, 0, 51, 92, 0, 50, 89, 0, 49, 87, 0, 48, 85, 0, 46, 83, 0, 45, 81, 0, 44, 78, 0, 43, 76, 0, 42, 74, 0, 40, 72, 0, 39, 70, 0, 38, 68, 0, 37, 66, 0, 36, 64, 0, 35, 62, 0, 34, 60, 0, 32, 58, 0, 31, 56, 0, 30, 54, 0, 29, 52, 0, 28, 50, 0, 27, 48, 0, 26, 46, 0, 25, 44, 0, 24, 42, 0, 23, 41, 0, 22, 39, 0, 21, 37, 0, 21, 36, 0, 20, 34, 0, 19, 32, 0, 18, 31, 0, 17, 29, 0, 16, 28, 0, 15, 26, 0, 15, 25, 0, 14, 23, 0, 13, 22, 0, 12, 20, 0, 12, 19, 0, 11, 18, 0, 10, 17, 0, 10, 15, 0, 9, 14, 0, 9, 13, 0, 8, 12, 0, 7, 11, 0, 7, 10, 0, 6, 9, 0, 6, 8, 0, 5, 7, 0, 5, 6, 0, 5, 5, 0, 4, 5, 0, 4, 4, 0, 3, 3, 0, 3, 3, 0, 3, 2, 0, 3, 2, 0, 2, 1, 0, 2, 1, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 0, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 2, 2, 0, 2, 2, 0, 3, 2, 0, 3, 2, 0, 4, 2, 0, 5, 2, 0, 5, 2, 0, 6, 2, 0, 7, 2, 0, 8, 2, 0, 8, 2, 0, 9, 2, 0, 10, 2, 0, 11, 2, 0, 12, 2, 0, 13, 2, 0, 14, 2, 0, 15, 2, 0, 16, 2, 0, 17, 2, 0, 18, 2, 0, 19, 2, 0, 20, 3, 0, 21, 3, 0, 23, 3, 0, 24, 3, 0, 25, 3, 0, 26, 3, 0, 27, 3, 0, 29, 3, 0, 30, 3, 0, 31, 3, 0, 32, 3, 0, 34, 3, 0, 35, 3, 0, 36, 3, 0, 38, 3, 0, 39, 3, 0, 40, 4, 0, 42, 4, 0, 43, 4, 0, 45, 4, 0, 46, 4, 0, 47, 4, 0, 49, 4, 0, 50, 4, 0, 51, 4, 0, 53, 4, 0, 54, 4, 0, 55, 4, 0, 57, 4, 0, 58, 4, 0, 60, 5, 0, 61, 5, 0, 62, 5, 0, 64, 5, 0, 65, 5, 0, 66, 5, 0, 67, 5, 0, 69, 5, 0, 70, 5, 0, 71, 5, 0, 73, 5, 0, 74, 5, 0, 75, 5, 0, 76, 5, 0, 77, 5, 0, 78, 5, 0, 80, 6, 0, 81, 6, 0, 82, 6, 0, 83, 6, 0, 84, 6, 0, 85, 6, 0, 86, 6, 0, 87, 6, 0, 88, 6, 0, 89, 6, 0, 90, 6, 0, 90, 6, 0, 91, 6, 0, 92, 6, 0, 93, 6, 0, 94, 6, 0, 94, 6, 0, 95, 6, 0, 95, 6, 0, 96, 6, 0, 97, 6, 0, 97, 6, 0, 97, 6, 0, 98, 6, 0, 98, 6, 0, 99, 6, 0, 99, 6, 0, 99, 6, 0, 99, 6, 0, 99, 6, 0, 99, 6, 0, 99, 6, 0 };
            current_image = new Bitmap(WIDTH, HEIGHT, WIDTH * 3,
                PixelFormat.Format24bppRgb,
                System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(mand_data, 0));
            //byte* data = (byte*)malloc(WIDTH * HEIGHT * 3 * sizeof(byte));

            //Color[] colors = { Color.FromArgb(178, 0, 255), Color.FromArgb(214, 127, 128), Color.FromArgb(255, 255, 255), Color.FromArgb(2, 191, 255), Color.FromArgb(0, 0, 0) };
            //get_colormap(colors);
            colormapForm = new ColormapForm(this);
            string here = System.Reflection.Assembly.GetEntryAssembly().Location.Replace("MyMandelbrotExplorer.dll", "");
            //Console.WriteLine(String.Concat(here, @"ffmpeg"));
            FFMediaToolkit.FFmpegLoader.FFmpegPath = here;
            try
            {
                FFMediaToolkit.FFmpegLoader.LoadFFmpeg();
            } catch (DllNotFoundException)
            {
                post_to_textbox("Error importing FFmpeg\n");
                button1.Enabled = false;
                label5.Enabled = false;
                DestZoomUpDown.Enabled = false;
            }
            this.XUpDown.Controls[0].Hide();
            this.YUpDown.Controls[0].Hide();
            this.ZoomUpDown.Controls[0].Hide();
            this.DestZoomUpDown.Controls[0].Hide();
            this.JuliaXUpDown.Controls[0].Hide();
            this.JuliaYUpDown.Controls[0].Hide();
            load_colormaps();

            init_chunk_array();
            this.rect = new Rect();
            setZoomLabels();
            set_centerXY();
            render("Rendering...");
            sw.Restart();
            for (int i = 0; i < 20; i++)
            {   for(int c=0; c<4; c++)
                    getMandelbrotSet_chunk(202, 0);
            }
            sw.Stop();
            //post_to_textbox(Math.Round(sw.Elapsed.TotalSeconds, 3).ToString()); //post time
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                drag = true;
                last_pos = e.Location;
            }
            else if (e.Button == MouseButtons.Middle)
            {
                julia_picking = true;
                pictureBox1_MouseMove(sender, e);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) //release drag
            {
                drag = false;
                double x = (WIDTH / 2 - draw_rect.X) * this.rect.w / WIDTH;
                double y = (HEIGHT / 2 - draw_rect.Y) * this.rect.h / HEIGHT;
                rect.set_center(rect.left + x, rect.top - y);
                set_centerXY();
                render();
                reset_draw_rect();
            }
            else if (e.Button == MouseButtons.Right) //set center
            {
                Point pos = e.Location;
                double x = pos.X * this.rect.w / WIDTH;
                double y = pos.Y * this.rect.h / HEIGHT;
                rect.set_center(rect.left + x, rect.top - y);
                set_centerXY();
                render();
            }
            else if (e.Button == MouseButtons.Middle)
            {
                julia_picking = false;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag) //drag move
            {
                draw_rect.Offset(e.X - last_pos.X, e.Y - last_pos.Y);
                last_pos = e.Location;
                this.pictureBox1.Paint += new PaintEventHandler(this.pictureBox1_Paint);
                pictureBox1.Refresh();
                this.pictureBox1.Paint -= new PaintEventHandler(this.pictureBox1_Paint);
            }
            else //set x, y labels
            {
                Point pos = e.Location;
                double x = pos.X * this.rect.w / WIDTH;
                double y = pos.Y * this.rect.h / HEIGHT;
                xLabel.Text = (rect.left + x).ToString();
                yLabel.Text = (rect.top - y).ToString();
            }
            if (julia_picking)
            {
                julia_real = rect.left + e.X * this.rect.w / WIDTH;
                JuliaXUpDown.ValueChanged -= new EventHandler(this.JuliaXUpDown_ValueChanged);
                JuliaXUpDown.Value = (decimal)julia_real;
                JuliaXUpDown.ValueChanged += new EventHandler(this.JuliaXUpDown_ValueChanged);
                JuliaXUpDown.DecimalPlaces = get_decimal_places(JuliaXUpDown.Value.ToString());

                julia_imag = rect.top - e.Y * this.rect.h / HEIGHT;
                JuliaYUpDown.ValueChanged -= new EventHandler(this.JuliaYUpDown_ValueChanged);
                JuliaYUpDown.Value = (decimal)julia_imag;
                JuliaYUpDown.ValueChanged += new EventHandler(this.JuliaYUpDown_ValueChanged);
                JuliaYUpDown.DecimalPlaces = get_decimal_places(JuliaYUpDown.Value.ToString());
                if (!mandelbrot)
                    render();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.DrawImage(this.pictureBox1.Image, draw_rect);
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            Point pos = e.Location;
            pos.X -= draw_rect.X;
            pos.Y -= draw_rect.Y;

            if (e.Delta > 0)
            {
                double x = (pos.X + (WIDTH / 2 - pos.X) * rect.zoom_factor_in) * this.rect.w / WIDTH;
                double y = (pos.Y + (HEIGHT / 2 - pos.Y) * rect.zoom_factor_in) * this.rect.h / HEIGHT;
                rect.zoom_point_in(rect.left + x, rect.top - y);
            }
            else
            {
                double x = (pos.X + (WIDTH / 2 - pos.X) * rect.zoom_factor_out) * this.rect.w / WIDTH;
                double y = (pos.Y + (HEIGHT / 2 - pos.Y) * rect.zoom_factor_out) * this.rect.h / HEIGHT;
                rect.zoom_point_out(rect.left + x, rect.top - y);
            }
            set_centerXY();
            setZoomLabels();
            start_render("\nRendering...");
            zoom_animate(e.Location, Math.Sign(e.Delta));
            wait_for_render();
            this.pictureBox1.Image = current_image;
            reset_draw_rect();
        }

        private void renderButton_Click(object sender, EventArgs e)
        {
            render();
            reset_draw_rect();
        }

        //21, 202, 298, 412, 544, 694, 862, 1048, 1252, 1474, 1714, 1971, 1972, 2247, 2248, 2541, 2852, 2853, 3535
        public string colormap_path = @"color palettes";
        //string screenshots_path = @"C:\Users\Lorenzo\Downloads\mand_shots";
        string screenshots_path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        string ma_screenshot_name = "shot{0}.png";
        string ju_screenshot_name = "jshot{0}.png";
        static int WIDTH = 1500, HEIGHT = 1000;
        static int thread_count = 16;
        ushort max_iterations = 202;
        double zoom_animation_factor_step = 0.1;
        bool drag = false;
        bool mandelbrot = true;
        bool julia_picking = false;
        double julia_real = 0, julia_imag = 0;
        List<Color[]> colormaps;
        Color[] colormap;
        ColormapForm colormapForm;
        Rect rect;
        Point last_pos;
        Bitmap current_image = new Bitmap(WIDTH, HEIGHT);
        Bitmap[] render_images = new Bitmap[thread_count];
        Thread[] thread_array = new Thread[thread_count];
        Rectangle draw_rect = new Rectangle(0, 0, WIDTH, HEIGHT);
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        byte[] mand_data;
        byte[] mand_data_2;
        byte[] ll_colormap;

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            max_iterations = (ushort)this.numericUpDown1.Value;
            render();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
                this.numericUpDown1.Value = 64;
            else if (trackBar1.Value == 1)
                this.numericUpDown1.Value = 202;
            else if (trackBar1.Value == 2)
                this.numericUpDown1.Value = 694;
            else if (trackBar1.Value == 3)
                this.numericUpDown1.Value = 1474;
            else
                this.numericUpDown1.Value = 3535;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog asksavefile = new SaveFileDialog();
            asksavefile.Filter = "PNG|*.png|JPG|*jpg|All files (*.*)|*.*";
            asksavefile.FilterIndex = 0;
            asksavefile.RestoreDirectory = true;

            if (asksavefile.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image.Save(asksavefile.FileName);
            }
        }

        private void zoomButtonIn_Click(object sender, EventArgs e)
        {
            rect.zoom_on_center_in();
            setZoomLabels();
            start_render("\nRendering...");
            zoom_animate(new Point(WIDTH / 2, HEIGHT / 2), 1);
            wait_for_render();
            this.pictureBox1.Image = current_image;
        }

        private void zoomButtonOut_Click(object sender, EventArgs e)
        {
            rect.zoom_on_center_out();
            setZoomLabels();
            start_render("\nRendering...");
            zoom_animate(new Point(WIDTH/2, HEIGHT/2), -1);
            wait_for_render();
            this.pictureBox1.Image = current_image;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            make_video();
        }

        private void XUpDown_ValueChanged(object sender, EventArgs e)
        {
            XUpDown.DecimalPlaces = get_decimal_places(XUpDown.Value.ToString());
            rect.set_center_x((double)XUpDown.Value);
            render();
        }

        private void YUpDown_ValueChanged(object sender, EventArgs e)
        {
            YUpDown.DecimalPlaces = get_decimal_places(YUpDown.Value.ToString());
            rect.set_center_y((double)YUpDown.Value);
            render();
        }

        private void ZoomUpDown_ValueChanged(object sender, EventArgs e)
        {
            ZoomUpDown.DecimalPlaces = get_decimal_places(ZoomUpDown.Value.ToString());
            rect.set_zoom_value((double)ZoomUpDown.Value);
            render();
        }

        private void DestZoomUpDown_ValueChanged(object sender, EventArgs e)
        {
            DestZoomUpDown.DecimalPlaces = get_decimal_places(DestZoomUpDown.Value.ToString());
        }

        private void sreenshotButton_Click(object sender, EventArgs e)
        {
            string scr_name, name, full_path;
            int n = 1;
            if (mandelbrot)
                scr_name = ma_screenshot_name;
            else
                scr_name = ju_screenshot_name;
            do
            {
                name = String.Format(scr_name, n);
                full_path = System.IO.Path.Join(screenshots_path, name);
                n++;
            }
            while (System.IO.File.Exists(full_path));
            this.pictureBox1.Image.Save(full_path);
            post_to_textbox("\nSaved as: "+name);
        }

        private void setDestButton_Click(object sender, EventArgs e)
        {
            DestZoomUpDown.DecimalPlaces = get_decimal_places(ZoomUpDown.Value.ToString());
            DestZoomUpDown.Value = ZoomUpDown.Value;
        }

        private void LeftIterButton_Click(object sender, EventArgs e)
        {
            if (trackBar1.Value-1 < 0)
                trackBar1.Value = trackBar1.Maximum;
            else
                trackBar1.Value -= 1;
            trackBar1_Scroll(null, null);
        }

        private void JuliaXUpDown_ValueChanged(object sender, EventArgs e)
        {
            JuliaXUpDown.DecimalPlaces = get_decimal_places(JuliaXUpDown.Value.ToString());
            julia_real = (double)JuliaXUpDown.Value;
            if (!mandelbrot)
                render();
        }

        private void JuliaYUpDown_ValueChanged(object sender, EventArgs e)
        {
            JuliaYUpDown.DecimalPlaces = get_decimal_places(JuliaYUpDown.Value.ToString());
            julia_imag = (double)JuliaYUpDown.Value;
            if (!mandelbrot)
                render();
        }

        private void resetJuliaButton_Click(object sender, EventArgs e)
        {
            julia_real = 0;
            JuliaXUpDown.ValueChanged -= new EventHandler(this.JuliaXUpDown_ValueChanged);
            JuliaXUpDown.Value = 0;
            JuliaXUpDown.ValueChanged += new EventHandler(this.JuliaXUpDown_ValueChanged);
            JuliaXUpDown.DecimalPlaces = 1;
            julia_imag = 0;
            JuliaYUpDown.ValueChanged -= new EventHandler(this.JuliaYUpDown_ValueChanged);
            JuliaYUpDown.Value = 0;
            JuliaYUpDown.ValueChanged += new EventHandler(this.JuliaYUpDown_ValueChanged);
            JuliaYUpDown.DecimalPlaces = 1;
            if (!mandelbrot)
                render();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mandelbrot = !mandelbrot;
            if (mandelbrot)
            {
                rect = new Rect();
                button2.Text = "Switch to Julia Set";
            }
            else
            {
                rect = new Rect(0, 0);
                button2.Text = "Switch to Mandelbrot Set";
            }
            render();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Color[] colors = { Color.FromArgb(178, 0, 255), Color.FromArgb(214, 127, 128), Color.FromArgb(255, 255, 255), Color.FromArgb(2, 191, 255), Color.FromArgb(0, 0, 0) };
            //if (color_idx == 0)
            //    colormap = colormap1;
            //else
            //    colormap = get_colormap(colors);
            //render();
            colormapForm.set_current(System.IO.Path.Join(colormap_path, colormapChooser.SelectedItem.ToString()));
            colormapForm.Show();
        }

        private void colormapChooser_SelectedIndexChanged(object sender, EventArgs e)
        {
            colormap = colormaps[colormapChooser.SelectedIndex];

            for (int i = 0; i < colormap.Length; i++)
            {
                ll_colormap[i * 3] = colormap[i].B;
                ll_colormap[i * 3 + 1] = colormap[i].G;
                ll_colormap[i * 3 + 2] = colormap[i].R;
            }

            set_show_img(System.IO.Path.Join(colormap_path, colormapChooser.SelectedItem.ToString()));
            Console.WriteLine(colormapChooser.SelectedItem.ToString());
            render();
        }

        private void RightIterButton_Click(object sender, EventArgs e)
        {
            trackBar1.Value = (trackBar1.Value + 1) % (trackBar1.Maximum+1);
            trackBar1_Scroll(null, null);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            if (mandelbrot)
                rect = new Rect();
            else
                rect = new Rect(0, 0);
            set_centerXY();
            setZoomLabels();
            reset_draw_rect();
            render();
        }
    }

    class Rect
    {
        public Rect()
        {
            left = -2;
            top = 1;
            w = 3;
            h = 2;
            center_real = left + w / 2;
            center_imag = top - h / 2;
            zoom_factor_in = 0.5;
            zoom_factor_out = 1 / zoom_factor_in;
            zoom_value = 1;
        }

        public Rect(double point_real, double point_imag) : this()
        {
            w = 3;
            h = 2;
            zoom_factor_in = 0.5;
            zoom_factor_out = 1 / zoom_factor_in;
            zoom_value = 1;
            set_center(point_real, point_imag);
        }

        public Rect(double zoom_val, double point_real, double point_imag) : this()
        {
            zoom_value = zoom_val;
            w = 3 * zoom_value;
            h = 2 * zoom_value;
            zoom_factor_in = 0.5;
            zoom_factor_out = 1 / zoom_factor_in;
            set_center(point_real, point_imag);
        }

        public void set_zoom_value(double zoom_val)
        {
            zoom_value = zoom_val;
            w = 3 * zoom_value;
            h = 2 * zoom_value;
            left = center_real - w / 2;
            top = center_imag + h / 2;
        }

        public void set_center_x(double point_real)
        {
            center_real = point_real;
            left = center_real - w / 2;
        }

        public void set_center_y(double point_imag)
        {
            center_imag = point_imag;
            top = center_imag + h / 2;
        }

        public void set_center(double point_real, double point_imag)
        {
            center_real = point_real;
            center_imag = point_imag;
            left = center_real - w / 2;
            top = center_imag + h / 2;
        }

        public void zoom_point(double factor, double point_real, double point_imag)
        {
            zoom_value *= factor;
            w = w * factor;
            h = h * factor;
            set_center(point_real, point_imag);
        }

        public void zoom_point_in(double point_real, double point_imag)
        {
            zoom_point(zoom_factor_in, point_real, point_imag);
        }

        public void zoom_point_out(double point_real, double point_imag)
        {
            zoom_point(zoom_factor_out, point_real, point_imag);
        }

        public void zoom_on_center(double factor)
        {
            zoom_value *= factor;
            w = w * factor;
            h = h * factor;
            left = center_real - w / 2;
            top = center_imag + h / 2;
        }

        public void zoom_on_center_in()
        {
            zoom_on_center(zoom_factor_in);
        }

        public void zoom_on_center_out()
        {
            zoom_on_center(zoom_factor_out);
        }

        public double left, top, w, h, center_real, center_imag, zoom_factor_in, zoom_factor_out, zoom_value;
    };
}
