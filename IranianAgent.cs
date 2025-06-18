public abstract class IranianAgent
{
    public abstract string type { get; }
    public int len { get; set; }
    public Dictionary<string, int> WeaknessesDict { get; set; }
    public Sensor[] ConnectedSensors { get; set; }
    public List<Sensor> ConnectedSensorsList { get; set; }
    public Dictionary<string, int> check { get; set; }


    public IranianAgent(int len)
    {
        this.len = len;
        this.WeaknessesDict = new Dictionary<string, int>();
        this.ConnectedSensors = new Sensor[this.len];
        this.ConnectedSensorsList = new List<Sensor>();
        this.check = new Dictionary<string, int>();

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
    public static int activations { get; set; }
    public static int attackAfter { get; set; }
    public SquadLeader() : base(4)
    {
        activations = 0;
        attackAfter = 3;
    }
    public static void RemoveSensor(Dictionary<string, int> WeaknessesDict, Dictionary<string, int> check)
    {
        bool removed = false;
        while (removed == false)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, control.sensorTypes.Count);
            string type = control.sensorTypes[num];
            if (check[type] > 0 && WeaknessesDict[type] > 0)
            {
                check[type]--;
                removed = true;
                Console.WriteLine("the Squad Leader removed 1 sensor.");
            }
        }
    }
}