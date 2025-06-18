public abstract class IranianAgent
{
    public abstract string grade { get; }
    public int len { get; set; }
    public Dictionary<string, int> WeaknessesDict { get; set; }
    public Sensor[] ConnectedSensors { get; set; }
    public List<Sensor> ConnectedSensorsList { get; set; }


    public IranianAgent(int len)
    {
        this.len = len;
        this.WeaknessesDict = new Dictionary<string, int>();
        this.ConnectedSensors = new Sensor[this.len];
        this.ConnectedSensorsList = new List<Sensor>();

    }
}

public class JuniorAgent: IranianAgent
{
    public override string grade => "Junior";

    public JuniorAgent(): base(2)
    {

    }
}