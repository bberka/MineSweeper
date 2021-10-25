using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        void createBoard(int _rows, int _columns, int _difficulty)
        {

            int bombcount = ((_rows * _columns) * _difficulty) / 100;
            int totalcount = _rows * _columns;
            int count = 0;
            bool[] bombList = createBomblist(totalcount, bombcount);

            for (int y = 0; y < _rows; y++)
            {
                for (int x = 0; x < _columns; x++)
                {
                    Cell btn = new Cell();
                    btn.BackColor = Color.White;
                    btn.Size = new Size(45, 40);
                    btn.ForeColor = Color.Red;
                    btn.Location = new Point(x * (45 + 3), y * (40 + 3));
                    btn.TextAlign = ContentAlignment.TopCenter;
                    btn.Name = x + "" + y;
                    btn.Font = new Font(btn.Font.FontFamily,14);
                    btn.Text = "0";
                    if (bombList[count] == true)
                    {
                        btn.Text = "X";
                        btn.isBomb = true;
                    }
                        
                    count++;

                    btn.x_column = x;
                    btn.y_row = y;
                    btn.TabStop = false;
                    this.gameBoard.Controls.Add(btn);
                    btn.Click += cellClick;
                }
            }
            buttonStart.Enabled = false;
            comboDifficulty.Enabled = false;
            buttonReset.Enabled = true;
            getNeighbors();
        }
        void clearBoard()
        {
            foreach (Button cell in gameBoard.Controls)
            {
                if (Controls.Contains(cell))
                    Controls.Remove(cell);
               
            }
            buttonStart.Enabled = true;
            comboDifficulty.Enabled = true;
            buttonReset.Enabled = false;
        }
        void getNeighbors() //overrides non-bomb cells text
        {
            List<Cell> _bomblist= new List<Cell>();
            
            foreach (Cell cell in gameBoard.Controls)
            {
                if (cell.isBomb == false) continue;
                _bomblist.Add(cell);
            }
            foreach (Cell c in _bomblist)
            {
                foreach (Cell d in getNeighborCells(c.x_column, c.y_row))
                {
                    if (d is null || d.isBomb == true) continue;
                    int number = Int16.Parse(d.Text);
                    number += 1;
                    d.Text = number.ToString();
                }
            }            
        }
        List<Cell> getNeighborCells(int x, int y)
        {
            List<Cell> neighborList = new List<Cell>();
            neighborList.Add(getCellbyCoordinate(x - 1, y - 1));
            neighborList.Add(getCellbyCoordinate(x, y - 1));
            neighborList.Add(getCellbyCoordinate(x + 1, y - 1));
            neighborList.Add(getCellbyCoordinate(x - 1, y));
            neighborList.Add(getCellbyCoordinate(x - 1, y + 1));
            neighborList.Add(getCellbyCoordinate(x + 1, y));
            neighborList.Add(getCellbyCoordinate(x + 1, y + 1));
            neighborList.Add(getCellbyCoordinate(x, y + 1));
            return neighborList;
        }
        Cell getCellbyCoordinate(int x, int y)
        {
            foreach (Cell c in gameBoard.Controls) if (c.x_column == x && c.y_row == y) return c;
            return null;
        }
       
        private void cellClick(object sender, EventArgs e) 
        {

            Cell b = (Cell)sender;
            //MessageBox.Show(b.Name.ToString());
            if (b.isBomb == true)
            {
                MessageBox.Show("Game Over!");
                clearBoard();
                return;
            }
            b.Enabled = false;
            b.isVisited = true;
        }
        bool[] createBomblist(int _totalcount, int _bombcount)
        {
            Random rand = new Random();
            bool[] list = new bool[_totalcount];
            for (int i = 0; i < _totalcount - _bombcount; i++) list[i] = false;
            for (int i = _totalcount - _bombcount; i < _totalcount ; i++) list[i] = true;
            for (int i = 0; i < _totalcount; i++)
            {
                int pos = rand.Next(_totalcount);
                bool save = list[i];
                list[i] = list[pos];
                list[pos] = save;
            }
            return list;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            int selected_diff = comboDifficulty.SelectedIndex;
            int diff = 0;
            if (selected_diff == 0) diff = 10;
            if (selected_diff == 1) diff = 30;
            if (selected_diff == 2) diff = 50;
           
            createBoard(7, 10,diff);

        }

        private void comboDifficulty_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;

        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            clearBoard();

        }
    }
}
