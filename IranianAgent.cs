public abstract class IranianAgent
{
    public abstract string grade { get; }
    public int len { get; set; }
    public string[] Weaknesses { get; set; }
    public Dictionary<string, int> WeaknessesDict { get; set; }
    public Sensor[] ConnectedSensors { get; set; }


    public IranianAgent(int len)
    {
        this.len = len;
        this.Weaknesses = new string[this.len];
        this.ConnectedSensors = new Sensor[this.len];
        this.WeaknessesDict = new Dictionary<string, int>();

    }
}

public class JuniorAgent: IranianAgent
{
    public override string grade => "Junior";

    public JuniorAgent(): base(2)
    {

    }
}