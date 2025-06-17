 public class game
{
    public void start()
    {
        JuniorAgent agent = new JuniorAgent();
        control.createWeaknesses(agent);
        int result = 0;
        while (result < agent.len)
        {
            Console.WriteLine($"enter {agent.len} numbers:");
            result = inputSet(agent);
            Console.WriteLine($"{result} / {agent.len}");
        }
    }

    public int inputSet(IranianAgent agent)
    {
        int cnt = 0;
        Dictionary<string, int> check = new Dictionary<string, int>();
        control.ResetDict(check);
        for (int i = 0; i < agent.len; i++)
        {
            addSensor(agent, cnt);
            Sensor newSensor = agent.ConnectedSensors[cnt];
            bool isActive = newSensor.activate(agent);
            if (isActive)
            {
                check[newSensor.type] += 1;
            }
        }
        foreach (string key in check.Keys)
        {
            if (check[key] >= agent.WeaknessesDict[key])
            { cnt += agent.WeaknessesDict[key]; }
            else { cnt += check[key]; }
        }
        return cnt;
    }
   public void addSensor(IranianAgent agent, int cnt)
    {
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1:
                AudioSensor audioSensor = new AudioSensor();
                agent.ConnectedSensors[cnt] = audioSensor;
                agent.ConnectedSensorsDict[audioSensor.type] += 1;
                break;
            case 2:
                ThermalSensor thermalSensor = new ThermalSensor();
                agent.ConnectedSensors[cnt] = thermalSensor;
                agent.ConnectedSensorsDict[thermalSensor.type] += 1;
                break;
            default:
                break;
        }
    }     
}
