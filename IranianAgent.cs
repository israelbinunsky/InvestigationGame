public abstract class IranianAgent
{
    public abstract string type { get; }
    public int len { get; set; }
    public Dictionary<string, int> WeaknessesDict { get; set; }
    public Sensor[] ConnectedSensors { get; set; }
    public List<Sensor> ConnectedSensorsList { get; set; }
    public Dictionary<string, int> check { get; set; }
    public int activations { get; set; }
    public int attackAfter { get; set; }
    public int numOfAttacks { get; set; }


    public IranianAgent(int len)
    {
        this.len = len;
        this.WeaknessesDict = new Dictionary<string, int>();
        this.ConnectedSensors = new Sensor[this.len];
        this.ConnectedSensorsList = new List<Sensor>();
        this.check = new Dictionary<string, int>();
        activations = 0;
    }
}

public class FootSoldier: IranianAgent
{
    public override string type => "Foot Soldier";

    public FootSoldier(): base(2)
    {

    }
}

public class SquadLeader: IranianAgent
{
    public override string type => "Squad Leader";
    public SquadLeader() : base(4)
    {
        attackAfter = 3;
        numOfAttacks = 1;
    }
}

public class SeniorCommander: IranianAgent
{
    public override string type => "Senior Commander";
    public SeniorCommander() : base(6)
    {
        attackAfter = 5;
        numOfAttacks = 2;
    }
}

public class OrganizationLeader: IranianAgent
{
    public override string type => "Organization Leader ";
    public OrganizationLeader() : base(8)
    {
        attackAfter = 6;
        numOfAttacks = 3;
    }
}

