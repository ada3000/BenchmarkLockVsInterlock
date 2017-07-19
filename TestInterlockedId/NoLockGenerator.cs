using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterlockedId
{
    public class NoLockGenerator : IGenBase
    {
        private int key = 0;
        
        public int NewId
        {
            get
            {
                key = key - 1;

                return key;
            }
        }
    }
}
