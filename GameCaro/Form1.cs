using System;
using System.Drawing;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        #endregion
        public Form1()
        {
            InitializeComponent();
            chessBoard = new ChessBoardManager(pnlchessboard);
            chessBoard.DrawChessBoard();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pctbavatar_Click(object sender, EventArgs e)
        {

        }

        
    }
}

