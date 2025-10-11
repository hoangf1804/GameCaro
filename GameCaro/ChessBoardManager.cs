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
        private List<Player> player;
        public List<Player> Player { get => player; set => player = value; }
       

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
       

        private TextBox playerName;
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        

        private PictureBox playerMark;
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark) 
        {
            this.chessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            this.Player = new List<Player>() 
            {
                new Player("QuocKhanh",Image.FromFile(Application.StartupPath + "\\Resources\\x.png")),
                new Player("DepTrai",Image.FromFile(Application.StartupPath + "\\Resources\\o.png"))
            };
            CurrentPlayer = 0;
            ChangePlayer();
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

                    btn.Click += btn_Click;

                    chessBoard.Controls.Add(btn);
                    Oldbutton = btn;
                }

                // Sau khi xong 1 hàng, reset lại Oldbutton để nhảy xuống hàng mới
                Oldbutton = new Button()
                {
                    Width = 0,
                    Height = 0,
                    Location = new Point(0, Oldbutton.Location.Y + Cons.CHESS_HEIGHT),
                    BackgroundImageLayout = ImageLayout.Stretch
                };
            }
        }
       
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;
            Mark(btn);

            ChangePlayer();
            
        }
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;
            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
        }
        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }
        #endregion
    }
}
