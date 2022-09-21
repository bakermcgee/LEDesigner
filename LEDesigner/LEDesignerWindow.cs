using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LEDMatrixController {
    public partial class LEDMD : Form {
        //===============================================================================
        System.Windows.Forms.Button[,] matrixButtons;
        
        Color[,] matrixColors;
        Color chosenColor = Color.White;
        
        bool firstMatrix = true;
        bool owMatrix = false;
        
        int rows;
        int cols;
        int realRows;
        int realCols;
        int mode = 0;
        int scrollMode = 0;
        int preFrameCount = 0;
        int postFrameCount = 0;
        //===============================================================================
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
        //===============================================================================
        private void updMatrix_Click(object sender, EventArgs e) {
            owMatrix = false;
            updateMatrixBox();
        }
        //===============================================================================
        private void button1_Click(object sender, EventArgs e) {
            mode = 0;
            button1.BackColor = Color.FromArgb(255, 100, 100, 100);
            button2.BackColor = Color.DarkGray;
            button3.BackColor = Color.DarkGray;
        }
        //===============================================================================
        private void button2_Click(object sender, EventArgs e) {
            mode = 1;
            button1.BackColor = Color.DarkGray;
            button2.BackColor = Color.FromArgb(255, 100, 100, 100);
            button3.BackColor = Color.DarkGray;
        }
        //===============================================================================
        private void button3_Click(object sender, EventArgs e) {
            mode = 2;
            button1.BackColor = Color.DarkGray;
            button2.BackColor = Color.DarkGray;
            button3.BackColor = Color.FromArgb(255, 100, 100, 100);
        }
        //===============================================================================
        private void button5_Click(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {

        }

        private void designArea_Paint(object sender, PaintEventArgs e) {

        }
        //===============================================================================
        void updateMatrixBox() { //updates the matrix when called 
            //-------------------------------------------------------------------
            //removes the previous Controls in the designArea panel
            foreach(Control btn in designArea.Controls.OfType<Button>().ToList()) {
                designArea.Controls.Remove(btn);
            }
            //-------------------------------------------------------------------
            rows = (int)rowVal.Value;
            cols = (int)colVal.Value;

            if(mode != 1) {
                realRows = rows;
                realCols = cols;
            } else {
                realRows = (int)realRow.Value;
                realCols = (int)realCol.Value;
            }

            matrixButtons = new System.Windows.Forms.Button[rows,cols];

            Color[,] tmpColor = matrixColors;
            matrixColors = new Color[rows, cols];

            int xPos = 0;
            int yPos = 0;
            //-------------------------------------------------------------------
            for (int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {

                    System.Windows.Forms.Button tmp = new System.Windows.Forms.Button();

                    tmp.Width = 25;
                    tmp.Height = 25;

                    if (firstMatrix || owMatrix) {
                        tmp.BackColor = Color.Black;

                    } else {
                        try {
                            tmp.BackColor = tmpColor[y, x];
                        } catch {
                            tmp.BackColor = Color.Black;
                        }
                    }

                    tmp.Left = xPos;
                    tmp.Top = yPos;
                    tmp.Tag = new int[] {y, x};
                    tmp.Click += new System.EventHandler(toggleButton);

                    yPos += 25;

                    matrixButtons[y, x] = tmp;
                    matrixColors[y, x] = tmp.BackColor;
                    designArea.Controls.Add(matrixButtons[y, x]);

                }
                xPos += 25;
                yPos = 0;
            }
            //-------------------------------------------------------------------
            firstMatrix = false;

        }
        //===============================================================================
        public void toggleButton(object sender, EventArgs e) {
            
            Button btn = (Button)sender;
            int[] xy = (int[])btn.Tag;

            if (btn.BackColor != chosenColor) {
                btn.BackColor = chosenColor;
            } else {
                btn.BackColor = Color.Black;
            }

            matrixColors[xy[0], xy[1]] = btn.BackColor;
            outputMatrix();

        }
        //===============================================================================
        private void groupBox1_Enter(object sender, EventArgs e) {

        }
        //===============================================================================
        private void colorButton_Click(object sender, EventArgs e) {
            if(chooseColor.ShowDialog() == DialogResult.OK) {
                chosenColor = chooseColor.Color;
                colorPrev.BackColor = chosenColor;
            }
        }
        //===============================================================================
        private void scrollConfig_Enter(object sender, EventArgs e) {

        }
        //===============================================================================
        private void radioButton1_CheckedChanged(object sender, EventArgs e) {
            scrollMode = 0;
        }
        //===============================================================================
        private void radioButton2_CheckedChanged(object sender, EventArgs e) {
            scrollMode = 1;
        }
        //===============================================================================
        private void radioButton3_CheckedChanged(object sender, EventArgs e) {
            scrollMode = 2;
        }
        //===============================================================================
        private void radioButton4_CheckedChanged(object sender, EventArgs e) {
            scrollMode = 3;
        }
        //===============================================================================
        private void ovrwrMatrix_Click(object sender, EventArgs e) {
            owMatrix = true;
            updateMatrixBox();
        }
        //===============================================================================
        void outputMatrix() {
            Console.WriteLine();
            for (int y = 0; y < rows; y++) {
                for (int x = 0; x < cols; x++) {
                    Console.Write(matrixColors[y, x]);
                }
                Console.WriteLine();
            }
        }
        //===============================================================================
        private void preVal_ValueChanged(object sender, EventArgs e) {
            preFrameCount = (int)preVal.Value;
        }
        //===============================================================================
        private void postVal_ValueChanged(object sender, EventArgs e) {
            postFrameCount = (int)postVal.Value;
        }
        //===============================================================================
        private void saveDesign_Click(object sender, EventArgs e) {
            if (matrixColors != null) {
                FileStream saveFile;
                StreamWriter saveWriter;
                String filePath = "";
                bool success = false;

                if (savePattern.ShowDialog() == DialogResult.OK) {
                    if ((saveFile = savePattern.OpenFile() as FileStream) != null) {

                        saveWriter = new StreamWriter(saveFile);
                        
                        for (int y = 0; y < rows; y++) {
                            for (int x = 0; x < cols; x++) {
                                String color = ColorTranslator.ToHtml(matrixColors[y, x]);
                                saveWriter.WriteLine(color);
                            }
                            saveWriter.WriteLine("-");
                        }

                        filePath = Path.GetDirectoryName(saveFile.Name) + @"\config.cfg";
                        success = true;

                        saveWriter.Close();
                        saveFile.Close();
                    }
                }

                if (success) {
                    
                    if (File.Exists(filePath)) {
                        File.Delete(filePath);
                    }

                    saveFile = new FileStream(filePath, FileMode.Create);
                    saveWriter = new StreamWriter(saveFile);

                    saveWriter.WriteLine("!Mode: 1 is static, 2 is scrolling, 3 is frame by frame");
                    saveWriter.WriteLine("mode = " + mode);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!Matrix Size: size of your LED matrix strip based on rows and columns");
                    saveWriter.WriteLine("rows = " + realRows);
                    saveWriter.WriteLine("columns = " + realCols);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!Scroll Mode: 1 right to left, 2 left to right, 3 top to bottom, 4 bottom to top");
                    saveWriter.WriteLine("scrollMode = " + scrollMode);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!In-between frames: set the number of frames before and after a non-static pattern");
                    saveWriter.WriteLine("preFrameCount = " + preFrameCount);
                    saveWriter.WriteLine("postFrameCount = " + postFrameCount);

                }
            }
        }
        //===============================================================================
    }
}
