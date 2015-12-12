using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Component_Game.Components {
    //Causes components to remove themselves when they touch something of higher priority than them.
    class KillOnContactComponent : Component {
        //All the entities that need to be killed, so they can be killed after Update() finishes.
        List<Entity> killList = new List<Entity>();

        public override void Update() {
            foreach(Entity entity in Container.Container.entityList) {
                if (Container.X == entity.X & Container.Y == entity.Y) {
                    if(entity != Container) {
                        if (entity.priority < Container.priority) {                            
                            Container.Container.killList.Add(entity);
                        } else if(entity.priority > Container.priority) {                           
                            Container.Container.killList.Add(Container);
                        } else {
                            ;
                        }
                    }
                }
            }
        }
    }
}
