public abstract class Sensor
{
    public abstract string type { get; }
    public int activations { get; set; }
    public virtual bool activate(IranianAgent agent)
    {
        if (agent.WeaknessesDict[this.type] > 0)
            return true;
        foreach (string a in agent.Weaknesses)
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

public class PulseSensor : Sensor
{
    public override string type => "pulse";
    public PulseSensor()
    {
        this.activations = 0;
    }
    public override bool activate(IranianAgent agent)
    {
        this.activations ++;
        return base.activate(agent);
    }
}