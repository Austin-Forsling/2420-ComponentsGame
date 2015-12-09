using System;

namespace Component_Game.Components {
    class KeyboardMoverComponent : Component {
        public override void Update(){
            Console.WriteLine("WASD!!!!");
            char key = Console.ReadLine()[0];
            if ( key == 'w' ) {
                Container.Y += Container.speed;
            }
            if ( key == 's' ) {
                Container.Y -= Container.speed;
            }
            if ( key == 'a' ) {
                Container.X -= Container.speed;
            }
            if(key=='d'){
                Container.X += Container.speed;
            }
        }
    }
}
