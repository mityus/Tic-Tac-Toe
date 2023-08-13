using Interfaces;

namespace Board
{
    public class BoardController
    {
        private BoardModel _boardModel;
        private IBorderView _boardView;

        public BoardController(IBorderView borderView)
        {
            _boardModel = new BoardModel();
            _boardView = borderView;
            
            _boardView.RenderBoard(_boardModel.SizeBoard);
        }
    }
}