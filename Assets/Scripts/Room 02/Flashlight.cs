using UnityEngine;

namespace DefaultNamespace
{
    public class Flashlight : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject front;
        
        public bool HasBeenShined => hasInteracted;


        public void Interact()
        {
            if (!hasInteracted)
            {
                objectInteractMessage = "Turned on";
                hasInteracted = true;
                ChangeColor();
            }
            else
            {
                objectInteractMessage = "Already turned on";
            }
        }

        public void ChangeColor()
        {
            Color newColor;
            if (ColorUtility.TryParseHtmlString("#FFD836", out newColor))
            {
                Renderer frontRenderer = front.GetComponent<Renderer>();
                if (frontRenderer != null)
                {
                    frontRenderer.material.color = newColor;
                }
                else
                {
                    Debug.LogError("Renderer not found on 'front' object.");
                }
            }
            else
            {
                Debug.LogError("Failed to parse color.");
            }
        }

    }
}