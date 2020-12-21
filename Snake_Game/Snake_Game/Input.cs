using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Windows.Forms;

namespace Snake_Game
{
    class Input
    {
        private static Hashtable Key_Table = new Hashtable();

        public static bool Key_Press(Keys key)
        {
            if (Key_Table[key] == null)
            {
                return false;
            }

            return (bool)Key_Table[key];
        }

        public static void Change_State(Keys key, bool state)
        {
            Key_Table[key] = state;
        }

    }
}
