using Component_Game.Components;
using System;
using System.Collections.Generic;

namespace Component_Game {
    class MonsterChaseGame {
        List<Entity> entityList = new List<Entity>();
        Entity player = new Entity();

        public void Initialize() {
            entityList.Add( player );
            player.AddComponent( new KeyboardMoverComponent() );
            player.AddComponent( new KeepInBoundsComponent() );
            player.AddComponent( new SpeedPowerUpComponent() );
        }

        public void DrawBoard() {
            for ( int y = 0; y < 23; y++ ) {
                List<char> charArray = new List<char>();
                for ( int x = 0; x < 23; x++ ) {
                    if ( player.X == ( x - 11 ) & player.Y == ( -y + 11 ) ) {
                        charArray.Add( 'X' );
                    }
                    else {
                        charArray.Add( '-' );
                    }
                }
                foreach ( char character in charArray ) {
                    Console.Write(character);
                }
                Console.WriteLine();
            }
        
        }

        public void start() {
            while ( true ) {
                player.Update();
                DrawBoard();
            }
        }
    }
}
