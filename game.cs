 public class game
{
    public void start(IranianAgent agent)
    {
        Console.WriteLine("Welcome to Investigation Game!");
        int choise = menue(agent);
        if (choise == 3)
        { return; }
        int correctResult = 0;
        while (correctResult < agent.len)
        {
            Console.WriteLine($"Enter {agent.len} numbers between 1 and {control.sensorTypes.Count}.");
            correctResult = inputSet(agent);
            Console.WriteLine($"{correctResult} / {agent.len}");
            if (control.pulseCnt > PulseSensor.possibleActivations)
            {
                Console.WriteLine("Pulse sensor is not count anymore.");
            }
        }
    }

    public int menue(IranianAgent agent)
    {
        
        Console.WriteLine("to show optinal sensors enter 1.");
        Console.WriteLine("to start the game enter 2.");
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
                    choise = menue(agent);
                    break;
                case 2:
                    return choise;
                case 3:
                    return choise;
                default:
                    Console.WriteLine("invalid choise.");
                    choise = menue(agent);
                    break;
            }
        }
        return choise;
    }

    public int inputSet(IranianAgent agent)
    {
        int choise = 0;
        bool pulseChoosed = false;
        bool isActive = false;
        bool isOutOfRange = false;
        Dictionary<string, int> check = new Dictionary<string, int>();
        control.ResetDict(check);
        for (int i = 0; i < agent.len; i++)
        {
            choise = addSensor(agent, i);
            if (choise == 3) { pulseChoosed = true; }
            if (choise > 0 && choise <= control.sensorTypes.Count)
            {
                Sensor newSensor = agent.ConnectedSensors[i];
                isActive = newSensor.activate(agent);
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
        if (isOutOfRange == true)
        {
            Console.WriteLine("one of the numbers is out of range.");
        }
        if (pulseChoosed == true) { control.pulseCnt++; }
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
                if (control.pulseCnt > PulseSensor.possibleActivations)
                {
                    return 0;
                }
                PulseSensor pulseSensor = new PulseSensor();
                agent.ConnectedSensors[cnt] = pulseSensor;
                break;
            default:
                break;
        }
       
        return choise;
 
    }     
}
