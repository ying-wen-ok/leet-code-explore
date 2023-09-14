using System;
using System.Collections.Generic;
using System.Text;

namespace QueueAndStack
{
    public class OpenTheLock
    {
        public int OpenLock(string[] deadends, string target)
        {
            Dictionary<string, int> StatesDict = new Dictionary<string, int>();
            foreach (string deadend in deadends) StatesDict.TryAdd(deadend, -1);

            string initialState = "0000";
            if (StatesDict.ContainsKey(initialState)) return -1;
            StatesDict.Add(initialState, 0);

            Queue<string> Q = new Queue<string>();
            if (target == initialState) return 0;
            Q.Enqueue(initialState);
            int[] moveDirections = new int[] { 1, -1 };
            while (Q.Count > 0)
            {
                string state = Q.Dequeue();
                int minTurns = StatesDict[state];

                for (int i = 0; i < 4; i++)
                {
                    foreach (int direction in moveDirections)
                    {
                        string nextState = GetNextState(state, i, direction);
                        if (nextState == target) return minTurns + 1;
                        if (!StatesDict.ContainsKey(nextState))
                        {
                            StatesDict.Add(nextState, minTurns + 1);
                            Q.Enqueue((nextState));
                        }
                    }
                }
            }
            return -1;
        }

        private string GetNextState(string s, int position, int turnDistance)
        {
            int curNumber = s[position] - '0';
            int afterTurnNumber = (curNumber + turnDistance + 10) % 10;
            char afterTurnChar = (char)('0' + afterTurnNumber);

            StringBuilder nextState = new StringBuilder();
            for (int i = 0; i < 4; i++)
            {
                if (i == position) nextState.Append(afterTurnChar);
                else nextState.Append(s[i]);
            }
            return nextState.ToString();
        }

    }
}
