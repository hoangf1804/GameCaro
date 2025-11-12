using System;
using System.Drawing;

namespace GameCaro
{
    [Serializable]
    public class SocketData
    {
        private int command;
        public int Command { get => command; set => command = value; }

        private Point point;
        public Point Point { get => point; set => point = value; }

        private string message;
        public string Message { get => message; set => message = value; }

        private int currentPlayer;
        public int CurrentPlayer { get => currentPlayer; set => currentPlayer = value; }

        public SocketData(int command, Point point, string message)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
            this.CurrentPlayer = 0;
        }

        public SocketData(int command, Point point, string message, int currentPlayer)
        {
            this.Command = command;
            this.Point = point;
            this.Message = message;
            this.CurrentPlayer = currentPlayer;
        }
    }

    public enum SocketCommand
    {
        SEND_POINT = 1, 
        NEW_GAME = 2,
        UNDO = 3,
        END_GAME = 4,
        TIME_OUT = 5,
        QUIT = 6,
        NOTIFY = 7
    }
}
