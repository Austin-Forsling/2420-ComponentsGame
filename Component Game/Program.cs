namespace Component_Game {
    class Program {
        static void Main() {
            MonsterChaseGame game = new MonsterChaseGame();
            game.Initialize();
            game.start();
        }
    }
}