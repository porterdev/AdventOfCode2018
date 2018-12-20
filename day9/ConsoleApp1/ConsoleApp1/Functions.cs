using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
        public static List<int> PlayGame(int players, int points)
        {
            var scores = new List<int>();

            //initialise the players
            for (int i = 0; i < players; i++)
            {
                scores.Add(0);
            }

            //now play the game
            var marble = new Marble { Value = 0 };
            marble.Previous = marble;
            marble.Next = marble;

            for (int i = 1; i <= points; i++)
            {
                //players are 0 based in my list. So current player = i-1 mod total_players
                var playerIndex = (i - 1) % players;
                var score = Functions.PlayRound(i, ref marble);
                scores[playerIndex] += score;
            }

            return scores;
        }

        public static int PlayRound(int newMarbleValue, ref Marble currentMarble)
        {
            var value = 0;

            if (newMarbleValue % 23 == 0)
            {
                //the current player keeps the marble they would have placed, adding it to their score.
                value += newMarbleValue;

                 //In addition, the marble 7 marbles counter-clockwise from the current marble is removed from the circle and also added to the current player's score.
                var marbleToRemove = currentMarble.Previous.Previous.Previous.Previous.Previous.Previous.Previous;
                value += marbleToRemove.Value;

                marbleToRemove.Previous.Next = marbleToRemove.Next;
                marbleToRemove.Next.Previous = marbleToRemove.Previous;

                //The marble located immediately clockwise of the marble that was removed becomes the new current marble.
                currentMarble = marbleToRemove.Next;
                
            }
            else
            {
                //add new marble between 1 and 2 marbles clockwise
                var newMarble = new Marble
                {
                    Value = newMarbleValue,
                    Previous = currentMarble.Next,
                    Next = currentMarble.Next.Next
                };
               
                newMarble.Previous.Next = newMarble;
                newMarble.Next.Previous = newMarble;

                // current marble is set to new marble
                currentMarble = newMarble;
            }

            return value;
        }

    }
}
