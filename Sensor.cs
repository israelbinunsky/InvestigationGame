public abstract class Sensor
{
    public abstract string type { get; }
    public virtual bool activate(IranianAgent agent)
    {
        if (agent.WeaknessesDict[this.type] > 0)
            return true;
        foreach (string a in agent.WeaknessesDict.Keys)
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
    public static int possibleActivations;
    public PulseSensor()
    {
        possibleActivations = 3;
    }
}