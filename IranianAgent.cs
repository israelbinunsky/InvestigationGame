public abstract class IranianAgent
{
    public abstract string grade { get; }
    public int len { get; set; }
    public string[] Weaknesses { get; set; }
    public Dictionary<string, int> WeaknessesDict { get; set; }
    public Sensor[] ConnectedSensors { get; set; }
    public Dictionary<string, int> ConnectedSensorsDict { get; set; }

    public IranianAgent(int len)
    {
        this.len = len;
        this.Weaknesses = new string[this.len];
        this.ConnectedSensors = new Sensor[this.len];
        this.WeaknessesDict = new Dictionary<string, int>();
        this.ConnectedSensorsDict = new Dictionary<string, int>();
        this.WeaknessesDict["audio"] = 0;
        this.WeaknessesDict["thermal"] = 0;
        this.ConnectedSensorsDict["audio"] = 0;
        this.ConnectedSensorsDict["thermal"] = 0;
    }

    public void createSuitableList()
    {
        for (int i = 0; i < this.len; i++)
        {
            string sensor = RandomSensor();
            this.Weaknesses[i] = sensor;
            WeaknessesDict[sensor] += 1;
        }
    }
    public string RandomSensor()
    {
        List<string> sensors = new List<string> { "audio", "thermal" };

        Random rnd = new Random();
        int index = rnd.Next(sensors.Count);
        string sensor = sensors[index];
        return sensor;
    }
}

public class JuniorAgent: IranianAgent
{
    public override string grade => "Junior";

    public JuniorAgent(): base(2)
    {

    }
}