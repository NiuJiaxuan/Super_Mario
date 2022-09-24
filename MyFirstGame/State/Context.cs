using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0.State
{
     class MarioPowerState
    {
        public static State smallMario;
        public static State superMario;
        public static State fireMario;
        public static State deadMario;
        public static State StarMario;

        private State currentState;


        public MarioPowerState()
        {
            this.currentState = new State();
        }


    }
}
