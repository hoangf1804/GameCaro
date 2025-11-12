using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace GameCaro
{
    public partial class Form1 : Form
    {
        #region Properties
        ChessBoardManager chessBoard;
        SocketManager socket;
        #endregion
        public Form1()
        {
            InitializeComponent();
            socket = new SocketManager();

            chessBoard = new ChessBoardManager(pnlchessboard, txbPlayerName, pctbMark);
            chessBoard.EndedGame += ChessBoard_EndedGame;
            chessBoard.PlayerMarked += ChessBoard_PlayerMarked;
            chessBoard.Socket = socket;

            prcbCoolDown.Step = Cons.COOL_DOWN_STEP;
            prcbCoolDown.Maximum = Cons.COOL_DOWN_TIME;
            prcbCoolDown.Value = 0;
            tmCoolDown.Interval = Cons.COOl_DOWN_INTERVAL;

            NewGame();
        }

        void EndGame()
        {
            tmCoolDown.Stop();
            pnlchessboard.Enabled = false;
            undoToolStripMenuItem.Enabled = false;
            MessageBox.Show("Kết thúc");
        }

        void NewGame()
        {
            prcbCoolDown.Value = 0;
            tmCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            chessBoard.DrawChessBoard();
            
            if (socket != null && !chessBoard.IsPlayingWithComputer)
            {
                try
                {
                    SocketData data = new SocketData((int)SocketCommand.NEW_GAME, new Point(), "");
                    socket.Send(data);
                }
                catch { }
            }
        }

        void NewGameFromNetwork()
        {
            prcbCoolDown.Value = 0;
            tmCoolDown.Stop();
            undoToolStripMenuItem.Enabled = true;
            chessBoard.DrawChessBoard();
        }

        void Quit()
        {
            Application.Exit();
        }

        void Undo()
        {
            chessBoard.Undo();
        }

        void UndoFromNetwork()
        {
            if (chessBoard.PlayTimeLine.Count <= 0)
                return;
            
            PlayInfo oldPoint = chessBoard.PlayTimeLine.Pop();
            Button btn = chessBoard.Matrix[oldPoint.Point.Y][oldPoint.Point.X];
            btn.BackgroundImage = null;
            
            if (chessBoard.PlayTimeLine.Count <= 0)
            {
                chessBoard.CurrentPlayer = 0;
            }
            else
            {
                oldPoint = chessBoard.PlayTimeLine.Peek();
                chessBoard.CurrentPlayer = oldPoint.CurrentPalyer == 1 ? 0 : 1;
            }
        }

        private void ChessBoard_PlayerMarked(object sender, EventArgs e)
        {
            tmCoolDown.Start();
            prcbCoolDown.Value = 0;
            pnlchessboard.Enabled = false;
        }

        private void ChessBoard_EndedGame(object sender, EventArgs e)
        {
            EndGame();
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

        private void prcbCoolDown_Click(object sender, EventArgs e)
        {

        }

        private void tmCoolDown_Tick(object sender, EventArgs e)
        {
            prcbCoolDown.PerformStep();
            if (prcbCoolDown.Value >= prcbCoolDown.Maximum)
            {
                EndGame();
            }
        }


        private void qQuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }



        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát ", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
                e.Cancel = true;
        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Undo();
        }
        private void btnLAN_Click(object sender, EventArgs e)
        {
            socket.IP = txbIP.Text;

            if (!socket.ConnectServer())
            {
                socket.CreateServer();
                chessBoard.IsPlayingWithComputer = false;
                pnlchessboard.Enabled = true;

                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        try
                        {
                            SocketData data = (SocketData)socket.Receive();
                            ProcessData(data);
                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();

                MessageBox.Show("Đang chờ người chơi kết nối...", "Server");
            }
            else
            {
                chessBoard.IsPlayingWithComputer = false;
                chessBoard.CurrentPlayer = 1;
                pnlchessboard.Enabled = false;

                Thread listenThread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        {
                            SocketData data = (SocketData)socket.Receive();
                            ProcessData(data);
                        }
                        catch
                        {

                        }
                    }
                });
                listenThread.IsBackground = true;
                listenThread.Start();

                MessageBox.Show("Đã kết nối thành công!", "Client");
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                string ip = socket.GetLocalIPv4(NetworkInterfaceType.Wireless80211);

                if (string.IsNullOrEmpty(ip))
                {
                    ip = socket.GetLocalIPv4(NetworkInterfaceType.Ethernet);
                }

                if (!string.IsNullOrEmpty(ip))
                {
                    txbIP.Text = ip;
                }
                else
                {
                    txbIP.Text = "127.0.0.1";
                    MessageBox.Show("Không tìm thấy card mạng WiFi/Ethernet đang hoạt động.\n\nVui lòng nhập IP thủ công: 192.168.157.91", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                txbIP.Text = "127.0.0.1";
                MessageBox.Show("Không thể lấy IP tự động. Vui lòng nhập IP thủ công.\n\nLỗi: " + ex.Message, "Thông báo");
            }
        }

        void ProcessData(SocketData data)
        {
            if (data == null)
                return;

            switch (data.Command)
            {
                case (int)SocketCommand.SEND_POINT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        prcbCoolDown.Value = 0;
                        pnlchessboard.Enabled = true;
                        chessBoard.OtherPlayerMark(data.Point, data.CurrentPlayer);
                    }));
                    break;
                case (int)SocketCommand.NEW_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        NewGameFromNetwork();
                    }));
                    break;
                case (int)SocketCommand.UNDO:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        UndoFromNetwork();
                    }));
                    break;
                case (int)SocketCommand.END_GAME:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show(data.Message);
                    }));
                    break;
                case (int)SocketCommand.TIME_OUT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Hết giờ!");
                    }));
                    break;
                case (int)SocketCommand.QUIT:
                    this.Invoke((MethodInvoker)(() =>
                    {
                        MessageBox.Show("Đối thủ đã thoát!");
                    }));
                    break;
            }
        }


    }
}

