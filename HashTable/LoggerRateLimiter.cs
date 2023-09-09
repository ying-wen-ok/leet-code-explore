using System;
using System.Collections.Generic;

namespace HashTable
{
    /// <summary>
    /// Each unique message should only be printed at most every 10 seconds 
    /// (i.e. a message printed at timestamp t will prevent other identical messages from being printed 
    /// until timestamp t + 10).
    /// </summary>
    public class Logger
    {
        private Dictionary<string, int> printedData;
        private int printeGap;
        public Logger()
        {
            printedData = new Dictionary<string, int>();
            printeGap = 10;
        }

        public bool ShouldPrintMessage(int timestamp, string message)
        {
            if(printedData.ContainsKey(message))
            {
                int prePrintedTimestamp = printedData[message];
                if(timestamp - prePrintedTimestamp >= printeGap)
                {
                    printedData[message] = timestamp;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                printedData.Add(message, timestamp);
                return true;
            }
        }
    }
}