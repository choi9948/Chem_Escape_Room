using UnityEngine;

namespace DefaultNamespace
{
    public class BombCalorimeter : MonoBehaviour,IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;

        [Header("Objects")]
        [SerializeField] GameObject thermometer1;
        [SerializeField] GameObject thermometer2;
        [SerializeField] GameObject ignitionBox1;
        [SerializeField] GameObject ignitionBox2;
        [SerializeField] GameObject stirrer1;
        [SerializeField] GameObject stirrer2;
        public bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;
        private bool material1 = false;
        private bool material2 = false;
        private bool material3 = false;

        public void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
            thermometer1.SetActive(false);
            ignitionBox1.SetActive(false);
            stirrer1.SetActive(false);

        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == thermometer2)
                {
                    thermometer1.SetActive(true);
                    thermometer2.SetActive(false);
                    material1 = true;
                }
                else
                {
                    objectInteractMessage = "Missing Thermometer.";
                }

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == ignitionBox2)
                {
                    ignitionBox1.SetActive(true);
                    ignitionBox2.SetActive(false);
                    material2 = true;
                }
                else
                {
                    objectInteractMessage = "Missing Ignition Box.";
                }

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == stirrer2)
                {
                    stirrer1.SetActive(true);
                    stirrer2.SetActive(false);
                    material3 = true;
                }
                else
                {
                    objectInteractMessage = "Missing Stirrer.";
                }

                if (material1 == true && material2 == true && material3 == true)
                {
                    hasInteracted = true;
                }
            }
            else
            {
                objectInteractMessage = "Already Completed.";
                Destroy(this);
            }
        }

    }
}