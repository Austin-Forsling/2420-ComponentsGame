using System.Collections.Generic;
using System.Windows;

namespace Component_Game {
    class Entity {
        public int X { get; set; }
        public int Y { get; set; }
        List<Component> components = new List<Component>();
        List<Component> removeComponentsList = new List<Component>();
        

        public void AddComponent( Component component ) {
            component.Container = this;
            components.Add( component );
            component.Adding();
        }

        public void Update() {
            foreach ( Component component in components ) {
                component.Update();
                if ( component.Remove == true ) {
                    removeComponentsList.Add( component );
                }
            }
            foreach ( Component component in removeComponentsList ) {
                RemoveComponent(component);
            }
            removeComponentsList.Clear();
        }

        public T GetComponent<T>() where T : Component {
            foreach(Component component in components){
                T componentAsT = component as T;
                if ( componentAsT != null ) {
                    return componentAsT;
                }
            }
            return null;
        }

        public void RemoveComponent( Component component ) {
            components.Remove( component );
        }
    }
}
