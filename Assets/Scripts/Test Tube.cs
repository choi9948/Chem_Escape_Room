using UnityEngine;

namespace DefaultNamespace
{
    public class TestTube : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] private string objectInteractMessage;
        private PlayerPickUpDrop playerPickUpDrop;
        [SerializeField] GameObject dropper;
        [SerializeField] GameObject dropperTip;
        [SerializeField] GameObject tube;
        private void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }

        public void DropperChangeColour()
        {
            Renderer tubeRenderer = tube?.GetComponent<Renderer>();
            Renderer dropperTipRenderer = dropperTip?.GetComponent<Renderer>();
            if (tubeRenderer != null && dropperTipRenderer != null)
            {
                Color tubeColor = tubeRenderer.material.color;
                dropperTipRenderer.material.color = tubeColor;
            }
        }

        public void Interact()
        {

            if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == dropper)//if holding object
            {
                DropperChangeColour();
                objectInteractMessage = "Catalyst Collected.";
            }
            else
            {
                objectInteractMessage = "Missing Dropper";
            }
        }

    }
}