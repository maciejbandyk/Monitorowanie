using System.Threading.Tasks;

namespace Monitorowanie
{
    class Controller
    {
        private Colors colors;
        private Field field;

        public Controller()
        {
            field = new Field(90, 25);
            colors = new Colors();
        }

        public void Run()
        {
            field.InitField();

            Player player = new Player(field)
            {
                TextColor = colors.SetRandomColor()
            };
            player.SetPosition(field.ReturnCells());
            Player player2 = new Player(field)
            {
                TextColor = colors.SetRandomColor()
            };
            player2.SetPosition(field.ReturnCells());
            Player player3 = new Player(field)
            {
                TextColor = colors.SetRandomColor()
            };
            player3.SetPosition(field.ReturnCells());

            StartMovingPlayer(player, field.ReturnCells(), false);
            StartMovingPlayer(player2, field.ReturnCells(), false);
            StartMovingPlayer(player3, field.ReturnCells(), true);
        }

        public void Stop()
        {

        }

        public static async void StartMovingPlayer(Player player, Cell[,] cells, bool updateToken)
        {
            await Task.Run(() => player.StartMoving(cells, updateToken));
        }
    }
}
