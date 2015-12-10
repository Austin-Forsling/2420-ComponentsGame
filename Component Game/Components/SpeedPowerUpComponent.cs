
namespace Component_Game.Components {
    class SpeedPowerUpComponent : Component {
        int turnsActive = 0;
        KeyboardMoverComponent mover;

        public override void Adding() {
            mover = Container.GetComponent<KeyboardMoverComponent>();
            if (mover != null){
                mover.Speed = 2;
            }
        }

        public override void Update() {
            if ( ++turnsActive == 3 ) {
                mover.Speed = 1;
                this.Remove = true;
            }
        }
    }
}
