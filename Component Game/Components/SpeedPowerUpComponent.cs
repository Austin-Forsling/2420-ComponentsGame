
namespace Component_Game.Components {
    class SpeedPowerUpComponent : Component {
        int turnsActive = 3;
        public override void Update() {
            Container.speed = 2;
            turnsActive--;
            if ( turnsActive <= 0 ) {
                Container.RemoveComponent( this );
            }
        }
    }
}
