using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pazzl
{
    public partial class Form1 : Form
    {
        private PictureBox[] puzzlePieces;
        private Image[] images;
        private Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            InitializePuzzle();
            ShufflePuzzle();
        }

        private void InitializePuzzle()
        {
            puzzlePieces = new PictureBox[]
            {
                picture1, picture2, picture3, picture4, picture5, picture6, picture7,
                picture8, picture9, picture10, picture11, picture12, picture13, picture14,
                picture15, picture16
            };

            images = new Image[16];
            for (int i = 0; i < images.Length; i++)
            {
                images[i] = Image.FromFile($@"C:\Users\gold_\source\repos\Pazzl\singapore_city\{i + 1}.jpg");
            }
        }

        private void ShufflePuzzle()
        {
            List<int> indices = Enumerable.Range(0, images.Length).ToList();

            for (int i = indices.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = indices[i];
                indices[i] = indices[j];
                indices[j] = temp;
            }

            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                puzzlePieces[i].Image = images[indices[i]];
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 16; i++)
            {
                ((PictureBox)(Controls.Find("picture" + i, true)[0])).AllowDrop = true;
            }
        }

        private void picture1_MouseDown(object sender, MouseEventArgs e)
        {
            DoDragDrop((PictureBox)sender, DragDropEffects.Move);
        }

        private void picture1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void picture1_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox receiver = (PictureBox)sender;

            PictureBox source = (PictureBox)e.Data.GetData((typeof(PictureBox)));
            Image Temp = receiver.Image;
            receiver.Image = source.Image;
            source.Image = Temp;
            CheckPuzzleComplete();
        }

        private void CheckPuzzleComplete()
        {
            for (int i = 0; i < puzzlePieces.Length; i++)
            {
                if (puzzlePieces[i].Image != images[i])
                {
                    return;
                }
            }

            MessageBox.Show("Congrats! Puzzle is completed!", "Vi Von", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 fullImageForm = new Form2();
            fullImageForm.ShowDialog();
        }
    }
}
