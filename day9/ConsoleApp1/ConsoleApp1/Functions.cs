using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Functions
    {
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
