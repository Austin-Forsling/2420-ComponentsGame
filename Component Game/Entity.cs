using System.Collections.Generic;

namespace Component_Game {
    class Entity {
        public int X { get; set; }
        public int Y { get; set; }
        public int speed = 1;
        List<Component> components = new List<Component>();

        public void AddComponent( Component component ) {
            component.Container = this;
            components.Add( component );
        }
        public void RemoveComponent( Component component ) {
            components.Remove( component );
        }
        public void Update() {
            foreach ( Component component in components ) {
                component.Update();
            }
        }
    }
}
