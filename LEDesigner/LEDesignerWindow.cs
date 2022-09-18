using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDMatrixController {
    public partial class LEDMD : Form {

        System.Windows.Forms.Button[,] matrixButtons;
        Color chosenColor = Color.White;
        int mode = 0;
        public LEDMD() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        private void updMatrix_Click(object sender, EventArgs e) {
            updateMatrixBox();
        }

        private void button1_Click(object sender, EventArgs e) {
            mode = 0;
            button1.BackColor = Color.FromArgb(255, 100, 100, 100);
            button2.BackColor = Color.DarkGray;
            button3.BackColor = Color.DarkGray;
        }

        private void button2_Click(object sender, EventArgs e) {
            mode = 1;
            button1.BackColor = Color.DarkGray;
            button2.BackColor = Color.FromArgb(255, 100, 100, 100);
            button3.BackColor = Color.DarkGray;
        }

        private void button3_Click(object sender, EventArgs e) {
            mode = 2;
            button1.BackColor = Color.DarkGray;
            button2.BackColor = Color.DarkGray;
            button3.BackColor = Color.FromArgb(255, 100, 100, 100);
        }

        private void button5_Click(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {

        }

        private void designArea_Paint(object sender, PaintEventArgs e) {

        }

        void updateMatrixBox() {

            foreach(Control btn in designArea.Controls.OfType<Button>().ToList()) {
                designArea.Controls.Remove(btn);
            }

            int rows = 1;
            int cols = 1;

            if (true) {
                rows = (int)rowVal.Value;
                cols = (int)colVal.Value;
            }

            matrixButtons = new System.Windows.Forms.Button[rows,cols];

            int xPos = 0;
            int yPos = 0;

            for (int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {
                    
                    

                    System.Windows.Forms.Button tmp = new System.Windows.Forms.Button();

                    tmp.Width = 25;
                    tmp.Height = 25;
                    tmp.BackColor = Color.Black;
                    tmp.Left = xPos;
                    tmp.Top = yPos;
                    tmp.Click += new System.EventHandler(toggleButton);

                    yPos += 25;

                    matrixButtons[y, x] = tmp;
                    designArea.Controls.Add(matrixButtons[y, x]);


                }
                xPos += 25;
                yPos = 0;
            }
        }

        public void toggleButton(object sender, EventArgs e) {
            Button btn = (Button)sender;
            if (btn.BackColor != chosenColor) {
                btn.BackColor = chosenColor;
            } else {
                btn.BackColor = Color.Black;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }
        
        private void colorButton_Click(object sender, EventArgs e) {
            if(chooseColor.ShowDialog() == DialogResult.OK) {
                chosenColor = chooseColor.Color;
                colorPrev.BackColor = chosenColor;
            }
        }

        private void scrollConfig_Enter(object sender, EventArgs e) {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e) {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e) {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e) {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e) {

        }
    }
}
