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

namespace NoahWilson_GOL
{
    public partial class Form1 : Form
    {
        // The universe array
        int universeX = Properties.Settings.Default.UniverseX;
        int universeY = Properties.Settings.Default.UniverseY;
        bool[,] universe;
        bool[,] scratchPad;

        //Random number for use with universe resetting
        Random rand = new Random();

        // Drawing colors
        Color gridColor = Color.Black;
        Color cellColor = Color.Gray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;
        bool nextgen = true;

        //bool to decide what type of universe to use
        bool finite = Properties.Settings.Default.Finite;

        public Form1()
        {
            InitializeComponent();

            //resize universe
            int universeX = Properties.Settings.Default.UniverseX;
            int universeY = Properties.Settings.Default.UniverseY;
            universe = new bool[universeX, universeY];
            scratchPad = new bool[universeX, universeY];
            // Setup the timer
            RandyUniverse(0); //randomize the universe
            timer.Interval = Properties.Settings.Default.TimerInterval; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = true;
            //Updating color settings
            graphicsPanel1.BackColor = Properties.Settings.Default.DeadCellColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.LiveCellColor;
        }

        //random universe creation
        private void RandyUniverse(int seed)
        {
            if(seed != 1) // does not create a new seed if the int is 1 so we can restart off the current seed if necessary
            rand = new Random(seed);

            int spawnnum;
            scratchPad = new bool[universeX, universeY];
            for (int i = 0; i < universe.GetLength(0); i++)
            {
                for (int j = 0; j < universe.GetLength(1); j++)
                {
                    spawnnum = rand.Next(0, 3);
                    if (spawnnum == 0)
                    {
                        scratchPad[i, j] = true;
                    }
                }
            }
            universe = scratchPad;
            graphicsPanel1.Invalidate();
        }


        // Calculate the next generation of cells
        private void NextGeneration()
        {
            scratchPad = new bool[universe.GetLength(0), universe.GetLength(1)];
            int livingcells = 0;
            // Increment generation count
            generations++;
            for (int i = 0; i < scratchPad.GetLength(0); i++) // i acts as the y variable
            {
                for (int j = 0; j < scratchPad.GetLength(1); j++) // j acts as the x variable
                {
                    int neighbors = 0; //counts the neighbors of each cell for calculations
                    //iterating through all the cells in the array
                    if (finite) // if finite is true, finite universe neighbor count ensues otherwise i use toroidal
                    {
                        neighbors = CountNeighborsFinite(i, j);
                    }
                    else neighbors = CountNeighborsToroidal(i, j);
                    if (!universe[i, j]) // if the cell is dead
                    {
                        if (neighbors == 3)
                        {
                            livingcells++; // if the cell is on, increase the living cells status strip number.
                            scratchPad[i, j] = true;
                        }
                    }
                    else if (universe[i, j])
                    {
                        if (neighbors == 2 || neighbors == 3)
                        {
                            livingcells++; // if the cell is on, increase the living cells status strip number.
                            scratchPad[i, j] = true;
                            toolStripStatusLabelLC.Text = "Living Cells = " + livingcells;
                        }
                        if (neighbors < 2)
                        {
                            scratchPad[i, j] = false;

                        }
                        if (neighbors > 3)
                        {
                            scratchPad[i, j] = false;

                        }
                    }
                }
            }
            universe = scratchPad;
            graphicsPanel1.Invalidate();
            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
        }

        private int CountNeighborsToroidal(int x, int y)

        {

            int count = 0;

            int xLen = universe.GetLength(0);

            int yLen = universe.GetLength(1);


            for (int yOffset = -1; yOffset <= 1; yOffset++)

            {

                for (int xOffset = -1; xOffset <= 1; xOffset++)

                {

                    int xCheck = x + xOffset;

                    int yCheck = y + yOffset;


                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }
                    if (xCheck < 0)
                    {
                        xCheck = xLen - 1;
                    }
                    if (yCheck < 0)
                    {
                        yCheck = yLen - 1;
                    }
                    if (xCheck >= xLen)
                    {
                        xCheck = 0;
                    }
                    if (yCheck >= yLen)
                    {
                        yCheck = 0;
                    }

                    // if xCheck is less than 0 then set to xLen - 1

                    // if yCheck is less than 0 then set to yLen - 1

                    // if xCheck is greater than or equal too xLen then set to 0

                    // if yCheck is greater than or equal too yLen then set to 0




                    if (universe[xCheck, yCheck] == true) count++;

                }

            }


            return count;

        }

        //count the neighbors of the universe in a closed space
        private int CountNeighborsFinite(int x, int y)

