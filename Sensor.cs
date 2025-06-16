public abstract class Sensor
{
    public abstract string type { get; }
    public bool IsActive;
    static public void activate()
    {

    }
}

public class AudioSensor: Sensor
{
    public override string type => "audio";
}

public class ThermalSensor : Sensor
{
    public override string type => "thermal";
}