using Component_Game.Components;
using System;
using System.Collections.Generic;

namespace Component_Game {
    class MonsterChaseGame {
        List<Entity> entityList = new List<Entity>();
        Entity player = new Entity();
        bool emptySpace = true;
        int turnspassed = 0;

        public void Initialize() {
            entityList.Add( player );
            player.Sprite = 'X';
            player.AddComponent( new KeyboardMoverComponent() );
            player.AddComponent( new KeepInBoundsComponent() );
            //player.AddComponent( new SpeedPowerUpComponent() );
        }

        public void DrawBoard() {
            Console.Clear();
            for ( int y = 0; y < 18; y++ ) {
                List<char> charArray = new List<char>();
                for ( int x = 0; x < 24; x++ ) {
                    foreach(Entity entity in entityList){
                        if ( entity.X == ( x - 11 ) & entity.Y == ( -y + 8 ) ) {
                            charArray.Add( entity.Sprite );
                            emptySpace = false;
                        }
                    }
                    if(x == 23 & y == 17){
                        charArray.Add('+');
                    }
                    else if (x == 23) {
                        charArray.Add('|');
                    }
                    else if (y == 17) {
                        charArray.Add('-');
                    }
                    else if (emptySpace & x != 23) {
                        charArray.Add(' ');
                    }                    
                    emptySpace = true;
                }
                foreach ( char character in charArray ) {
                    Console.Write(character);
                }
                Console.WriteLine();
            }
        
        }

        public void start() {
            while ( true ) {
                DrawBoard();
                foreach (Entity entity in entityList) {
                    entity.Update();
                }
                turnspassed++;
                if (turnspassed == 100) { 
                    
                }
            }
        }
    }
}
