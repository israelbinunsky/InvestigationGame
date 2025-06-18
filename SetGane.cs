public static class SetGame
{
    public static void playSet(IranianAgent agent)
    {
        int correctResult = 0;
        while (correctResult < agent.len)
        {
            Console.WriteLine($"Enter {agent.len} numbers between 1 and {control.sensorTypes.Count}.");
            correctResult = inputSet(agent);
            Console.WriteLine($"{correctResult} / {agent.len}");
            if (PulseSensor.pulseCnt > PulseSensor.possibleActivations)
            {
                Console.WriteLine("Pulse sensor is not count anymore.");
            }
        }
    }

    public static int inputSet(IranianAgent agent)
    {
        int choise = 0;
        bool pulseChoosed = false;
        bool isActive = false;
        bool isOutOfRange = false;  
        control.ResetDict(agent.check);
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
                    agent.check[newSensor.type] += 1;
                }
            }
            else if (PulseSensor.pulseCnt <= PulseSensor.possibleActivations)
            {
                isOutOfRange = true;
            }
        }
        if (isOutOfRange == true)
        {
            Console.WriteLine("one of the numbers is out of range.");
        }
        if (pulseChoosed == true) { PulseSensor.pulseCnt++; }
        int result = game.compere(agent);
        return result;
    }

    public static int addSensor(IranianAgent agent, int cnt)
    {
        string input = Console.ReadLine();
        int choise;

        if (!int.TryParse(input, out choise))
        {
            Console.WriteLine("Invalid input. Please enter a number.");
            return 0;
        }
        if (choise == 3 && PulseSensor.pulseCnt > PulseSensor.possibleActivations)
        {
            return -1;
        }
        if (choise < 1 || choise > control.sensorTypes.Count)
        {
            return choise;
        }
        string name = control.sensorTypes[choise - 1];
        Type type = control.GetSensorType(name);
        Sensor instance = (Sensor)Activator.CreateInstance(type);
        agent.ConnectedSensors[cnt] = instance;
        //switch (choise)
        //{
        //    case 1:
        //        AudioSensor audioSensor = new AudioSensor();
        //        agent.ConnectedSensors[cnt] = audioSensor;
        //        break;
        //    case 2:
        //        ThermalSensor thermalSensor = new ThermalSensor();
        //        agent.ConnectedSensors[cnt] = thermalSensor;
        //        break;
        //    case 3:
        //        if (PulseSensor.pulseCnt > PulseSensor.possibleActivations)
        //        {
        //            return -1;
        //        }
        //        PulseSensor pulseSensor = new PulseSensor();
        //        agent.ConnectedSensors[cnt] = pulseSensor;
        //        break;
        //    default:
        //        break;
        //}

        return choise;
    }
}