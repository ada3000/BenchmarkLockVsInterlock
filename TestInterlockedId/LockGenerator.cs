using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestInterlockedId
{
    public class LockGenerator : IGenBase
    {
        private int key = 0;
        
        /// <summary>
        /// Свойство для получения очередного ключа объкта
        /// </summary>
        public int NewId
        {
            get
            {
                lock (this)
                {
                    key = key - 1;
                }

                return key;
            }
        }
    }
}
