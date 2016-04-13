using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pairs_Trading.Classes
{
    class UISync
    {
        private static ISynchronizeInvoke _sync;

        public static void Init(ISynchronizeInvoke sync)
        {
            _sync = sync;
        }

        public static void Execute(System.Action action)
        {
            try
            {
                _sync.Invoke(action, null);
                //_sync.BeginInvoke(action, null);
            }
            catch
            {
            }
        }
    }
}
