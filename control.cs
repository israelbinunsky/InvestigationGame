using System.ComponentModel.Design;
using static System.Net.Mime.MediaTypeNames;

public static class control
{
    public static List<string> sensorTypes { get; set; }
    public static List<string> agentTypes { get; set; }
    public static int pulseCnt { get; set; } = 0;
     static control()
    {
        sensorTypes = new List<string> { "audio", "thermal", "pulse", "motion" };
        agentTypes = new List<string> { "Foot Soldier", "Squad Leader", "Senior Commander", "Organization Leader" };
    }
    public static Type GetSensorType(string name)
    {
        switch (name)
        {
            case "audio":
                return typeof(AudioSensor);
            case "thermal":
                return typeof(ThermalSensor);
            case "pulse":
                return typeof(PulseSensor);
            case "motion":
                return typeof(MotionSensor);
            default:
                return null;
        }
    }
    public static Type GetAgentType(string name)
    {
        switch (name)
        {
            case "Foot Soldier":
                return typeof(FootSoldier);
            case "Squad Leader":
                return typeof(SquadLeader);
            case "Senior Commander":
                return typeof(SeniorCommander);
            case "Organization Leader":
                return typeof(OrganizationLeader);
            default:
                return null;
        }
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
    public static void RemoveSensor(IranianAgent agent)
    {
        bool removed = false;
        while (removed == false)
        {
            Random rnd = new Random();
            int num = rnd.Next(1, control.sensorTypes.Count);
            string type = control.sensorTypes[num];
            if (agent.check[type] > 0 && agent.WeaknessesDict[type] > 0)
            {
                agent.check[type]--;
                removed = true;
                Console.WriteLine($"the Squad Leader removed {agent.numOfAttacks} sensor.");
            }
        }
    }
}