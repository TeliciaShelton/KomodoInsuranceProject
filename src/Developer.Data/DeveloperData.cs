
public class DeveloperData
{
    public DeveloperData(){}
    public DeveloperData(string firstName, string lastName, int id)
    {
        FirstName=firstName;
        LastName=lastName;
        ID=id;
    }
    //*Properties 
    public int ID {get; set; }
    public string firstName {get; set; }
    public string lastName {get; set; }
    public bool PluralsightAccess {get; set; }
}
