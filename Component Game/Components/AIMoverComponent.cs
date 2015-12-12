using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Component_Game.Components {
    //Allows monsters to move.
    class AIMoverComponent : Component {
        public override void Update() {
            int speed = 1;
            int targetX = Container.Container.player.X;
            int targetY = Container.Container.player.Y;
            int currentX = Container.X;
            int currentY = Container.Y;
            int runningX = currentX;
            int runningY = currentY;
            string direction;

            if (Math.Abs(runningX - targetX) > Math.Abs(runningY - targetY)) {
                if (runningX < targetX) {
                    direction = "X+1";
                    runningX++;
                } else {
                    direction = "X-1";
                    runningX--;
                }
            } else {
                if (runningY < targetY) {
                    direction = "Y+1";
                    runningY++;
                } else {
                    direction = "Y-1";
                    runningY--;
                }
            }
            if(direction == "X+1") {
                Container.X += speed;
            } else if(direction == "X-1") {
                Container.X -= speed;
            } else if(direction == "Y+1") {
                Container.Y += speed;
            }else {
                Container.Y -= speed;
            }
        }
    }
}
