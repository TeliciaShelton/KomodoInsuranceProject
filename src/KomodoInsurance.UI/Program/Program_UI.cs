using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program_UI
{
    private readonly DeveloperRepo _dRepo = new DeveloperRepo();

    private readonly DevTeamRepo _dtRepo = new DevTeamRepo();

    public void Run()
    {
        RunMenu();
    }

    private void RunMenu()
    {
        bool continueToRun = true;
            while (continueToRun)
        {
                Console.Clear();
                System.Console.WriteLine("Please    make a selection: /n" +
                 "1.Developer List \n" +
                 "2.Add Developer \n" +
                 "3.Remove Developer \n" +
                 "4. Find Developer by ID \n" +
                 "5. Developers with PluralSight \n" +
                 "6. Create new Developer Team \n" +
                 "7.Add Developer to Team \n" +
                 "8. Remove Developer from Team \n" 
                );

            string userInput = Console.ReadLine ();
            switch(userInput)
            {
                case "1":
                    ShowAllDevelopers();
                    break;
                case "2":
                    CreateNewDeveloper();
                    break;
                case "3":
                    RemoveDeveloper();
                    break;
                case "4":
                    ShowDeveloperByID();
                    break;
                case "5":
                    CreateNewDevTeam();
                    break;
                case "6":
                    AddDevelopertoTeam();
                    break;
                case "7":
                    RemoveDeveloperfromTeam();
                    break;
                case "8": 
                    continueToRun = false;
                    System.Console.WriteLine("Try again!");
                    PauseUntilKeyPress();
                default:
                    System.Console.WriteLine("Must make a selection from above!");
                    PauseUntilKeyPress();
                break;
            }
        }

    }
    
    private void PauseUntilKeyPress();

    private void ShowAllDevelopers()
    {
        Console.Clear();
        System.Console.WriteLine("All Developers");
        List<DeveloperData>ListofDevelopers = _dRepo.GetAllDevelopers();
        foreach (DeveloperData data in ListofDevelopers)
        {
            DisplayDeveloper(data);
        }
        PressAnyKey();
    }

    private void DisplayDeveloper(DeveloperData data)
    {
        System.Console.WriteLine($"Developer Name: {firstName + lastName} \n", 
        $"Developer ID: {id} \n",
        $"PluralsightAccess: {pluralsightaccess}");
    }
    private void SeedData()
    {
        DeveloperData ryan = new DeveloperData("Ryan", "Williams", 1, true);
        DeveloperData terri = new DeveloperData("Terri", "Watt", 2, false);
        DeveloperData larry = new DeveloperData("Larry", "Jones", 3, true);
        

        _dRepo.AddDeveloperToDataBase(ryan);
        _dRepo.AddDeveloperToDataBase(terri);
        _dRepo.AddDeveloperToDataBase(larry);

        DevTeam alpha = new DevTeam ("Alpha Team");
        DevTeam pink = new DevTeam ("Pink Team");
        DevTeam best = new DevTeam ("Best Team");

        _dtRepo.AddDevTeamtoDataBase(alpha);
        _dtRepo.AddDevTeamtoDataBase(pink);
        _dtRepo.AddDevTeamtoDataBase(best);
    }
    private void CreateNewDeveloper()
    {
        Console.Clear();
        DeveloperData data = new DeveloperData();
        System.Console.WriteLine("Enter Developer first name: ");
        data.FirstName = Console.ReadLine(); 

        System.Console.WriteLine("Enter Developer last name: ");
        data.LastName = Console.ReadLine();

        // System.Console.WriteLine("Enter Developer ID: ");
        // data.ID = Console.ReadLine();

        System.Console.WriteLine("Does this developer have access to PluralsightAccess?(enter true or false):");
        data.PluralsightAccess = Console.ReadLine();
    }
    private void RemoveDeveloper()
    {
        Console.Clear();
        System.Console.WriteLine("");
        var DeveloperData = _dRepo.ListofDevelopers();

        foreach(DeveloperData d in ListofDevelopers)
        (
            DisplayDeveloper(d)
        )
        try
        {
            System.Console.WriteLine("Please select a developer by ID: \n");
            int userInputSelectedDeveloper = int.Parse(Console.ReadLine());
            bool isSuccessful = _dRepo. RemoveDeveloperDataFromDataBase(userInputSelectedDeveloper);

            if(isSuccessful)
            {
                System.Console.WriteLine("Removed the Developer!");
            }
            else
            {
                System.Console.WriteLine("Developer could not be removed.");
            }
        }
        catch 
        {
            System.Console.WriteLine("Sorry invaild selection.");
        }
        PauseUntilKeyPress();
    }
    private void ShowDeveloperByID()
    {
        Console.Clear();
        System.Console.WriteLine("List of Developers");
        var developer = _dRepo.GetAllDevelopers();

        foreach(DeveloperData d in ListofDevelopers)
        {
            DisplayDeveloper(d);
        }
        try
        {
            System.Console.WriteLine("Please input developer ID: ");
            int userInput - int.Parse(Console.ReadLine());
            var selectedDeveloper = _dRepo.GetDeveloperbyid(userInput);

            if(selectedDeveloper !=null)
            {
                DisplayDeveloper(selectedDeveloper);
            }
            else
        {
            System.Console.WriteLine("Who are you looking for?");
        }
        }
        catch
        {
            System.Console.WriteLine("Invalid selection");
        }
        PauseUntilKeyPress();
    }
    private void CreateNewDevTeam()
    {
        Console.Clear();
        DevTeam data = new DevTeam();
        System.Console.WriteLine("Enter New Dev Team Name: ");
        data.Name = Console.ReadLine();
    }
    private void AddDeveloperToTeam()
    {
        Console.Clear();
        var availTeams = _dtRepo.GetAllTeams();
        var currentDevelopers = _dRepo.GetAllDevelopers();
        foreach(var t in availTeams)
        {
            DisplayTeamList(t);
        }

        System.Console.WriteLine("Please select a team by ID: \n");
        int userInput = int.Parse(Console.ReadLine());
        var selectedTeam = _dtRepo.GetTeamByID(userInput);

        if(selectedTeam != null)
        {
             Console.Clear();
             System.Console.WriteLine("Please select developer by ID \n");
             int developerSelected = int.Parse(Console.ReadLine());
             var selectedDeveloper = _dRepo.GetDeveloperById(developerSelected);

             if(selectedDeveloper != null)
            {
                availTeams.DeveloperData.Add(selectedDeveloper);
                currentDevelopers.Remove(selectedDeveloper);
            }
              else
            {
                System.Console.WriteLine("Developer not added");
            }
        }
        else
        {
            System.Console.WriteLine("Sorry, this team does not exist, please create a new team. ");
        }
    }
    private void RemoveDeveloperFromTeam()
    {
        Console.Clear();
        var availTeams = _dtRepo.GetAllTeams();
        var currentDevelopers = _dRepo.GetAllTeams();
        foreach(var t in availTeams)
        {
            DisplayTeamList(t);
        }

        System.Console.WriteLine("Please select a team by ID: \n");
        int userInput = int.Parse(Console.ReadLine());
        var selectedTeam = _dtRepo.GetTeamByID(userInput);

        if(selectedTeam != null)
        {
            Console.Clear();
            System.Console.WriteLine("Please select developer by ID. \n");
            int developerSelected = int.Parse(Console.ReadLine());
            var selectedDeveloper = _dRepo.GetDeveloperById(developerSelected);

            if(selectedDeveloper != null)
            {
                availTeams.DeveloperData.Remove(selectedDeveloper);
                currentDevelopers.Remove(selectedDeveloper);
            }
            else
            {
                 System.Console.WriteLine("No Developer to remove");
            }
        }
        else
            {
                System.Console.WriteLine("Developer could not be removed");
            }

    }
} 














