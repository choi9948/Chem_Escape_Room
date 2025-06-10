using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ComputerA : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;
        [SerializeField] public GameObject computerScreenUI;
        [SerializeField] public GameObject tnt;
        [SerializeField] private InputManager playerMovementScript;
        [SerializeField] private InteractionController interactionControllerScript;
        [SerializeField] GameObject player;


        [Header("Screens")]
        [SerializeField] GameObject screen1;
        [SerializeField] GameObject screen2;

        [Header("Blanks")]
        [SerializeField] InputField input1;
        [SerializeField] InputField input2;
        [SerializeField] InputField input3;
        [SerializeField] InputField input4;
        [SerializeField] InputField username;
        [SerializeField] InputField password;

        private bool hasInteracted = false;

        private void DisableMovement()
        {
            playerMovementScript.enabled = false;
            interactionControllerScript.enabled = false;
        }

        private void EnableMovement()
        {
            playerMovementScript.enabled = true;
            interactionControllerScript.enabled = true;
        }

        void Spawn()
        {
            tnt.transform.position = transform.position + Vector3.up + new Vector3(0,0,-1f);
            Rigidbody rb = tnt.GetComponent<Rigidbody>();
        }

        public void Start()
        {
            computerScreenUI.SetActive(false);
            screen1.SetActive(false);
            screen2.SetActive(false);
            playerMovementScript = player.GetComponent<InputManager>();
            interactionControllerScript = player.GetComponent<InteractionController>();
        }

        public void Interact()
        {
            computerScreenUI.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;


            if (!hasInteracted)
            {
                screen1.SetActive(true);
                screen2.SetActive(false);
                DisableMovement();
            }
            else
            {
                objectInteractMessage = "Already Completed";
            }
        }

        public void Check1()
        {
            string userInput5 = username.text.Trim().ToLower();
            string userInput6 = password.text.Trim().ToLower();

            if (userInput5 == "albert einstein" && userInput6 == "7536")
            {
                screen1.SetActive(false);
                screen2.SetActive(true);
            }
            else
            {
                return;
            }
        }

        public void Check2()
        {
            string userInput1 = input1.text.Trim().ToLower();
            string userInput2 = input2.text.Trim().ToLower();
            string userInput3 = input3.text.Trim().ToLower();
            string userInput4 = input4.text.Trim().ToLower();

            if (userInput1 == "no" && userInput2 == "yes" && userInput3 == "no" && userInput4 == "incorrect")
            {
                Spawn();
                screen1.SetActive(false);
                screen2.SetActive(false);
                Cursor.visible = false;
                computerScreenUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                EnableMovement();
                hasInteracted = true;
            }
            else
            {
                return;
            }
        }
    }
}