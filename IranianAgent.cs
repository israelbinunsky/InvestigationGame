public abstract class IranianAgent
{
    public abstract string grade { get; }
    public int len { get; set; }
    public string[] SuitableSensors { get; set; }
    public Sensor[] ConnectedSensors { get; set; }
    public Dictionary<Sensor, int> ConnectedSensorsDict { get; set; }

    public IranianAgent(int len)
    {
        this.len = len;
        this.SuitableSensors = new string[this.len];
    }

    public void createSuitableList()
    {
        for (int i = 0; i < this.len; i++)
        {
            string sensor = RandomSensor();
            this.SuitableSensors[i] = sensor;
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