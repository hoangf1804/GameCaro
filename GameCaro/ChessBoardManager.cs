using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameCaro
{
    public class ChessBoardManager
    {
        #region Properties
        private readonly Panel chessBoard; 
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard) 
        {
            this.chessBoard = chessBoard;
        }
        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            Button Oldbutton = new Button() { Width = 0, Location = new Point(0, 0) };

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)  // số hàng
            {
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)  // số cột
                {
                    Button btn = new Button();
                    btn.Width = Cons.CHESS_WIDTH;
                    btn.Height = Cons.CHESS_HEIGHT;
                    btn.Location = new Point(Oldbutton.Location.X + Oldbutton.Width, Oldbutton.Location.Y);

                    chessBoard.Controls.Add(btn);
                    Oldbutton = btn;
                }

                // Sau khi xong 1 hàng, reset lại Oldbutton để nhảy xuống hàng mới
                Oldbutton = new Button()
                {
                    Width = 0,
                    Height = 0,
                    Location = new Point(0, Oldbutton.Location.Y + Cons.CHESS_HEIGHT)
                };
            }
        }
        #endregion
        
    }
}
