using System;
using System.Net.Http;
using System.Threading.Tasks;
using Services.ApiService;

namespace CarSimulator
{
    public class App
    {
        private readonly Car _car;
        private readonly Driver _driver;
        private readonly CarActions _carActions;
        private readonly Status _status;
        private readonly HttpClient _httpClient;
        private Result _user;
        private bool _IsFirstRun;

        public App()
        {
            _car = new Car();
            _driver = new Driver();
            _carActions = new CarActions();
            _status = new Status();
            _httpClient = new HttpClient();
            _IsFirstRun = true;
        }

        public void Run()
        {
            var apiService = new GetTheApi(_httpClient);
            FetchAndSetApiData(apiService).Wait();

            while (true)
            {
                PrintApiData();
                _status.PrintStatus(_car, _driver);
                ShowMenu.PrintMenu();
                string command = Console.ReadLine().ToLower();

                switch (command)
                {
                    case "1":
                        CarActions.Drive(_car, _driver);
                        break;
                    case "2":
                        CarActions.TurnLeft(_car, _driver);
                        break;
                    case "3":
                        CarActions.TurnRight(_car, _driver);
                        break;
                    case "4":
                        CarActions.Reverse(_car, _driver);
                        break;
                    case "5":
                        _carActions.Refuel(_car, _driver);
                        break;
                    case "6":
                        DriverActions.Rest(_driver);
                        break;
                    case "7":
                        Console.WriteLine("The program is exiting.");
                        return;
                    default:
                        Console.WriteLine("Invalid command. Press Enter to continue.");
                        Console.ReadKey();
                        break;
                }

                _IsFirstRun = false;
                Console.Clear();
            }
        }

        private async Task FetchAndSetApiData(GetTheApi apiService)
        {
            try
            {
                _user = await apiService.FetchApiData();
                Console.WriteLine($"Welcome {_user.Name.First} {_user.Name.Last}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error fetching API data: {e.Message}");
            }
        }

        private void PrintApiData()
        {
            if (_user != null)
            {
                if (_IsFirstRun)
                {
                    Console.WriteLine($"Welcome! {_user.Name.Title} {_user.Name.First} {_user.Name.Last}, enjoy your ride!");
                }
                else
                {
                    Console.WriteLine($"You're doing great, {_user.Name.First}! Keep driving!");
                }
            }
        }
    }
}
