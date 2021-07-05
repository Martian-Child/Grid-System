namespace MartianChild.Utility.Design_Patterns
{
    /// <summary>
    /// This is base state script implementation.
    /// StateMachine uses these virtual methods to call state when it needs to prepare itself for operating, updating or even being destroyed.
    /// </summary>
    public abstract class State
    {
        public StateMachine owner;
        
        /// <summary>
        /// Method called to prepare state to operate - same as Unity's Start()
        /// </summary>
        public virtual void PrepareState() { }
        
        /// <summary>
        /// Method called to update state on every frame - same as Unity's Update()
        /// </summary>
        public virtual void UpdateState() { }
        
        /// <summary>
        /// Method called to destroy state - same as Unity's OnDestroy() but here it might be important!
        /// </summary>
        public virtual void DestroyState() { }
    }
}