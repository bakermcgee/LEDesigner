using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
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
        bool fill = false;
        bool pickCol = false;
        
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
        int zoom = 25;
        
        double preFrameCount = 0;
        double postFrameCount = 0;
        double spd = 1.0;

        String gapColor = "#000000";

        //===============================================================================
        public LEDMD() {
            InitializeComponent();
        }
        //===============================================================================
        private void updMatrix_Click(object sender, EventArgs e) {
            owMatrix = false;
            updateMatrixBox();

            if (mode == 2) {
                numOfFrames.Value = 1;
                updateFrameCount.PerformClick();
            }
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
            imgFrames.Enabled = false;

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
            imgFrames.Enabled= false;

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
        }
        //===============================================================================
        private void button5_Click(object sender, EventArgs e) {
            
            String filePath = "";
            String fileName = "";
            FileStream saveFile;
            StreamReader saveReader;

            if (loadPattern.ShowDialog() == DialogResult.OK) {
                if ((saveFile = loadPattern.OpenFile() as FileStream) != null) {
                    filePath = Path.GetDirectoryName(saveFile.Name);
                    fileName = Path.GetFileName(saveFile.Name);

                    saveFile.Close();

                    try {
                        saveReader = new StreamReader(filePath + @"\config.cfg");
                        string settings;
                        while ((settings = saveReader.ReadLine()) != null) {
                            if (settings[0] != '!') {
                                if (settings.Contains("mode = ")) {
                                    mode = Int32.Parse(settings.Substring(7));

                                } else if (settings.Contains("rows = ")) {
                                    realRows = Int32.Parse(settings.Substring(7));
                                    realRow.Value = realRows;

                                } else if (settings.Contains("columns = ")) {
                                    realCols = Int32.Parse(settings.Substring(10));
                                    realCol.Value = realCols;

                                } else if (settings.Contains("scrollMode = ")) {
                                    scrollMode = Int32.Parse(settings.Substring(13));

                                } else if (settings.Contains("preFrame = ")) {
                                    preFrameCount = Double.Parse(settings.Substring(11));
                                    preVal.Value = (decimal)preFrameCount;

                                } else if (settings.Contains("postFrame = ")) {
                                    postFrameCount = Double.Parse(settings.Substring(12));
                                    postVal.Value = (decimal)postFrameCount;

                                } else if (settings.Contains("patternFile = ")) {

                                } else if (settings.Contains("frames = ")) {
                                    frameCount = Int32.Parse(settings.Substring(9));
                                    numOfFrames.Value = (int)frameCount;

                                } else if (settings.Contains("gpio = ")) {
                                    gpioPin.Value = Int32.Parse(settings.Substring(7));
                                    gpio = (int)gpioPin.Value;

                                } else if (settings.Contains("freqhz = ")) {
                                    freq.Value = Int32.Parse(settings.Substring(9));

                                } else if (settings.Contains("dma = ")) {
                                    dma.Value = Int32.Parse(settings.Substring(6));

                                } else if (settings.Contains("brightness = ")) {
                                    brightnessLED.Value = Int32.Parse(settings.Substring(13));

                                } else if (settings.Contains("inv = ")) {
                                    if (Int32.Parse(settings.Substring(6)) == 1) {
                                        invertSignal.Checked = true;
                                    }

                                } else if (settings.Contains("speed = ")) {
                                    spd = Double.Parse(settings.Substring(8));
                                    animateSpd.Value = (decimal)spd;

                                } else if (settings.Contains("gapColor = ")) {
                                    gapColor = settings.Substring(11);
                                    gapVal.Text = gapColor;

                                }
                            }
                        }

                        saveReader.Close();

                        if (mode == 0) {
                            button1.PerformClick();
                        } else if (mode == 1) {
                            button2.PerformClick();
                        } else if (mode == 2) {
                            button3.PerformClick();
                            updateFrameCount.PerformClick();
                        }

                        saveReader = new StreamReader(filePath + @"\" + fileName);

                        List<String> hexList = new List<String>();
                        string hex;
                        bool first = true;
                        rows = 0;
                        cols = 0;
                        while ((hex = saveReader.ReadLine()) != null) {
                            if (hex[0] == '#') {
                                hexList.Add(hex);
                            } else if (hex[0] == '-') {
                                if (first) {
                                    cols = hexList.Count;
                                    colVal.Value = cols;
                                    first = false;
                                }
                                rows += 1;
                            }
                        }
                        Console.WriteLine(hexList.Count);
                        saveReader.Close();

                        if (frameCount > 0) {
                            rows = rows / frameCount;
                            rowVal.Value = rows;
                            colorMatrices = new List<Color[,]>();
                            int i = 0;

                            for (int frame = 0; frame < frameCount; frame++) {
                                matrixColors = new Color[rows, cols];

                                for (int y = 0; y < rows; y++) {
                                    for (int x = 0; x < cols; x++) {
                                        matrixColors[y, x] = ColorTranslator.FromHtml(hexList[i]);
                                        i++;
                                    }
                                }

                                colorMatrices.Add(matrixColors);
                            }

                            currentFrame = 0;
                            firstMatrix = false;
                            owMatrix = false;
                            updateMatrixBox();
                            firstFrame();

                        } else {
                            rowVal.Value = rows;
                            matrixColors = new Color[rows, cols];
                            int i = 0;

                            for (int y = 0; y < rows; y++) {
                                for (int x = 0; x < cols; x++) {
                                    Console.WriteLine(rows);
                                    Console.WriteLine(cols);
                                    Console.WriteLine(i);
                                    Console.WriteLine(hexList.Count);

                                    matrixColors[y, x] = ColorTranslator.FromHtml(hexList[i]);
                                    i++;
                                }
                            }

                            firstMatrix = false;
                            owMatrix = false;
                            updateMatrixBox();
                        }
                    } catch {
                        errorMessage.Text = "An error occured: probably missing config file.";
                    }
                }
            }
        }
        //===============================================================================
        private void button4_Click(object sender, EventArgs e) {
            System.Windows.Forms.Application.Exit();
        }
        //===============================================================================
        void updateMatrixBox() { //updates the matrix when called 
            //-------------------------------------------------------------------
            //removes the previous Controls in the designArea panel
            foreach (Control btn in designArea.Controls.OfType<Button>().ToList()) {
                designArea.Controls.Remove(btn);
            }
            //-------------------------------------------------------------------
            rows = (int)rowVal.Value;
            cols = (int)colVal.Value;

            if (mode != 1) {
                realRows = rows;
                realCols = cols;
            } else {
                realRows = (int)realRow.Value;
                realCols = (int)realCol.Value;
            }

            if (rows > 5 && cols > 5) {
                imgFrame.Enabled = true;
                if(mode == 2)
                    imgFrames.Enabled = true;
            } else { 
                imgFrame.Enabled = false;
                imgFrames.Enabled = false;
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

                    tmp.Width = zoom;
                    tmp.Height = zoom;

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

                    yPos += zoom;

                    matrixButtons[y, x] = tmp;
                    matrixColors[y, x] = tmp.BackColor;
                    designArea.Controls.Add(matrixButtons[y, x]);

                }
                xPos += zoom;
                yPos = 0;
            }
            //-------------------------------------------------------------------
            firstMatrix = false;
        }
        //===============================================================================
        //toggles a "pixel" when clicked
        public void toggleButton(object sender, EventArgs e) {
            
            Button btn = (Button)sender;
            int[] xy = (int[])btn.Tag;
            Color tmp = btn.BackColor;
            bool canFill = false;

            if (!pickCol) { 
                if (btn.BackColor != chosenColor) {
                    btn.BackColor = chosenColor;
                    canFill = true;
                } else {
                    btn.BackColor = Color.Black;
                }

                matrixColors[xy[0], xy[1]] = btn.BackColor;

                if (canFill && fill) { //fills pixels when fill is toggled true
                    int y = xy[0];
                    int x = xy[1];

                    while (y < rows - 1 && matrixColors[y + 1, x] == tmp) {
                        matrixColors[y + 1, x] = chosenColor;
                        y++;
                    }
                    y = xy[0];
                
                    while (y > 0 && matrixColors[y - 1, x] == tmp) {
                        matrixColors[y - 1, x] = chosenColor;
                        y--;
                    }
                    y = xy[0];

                    while (x < cols - 1 && matrixColors[y, x + 1] == tmp) {
                        matrixColors[y, x + 1] = chosenColor;
                        while (y < rows - 1 && matrixColors[y + 1, x + 1] == tmp) {
                            matrixColors[y + 1, x + 1] = chosenColor;
                            y++;
                        }
                        y = xy[0];
                    
                        while (y > 0 && matrixColors[y - 1, x + 1] == tmp) {
                            matrixColors[y - 1, x + 1] = chosenColor;
                            y--;
                        }
                        y = xy[0];
                        x++;
                    }

                    y = xy[0];
                    x = xy[1];

                    while (x > 0 && matrixColors[y, x - 1] == tmp) {
                        matrixColors[y, x - 1] = chosenColor;
                        while (y < rows - 1 && matrixColors[y + 1, x - 1] == tmp) {
                            matrixColors[y + 1, x - 1] = chosenColor;
                            y++;
                        }
                        y = xy[0];
                    
                        while (y > 0 && matrixColors[y - 1, x - 1] == tmp) {
                            matrixColors[y - 1, x - 1] = chosenColor;
                            y--;
                        }
                        y = xy[0];
                        x--;
                    }

                    owMatrix = false;
                    updateMatrixBox();

                }

                if(mode == 2) {
                    Console.WriteLine(currentFrame);
                    Console.WriteLine(colorMatrices.Count);
                    colorMatrices[currentFrame] = matrixColors;
                }
            } else {
                chosenColor = btn.BackColor;
                colorPrev.BackColor = chosenColor;
            }
            //outputMatrix();
        }
        //===============================================================================
        private void colorButton_Click(object sender, EventArgs e) {
            if(chooseColor.ShowDialog() == DialogResult.OK) {
                chosenColor = chooseColor.Color;
                colorPrev.BackColor = chosenColor;
            }
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

            if (mode == 2) {
                numOfFrames.Value = 1;
                updateFrameCount.PerformClick();
            }
        }
        //===============================================================================
        //outputs matrix to console - meant for debug purposes
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
                    saveWriter.WriteLine("gapColor = " + gapColor); //11

                    saveWriter.Close();
                    saveFile.Close();

                    saveBar.Value = 100;
                    saveDesign.Enabled = true;

                }
            }
        }
        //===============================================================================
        private void realRow_ValueChanged(object sender, EventArgs e) {
            if(mode == 1) {
                realRows = (int)realRow.Value;
            }
        }
        //===============================================================================
        private void realCol_ValueChanged(object sender, EventArgs e) {
            if (mode == 1) {
                realCols = (int)realCol.Value;
            }            
        }
        //===============================================================================
        private void invertSignal_CheckedChanged(object sender, EventArgs e) {
            if(invSignal == 0) {
                invSignal = 1;
            } else {
                invSignal = 0;
            }
        }
        //===============================================================================
        private void gpioPin_ValueChanged(object sender, EventArgs e) {
            gpio = (int)gpioPin.Value;
        }
        //===============================================================================
        private void freq_ValueChanged(object sender, EventArgs e) {
            freqhz = (int)freq.Value;
        }
        //===============================================================================
        private void dma_ValueChanged(object sender, EventArgs e) {
            dmaChannel = (int)dma.Value;
        }
        //===============================================================================
        private void brightnessLED_ValueChanged(object sender, EventArgs e) {
            brightLED = (int)brightnessLED.Value;
        }
        //===============================================================================
        private void animateSpd_ValueChanged(object sender, EventArgs e) {
            spd = (double)animateSpd.Value;
        }
        //===============================================================================
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

            if(currentFrame != frameCount && currentFrame < frameCount - 1) {
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
        //===============================================================================
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
        //===============================================================================
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
        //===============================================================================
        private void duplicateNext_CheckedChanged(object sender, EventArgs e) {
            dupNext = !dupNext;
        }
        //===============================================================================
        private void duplicatePrev_CheckedChanged(object sender, EventArgs e) {
            dupPrev = !dupPrev;
        }
        //===============================================================================
        private void button6_Click(object sender, EventArgs e) {
            
            fill = !fill;
            
            if (!fill) {
                button6.BackColor = Color.DarkGray;
            } else {
                if (pickCol) {
                    colorPick.PerformClick();
                }
                button6.BackColor = Color.FromArgb(255, 100, 100, 100);
            }
        
        }
        //===============================================================================
        private void gapVal_TextChanged(object sender, EventArgs e) {
            gapColor = gapVal.Text;
        }
        //===============================================================================
        private void button7_Click(object sender, EventArgs e) {

            if (!button8.Enabled) {
                button8.Enabled = true;
            }

            if (zoom > 10) {
                zoom -= 1;
            }
            owMatrix = false;
            updateMatrixBox();

            if (zoom == 10) {
                button7.Enabled = false;
            }

        }
        //===============================================================================
        private void button8_Click(object sender, EventArgs e) {

            if (!button7.Enabled) {
                button7.Enabled = true;
            }

            if (zoom < 30) {
                zoom += 1;
            }
            
            owMatrix = false;
            updateMatrixBox();

            if (zoom == 30) { 
                button8.Enabled = false;
            }
        }
        //===============================================================================
        private void colorPick_Click(object sender, EventArgs e) {
            pickCol = !pickCol;

            if (!pickCol) {
                colorPick.BackColor = Color.DarkGray;
            } else {
                if (fill) {
                    button6.PerformClick();
                }
                colorPick.BackColor = Color.FromArgb(255, 100, 100, 100);
            }
        }
        //===============================================================================
        private void imgFrame_Click(object sender, EventArgs e) { //converts an image to a single frame
            if (loadImage.ShowDialog() == DialogResult.OK) { 
                
                string path = Path.GetFullPath(loadImage.FileName);
                Image inputImage = Image.FromFile(path);

                matrixColors = new Color[rows, cols];

                Bitmap bmp = new Bitmap(inputImage, new Size(cols, rows));
                for (int y = 0; y < rows; y++) {
                    for (int x = 0; x < cols; x++) {
                        matrixColors[y, x] = bmp.GetPixel(x, y);
                    }
                }

                if (mode == 2)
                    colorMatrices[currentFrame] = matrixColors;

                firstMatrix = false;
                owMatrix = false;
                updateMatrixBox();

                bmp.Dispose();
                inputImage.Dispose();
            }
        }
        //===============================================================================
        private void imgFrames_Click(object sender, EventArgs e) { //converts an animated image into multiple frames
            if (loadGif.ShowDialog() == DialogResult.OK) {

                string path = Path.GetFullPath(loadGif.FileName);
                Image inputImage = Image.FromFile(path);
                FrameDimension imgDim = new FrameDimension(inputImage.FrameDimensionsList[0]);

                frameCount = inputImage.GetFrameCount(imgDim);
                numOfFrames.Value = (int)frameCount;
                updateFrameCount.PerformClick();

                colorMatrices = new List<Color[,]>();

                for (int i = 0; i < frameCount; i++) {
                    
                    matrixColors = new Color[rows, cols];
                    
                    inputImage.SelectActiveFrame(imgDim, i);
                    Bitmap bmp = new Bitmap(inputImage, new Size(cols, rows));
                    
                    for (int y = 0; y < rows; y++) {
                        for (int x = 0; x < cols; x++) {
                            matrixColors[y, x] = bmp.GetPixel(x, y);
                        }
                    }

                    bmp.Dispose();
                    colorMatrices.Add(matrixColors);
                }

                currentFrame = 0;
                firstMatrix = false;
                owMatrix = false;
                updateMatrixBox();
                firstFrame();

                
                inputImage.Dispose();
            }
        }
        //===============================================================================
        void firstFrame() { //returns a fbf pattern to the first frame
            prevFrame.Enabled = false;
            nextFrame.Enabled = true;
        }

        private void button9_Click(object sender, EventArgs e) {
            if (allFrames.Checked && mode == 2) {
                var tmps = colorMatrices;
                int r = (int)rVal.Value;
                int g = (int)gVal.Value;
                int b = (int)bVal.Value;

                try {

                    for (int frame = 0; frame < frameCount; frame++) {
                        var tmp = tmps[frame];

                        for (int y = 0; y < rows; y++) {
                            for (int x = 0; x < cols; x++) {
                                var cr = tmp[y, x].R;
                                var cg = tmp[y, x].G;
                                var cb = tmp[y, x].B;
                                tmp[y, x] = Color.FromArgb(cr + r, cg + g, cb + b);
                            }
                        }

                        tmps.Add(tmp);
                    }

                    colorMatrices = tmps;
                    updateMatrixBox();
                    firstFrame();

                } catch {
                    rVal.Value = 0;
                    gVal.Value = 0;
                    bVal.Value = 0;
                }
            } else {
                var tmp = matrixColors;
                int r = (int)rVal.Value;
                int g = (int)gVal.Value;
                int b = (int)bVal.Value;

                try {
                    for (int y = 0; y < rows; y++) {
                        for (int x = 0; x < cols; x++) {
                            var cr = tmp[y, x].R;
                            var cg = tmp[y, x].G;
                            var cb = tmp[y, x].B;
                            tmp[y, x] = Color.FromArgb(cr + r, cg + g, cb + b);
                        }
                    }

                    matrixColors = tmp;
                    updateMatrixBox();

                    if (mode == 2) {
                        colorMatrices[currentFrame] = matrixColors;
                    }

                } catch {
                    rVal.Value = 0;
                    gVal.Value = 0;
                    bVal.Value = 0;
                }
            }
        }
        //===============================================================================
    }
}
