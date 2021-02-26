using System;
using System.Collections.Generic;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public string RandomString()
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, this.Count - 1);
            string stringToRemove = this[randomIndex];
            this.RemoveAt(randomIndex);
            return stringToRemove;
        }
    }
}
