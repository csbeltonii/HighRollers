/******************************************************************/
//  High Rollers
//
//  A project given in my Intro to C++ Class in 2011
//  that essential emulates Yahtzee.
/******************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using High_Rollers;

class Play
{
    static void Main(string[] args)
    {
        Hand player = new Hand("Craig");
        Hand computer = new Hand("House");
        bool contPlay = true;

        while (contPlay)
        {
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

            char c;

            try
            {
                Console.Write("Play again? (Y/N) ");
                c = Console.ReadLine().ToCharArray()[0];
            }
            catch (NullReferenceException nre)
            {
                c = 'N';
            }

            if (c != 'Y')
                contPlay = false;
        }
        
    }

    static int GetScore(Hand player)
    {
        Die[] dies = player.GetHand();
        int[] hand = new int[5];
        int score = 0;
        int i = 0;

        foreach (Die d in dies)
        {
            hand[i++] = d.GetResult();
        }

        score = CheckYahtzee(hand);

        if (score == 0)
            score = CheckFullStraight(hand);
        if (score == 0)
            score = CheckSmallStraight(hand);
        if (score == 0)
            score = AddRolls(hand);

        Console.WriteLine("{0}'s score is {1}", player.PlayerName, score);

        return score;
    }

    static int CheckYahtzee(int[] hand)
    {
        int ct = 0;
        int ck = hand.Aggregate(
            hand[0],
            (acc, x) =>
            {
                if (acc == x)
                    ct++;
                return x;
            });

        if (ct == 5)
            return 50;

        return 0;
    }

    static int CheckFullStraight(int[] hand)
    {
        Array.Sort(hand);

        int num = hand.Aggregate(
            hand[0] - 1,
            (acc, x) =>
            {
                if (x == acc + 1)
                    return x;
                return 0;
            });

        if (num == 6 || num == 5)
            return 40;

        return 0;
    }

    static int CheckSmallStraight(int[] hand)
    {
        Array.Sort(hand);
        int matches = 1;
        HashSet<int> nums = new HashSet<int>();

        foreach (int i in hand)
        {
            if (!nums.Contains(i))
                nums.Add(i);
            else
                matches--;
        }

        int ct = nums.Aggregate(
            0,
            (acc, x) =>
            {
                if (x == acc + 1)
                    return x;
                return 0;
            });

        if ((ct == 6 || ct == 5 || ct == 4) && (matches ==0))
            return 30;

        return 0;
    }

    static int AddRolls(int[] hand)
    {
        int sum = hand.Sum();

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