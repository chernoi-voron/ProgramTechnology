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
            var gen = new TestGenerator();
            var consoleout = new ConsoleOutput();
            var consolein = new ConsoleInput();
            var repo = new CsvRepository("G:\\");
            PersonAccount? person = null;
            Player? player = null;
            CustomMode? customMode = null;
            Authorization authorization = new Authorization(repo);
            var Stat = new StatisticService(repo);
            void HandleGameWin(object? sender, GameWinEventArgs e)
            {
                consoleout.Print(e.Message);
                consoleout.Print($"Amount of attempts {e.Statistic.Attempts}");
                if (e.Exodus == true) { Stat.RecordGame(player.ID, e.Statistic); }

            }


            while (Auth)
            {
                consoleout.Print("Enter a num 1 - Register new Account 2 - Login your Account 3 - Exit");
                switch (int.TryParse(Console.ReadLine(), out int choice) ? choice : 0)
                {
                    case 1:
                        {
                            consoleout.Print("Enter your wish login and name of your game person");
                            var regdata = Console.ReadLine()!.Split(' ');
                            person = authorization.Register(regdata[0], regdata[1]);
                            player = new Player(person!.Name,Guid.NewGuid());
                            Auth = false;
                            break;
                        }
                    case 2:
                        {
                            consoleout.Print("Enter your login");
                            var login = Console.ReadLine();
                            if (login == "")
                            {
                                consoleout.Print("Incorrect login");
                                break;
                            }
                            person = authorization.Login(login);
                            if (person is null)
                            {
                                consoleout.Print("User not found");
                                break;
                            }
                            player = new Player(person.Name, person.Id);
                            Auth = false;
                            break;
                        }
                    case 3:
                        {
                            consoleout.Print("Exit from program");
                            Auth = false;
                            game = false;
                            break;
                        }
                    default:
                        {
                            consoleout.Print("Incorrect menu item");
                            break;
                        }

                }

            }
            GameSession gameSession = new GameSession(new Attempt(new RealMode()), gen.Generate());
            gameSession.GameExodus += HandleGameWin;
            GameService gameService = new GameService(player!, gameSession, consoleout, consolein);
            if(Stat.PrintMyStats(player!.ID) == null) { consoleout.Print($"Welcome {player.Name}"); }
            else { consoleout.Print($"Welcome back {player.Name}"); }
            while(game)
            {
                consoleout.Print("Choose menu item 1 - See your stats, 2 - Play the Game\n 3 - Create custom game, 4 - Switch mode\n 5 - Print current mode 6 - exit from Program");
                int result = 0;
                int.TryParse(Console.ReadLine(), out result);
                switch (result)
                {
                    case (1):
                        {
                                var statsPlayer = Stat.PrintMyStats(player.ID);
                                if(statsPlayer is null) { consoleout.Print("Stats don't avalaibe"); }
                                else { consoleout.Print(statsPlayer); }
                                break;
                        }
                    case (2):
                        {
                            gameService.Menu();
                            break;
                        }
                    case (3):
                        {
                            consoleout.Print("Enter a number of max attempts");
                            var maxAttempts = consolein.Read();
                            consoleout.Print("Enter a number of cost attempts");
                            var costAttempt = consolein.Read();
                            customMode = new CustomMode(maxAttempts, costAttempt);
                            break;
                        }
                    case (4):
                        {
                            consoleout.Print("Choose a mode 1 - RealMode 2 - CustomMode 3 - EndlessMode 4 - Exit");
                            switch(consolein.Read())
                            {
                                case (1):
                                    {
                                        gameService._session.attemptCounter.SwitchMode(new RealMode());
                                        break;
                                    }
                                case (2):
                                    {
                                        if (customMode is null) { consoleout.Print("Custom mode don't avalaibe"); break; }
                                        gameService._session.attemptCounter.SwitchMode(customMode);
                                        break;
                                    }
                                case (3):
                                    {
                                        gameService._session.attemptCounter.SwitchMode(new EndlessMode());
                                        break;
                                    }
                                case (4):
                                    {
                                        break;
                                    }
                                default:
                                    {
                                        consoleout.Print("Incorrect menu item");
                                        break;
                                    }

                            }
                            break;
                        }
                    case (5):
                        {
                            consoleout.Print($"Current mode is {gameService._session.attemptCounter.GetType().Name}");
                            break;
                        }
                    case (6):
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
            repo.WriteAccountToRep(person!);
            

        }

    }
}
