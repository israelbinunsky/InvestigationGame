public abstract class Sensor
{
    public abstract string type { get; }
    public bool active;
    public bool activate(IranianAgent agent)
    {
        foreach (string a in agent.SuitableSensors)
        {
            if (a == this.type)
            {
                return true;
            }
        }
        return false;
    }
}

public class AudioSensor : Sensor
{
    public override string type => "audio";
}

public class ThermalSensor : Sensor
{
    public override string type => "thermal";
}