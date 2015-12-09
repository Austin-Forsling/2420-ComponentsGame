using Component_Game.Components;
using System;

namespace Component_Game {
    class MonsterChaseGame {
        Entity player = new Entity();

        public void Initialize() {
            player.AddComponent( new KeyboardMoverComponent() );
            player.AddComponent( new KeepInBoundsComponent() );
            player.AddComponent( new SpeedPowerUpComponent() );
        }
        public void start() {
            while ( true ) {
                player.Update();
                Console.WriteLine(player.X + ", " + player.Y);
            }
        }
    }
}
