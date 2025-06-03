using UnityEngine;

namespace DefaultNamespace
{
    public class Beaker : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        public bool HasBeenFilled => hasInteracted;
        private bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;

        [SerializeField] GameObject propanol;
        [SerializeField] string objectInteractMessage;
        [SerializeField] private Material blue;

        private void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }
        
        public void ChangeColour(Material colour)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null && colour != null)
            {
                renderer.material = colour;
            }
        }


        public void Interact()
        {
            if (!hasInteracted)
            {

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == propanol)//if holding object
                {
                    ChangeColour(blue);
                    propanol.SetActive(false);
                    objectInteractMessage = "Propanol Successfully Added.";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing Propanol";
                }
            }
            else
            {
                objectInteractMessage = "Already Filled.";
            }
        }
    }
}
