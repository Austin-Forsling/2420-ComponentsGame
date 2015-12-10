
namespace Component_Game.Components {
    class KeepInBoundsComponent : Component {

        public override void Update() {
            if ( Container.X > 11 ) {
                Container.X = -11;
            }
            if ( Container.X < -11 ) {
                Container.X = 11;
            }
            if ( Container.Y > 11 ) {
                Container.Y = -11;
            }
            if ( Container.Y < -11 ) {
                Container.Y = 11;
            }
        }
    }
}
