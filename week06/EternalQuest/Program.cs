// Creativity and exceeds requirements:
// I added a player level system that rewards progress by
// assigning different levels based on the player's score.

using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        goalManager.Start();
    }
}