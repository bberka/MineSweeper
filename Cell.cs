using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineSweeper
{
    class Cell : Button
    {
        public int x_column;
        public int y_row;
        public bool isVisited = false;
        public bool isBomb = false;
    }
}
