using System.Collections.Generic;
using Component_Game.Components;

namespace Component_Game {
    class Entity {
        public MonsterChaseGame Container { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public char Sprite { get; set; }
        public int priority { get; set; }
        List<Component> components = new List<Component>();
        List<Component> removeComponentsList = new List<Component>();
        
        //Adds components to the list so that they can be updated with the others.
        public void AddComponent( Component component ) {
            component.Container = this;
            components.Add( component );
            component.Adding();
        }

        //Goes through the components tied to this Entity and allows them to run their own updates.
        public void Update() {
            foreach ( Component component in components ) {
                component.Update();
                if ( component.Remove == true ) {
                    removeComponentsList.Add( component );
                }
            }
            foreach ( Component component in removeComponentsList ) {
                components.Remove(component);
            }
            removeComponentsList.Clear();
        }

        //Returns a component of a given type. Used for some power ups.
        public T GetComponent<T>() where T : Component {
            foreach(Component component in components){
                T componentAsT = component as T;
                if ( componentAsT != null ) {
                    return componentAsT;
                }
            }
            return null;
        }

        //If this Entity is killed, based on it's priority it will give a powerup to the player or end the game.
        public void isKilled(Entity killer) {
            if (priority == 0) {
                killer.AddComponent(new SpeedPowerUpComponent());
            }
            if(priority == 5) {
                Container.EndGameLose();
            }
        }
        
    }
}
