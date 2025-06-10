using UnityEngine;
namespace DefaultNamespace
{
    public class PotionSlot : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject potion;
        [SerializeField] GameObject confirmationReceipt;
        public bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;

        public void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();

        }

        void Spawn()
        {
            potion.transform.position = transform.position + Vector3.up + new Vector3(0,0,-1f);
            Rigidbody rb = potion.GetComponent<Rigidbody>();
        }

        public void Interact()
        {
            Spawn();
            if (!hasInteracted)
            {
                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == confirmationReceipt)
                {
                    Spawn();
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing confirmation receipt.";
                }
            }
            else
            {
                objectInteractMessage = "Already Unlocked.";
            }
        }
    }
}