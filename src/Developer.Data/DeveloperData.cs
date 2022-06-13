
public class DeveloperData
{
    public DeveloperData(){}
    public DeveloperData(string firstName, string lastName, int id)
    {
        FirstName=firstName;
        LastName=lastName;
        ID=id;
        PluralsightAccess = PluralsightAccess;
    }
    //*Properties 
    public int ID {get; set; }
    public string FirstName {get; set; }
    public string LastName {get; set; }
    public bool PluralsightAccess {get; set; }
}
