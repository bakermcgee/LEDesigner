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

        List<Color[,]> colorMatrices = new List<Color[,]>();
        Color[,] matrixColors;
        Color chosenColor = Color.White;
        
        bool firstMatrix = true;
        bool owMatrix = false;
        bool dupNext = false;
        bool dupPrev = false;
        
        int rows;
        int cols;
        int realRows;
        int realCols;
        int mode = 0;
        int scrollMode = 0;
        int frameCount = 0;
        int currentFrame = 0;
        int gpio = 18;
        int freqhz = 800;
        int dmaChannel = 10;
        int brightLED = 10;
        int invSignal = 0;
        
        double preFrameCount = 0;
        double postFrameCount = 0;
        double spd = 1.0;

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

            frameCount = 0;
            numOfFrames.Value = 0;
            colorMatrices = new List<Color[,]>();
        }
        //===============================================================================
        private void button1_Click(object sender, EventArgs e) {
            mode = 0;
            realRows = (int)rowVal.Value;
            realCols = (int)colVal.Value;

            button1.BackColor = Color.FromArgb(255, 100, 100, 100);
            button2.BackColor = Color.DarkGray;
            button3.BackColor = Color.DarkGray;
            nextFrame.BackColor = Color.DimGray;
            prevFrame.BackColor = Color.DimGray;

            scrollConfig.Enabled = false;
            frameConfig.Enabled = false;
            fbfConfig.Enabled = false;
            fbfPages.Enabled = false;

            frameCount = 0;
            numOfFrames.Value = 0;
            colorMatrices = new List<Color[,]>();
        }
        //===============================================================================
        private void button2_Click(object sender, EventArgs e) {
            mode = 1;

            button1.BackColor = Color.DarkGray;
            button2.BackColor = Color.FromArgb(255, 100, 100, 100);
            button3.BackColor = Color.DarkGray;
            nextFrame.BackColor = Color.DimGray;
            prevFrame.BackColor = Color.DimGray;

            scrollConfig.Enabled = true;
            frameConfig.Enabled = true;
            fbfConfig.Enabled = false;
            fbfPages.Enabled = false;

            frameCount = 0;
            numOfFrames.Value = 0;
            colorMatrices = new List<Color[,]>();
        }
        //===============================================================================
        private void button3_Click(object sender, EventArgs e) {
            mode = 2;
            realRows = (int)rowVal.Value;
            realCols = (int)colVal.Value;

            button1.BackColor = Color.DarkGray;
            button2.BackColor = Color.DarkGray;
            button3.BackColor = Color.FromArgb(255, 100, 100, 100);
            nextFrame.BackColor = Color.WhiteSmoke;
            prevFrame.BackColor = Color.WhiteSmoke;

            scrollConfig.Enabled = false;
            frameConfig.Enabled = true;
            fbfConfig.Enabled = true;
            fbfPages.Enabled = true;
            //nextFrame.Enabled = true;
            //prevFrame.Enabled = true;
        }
        //===============================================================================
        private void button5_Click(object sender, EventArgs e) {

        }

        private void button4_Click(object sender, EventArgs e) {
            System.Windows.Forms.Application.Exit();
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

            if(mode == 2) {
                colorMatrices[currentFrame] = matrixColors;
            }

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

            frameCount = 0;
            numOfFrames.Value = 0;
            colorMatrices = new List<Color[,]>();
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
            preFrameCount = (double)preVal.Value;
        }
        //===============================================================================
        private void postVal_ValueChanged(object sender, EventArgs e) {
            postFrameCount = (double)postVal.Value;
        }
        //===============================================================================
        private void saveDesign_Click(object sender, EventArgs e) {
            if (matrixColors != null) {
                FileStream saveFile;
                StreamWriter saveWriter;
                String filePath = "";
                String fileName = "";
                bool success = false;
                saveDesign.Enabled = false;

                if (savePattern.ShowDialog() == DialogResult.OK) {
                    saveBar.Value = 0;
                    if ((saveFile = savePattern.OpenFile() as FileStream) != null) {

                        saveWriter = new StreamWriter(saveFile);
 
                        if (mode != 2) {
                            for (int y = 0; y < rows; y++) {
                                for (int x = 0; x < cols; x++) {
                                    String color = ColorTranslator.ToHtml(Color.FromArgb(matrixColors[y, x].ToArgb()));
                                    saveWriter.WriteLine(color);
                                    saveBar.Value += (50 / (rows * cols));
                                }
                                saveWriter.WriteLine("-");
                            }
                        } else {
                            foreach(Color[,] frame in colorMatrices) {
                                for (int y = 0; y < rows; y++) {
                                    for (int x = 0; x < cols; x++) {
                                        String color = ColorTranslator.ToHtml(Color.FromArgb(frame[y, x].ToArgb()));
                                        saveWriter.WriteLine(color);
                                    }
                                    saveWriter.WriteLine("-");
                                }
                                saveBar.Value += (50 / frameCount);
                                saveWriter.WriteLine("=");
                            }
                        }

                        filePath = Path.GetDirectoryName(saveFile.Name) + @"\config.cfg";
                        fileName = Path.GetFileName(saveFile.Name);
                        success  = true;

                        saveWriter.Close();
                        saveFile.Close();

                        saveBar.Value = 50;
                    }
                } else if (savePattern.ShowDialog() != DialogResult.OK) {
                    saveDesign.Enabled = true;
                }

                if (success) {
                    
                    if (File.Exists(filePath)) {
                        File.Delete(filePath);
                    }

                    saveFile = new FileStream(filePath, FileMode.Create);
                    saveWriter = new StreamWriter(saveFile);

                    saveWriter.WriteLine("!Mode: 0 is static, 1 is scrolling, 2 is frame by frame");
                    saveWriter.WriteLine("mode = " + mode);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!Matrix Size: size of your LED matrix strip based on rows and columns");
                    saveWriter.WriteLine("rows = " + realRows);
                    saveWriter.WriteLine("columns = " + realCols);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!Scroll Mode: 0 right to left, 1 left to right, 2 top to bottom, 3 bottom to top");
                    saveWriter.WriteLine("scrollMode = " + scrollMode);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!In-between patterns: set the number of seconds before and after a non-static pattern");
                    saveWriter.WriteLine("preFrame = " + preFrameCount);
                    saveWriter.WriteLine("postFrame = " + postFrameCount);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("patternFile = " + fileName);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!Frames: set the number of frames in a pattern");
                    saveWriter.WriteLine("frames = " + frameCount);
                    saveWriter.WriteLine("!---------------------------------------------------------------------------------");
                    saveWriter.WriteLine("!LED Strip/RaspberryPi Settings");
                    saveWriter.WriteLine("gpio = " + gpio); //7
                    saveWriter.WriteLine("freqhz = " + freqhz);//9
                    saveWriter.WriteLine("dma = " + dmaChannel);//6
                    saveWriter.WriteLine("brightness = " + brightLED);//13
                    saveWriter.WriteLine("inv = " + invSignal);//6
                    saveWriter.WriteLine("speed = " + spd);//8

                    saveWriter.Close();
                    saveFile.Close();

                    saveBar.Value = 100;
                    saveDesign.Enabled = true;

                }
            }
        }

        private void realRow_ValueChanged(object sender, EventArgs e) {
            if(mode == 1) {
                realRows = (int)realRow.Value;
            }
        }

        private void realCol_ValueChanged(object sender, EventArgs e) {
            if (mode == 1) {
                realCols = (int)realCol.Value;
            }            
        }

        private void label10_Click(object sender, EventArgs e) {

        }

        private void invertSignal_CheckedChanged(object sender, EventArgs e) {
            if(invSignal == 0) {
                invSignal = 1;
            } else {
                invSignal = 0;
            }
        }

        private void gpioPin_ValueChanged(object sender, EventArgs e) {
            gpio = (int)gpioPin.Value;
        }

        private void freq_ValueChanged(object sender, EventArgs e) {
            freqhz = (int)freq.Value;
        }

        private void dma_ValueChanged(object sender, EventArgs e) {
            dmaChannel = (int)dma.Value;
        }

        private void brightnessLED_ValueChanged(object sender, EventArgs e) {
            brightLED = (int)brightnessLED.Value;
        }

        private void animateSpd_ValueChanged(object sender, EventArgs e) {
            spd = (double)animateSpd.Value;
        }

        private void updateFrameCount_Click(object sender, EventArgs e) {
            int tmp = frameCount;
            frameCount = (int)numOfFrames.Value;

            Color[,] mC = new Color[rows, cols];

            for (int x = 0; x < cols; x++) {
                for (int y = 0; y < rows; y++) {
                    mC[y, x] = Color.Black;
                }
            }

            if (frameCount > tmp) {
                foreach(int i in Enumerable.Range(tmp, (frameCount - tmp))) {
                    colorMatrices.Add(mC);
                }
            }else if(frameCount < tmp) {
                foreach (int i in Enumerable.Range(frameCount, (tmp - frameCount)).Reverse()) {
                    colorMatrices.RemoveAt(i);
                }
            }

            if(currentFrame != frameCount) {
                nextFrame.Enabled = true;
            } else {
                nextFrame.Enabled = false;
            }

            if(currentFrame != 0) {
                prevFrame.Enabled = true;

            } else {
                prevFrame.Enabled = false;
            }

            Console.WriteLine(colorMatrices.Count);
        }

        private void nextFrame_Click(object sender, EventArgs e) {
            currentFrame++;
            duplicatePrev.Checked = false;

            if (currentFrame != 0) {
                prevFrame.Enabled = true;
            }

            if (dupNext) {
                colorMatrices[currentFrame] = matrixColors;
            }

            matrixColors = colorMatrices[currentFrame];
            owMatrix = false;
            updateMatrixBox();
            
            if(currentFrame == frameCount - 1) {
                nextFrame.Enabled = false;
            }
        }

        private void prevFrame_Click(object sender, EventArgs e) {
            currentFrame--;
            duplicateNext.Checked = false;

            if (currentFrame != frameCount) {
                nextFrame.Enabled = true;
            }

            if (dupPrev) {
                colorMatrices[currentFrame] = matrixColors;
            }

            matrixColors = colorMatrices[currentFrame];
            owMatrix = false;
            updateMatrixBox();

            if (currentFrame == 0) {
                prevFrame.Enabled = false;
            }
        }

        private void duplicateNext_CheckedChanged(object sender, EventArgs e) {
            dupNext = !dupNext;
        }

        private void duplicatePrev_CheckedChanged(object sender, EventArgs e) {
            dupPrev = !dupPrev;
        }

        //===============================================================================
    }
}
