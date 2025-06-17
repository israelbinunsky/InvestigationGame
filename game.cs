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
            result = SetNums(agent);
            Console.WriteLine($"{result} / {agent.len}");
        }
    }

    public Dictionary<string, int> inputSet(IranianAgent agent)
    {
        int choise = 0;
        bool isOutOfRange = false;
        Dictionary<string, int> check = new Dictionary<string, int>();
        control.ResetDict(check);
        for (int i = 0; i < agent.len; i++)
        {
            choise = addSensor(agent, i);
            if (choise > 0 && choise <= agent.len)
            {
                Sensor newSensor = agent.ConnectedSensors[i];
                bool isActive = newSensor.activate(agent);
                if (isActive)
                {
                    check[newSensor.type] += 1;
                }
            }
            else
            {
                isOutOfRange = true;
            }
        }
        if (isOutOfRange = true)
        {
            Console.WriteLine("one of the numbers is out of range.");
        }
        return check;
    }

    public int SetNums(IranianAgent agent)
    {
        Dictionary<string, int> check = inputSet(agent);
        int cnt = 0;
        foreach (string key in check.Keys)
        {
            if (check[key] >= agent.WeaknessesDict[key])
            { cnt += agent.WeaknessesDict[key]; }
            else { cnt += check[key]; }
        }
        return cnt;
    }

   public int addSensor(IranianAgent agent, int cnt)
    {
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1:
                AudioSensor audioSensor = new AudioSensor();
                agent.ConnectedSensors[cnt] = audioSensor;
                break;
            case 2:
                ThermalSensor thermalSensor = new ThermalSensor();
                agent.ConnectedSensors[cnt] = thermalSensor;
                break;
            default:
                break;
        }
        return choise;
    }     
}
