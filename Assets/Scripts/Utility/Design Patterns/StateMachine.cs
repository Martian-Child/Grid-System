using UnityEngine;

namespace MartianChild.Utility.Design_Patterns
{
    /// <summary>
    /// State Machine implementation.
    /// Uses State as base class for storing currently operating state.
    /// </summary>
    public class StateMachine : MonoBehaviour
    {
        // Reference to currently operating state.
        private State currentState;

        /// <summary>
        /// Unity method called each frame
        /// </summary>
        private void Update()
        {
            // If we have reference to state, we should update it!
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
            // If we currently have state, we need to destroy it!
            if (currentState != null)
            {
                currentState.DestroyState();
            }

            // Swap reference
            currentState = newState;
            // If we passed reference to new state, we should assign owner of that state and initialize it!
            // If we decided to pass null as new state, nothing will happened.
            if (currentState != null)
            {
                currentState.owner = this;
                currentState.PrepareState();
            }
        }
    }
}