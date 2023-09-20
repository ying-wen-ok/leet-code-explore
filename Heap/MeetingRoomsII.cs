using System;
using System.Collections.Generic;

namespace Heap
{
    public class MeetingRoomsII
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            PriorityQueue<int[], int> sortByStartTime = new PriorityQueue<int[], int>();
            foreach (int[] i in intervals) sortByStartTime.Enqueue(i, i[0]);         

            PriorityQueue<int, int> roomReleaseTime = new PriorityQueue<int, int>();
            int count = 0;

            while(sortByStartTime.Count > 0)
            {
                int[] i = sortByStartTime.Dequeue();
                int startTime = i[0];
                int endTime = i[1];

                if (roomReleaseTime.Count == 0 || roomReleaseTime.Peek() > startTime) 
                { 
                    count++; 
                    roomReleaseTime.Enqueue(endTime, endTime); 
                }
                else
                {
                    roomReleaseTime.Enqueue(endTime, endTime);
                    roomReleaseTime.Dequeue();
                }
            }
            return count;
        }
    }
}
