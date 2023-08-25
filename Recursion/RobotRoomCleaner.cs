using System;
using System.Collections.Generic;

namespace Recursion
{
    public interface Robot
    {
        // Returns true if the cell in front is open and robot moves into the cell.
        // Returns false if the cell in front is blocked and robot stays in the current cell.
        public bool Move();

        // Robot will stay in the same cell after calling turnLeft/turnRight.
        // Each turn will be 90 degrees.
        public void TurnLeft();
        public void TurnRight();

        // Clean the current cell.
        public void Clean();
    }

    public class RobotRoomCleaner
    {
        /// <summary>
        ///   记录去过的坐标位置 避免走回头路是必须的， 
        ///   虽然 这个题目没有给 Room 的input， 
        ///   那么我们可以假设 起点是（0,0）， 记录下所有去过的点的坐标
        /// </summary>
        public void CleanRoom(Robot robot)
        {
            r = robot;
            cleanSpot = new HashSet<(int, int)>();
            Visit(0, 0, 0);
        }

        Robot r;
        HashSet<(int, int)> cleanSpot;
        (int i, int j)[] directions = new (int i, int j)[]
        {
            (-1,0),
            (0,1),
            (1,0),
            (0,-1)
        };

        // 走每一步的时候 都跟当前的 坐标和方向有关系， 所以 需要 有这三个输入
        private void Visit(int i, int j, int d)
        {
            cleanSpot.Add((i, j));
            r.Clean();

            for (int x = 0; x < 4; x++)
            {
                int nextd = (d + x) % 4;
                int nexti = i + directions[nextd].i;
                int nextj = j + directions[nextd].j;

                if (!cleanSpot.Contains((nexti, nextj)) && r.Move())
                {
                    Visit(nexti, nextj, nextd);
                    GoBack();
                }
                r.TurnRight();
            }
        }

        private void GoBack()
        {
            r.TurnRight();
            r.TurnRight();
            r.Move();
            r.TurnRight();
            r.TurnRight();
        }
    }
}
