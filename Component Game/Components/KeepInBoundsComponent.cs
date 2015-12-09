
namespace Component_Game.Components {
    class KeepInBoundsComponent : Component {
        public override void Update() {
            if ( Container.X > 5 ) {
                Container.X = -5;
            }
            if ( Container.X < -5 ) {
                Container.X = 5;
            }
            if ( Container.Y > 5 ) {
                Container.Y = -5;
            }
            if ( Container.Y < -5 ) {
                Container.Y = 5;
            }
        }
    }
}
