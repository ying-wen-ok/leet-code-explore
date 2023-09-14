using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class WallsAndGatesShortedPath
    {
        public void WallsAndGates(int[][] rooms)
        {          
            int gate = 0;       
            int m = rooms.Length;
            int n = rooms[0].Length;

            Queue<(int i, int j)> reachedRooms = new Queue<(int i, int j)>();
            for(int i = 0; i < m; i++)
                for(int j = 0; j < n; j++)
                {
                    if (rooms[i][j] == gate) reachedRooms.Enqueue((i,j));
                }

            (int i, int j)[] directions = new (int i, int j)[4]
            {
                (1,0),
                (0,1),
                (-1,0),
                (0,-1),
            };

            while(reachedRooms.Count > 0)
            {
                (int i, int j) = reachedRooms.Dequeue();
                foreach(var direction in directions)
                {
                    int nextI = i + direction.i;
                    int nextJ = j + direction.j;

                    if(nextI >= 0 && nextJ >= 0 && nextI < m && nextJ < n)
                    {
                        int nextPossibleShortestDistanceToGate = rooms[i][j] + 1;
                        if (rooms[nextI][nextJ] > nextPossibleShortestDistanceToGate)
                        {
                            rooms[nextI][nextJ] = nextPossibleShortestDistanceToGate;
                            reachedRooms.Enqueue((nextI, nextJ));
                        }
                    }
                }
            }
        }
    }
}