        {

            int count = 0;

            int xLen = universe.GetLength(0);

            int yLen = universe.GetLength(1);


            for (int yOffset = -1; yOffset <= 1; yOffset++)

            {

                for (int xOffset = -1; xOffset <= 1; xOffset++)

                {

                    int xCheck = x + xOffset;

                    int yCheck = y + yOffset;


                    // if xOffset and yOffset are both equal to 0 then continue
                    if (xOffset == 0 && yOffset == 0)
                    {
                        continue;
                    }

                    // if xCheck is less than 0 then continue
                    if (xCheck < 0)
                    {
                        continue;
                    }
                    // if yCheck is less than 0 then continue
                    if (yCheck < 0)
                    {
                        continue;
                    }
                    // if xCheck is greater than or equal too xLen then continue
                    if (xCheck >= xLen)
                    {
                        continue;
                    }
                    // if yCheck is greater than or equal too yLen then continue
                    if (yCheck >= yLen)
                    {
                        continue;
                    }



                    if (universe[xCheck, yCheck] == true) count++;
                }
            }
            return count;
        }

        //saves the universe to a new file
        private void SaveUniverse()
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
            StreamWriter writer;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                writer = new StreamWriter(dlg.FileName);

                // Write any comments you want to include first.
                // Prefix all comment strings with an exclamation point.
                // Use WriteLine to write the strings to the file. 
                // It appends a CRLF for you.
                writer.WriteLine("!Noah Wilson Save");

                // Iterate through the universe one row at a time.
                for (int y = 0; y < universe.GetLength(0); y++)
                {
                    // Create a string to represent the current row.
                    String currentRow = string.Empty;

                    // Iterate through the current row one cell at a time.
                    for (int x = 0; x < universe.GetLength(1); x++)
                    {
                        // If the universe[x,y] is alive then append 'O' (capital O)
                        // to the row string.
                        if (universe[x, y])
                        {
                            currentRow += 'O';
                        }


                        // Else if the universe[x,y] is dead then append '.' (period)
                        // to the row string.
                        else currentRow += '.';
                    }

                    // Once the current row has been read through and the 
                    // string constructed then write it to the file using WriteLine.
                    writer.WriteLine(currentRow);
                }

