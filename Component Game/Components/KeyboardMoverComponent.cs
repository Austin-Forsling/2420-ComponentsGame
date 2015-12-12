using System;

namespace Component_Game.Components {
    //Lets the player move using the keyboard.
    class KeyboardMoverComponent : Component {
        public int Speed { get; set; }

        public KeyboardMoverComponent() {
            Speed = 1;
        }

        //Takes the first given key to choose a direction. WILL BLOW UP IF THERE IS NO LINE TO READ!!!
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
