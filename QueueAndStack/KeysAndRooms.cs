using System;
using System.Collections.Generic;

namespace QueueAndStack
{
    public class KeysAndRooms
    {
        public bool CanVisitAllRooms(IList<IList<int>> _rooms)
        {
            rooms = _rooms;
            int n = rooms.Count;
            unlocked = new bool[n];
            
            keys = new Queue<int>();
            keys.Enqueue(0);
            while(keys.Count > 0) visitRoom();
          
            for (int i = 0; i < n; i++)
                if (!unlocked[i]) return false;

            return true;
        }

        IList<IList<int>> rooms;
        bool[] unlocked;
        Queue<int> keys;
        private void visitRoom()
        {
            if (keys.Count == 0) return;
            int key = keys.Dequeue();
            if (unlocked[key]) return;
            unlocked[key] = true;
            foreach (int i in rooms[key])
                if (!unlocked[i]) keys.Enqueue(i);

            visitRoom();
        }
    }
}
