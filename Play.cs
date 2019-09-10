/******************************************************************/
//  High Rollers
//
//  A project given in my Intro to C++ Class in 2011
//  that essentially emulates Yahtzee.
/******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using High_Rollers;

class Play
{
    static void Main(string[] args)
    {
        Hand player = new Hand("Craig");
        Hand computer = new Hand("House");
        
        // Get and display player's hand
        player.RollHand();
        player.ShowHand();

        // Get and display computer's hand
        computer.RollHand();
        computer.ShowHand();

        // Calculate scores for each player
        player.Score = GetScore(player);
        computer.Score = GetScore(computer);

        // Determine winner
        DetermineWinner(player, computer);
    }

    static int GetScore(Hand player)
    {
        Die[] hand = player.GetHand();
        int[] counts = {0, 0, 0, 0, 0, 0};
        int score = 0;

        foreach (Die d in hand)
        {
            int index = d.GetResult();

            counts[index-1]++;
        }

        score = CheckYahtzee(counts);

        if (score == 0)
            score = CheckStraight(counts);

        if (score == 0)
            score = AddRolls(counts);

        Console.WriteLine("{0}'s score is {1}", player.PlayerName, score);

        return score;
    }

    static int CheckYahtzee(int[] faces)
    {
        for (int i = 0; i < faces.Length; i++)
            if (faces[i] == 5)
            {
                Console.WriteLine("Yahtzee!");
                return 50;
            }
                

        return 0;
    }

    static int CheckStraight(int[] faces)
    {
        int unique = 0;

        for (int i = 0; i < faces.Length; i++)
        {
            if (faces[i] == 1)
                unique++;
        }

        if (unique == 6)
        {
            Console.WriteLine("Full Straight!");
            return 40; // Full Straight
        }
        else if (unique == 5)
        {
            Console.WriteLine("Small Straight!");
            return 30; // Small Straight
        }
            

        return 0;
    }

    static int AddRolls(int[] faces)
    {
        int sum = 0;
        int j = 1;

        for (int i = 0; i < faces.Length; i++, j++)
        {
            sum += faces[i] * j;
        }

        return sum;
    }

    static void DetermineWinner(Hand player, Hand computer)
    {
        if (player.Score > computer.Score)
            Console.WriteLine("{0} is the winner!", player.PlayerName);
        else
            Console.WriteLine("{0} is the winner!", computer.PlayerName); // House wins in the event of a tie as well.
    }
}