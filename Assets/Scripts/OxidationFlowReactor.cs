using UnityEngine;

namespace DefaultNamespace
{
    public class OxidationFlowReactor : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        [SerializeField] string objectInteractMessage;
        [SerializeField] private Material orange;
        [SerializeField] private Beaker beaker;

      
        
        public void Interact()
        {
            if (!hasInteracted)
            {

                if (beaker != null && beaker.HasBeenFilled)
                {
                    beaker.ChangeColour(orange);
                    objectInteractMessage = "Controlled Oxidation Sucessful.";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Beaker is not Filled.";
                }
            }
            else
            {
                objectInteractMessage = "Oxidation already Complete.";
            }
        }
    }
}
