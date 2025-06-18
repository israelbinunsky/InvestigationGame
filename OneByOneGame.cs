public static class OneByOneGame
{
    public static void playOne(IranianAgent agent)
    {
        int correctResult = 0;
        int prvResult = 0;
        int cnt = 0;
        control.ResetDict(agent.check);
        while (correctResult < agent.len)
        {
            Console.WriteLine($"Enter number between 1 and {control.sensorTypes.Count}.");
            correctResult = inputOne(agent);
            prvResult = correctResult;
            if (agent.type == "Squad Leader")
            {
                SquadLeader.activations++;
            }
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
        agent.ConnectedSensorsList.Add(instance);

        //switch (choise)
        //{
        //    case 1:
        //        AudioSensor audioSensor = new AudioSensor();
        //        agent.ConnectedSensorsList.Add(audioSensor);
        //        break;
        //    case 2:
        //        ThermalSensor thermalSensor = new ThermalSensor();
        //        agent.ConnectedSensorsList.Add(thermalSensor);
        //        break;
        //    case 3:
        //        if (PulseSensor.pulseCnt > PulseSensor.possibleActivations)
        //        {
        //            return -1;
        //        }
        //        PulseSensor pulseSensor = new PulseSensor();
        //        agent.ConnectedSensorsList.Add(pulseSensor);
        //        break;
        //    default:
        //        break;
        //}

        return choise;
    }

    public static int inputOne(IranianAgent agent)
    {
        int result = 0;
        int choise = 0;
        bool isActive = false;
        if (agent.type == "Squad Leader" && SquadLeader.activations > 0 && SquadLeader.activations % SquadLeader.attackAfter == 0)
        {
            SquadLeader.RemoveSensor(agent.WeaknessesDict, agent.check);
        }
        choise = addSensorToList(agent);
        if (choise == 3) { PulseSensor.pulseCnt++; }
        if (choise > 0 && choise <= control.sensorTypes.Count)
        {
            Sensor newSensor = agent.ConnectedSensorsList.Last();
            isActive = newSensor.activate(agent);
            if (isActive)
            {
                agent.check[newSensor.type] += 1;
            }
        }
        else if (PulseSensor.pulseCnt <= PulseSensor.possibleActivations)
        {
            Console.WriteLine("The number is out of range.");
        }
        result = game.compere(agent);
        return result;
    }
}