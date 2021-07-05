using UnityEngine;

namespace MartianChild.Utility.Design_Patterns
{
    /// <summary>
    /// State Machine implementation.
    /// Uses State as base class for storing currently operating state.
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        private State currentState;

        /// <summary>
        /// Unity method called each frame
        /// </summary>
        private void Update()
        {
            if (currentState != null)
            {
                currentState.UpdateState();
            }
        }

        /// <summary>
        /// Method used to change state
        /// </summary>
        /// <param name="newState">New state.</param>
        public void ChangeState(State newState)
        {
            if (currentState != null)
            {
                currentState.DestroyState();
            }
            
            currentState = newState;
            
            if (currentState != null)
            {
                currentState.owner = this;
                currentState.PrepareState();
            }
        }
    }
}