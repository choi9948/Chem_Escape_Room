using UnityEngine;
namespace DefaultNamespace
{
    public class Beaker4 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;
        [SerializeField] GameObject emptyBeaker;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject beaker;

        private void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }

        public void emptyBeakerChangeColour()
        {
            Renderer beakerRenderer = beaker?.GetComponent<Renderer>();
            Renderer emptyBeakerRenderer = emptyBeaker?.GetComponent<Renderer>();
            if (beakerRenderer != null && emptyBeakerRenderer != null)
            {
                Color beakerColor = beakerRenderer.material.color;
                emptyBeakerRenderer.material.color = beakerColor;
            }
        }

        public void Interact()
        {
            if (!hasInteracted)
            {

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == emptyBeaker)//if holding object
                {
                    emptyBeakerChangeColour();
                    objectInteractMessage = "Propanoic Acid Collected.";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing Empty Beaker";
                }
            }
            else
            {
                objectInteractMessage = "Already Collected.";
            }
        }

    }
}
