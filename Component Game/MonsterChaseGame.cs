using Component_Game.Components;
using System;
using System.Collections.Generic;

namespace Component_Game {
    class MonsterChaseGame {
        public List<Entity> entityList = new List<Entity>();
        public List<Entity> killList = new List<Entity>();
        public Entity speedUp = new Entity();
        public Entity player = new Entity();
        public Entity monster1 = new Entity();
        public Entity monster2 = new Entity();
        public Entity monster3 = new Entity();
        public Entity monster4 = new Entity();
        bool emptySpace = true;
        int turnspassed = 0;
        Random random = new Random();

        //Sets up the initial powerup positions as well as player and monster.
        public void Initialize() {
            entityList.Add(player);
            player.Sprite = 'X';
            player.priority = 5;
            player.AddComponent(new KeyboardMoverComponent());
            player.AddComponent(new KeepInBoundsComponent());
            player.AddComponent(new KillOnContactComponent());

            entityList.Add(speedUp);
            speedUp.Sprite = 'S';
            speedUp.priority = 0;
            speedUp.X = random.Next(-11, 11);
            speedUp.Y = random.Next(-8, 8);

            entityList.Add(monster1);
            monster1.Sprite = 'M';
            monster1.priority = 6;
            monster1.X = -7;
            monster1.Y = 4;
            monster1.AddComponent(new AIMoverComponent());
            monster1.AddComponent(new KillOnContactComponent());

            entityList.Add(monster2);
            monster2.Sprite = 'M';
            monster2.priority = 6;
            monster2.X = 7;
            monster2.Y = 4;
            monster2.AddComponent(new AIMoverComponent());
            monster2.AddComponent(new KillOnContactComponent());

            entityList.Add(monster3);
            monster3.Sprite = 'M';
            monster3.priority = 6;
            monster3.X = -7;
            monster3.Y = -4;
            monster3.AddComponent(new AIMoverComponent());
            monster3.AddComponent(new KillOnContactComponent());

            entityList.Add(monster4);
            monster4.Sprite = 'M';
            monster4.priority = 6;
            monster4.X = 7;
            monster4.Y = -4;
            monster4.AddComponent(new AIMoverComponent());
            monster4.AddComponent(new KillOnContactComponent());

            foreach (Entity entity in entityList) {
                entity.Container = this;
            }

        }

        //Clears the screen and prints out a new state during every Update().
        public void DrawBoard() {
            Console.Clear();
            for (int y = 0; y < 18; y++) {
                List<char> charArray = new List<char>();
                for (int x = 0; x < 24; x++) {
                    foreach (Entity entity in entityList) {
                        if (entity.X == (x - 11) & entity.Y == (-y + 8)) {
                            if (emptySpace == true) {
                                charArray.Add(entity.Sprite);
                                emptySpace = false;
                            }
                        }
                    }
                    if (x == 23 & y == 17) {
                        charArray.Add('+');
                    } else if (x == 23) {
                        charArray.Add('|');
                    } else if (y == 17) {
                        charArray.Add('-');
                    } else if (emptySpace & x != 23) {
                        charArray.Add(' ');
                    }
                    emptySpace = true;
                }
                foreach (char character in charArray) {
                    Console.Write(character);
                }
                Console.WriteLine();
            }

        }

        //Deletes the board and displays the lose message if the player touches a monster.
        public void EndGameLose() {
            Console.Clear();
            Console.WriteLine("You lose, sorry!");
            Environment.Exit(0);
        }

        //Delets the board the displays the win message if the player survives long enough.
        public void EndGameWin() {
            Console.Clear();
            Console.WriteLine("You've sucessfully survived the monster attack!");
            Environment.Exit(0);
        }

        //Officially kills everything detected by the KillOnContactComponent. (Had to put it here because the component couldn't mess with other components during the Update() run.)
        public void Kill(Entity ent1, Entity ent2) {
            if (ent1.priority < ent2.priority) {
                entityList.Remove(ent1);
                ent1.isKilled(ent2);
            } else {
                entityList.Remove(ent2);
                ent2.isKilled(ent1);
            }
        }

        //Displays the opening messages and allows the player to start the game. Then prints out the board with all the sprites. Updates every frame.
        public void start() {
            Console.WriteLine("Monster Chase");
            Console.WriteLine();
            Console.WriteLine("This is you -> X");
            Console.WriteLine();
            Console.WriteLine("Run away from the monsters -> M");
            Console.WriteLine();
            Console.WriteLine("Pick up powerups -> S");
            Console.WriteLine();
            Console.WriteLine("Move by pressing w, a, s, or d and hitting enter.");
            Console.WriteLine();
            Console.WriteLine("Press any key to start!");
            Console.ReadKey();
            while (true) {
                DrawBoard();
                foreach (Entity entity in entityList) {
                    entity.Update();
                }
                foreach(Entity entity in killList) {
                    Kill(entity, player);
                }
                killList.Clear();
                turnspassed++;
                if (turnspassed == 99) {
                    EndGameWin();
                }
            }
        }
    }
}
