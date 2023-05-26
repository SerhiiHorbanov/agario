using Engine;
using Agario.States;

namespace Agario
{
    internal class Program
    {
        public static Random random = new Random();
        static void Main(string[] args)
        {
            Game game = new Game();
            game.stateMachine.SetState(new Playing(game.stateMachine));//мені це не подобається, але я не знаю як краще зробити :skull:
            game.Run();
        }
    }
}
