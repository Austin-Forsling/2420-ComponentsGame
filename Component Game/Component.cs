namespace Component_Game {
    class Component {
        public Entity Container { get; set; }
        public bool Remove { get; set; }

        public Component() { 
            Remove = false;
        }

        public virtual void Adding() { }
        public virtual void Update() { }
    }
}
