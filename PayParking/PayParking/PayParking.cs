using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PayParkingNS
{
    public class PayParking
    {

        private static string[] parkingLot = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        private static string[] parkingLotTimeStamp = { "", "", "", "", "", "", "", "", "", "" };

        static void Main(string[] args)
        {
            PayParking p = new PayParking();
            p.DisplayMenu();
        }


        public void DisplayMenu()
        {
            Console.WriteLine("==========");
            Console.WriteLine("PayParking");
            Console.WriteLine("==========");
            Console.WriteLine("Options:");
            Console.WriteLine("1. Display parking spaces");
            Console.WriteLine("2. Check-in");
            Console.WriteLine("3. Check-out");
            Console.WriteLine("4. Exit");

            var line = Console.ReadLine();

            switch (line)
            {
                case "1":
                    DisplaySpaces();
                    break;
                case "2":
                    CheckIn();
                    break;
                case "3":
                    Checkout();
                    break;
                case "4":
                    ExitMenu();
                    break;
                default:
                    Console.WriteLine("Pick an option from the menu.");
                    DisplayMenu();
                    break;
            }

        }

        public string DisplaySpaces()
        {
            string status = "Current parking status:\n";
            
            for (int i = 0; i < parkingLot.Length; i++)
            {
                status += " |" + parkingLot[i] + "| ";
            }
            Console.WriteLine(status);
            return status;
        }

        public void CheckIn()
        {
            DisplaySpaces();
            Console.WriteLine("\nPick an empty place.");
            var place = Console.ReadLine();
            bool check = CheckIfAvailable(place);

            if (check == true)
            {
                string userCarPlate = Scan();
                parkingLot[Convert.ToInt32(place) - 1] = userCarPlate;
                parkingLotTimeStamp[Convert.ToInt32(place) - 1] = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                DisplaySpaces();
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Selected parking space is occupied.");
                DisplayMenu();
            }


        }

        public void Checkout()
        {
            DisplaySpaces();
            Console.WriteLine("Parking space number to clear: ");
            string parkingSpaceNo = Console.ReadLine();

            string checkInTimestamp = "";
            string checkOutTimestamp = "";
            string parkedTime = "";

            if (Convert.ToInt32(parkingSpaceNo) > 0 && Convert.ToInt32(parkingSpaceNo) <= 10 && parkingLot[Convert.ToInt32(parkingSpaceNo) - 1].Length > 2)
            {
                parkingLot[Convert.ToInt32(parkingSpaceNo) - 1] = parkingSpaceNo;
                Console.WriteLine(parkingLot[Convert.ToInt32(parkingSpaceNo) - 1]);
                checkInTimestamp = parkingLotTimeStamp[Convert.ToInt32(parkingSpaceNo) - 1];
                Console.WriteLine(checkInTimestamp);
                parkingLotTimeStamp[Convert.ToInt32(parkingSpaceNo) - 1] = "";
                checkOutTimestamp = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                Console.WriteLine(checkOutTimestamp);
                parkedTime = (Convert.ToDateTime(checkOutTimestamp) - Convert.ToDateTime(checkInTimestamp)).ToString();
                int hours = Convert.ToDateTime(parkedTime).Hour;
                int minutes = Convert.ToDateTime(parkedTime).Hour;
                int seconds = Convert.ToDateTime(parkedTime).Second;

                if (minutes > 0 || seconds > 0)
                    hours++;

                Console.WriteLine("Parked time: " + parkedTime + "; Rounded to " + hours + " hour(s).");
                DisplayMenu();
            }
            else
            {
                Console.WriteLine("Number entered is not valid or parking space already empty.");
                DisplayMenu();
            }
        }

        public void ExitMenu()
        {
            Environment.Exit(0);
        }

        public bool CheckIfAvailable(string place)
        {
            if (Convert.ToInt32(place) > 0 && Convert.ToInt32(place) <= 10)
            {
                if (parkingLot[Convert.ToInt32(place) - 1].Length <= 2)
                    return true;
                else return false;
            }
            return false;
        }

        public string Scan()
        {
            string licencePlate = RandomString();
            Console.WriteLine("Licence plate " + licencePlate + " registered.");
            return licencePlate;
        }


        private static Random random = new Random();
        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7).Select(s => s[random.Next(s.Length)]).ToArray());
        }


    }
}