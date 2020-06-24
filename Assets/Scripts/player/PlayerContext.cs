using UnityEngine;

namespace FlightAce.player
{
    public class PlayerContext : MonoBehaviour, IActorContext
    {
        
        public IInput Input { get; private set; }
        private void Awake()
        {
            Input = new PlayerInput();
        }
    }
}
