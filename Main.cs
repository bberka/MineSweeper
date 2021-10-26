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
        void createBoard(int max_columns, int max_rows, int difficulty) //creates board by giv
        {
            int bombcount = ((max_columns * max_rows) * difficulty) / 100;
            int totalcount = max_columns * max_rows;
            int count = 0;
            bool[] bombList = createBomblist(totalcount, bombcount);
            for (int y = 0; y < max_rows; y++)
            {
                for (int x = 0; x < max_columns; x++)
                {
                    Cell c = new Cell();
                    c.BackColor = Color.White;
                    c.Size = new Size(45, 40);
                    c.Location = new Point(x * (45), y * (40));
                    c.FlatAppearance.BorderSize = 1;
                    c.TextAlign = ContentAlignment.TopCenter;
                    c.Font = new Font(c.Font.FontFamily, 14);
                    if (bombList[count] == true) c.isBomb = true;
                    if (c.isBomb == false) c.liveNeighbors = 0;
                    c.x_column = x;
                    c.y_row = y;
                    c.TabStop = false;
                    this.gameBoard.Controls.Add(c);
                    c.Click += cellClick;
                    count++;
                }
            }
            buttonStart.Enabled = false;
            comboDifficulty.Enabled = false;
            buttonReset.Enabled = true;
            calcNeighbors();
        }
        void clearBoard() //restarts app
        {
            Application.Restart();
        }
        void showBombs() //show bomb checkbox cheat
        {
            foreach (Cell c in gameBoard.Controls)
            {
                if (c.isBomb == true)
                {
                    if (c.BackColor == Color.Red) c.BackColor = Color.White;
                    else if (c.BackColor == Color.White) c.BackColor = Color.Red;
                }
            }
        }

        void calcNeighbors() //calculates neighbors
        {
            foreach (Cell c in getAllCells(2))
            {
                foreach (Cell cell in getNeighborCells(c.x_column, c.y_row, false))
                {
                    if (cell.isBomb == true) continue;
                    cell.liveNeighbors += 1;
                }
            }
        }
        List<Cell> getAllCells(int get) //0: gets all cells // 1: gets non-bombs // 2: gets bombs // 3: gets unrevealed non-bomb cells
        {
            List<Cell> cellList = new List<Cell>();
            foreach (Cell c in gameBoard.Controls)
            {
                switch (get)
                {
                    case 1: if (c.isBomb == true) continue; break;
                    case 2: if (c.isBomb == false) continue; break;
                    case 3: if (c.isBomb == true && c.isVisited == true) continue; break;
                }
                cellList.Add(c);
            }
            return cellList;
        }
        List<Cell> getNeighborCells(int x, int y, bool get) //false: gets all 8 neighbor cells // true: gets 4 neighbor cells 
        {
            List<Cell> nList = new List<Cell>();
            List<Cell> neighborList = new List<Cell>();
            if (get == false)
            {
                nList.Add(getCellbyCoordinate(x - 1, y - 1));
                nList.Add(getCellbyCoordinate(x + 1, y - 1));
                nList.Add(getCellbyCoordinate(x - 1, y + 1));
                nList.Add(getCellbyCoordinate(x + 1, y + 1));
            }
            nList.Add(getCellbyCoordinate(x, y + 1));
            nList.Add(getCellbyCoordinate(x, y - 1));
            nList.Add(getCellbyCoordinate(x - 1, y));
            nList.Add(getCellbyCoordinate(x + 1, y));
            foreach (Cell c in nList) if (c != null) neighborList.Add(c);
            return neighborList;
        }
        Cell getCellbyCoordinate(int x, int y) //gets cell by given coordinate returns null if theres no cell
        {
            foreach (Cell c in gameBoard.Controls) if (c.x_column == x && c.y_row == y) return c;
            return null;
        }

        private void cellClick(object sender, EventArgs e) //cell click event
        {
            Cell c = (Cell)sender;
            if (c.isBomb == true)
            {
                showBombs();
                MessageBox.Show("Game Over!\nPoints:" + Int16.Parse(PointLabel.Text), "!!!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                clearBoard();
                return;
            }
            cellLogic(c);
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

            //flags a bomb cell if 4~ neighbors revealed
            foreach (Cell cell in getNeighborCells(c.x_column, c.y_row, false)) 
            {
                if (cell.isBomb == true)
                {
                    int count = 0;
                    int bombcount = 0;
                    foreach (Cell cell2 in getNeighborCells(cell.x_column, cell.y_row, false))
                    {
                        if (cell2.isVisited == true) count++;
                        if (cell2.isBomb == true) bombcount++;
                    }
                    if (count > 4 - bombcount) cell.BackColor = Color.Yellow;
                }
            }
        }
        void cellLogic(Cell c) //Recurisive game logic function
        {
            revealCell(c);
            if (c.liveNeighbors != 0) return;
            foreach (Cell cell in getNeighborCells(c.x_column, c.y_row, true))
            {
                if (cell.isBomb == true || cell.isVisited) continue;
                int liveN = cell.liveNeighbors;
                revealCell(cell);
                if (cell.liveNeighbors != 0) continue;
                cellLogic(cell);
            }
        }

        bool[] createBomblist(int total, int bomb) //creates randomized bomb list
        {
            Random rand = new Random();
            bool[] list = new bool[total];
            List<int> bomblist = new List<int>();
            int number = 0;

            for (int i = 0; i < total - bomb; i++) list[i] = false;
            for (int i = 0; i < bomb; i++)
            {
                do
                {
                   number = rand.Next(0, total);
                } while (bomblist.Contains(number));
                bomblist.Add(number);
                list[number] = true;
            }
            return list;
        }
        int getDifficulty() //gets selected difficulty // calculated as percentage
        {
            int selected_diff = comboDifficulty.SelectedIndex;
            if (selected_diff == 1) return 20;
            if (selected_diff == 2) return 30;
            return 10; //easy - default value
        }
        void changeWindowSize() //changes window size by checking game board
        {
            if (comboBoard.SelectedIndex == 0)
            {
                this.Width = 494;
                this.Height = 340;
            }
            else if (comboBoard.SelectedIndex == 1)
            {
                this.Width = 630;
                this.Height = 463;
            }
            else if (comboBoard.SelectedIndex == 2)
            {
                this.Width = 763;
                this.Height = 580;
            }
            else if (comboBoard.SelectedIndex == 3)
            {
                this.Width = 946;
                this.Height = 742;
            }
        }
        private void buttonStart_Click(object sender, EventArgs e)
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
            comboDifficulty.Enabled = false;
            comboBoard.Enabled = false;
            checkShowBomb.Enabled = true;
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
