public static class OneByOneGame
{
    public static void playOne(IranianAgent agent)
    {
        int correctResult = 0;
        int prvResult = 0;
        Dictionary<string, int> check = new Dictionary<string, int>();
        control.ResetDict(check);
        while (correctResult < agent.len)
        {
            Console.WriteLine($"Enter number between 1 and {control.sensorTypes.Count}.");
            correctResult = inputOne(agent, check);
            prvResult = correctResult;
            Console.WriteLine($"{correctResult} / {agent.len}");
            if (PulseSensor.pulseCnt > PulseSensor.possibleActivations)
            {
                Console.WriteLine("Pulse sensor is not count anymore.");
            }  
        }
    }

    public static int addSensorToList(IranianAgent agent)
    {
        string input = Console.ReadLine();
        int choise;

        if (!int.TryParse(input, out choise))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return 0;
        }

        switch (choise)
        {
            case 1:
                AudioSensor audioSensor = new AudioSensor();
                agent.ConnectedSensorsList.Add(audioSensor);
                break;
            case 2:
                ThermalSensor thermalSensor = new ThermalSensor();
                agent.ConnectedSensorsList.Add(thermalSensor);
                break;
            case 3:
                if (PulseSensor.pulseCnt > PulseSensor.possibleActivations)
                {
                    return -1;
                }
                PulseSensor pulseSensor = new PulseSensor();
                agent.ConnectedSensorsList.Add(pulseSensor);
                break;
            default:
                break;
        }

        return choise;
    }

    public static int inputOne(IranianAgent agent, Dictionary<string, int> check)
    {
        int result = 0;
        int choise = 0;
        bool isActive = false;
        choise = addSensorToList(agent);
        if (choise == 3) { PulseSensor.pulseCnt++; }
        if (choise > 0 && choise <= control.sensorTypes.Count)
        {
            Sensor newSensor = agent.ConnectedSensorsList.Last();
            isActive = newSensor.activate(agent);
            if (isActive)
            {
                check[newSensor.type] += 1;
            }
        }
        else if (choise != -1)
        {
            Console.WriteLine("The number is out of range.");
        }
        result = game.compere(agent, check);
        return result;
    }
}