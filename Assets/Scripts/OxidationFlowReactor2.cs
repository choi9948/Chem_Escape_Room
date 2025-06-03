using UnityEngine;
using TMPro;
namespace DefaultNamespace
{

    public class OxidationFlowReactor2 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;

        [SerializeField] string objectInteractMessage;
        [SerializeField] private Material red;
        [SerializeField] private Beaker3 beaker3;
        [SerializeField] private TextMeshPro labelText; 

        public void Interact()
        {
            if (!hasInteracted)
            {

                if (beaker3 != null && beaker3.HasBeenCatalyzed)
                {
                    beaker3.ChangeColour(red);
                    objectInteractMessage = "Controlled Oxidation Sucessful.";
                    hasInteracted = true;
                    labelText.text = "Propanoic Acid";
                }
                else
                {
                    objectInteractMessage = "Beaker is not Catalyzed.";
                }
            }
            else
            {
                objectInteractMessage = "Oxidation already Complete.";
            }
        }
    }
}
