public abstract class IranianAgent
{
    public abstract string grade { get; }
    public int len { get; set; }
    public Sensor[] SuitableSensors { get; set; }
    public Sensor[] ConnectedSensors { get; set; }
    public Dictionary<Sensor, int> ConnectedSensorsDict { get; set; }

    public IranianAgent(int len)
    {
        this.len = len;
        this.SuitableSensors = new Sensor[this.len];
    }


}

public class JuniorAgent: IranianAgent
{
    public override string grade => "a";

    public JuniorAgent(): base(2)
    {

    }
}