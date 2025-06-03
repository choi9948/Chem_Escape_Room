using UnityEngine;
namespace DefaultNamespace
{
    public class Beaker3 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;
        public bool HasBeenCatalyzed => hasInteracted;

        [SerializeField] GameObject dropper;
        [SerializeField] GameObject dropperTip;
        [SerializeField] string objectInteractMessage;

        private void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }

        public void Interact()
        {
            if (!hasInteracted)
            {

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == dropper)//if holding object
                {
                    Renderer dropperTipRenderer = dropperTip?.GetComponent<Renderer>();
                    Color expectedPurple = new Color(156f / 255f, 32f / 255f, 240f / 255f); // #9C20F0

                    if (dropperTipRenderer != null && ColorsAreClose(dropperTipRenderer.material.color, expectedPurple))
                    {
                        objectInteractMessage = "Successfuly Catalyzed";
                        hasInteracted = true;
                    }
                    else
                    {
                        objectInteractMessage = "Incorrect Catalyst";
                    }
                }
                else
                {
                    objectInteractMessage = "Missing Dropper";
                }
            }
            else
            {
                objectInteractMessage = "Already Catalyzed.";
            }
        }

        private bool ColorsAreClose(Color a, Color b, float tolerance = 0.01f)
        {
            return Mathf.Abs(a.r - b.r) < tolerance &&
                   Mathf.Abs(a.g - b.g) < tolerance &&
                   Mathf.Abs(a.b - b.b) < tolerance;
        }
        
        public void ChangeColour(Material colour)
        {
            Renderer renderer = GetComponent<Renderer>();
            if (renderer != null && colour != null)
            {
                renderer.material = colour;
            }
        }
    }
}