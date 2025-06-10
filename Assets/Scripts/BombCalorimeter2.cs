using UnityEngine;
namespace DefaultNamespace
{
    public class BombCalorimeter2 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject tnt;
        private PlayerPickUpDrop playerPickUpDrop;
        private bool hasInteracted = false;

        public void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == tnt)
                {
                    tnt.SetActive(false);
                    objectInteractMessage = "Initiating combustion reaction";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing Trinitrotoluene.";
                }
            }
            else
            {
                objectInteractMessage = "Results: mass = 5.00g, initial temp = 25 degrees celcius, final temp = 40 degrees celcius";
            }
        }
    }
}