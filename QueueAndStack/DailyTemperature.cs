using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class DailyTemperature
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int n = temperatures.Length;
            int[] answer = new int[n];

            Stack<int> preDays = new Stack<int>();
            preDays.Push(0);

            for(int curDay = 1; curDay < n; curDay++)
            {
                int curDayTemperatures = temperatures[curDay];
                while(preDays.Count > 0)
                {
                    int preDay = preDays.Peek();
                    if (temperatures[preDay] < curDayTemperatures)
                    {
                        preDays.Pop();
                        answer[preDay] = curDay - preDay;
                    }
                    else
                    {
                        break;
                    }
                }
                preDays.Push(curDay);
            }
            return answer;
        }
    }
}
