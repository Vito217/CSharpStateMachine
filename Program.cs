using System;
using System.Collections.Generic;

namespace StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {

            //Primero, creas los estados que tendra tu maquina

            State hide = new HideState();
            State attack = new AttackState();
            State flee = new FleeState();
            State dance = new DanceState();

            // Luego, mapeamos cada estado y le damos etiquetas

            hide.setMap(new Dictionary<string, State> {
                {"notice_sempai", dance}
            });

            attack.setMap(new Dictionary<string, State> {
                {"afraid", flee}
            });

            flee.setMap(new Dictionary<string, State> {
                {"not_afraid", dance}
            });

            dance.setMap(new Dictionary<string, State>{
                {"not_afraid", attack},
                {"afraid", flee}
            });

            // Creamos nuestro state machine, dandole un estado inicial

            ObjectStateMachine sm = new ObjectStateMachine(hide);

            if (sm.getState() is HideState) {
                Console.WriteLine("Se escondio");
            }

            // Ahora le damos un input

            Dictionary<string, bool> input = new Dictionary<string, bool> {
                {"notice_sempai", true}
            };

            sm.updateState(input);

            if (sm.getState() is DanceState)
            {
                Console.WriteLine("Te noticeo");
            }
        }
    }
}