                // After all rows and columns have been written then close the file.
                writer.Close();
            }
        }

        //loads the universe into the game
        private void OpenUniverse()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);

                // Create a couple variables to calculate the width and height
                // of the data in the file.
                int maxWidth = 0;
                int maxHeight = 0;

                // Iterate through the file once to get its size.
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then it is a comment
                    // and should be ignored.
                    if(row.StartsWith("!"))
                    {
                        continue;
                    }
                    else
                    {
                        maxHeight++;
                        maxWidth = row.Length;
                    }

                    // If the row is not a comment then it is a row of cells.
                    // Increment the maxHeight variable for each row read.

                    // Get the length of the current row string
                    // and adjust the maxWidth variable if necessary.
                }

                universe = new bool[maxWidth, maxHeight];
                // Resize the current universe and scratchPad
                // to the width and height of the file calculated above.

                // Reset the file pointer back to the beginning of the file.
                reader.BaseStream.Seek(0, SeekOrigin.Begin);

                // Iterate through the file again, this time reading in the cells.
                int y = 0;
                while (!reader.EndOfStream)
                {
                    // Read one row at a time.
                    string row = reader.ReadLine();

                    // If the row begins with '!' then
                    // it is a comment and should be ignored.
                    if (row.StartsWith("!"))
                    {
                        continue;
                    }
                    // If the row is not a comment then 
                    // it is a row of cells and needs to be iterated through.
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {
                            // If row[xPos] is a 'O' (capital O) then
                            if (row[xPos] == 'O')
                            {
                                universe[xPos, y] = true;
                            }
                            else universe[xPos, y] = false;
                            // set the corresponding cell in the universe to alive.

                            // If row[xPos] is a '.' (period) then
                            // set the corresponding cell in the universe to dead.
                        }
                    y++;
                }

                // Close the file.
                reader.Close();
            }
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e)
        {
            NextGeneration();
            if(nextgen)
            {
                nextgen = false;
                timer.Stop();
            }
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush cellBrush = new SolidBrush(cellColor);

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    //drawing the count neighbors
                    if (viewNeighborCountToolStripMenuItem.Checked)
                    {
                        if (finite)
                        {
                            if (CountNeighborsFinite(x, y) > 0)
                                e.Graphics.DrawString(CountNeighborsFinite(x, y).ToString(), Font, Brushes.Black, cellRect);
                        }
                        else
                        {
                            if (CountNeighborsFinite(x, y) > 0)
                                e.Graphics.DrawString(CountNeighborsToroidal(x, y).ToString(), Font, Brushes.Black, cellRect);
                        }
                    }

                    // Fill the cell with a brush if alive
                    if (universe[x, y] == true)
                    {
                        e.Graphics.FillRectangle(cellBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }

            // Cleaning up pens and brushes
            gridPen.Dispose();
            cellBrush.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left)
            {
                // Calculate the width and height of each cell in pixels
                float cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                float cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                float x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                float y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[(int)x, (int)y] = !universe[(int)x, (int)y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
        }

        //play button starts the timer
        private void toolStripButton1_Click(object sender, EventArgs e) //play button
        {
            timer.Start();
        }

        //pause button stops the timer
        private void toolStripButton2_Click(object sender, EventArgs e) // pause button
        {
            timer.Stop();
        }

        //next generation button that moves the game forward 1 generation
        private void toolStripButton3_Click(object sender, EventArgs e) //next generation
        {
            timer.Start();
            nextgen = true;
        }

        //new file shortcut, resets the universe to 50,50 and empty.
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            universe = new bool[universeX, universeY];
            graphicsPanel1.Invalidate();
        }

        //new file shortcut, resets the universe to 50,50 and empty.
        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            universe = new bool[universeX, universeY];
            graphicsPanel1.Invalidate();
        }

        //sets the grid color
        private void gridColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if(DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        //sets the living cell color
        private void livingCellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        //sets the color of the background
        private void deadCellColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
            graphicsPanel1.Invalidate();
        }

        //exits the application and saves all changes to the properties
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DeadCellColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridColor = gridColor;
            Properties.Settings.Default.LiveCellColor = cellColor;
            this.Close();
        }

        //exits the application and saves all changes to the properties
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.DeadCellColor = graphicsPanel1.BackColor;
            Properties.Settings.Default.GridColor = gridColor;
            Properties.Settings.Default.LiveCellColor = cellColor;
            Properties.Settings.Default.TimerInterval = timer.Interval;
            Properties.Settings.Default.UniverseX = universeX;
            Properties.Settings.Default.UniverseY = universeY;

            Properties.Settings.Default.Save();
        }

        //Reset colors back to default
        private void resetColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            graphicsPanel1.BackColor = Color.White;
            gridColor = Color.Black;
            cellColor = Color.Silver;
            Properties.Settings.Default.Reset();
        }

        //Reloads the colors to the default
        private void reloadColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            graphicsPanel1.BackColor = Properties.Settings.Default.DeadCellColor;
            gridColor = Properties.Settings.Default.GridColor;
            cellColor = Properties.Settings.Default.LiveCellColor;
        }

        //Opens the timer dialog window to change the ticker interval
        private void timerIntervalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimerDialog dlg = new TimerDialog();
            dlg.timervalue = timer.Interval;

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                timer.Interval = dlg.timervalue;
                Properties.Settings.Default.TimerInterval = dlg.timervalue;
            }
        }

        //Opens the universe size dialog window to change the dimensions of the universe
        private void universeSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniverseDialog dlg = new UniverseDialog();
            dlg.UniverseX = universeX;
            dlg.UniverseY = universeY;

            if(dlg.ShowDialog() == DialogResult.OK)
            {
                universe = new bool[dlg.UniverseX, dlg.UniverseY];
                Properties.Settings.Default.UniverseX = dlg.UniverseX;
                Properties.Settings.Default.UniverseY = dlg.UniverseY;
            }
        }

        //changes the universe type
        private void universeTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UniverseTypeDialog dlg = new UniverseTypeDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                finite = dlg.FiniteUniverse;
            }
        }

        //turns on and off the checkmark for universe type
        private void viewNeighborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewNeighborCountToolStripMenuItem.Checked = !viewNeighborCountToolStripMenuItem.Checked;
        }

        //change grid color on the context sensitive menu
        private void gridColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = gridColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                gridColor = dlg.Color;
            }
        }

        //change living cell color on the context sensitive menu
        private void livingCellColorToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = cellColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                cellColor = dlg.Color;
            }
        }

        //change background color on the context sensitive menu
        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();

            dlg.Color = graphicsPanel1.BackColor;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                graphicsPanel1.BackColor = dlg.Color;
            }
        }

        //change timer ticker on the context sensitive menu
        private void timerIntervalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TimerDialog dlg = new TimerDialog();
            dlg.timervalue = timer.Interval;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                timer.Interval = dlg.timervalue;
                Properties.Settings.Default.TimerInterval = dlg.timervalue;
            }
        }

        //changes the neighbor count view settings through the context sensitive menu item
        private void viewNeigborCountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            viewNeighborCountToolStripMenuItem.Checked = !viewNeighborCountToolStripMenuItem.Checked;
        }

        //saves the game from the toolstrip
        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveUniverse();
        }

        //saves the game from the menu item
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveUniverse();
        }

        //opens a saved file and loads it
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenUniverse();
        }

        //randomize from seed menu item
        private void fromSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandomizeDialog dlg = new RandomizeDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                RandyUniverse(dlg.newseed);
            }
        }

        //randomize from time menu item
        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            int time = int.Parse((date.ToString("%HH")+ date.ToString("%m") + date.ToString("%s") + date.ToString("%f")));
            RandyUniverse(time);
        }

        //randomize from current seed menu item (setting the value of the function to 0 does a reset from a new seed, 1 is same seed)
        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RandyUniverse(1);
        }
    }
}
