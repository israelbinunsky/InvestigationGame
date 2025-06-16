 class game
{
    public int start(IranianAgent agent)
    {
        int cnt = 0;
        int match = 0;
        for (int i = 0; i < agent.len; i++)
        {
            addSensor(agent, cnt);
            Sensor newSensor = agent.ConnectedSensors[cnt];
            bool isActive = newSensor.activate(agent);
            if (isActive)
            {
               if (agent.ConnectedSensorsDict[newSensor.type] > 0)
                {
                    cnt++;
                    agent.ConnectedSensorsDict[newSensor.type]--;
                }
            }
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
