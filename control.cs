public static class control
{
    public static List<string> sensorTypes { get; set; }
    public static int pulseCnt { get; set; } = 0;
     static control()
    {
        sensorTypes = new List<string> { "audio", "thermal", "pulse" };
    }

    public static Type GetSensorType(string name)
    {
        if (name == "audio")
            return typeof(AudioSensor);
        else if (name == "thermal")
            return typeof(ThermalSensor);
        else if (name == "pulse")
            return typeof(PulseSensor);
        else
            return null;
    }

    public static void ResetDict(Dictionary<string, int> dict)
    {
        foreach (string type in sensorTypes)
        {
            dict[type] = 0;
        }
    }
    public static void createWeaknesses(IranianAgent agent)
    {
        ResetDict(agent.WeaknessesDict);
        for (int i = 0; i < agent.len; i++)
        {
            string sensor = RandomSensor();
            agent.WeaknessesDict[sensor] += 1;
        }
    }
    public static string RandomSensor()
    {
        Random rnd = new Random();
        int index = rnd.Next(1,sensorTypes.Count);
        string sensor = sensorTypes[index];
        return sensor;
    }

    public static void showWeaknesses(IranianAgent agent)
    {
        foreach (string s in agent.WeaknessesDict.Keys)
        {
            Console.WriteLine(s);
        }
    }
}