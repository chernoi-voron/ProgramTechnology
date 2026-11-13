using GuessNumber.core.Game;
using GuessNumber.core.GameService;
using GuessNumber.core.AuthService;
using GuessNumber.core.Repository;
using GuessNumber.core.GeneratorOfNumbers;
using GuessNumber.core.AttemptsCounter;
using GuessNumber.core.GameSettings;
using GuessNumber.core.Player;
using GuessNumber.core.GameLogg;
using GuessNumber.core.PlayerAccount;
using GuessNumber.core.Account;
using GuessNumber.core.StatsService;

namespace GuessNumber.VisualConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool Auth = true,game = true;
            var gen = new Generator(-100, 100);
            var consoleout = new ConsoleOutput();
            var consolein = new ConsoleInput();
            var repo = new CsvRepository("C:\\Users\\Atlas-02\\source\\repos\\ProgramTechnology");
            PersonAccount person = new PersonAccount(Guid.NewGuid(),"xxx","xxx");
            Player player = new Player("xxx",Guid.NewGuid());

            Authorization authorization = new Authorization(repo);
            var Stat = new StatisticService(repo);

            Console.WriteLine("Enter a num 1 - Register new Account 2 - Login your Account");
            while (Auth)
            {
                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        {
                            Console.WriteLine("Enter your wish login and name of your game person");
                            person = authorization.Register(Console.ReadLine(), Console.ReadLine());
                            player = new Player(person.Name,Guid.NewGuid());
                            Auth = false;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter your login");
                            if (authorization.Login(Console.ReadLine()) is null)
                            {
                                Console.WriteLine("Incorrect login");
                                break;
                            }
                            Auth = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect menu item");
                            break;
                        }

                }

            }
            GameSession gameSession = new GameSession(new Attempt(new RealMode()), gen.Generate());
            GameService gameService = new GameService(player, gameSession, consoleout, consolein);
            Console.WriteLine("Choose menu item 1 - See your stats, 2 - Play the Game, 3 - exit from Program");
            while(game)
            {
                int result = 0;
                int.TryParse(Console.ReadLine(), out result);
                switch (result)
                {
                    case (1):
                        {
                            Stat.PrintMyStatic(gameService._player.ID); break;
                        }
                    case (2):
                        {
                            gameService.Menu();
                            Stat.RecordGame(gameService._player.ID, gameService._session.statistic);
                            break;
                        }
                    case (3):
                        {
                            game = false; break;
                        }
                    default:
                        {
                            Console.WriteLine("Incorrect menu item");
                            break;
                        }
                }

            }
            repo.Write(person);
            

        }

    }
}
