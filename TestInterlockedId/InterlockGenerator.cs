using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestInterlockedId
{
    public class InterlockGenerator : IGenBase
    {
        private int key = 0;
        
        /// <summary>
        /// Свойство для получения очередного ключа объкта
        /// </summary>
        public int NewId
        {
            get
            {
                Interlocked.Decrement(ref key);
                return key;
            }
        }
    }
}
