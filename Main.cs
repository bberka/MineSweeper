using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MineSweeper
{
    public partial class Game : Form
    {
        public Game()
        {
            InitializeComponent();
        }
        private void Game_Load(object sender, EventArgs e)
        {

        }
        #region create board

        void startGame() 
        {
            //default board values
            int max_columns_x = 15;
            int max_rows_y = 15;
            if (comboBoard.SelectedItem != null) //gets selected board values
            {
                max_columns_x = Int16.Parse(comboBoard.SelectedItem.ToString().Split('x')[0]);
                max_rows_y = Int16.Parse(comboBoard.SelectedItem.ToString().Split('x')[1]);
            }
            createBoard(max_columns_x, max_rows_y, getDifficulty());
            changeWindowSize();
            buttonStart.Enabled = false;
            buttonReset.Enabled = true;
            comboDifficulty.Enabled = false;
            comboBoard.Enabled = false;
            checkShowBomb.Enabled = true;            
        }
        void createBoard(int max_columns, int max_rows, int difficulty) //creates board 
        {
            int bombcount = ((max_columns * max_rows) * difficulty) / 100;
            int totalcount = max_columns * max_rows;
            int count = 0;
            bool[] bombList = createBomblist(totalcount, bombcount);
            for (int y = 0; y < max_rows; y++)
            {
                for (int x = 0; x < max_columns; x++)
                {
                    Cell c = new Cell
                    {
                        BackColor = Color.White,
                        Size = new Size(45, 40),
                        Location = new Point(x * 45, y * 40),
                        Font = new Font(Font.FontFamily, 18),
                        x_column = x,
                        y_row = y,
                        TabStop = false                         
                    };
                    c.Click += cellClick;
                    if (bombList[count] == true) c.isBomb = true;
                    else c.liveNeighbors = 0;
                    this.gameBoard.Controls.Add(c);
                    count++;
                }
            }
            calcNeighbors();
        }
        bool[] createBomblist(int total, int bomb) //creates randomized bomb list
        {
            Random rand = new Random();
            List<int> bomblist = new List<int>();
            bool[] list = new bool[total];            
            for (int i = 0; i < total - bomb; i++) list[i] = false;
            for (int i = 0; i < bomb; i++)
            {
                int number = 0;
                do {
                  number = rand.Next(0, total);
                } while (bomblist.Contains(number));
                bomblist.Add(number);
                list[number] = true;
            }
            return list;
        }
        void calcNeighbors() //calculates neighbors
        {
            foreach (Cell c in this.gameBoard.Controls)
            {
                if (!(c.isBomb)) continue;
                foreach (Cell cell in getNeighborCells(c.x_column, c.y_row, false))
                {
                    if (cell.isBomb) continue;
                    cell.liveNeighbors += 1;
                }
            }
        }
        #endregion

        #region getcell

        List<Cell> getNeighborCells(int x, int y, bool get) //false: gets all 8 neighbor cells // true: gets 4 neighbor cells 
        {           
            List<Cell> neighborList = new List<Cell>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (get && !(i == 0 || j == 0)) continue;
                    Cell c = getCellbyCoordinate(x + i, y + j);
                    if (c != null) neighborList.Add(c);
                }
            }            
            return neighborList;
        }
        Cell getCellbyCoordinate(int x, int y) //gets cell by given coordinate returns null if theres no cell
        {
            foreach (Cell c in gameBoard.Controls) if (c.x_column == x && c.y_row == y) return c;
            return null;
        }
        int getUnrevealedCellCount() //gets unrevealed cell count
        {
            int count = 0;
            foreach (Cell c in gameBoard.Controls)
            {
                if (c.isBomb) continue;
                if (!(c.isVisited)) count++;
            }
            return count;
        }
        #endregion

        #region logic
        void flagCell(Cell c) //flags and disables a bomb cell if 4~ neighbors revealed
        {
            foreach (Cell cell in getNeighborCells(c.x_column, c.y_row, false))
            {
                if (cell.isBomb == true)
                {
                    int count = 0;
                    int bombcount = 0;
                    foreach (Cell cell2 in getNeighborCells(cell.x_column, cell.y_row, false))
                    {
                        if (cell2.isVisited) count++;
                        if (cell2.isBomb) bombcount++;
                    }
                    if (count > 4 - bombcount)
                    {
                        cell.BackColor = Color.Yellow;
                        cell.Enabled = false;
                    }
                }
            }
        }
        void revealCell(Cell c)
        {
            int liveN = c.liveNeighbors;
            c.Enabled = false;
            c.isVisited = true;
            c.BackColor = Color.Gray;
            if (liveN != 0 && c.isBomb == false) c.Text = liveN.ToString();
            int points = Int16.Parse(PointLabel.Text);
            points++;
            PointLabel.Text = points.ToString();
            
            flagCell(c);
            //ends game if there is no cell left to reveal
            if (getUnrevealedCellCount() == 0)
            {
                MessageBox.Show("There is no cell left to reveal you win!\nPress OK to restart.", "!!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearBoard();
            }
        }
        void cellLogic(Cell c) //Recurisive game logic function
        {
            revealCell(c);
            if (c.liveNeighbors != 0) return;
            foreach (Cell cell in getNeighborCells(c.x_column, c.y_row, false))
            {
                if (cell.isBomb || cell.isVisited) continue;
                cellLogic(cell);
            }
        }

        private void cellClick(object sender, EventArgs e) //cell click event
        {
            Cell c = (Cell)sender;
            if (c.isBomb)
            {
                showBombs();
                MessageBox.Show("Game Over!\nPoints: " + Int16.Parse(PointLabel.Text), "!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearBoard();
                return;
            }
            cellLogic(c);
        }
        #endregion

        int getDifficulty() //gets selected difficulty // calculated as percentage
        {
            int selected_diff = comboDifficulty.SelectedIndex;
            if (selected_diff == 1) return 17;
            if (selected_diff == 2) return 25;
            return 10; //easy - default value
        }
        void changeWindowSize() //changes window size by checking game board
        {
            if (comboBoard.SelectedIndex == 0)
            {
                this.Width = 633;
                this.Height = 461;
            }
            else if (comboBoard.SelectedIndex == 1)
            {
                this.Width = 855;
                this.Height = 662;
            }
            else if (comboBoard.SelectedIndex == 2)
            {
                this.Width = 1082;
                this.Height = 862;
            }
        }
        void clearBoard() //restarts app
        {
            Application.Restart();
        }
        void showBombs() //show bomb checkbox cheat
        {
            foreach (Cell c in gameBoard.Controls)
            {
                if (c.isBomb)
                {
                    if (c.BackColor == Color.Red) c.BackColor = Color.White;
                    else if (c.BackColor == Color.White) c.BackColor = Color.Red;
                }
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            startGame();

        }

        private void comboDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBoard.Enabled = true;
        }
        private void comboBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            clearBoard();
        }

        private void checkShowBomb_CheckedChanged(object sender, EventArgs e)
        {
            showBombs();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }



    }
}
