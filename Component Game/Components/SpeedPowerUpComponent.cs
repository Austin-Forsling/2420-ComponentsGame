
namespace Component_Game.Components {
    //Increases player speed to 2 for 3 turns.
    class SpeedPowerUpComponent : Component {
        int turnsActive = 0;
        KeyboardMoverComponent mover;


        public override void Adding() {
            mover = Container.GetComponent<KeyboardMoverComponent>();
            mover.Speed = 2;
        }


        public override void Update() {
            if (++turnsActive == 3) {
                if (mover != null) {
                    mover.Speed = 1;
                }
                this.Remove = true;
            }
        }
    }
}
