using System;

namespace Component_Game.Components {
    class KeyboardMoverComponent : Component {
        public int Speed { get; set; }

        public KeyboardMoverComponent() {
            Speed = 1;
        }

        public override void Update(){
            char key = Console.ReadLine()[0];
            if ( key == 'w' ) {
                Container.Y += Speed;
            }
            if ( key == 's' ) {
                Container.Y -= Speed;
            }
            if ( key == 'a' ) {
                Container.X -= Speed;
            }
            if ( key == 'd' ) {
                Container.X += Speed;
            }
        }
    }
}
