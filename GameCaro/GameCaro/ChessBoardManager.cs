using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
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

        private SocketManager socket;
        public SocketManager Socket { get => socket; set => socket = value; }

        private bool isPlayingWithComputer;
        public bool IsPlayingWithComputer { get => isPlayingWithComputer; set => isPlayingWithComputer = value; }
       

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }
       

        private TextBox playerName;
        public TextBox PlayerName { get => playerName; set => playerName = value; }
        

        private PictureBox playerMark;
        public PictureBox PlayerMark { get => playerMark; set => playerMark = value; }
        private List<List<Button>> matrix;
        public List<List<Button>> Matrix { get => matrix; set => matrix = value; }

        private event EventHandler playerMarked;
        public event EventHandler PlayerMarked 
        {
            add { playerMarked += value; }
            remove { playerMarked -= value; }
        }
        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }
        private Stack<PlayInfo> playTimeLine;
        public Stack<PlayInfo> PlayTimeLine{
            get { return playTimeLine; }
            set { playTimeLine = value; }
        }
        #endregion

        #region Initialize
        public ChessBoardManager(Panel chessBoard, TextBox playerName, PictureBox mark) 
        {
            this.chessBoard = chessBoard;
            this.PlayerName = playerName;
            this.PlayerMark = mark;
            this.Player = new List<Player>() 
            {
                new Player("Player 1",Image.FromFile(Application.StartupPath + "\\Resources\\x.png")),
                new Player("Player 2",Image.FromFile(Application.StartupPath + "\\Resources\\o.png"))
            };
            this.IsPlayingWithComputer = false;
        }
        void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;
            
            Mark(btn);
            PlayTimeLine.Push(new PlayInfo(GetChessPoint(btn), (CurrentPlayer)));
            
            if (!IsPlayingWithComputer && Socket != null)
            {
                SocketData data = new SocketData((int)SocketCommand.SEND_POINT, GetChessPoint(btn), "", CurrentPlayer);
                Socket.Send(data);
            }

            CurrentPlayer = CurrentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if (playerMarked != null)
                playerMarked(this, new EventArgs());

            if (isEndGame(btn))
            {
                EndGame();
            }
            
        }
        public void EndGame() {
            if(endedGame != null)
                endedGame(this, new EventArgs());
        }

        public bool Undo()
        {
            if (PlayTimeLine.Count <= 0)
                return false;
            
            if (!IsPlayingWithComputer && Socket != null)
            {
                SocketData data = new SocketData((int)SocketCommand.UNDO, new Point(), "");
                Socket.Send(data);
            }

            PlayInfo oldPoint = PlayTimeLine.Pop();
            Button btn = Matrix[oldPoint.Point.Y][oldPoint.Point.X];
            btn.BackgroundImage = null;
            if (PlayTimeLine.Count <= 0)
            {
                CurrentPlayer = 0;
            }
            else
            {
                oldPoint = PlayTimeLine.Peek();
                CurrentPlayer = oldPoint.CurrentPalyer == 1 ? 0 : 1;
            }         
            ChangePlayer();
            return true;
        }

        private bool isEndGame(Button btn)
        {
            return isEndHorizontal(btn) || isEndVertical(btn) || isEndSub(btn) || isEndPrimary(btn);
        }
        private Point GetChessPoint(Button btn)
        {
              
            int vertical = Convert.ToInt32(btn.Tag);
            int horizontal = Matrix[vertical].IndexOf(btn);
            Point point = new Point(horizontal, vertical);
            return point;
        }
        private bool isEndHorizontal(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countLeft = 0;
            for (int i = point.X ; i >0; i--) 
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countLeft++;
                else
                    break;
            }
            int countRight = 0;
            for (int i = point.X + 1; i < Cons.CHESS_BOARD_WIDTH; i++)
            {
                if (Matrix[point.Y][i].BackgroundImage == btn.BackgroundImage)
                    countRight++;
                else
                    break;
            }
            return countLeft + countRight == 5;
        }
        private bool isEndVertical(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;
            for (int i = point.Y; i > 0; i--)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }
            int countBottom = 0;
            for (int i = point.Y + 1; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                if (Matrix[i][point.X].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndPrimary(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;

            for (int i =0; i <= point.X; i++)
            {
                if (point.X - i < 0 || point.Y - i < 0)
                    break;

                if (Matrix[point.Y-i][point.X-i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH-point.X; i++)
            {
                if(point.Y + i >= Cons.CHESS_BOARD_HEIGHT||point.X + i >= Cons.CHESS_BOARD_WIDTH)
                    break;
                if (Matrix[point.Y + i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom == 5;
        }
        private bool isEndSub(Button btn)
        {
            Point point = GetChessPoint(btn);
            int countTop = 0;

            for (int i = 0; i <= point.X; i++)
            {
                if (point.X + i >= Cons.CHESS_BOARD_WIDTH || point.Y - i < 0)
                    break;

                if (Matrix[point.Y - i][point.X + i].BackgroundImage == btn.BackgroundImage)
                    countTop++;
                else
                    break;
            }
            int countBottom = 0;
            for (int i = 1; i <= Cons.CHESS_BOARD_WIDTH - point.X; i++)
            {
                if ( point.Y + i >= Cons.CHESS_BOARD_WIDTH ||point.X - i < 0)
                    break; 
                if (Matrix[point.Y + i][point.X - i].BackgroundImage == btn.BackgroundImage)
                    countBottom++;
                else
                    break;
            }
            return countTop + countBottom == 5;
        }   



        #endregion

        #region Methods
        public void DrawChessBoard()
        {
            chessBoard.Enabled = true;
            chessBoard.Controls.Clear();
            PlayTimeLine = new Stack<PlayInfo>();
            CurrentPlayer = 0;
            ChangePlayer();
            Matrix = new List<List<Button>>();
            Button Oldbutton = new Button() { Width = 0, Location = new Point(0, 0) };

            for (int i = 0; i < Cons.CHESS_BOARD_HEIGHT; i++)
            {
                Matrix.Add(new List<Button>());
                for (int j = 0; j < Cons.CHESS_BOARD_WIDTH; j++)
                {
                    Button btn = new Button();
                    btn.Width = Cons.CHESS_WIDTH;
                    btn.Height = Cons.CHESS_HEIGHT;
                    btn.Location = new Point(Oldbutton.Location.X + Oldbutton.Width, Oldbutton.Location.Y);
                    btn.BackgroundImageLayout = ImageLayout.Stretch; 
                    btn.Tag = i.ToString();
                    
                    btn.Click += btn_Click;

                    chessBoard.Controls.Add(btn);
                    Matrix[i].Add(btn);
                    Oldbutton = btn;
                }

                Oldbutton = new Button()
                {
                    Width = 0,
                    Height = 0,
                    Location = new Point(0, Oldbutton.Location.Y + Cons.CHESS_HEIGHT),
                    BackgroundImageLayout = ImageLayout.Stretch
                    
                };
            }
        }
       
        private void Mark(Button btn)
        {
            btn.BackgroundImage = Player[CurrentPlayer].Mark;
            
        }
        private void ChangePlayer()
        {
            PlayerName.Text = Player[CurrentPlayer].Name;
            PlayerMark.Image = Player[CurrentPlayer].Mark;
        }

        public void OtherPlayerMark(Point point, int opponentPlayer)
        {
            Button btn = Matrix[point.Y][point.X];
            if (btn.BackgroundImage != null)
                return;

            btn.BackgroundImage = Player[opponentPlayer].Mark;
            PlayTimeLine.Push(new PlayInfo(point, opponentPlayer));
            
            CurrentPlayer = opponentPlayer == 1 ? 0 : 1;
            ChangePlayer();

            if (isEndGame(btn))
            {
                EndGame();
            }
        }
        #endregion
    }
   
}
