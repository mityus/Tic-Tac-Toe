namespace Board
{
    public class BoardModel
    {
        private const int _sizeBoard = 3;

        private int[,] _board;

        public int SizeBoard => _sizeBoard;

        public int[,] Board => _board;

        public BoardModel()
        {
            _board = new int[_sizeBoard, _sizeBoard];
        }
    }
}
