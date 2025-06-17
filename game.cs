 public class game
{
    public void start(IranianAgent agent)
    {
        int choise = menue(agent);
        if (choise == 3)
        { return; }
        int result = 0;
        while (result < agent.len)
        {
            Console.WriteLine($"Enter {agent.len} numbers between 1 and {control.sensorTypes.Count}."); 
            result = inputSet(agent);
            Console.WriteLine($"{result} / {agent.len}");
        }
    }

    public int menue(IranianAgent agent)
    {
        Console.WriteLine("Welcome to Investigation Game!");
        Console.WriteLine("to show optinal sensors enter 1.");
        Console.WriteLine("to start enter 2.");
        Console.WriteLine("to exit enter 3.");
        int choise = int.Parse(Console.ReadLine());
        while (choise > 0)
        {
            switch (choise)
            {
                case 1:
                    for (int i = 0; i < control.sensorTypes.Count; i++)
                    {
                        Console.WriteLine($"{control.sensorTypes[i]}: number {i + 1}.");
                    }
                    Console.WriteLine("to start enter 2.");
                    Console.WriteLine("to exit enter 3.");
                    choise = int.Parse(Console.ReadLine());
                    break;
                default:
                    return choise;               
            }
        }
        return choise;
    }

    public int inputSet(IranianAgent agent)
    {
        int choise = 0;
        bool isOutOfRange = false;
        Dictionary<string, int> check = new Dictionary<string, int>();
        control.ResetDict(check);
        for (int i = 0; i < agent.len; i++)
        {
            choise = addSensor(agent, i);
            if (choise > 0 && choise <= control.sensorTypes.Count)
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
       int result = compere(agent, check);
       return result;
    }

    public int compere(IranianAgent agent, Dictionary<string, int> check)
    {
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
            case 3:
                PulseSensor pulseSensor = new PulseSensor();
                agent.ConnectedSensors[cnt] = pulseSensor;
                break;
            default:
                break;
        }
       
        return choise;
 
    }     
}
