public static class control
{
    public static List<string> sensorTypes { get; set; }
     static control()
    {
        sensorTypes = new List<string> { "audio", "thermal" };
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
        ResetDict(agent.ConnectedSensorsDict);
        for (int i = 0; i < agent.len; i++)
        {
            string sensor = RandomSensor();
            agent.Weaknesses[i] = sensor;
            agent.WeaknessesDict[sensor] += 1;
        }
    }
    public static string RandomSensor()
    {
        Random rnd = new Random();
        int index = rnd.Next(sensorTypes.Count);
        string sensor = sensorTypes[index];
        return sensor;
    }
}