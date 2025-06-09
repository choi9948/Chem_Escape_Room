using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ChalkBoard : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject spawnPrefab;
        [SerializeField] GameObject chalk;

        [Header("Blanks")]
        [SerializeField] InputField input1;
        [SerializeField] InputField input2;
        [SerializeField] InputField input3;
        [SerializeField] InputField input4;
        [SerializeField] InputField input5;
        [SerializeField] InputField input6;
        [SerializeField] InputField input7;
        [SerializeField] InputField input8;


        [SerializeField] public GameObject computerScreenUI;
        private bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;

        public void Start()
        {
            computerScreenUI.SetActive(false);
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }

        void Spawn()
        {
            spawnPrefab.transform.position = transform.position + Vector3.up + new Vector3(-3.3f, 3f, -1.3f);
            Rigidbody rb = spawnPrefab.GetComponent<Rigidbody>();
        }

        public void Interact()
        {
            Spawn();

            if (!hasInteracted)
            {
                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject == chalk)
                {
                    computerScreenUI.SetActive(true);
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0f;
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing Chalk.";
                }
            }
            else
            {
                objectInteractMessage = "Already Completed.";
            }
        }
        
        public void Check()
        {
            string userInput1 = input1.text.Trim().ToLower();
            string userInput2 = input2.text.Trim().ToLower();
            string userInput3 = input3.text.Trim().ToLower();
            string userInput4 = input4.text.Trim().ToLower();
            string userInput5 = input5.text.Trim().ToLower();
            string userInput6 = input6.text.Trim().ToLower();
            string userInput7 = input7.text.Trim().ToLower();
            string userInput8 = input8.text.Trim().ToLower();
          
            if (userInput1 == "splitting" &&
                userInput2 == "hydrogen spectrum" &&
                userInput3 == "20" &&
                userInput4 == "valence electrons" &&
                userInput5 == "shells" &&
                userInput6 == "ionization" &&
                userInput7 == "sodium" &&
                userInput8 == "3rd")
            {
                Spawn();
                Cursor.visible = false;
                computerScreenUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                return;
            }
        }


    }
}
