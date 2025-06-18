 public static class game
{
    public static void start(IranianAgent agent)
    {
        Console.WriteLine("Welcome to Investigation Game!");
        menue(agent);
    }

    public static void menue(IranianAgent agent)
    {
        
        Console.WriteLine("to show optinal sensors enter 1.");
        Console.WriteLine("to start the game enter 2.");
        Console.WriteLine("to exit enter 3.");
        int choise = int.Parse(Console.ReadLine());
 
        switch (choise)
        {
            case 1:
                for (int i = 0; i < control.sensorTypes.Count; i++)
                {
                    Console.WriteLine($"{control.sensorTypes[i]}: number {i + 1}.");
                }
                menue(agent);
                break;
            case 2:
                gameMenue(agent);
                break;
            case 3:
                break;
            default:
                Console.WriteLine("invalid choise.");
                menue(agent);
                break;
            
        }
    }

    public static void gameMenue(IranianAgent agent)
    {
        Console.WriteLine("to play the set method enter 1.");
        Console.WriteLine("to play the one by one method enter 2.");
        int choise = int.Parse(Console.ReadLine());
        switch (choise)
        {
            case 1:
                SetGame.playSet(agent);
                break;
            case 2:
                OneByOneGame.playOne(agent);
                break;
            default:
                Console.WriteLine("invalid choise.");
                gameMenue(agent);
                break;

        }
    }


    public static int compere(IranianAgent agent)
    {
        int cnt = 0;
        foreach (string key in agent.check.Keys)
        {
            if (agent.check[key] >= agent.WeaknessesDict[key])
            { cnt += agent.WeaknessesDict[key]; }
            else { cnt += agent.check[key]; }
        }
        return cnt;
    }

 
    

}
