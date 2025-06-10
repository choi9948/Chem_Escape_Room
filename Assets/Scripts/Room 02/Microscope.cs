using UnityEngine;
namespace DefaultNamespace
{
    public class Microscope : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        [SerializeField] string objectInteractMessage;
        [SerializeField] private Flashlight flashlight;

        public void Interact()
        {
            if (!hasInteracted)
            {
                if ( flashlight.HasBeenShined)
                {
                    hasInteracted = true;
                    objectInteractMessage = "Electron jumped from energy level 3 to energy level 5";
                }
                else
                {
                    objectInteractMessage = "Shine light to begin test";
                }
               
            }
            else
            {
                objectInteractMessage = "Electron jumped from energy level 3 to energy level 5";
            }
        }
    }
}
