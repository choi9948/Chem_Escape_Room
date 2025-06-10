using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Computer2 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;
        [SerializeField] GameObject graph;

        [Header("Screens")]
        [SerializeField] GameObject screen1;
        [SerializeField] GameObject screen2;
        [SerializeField] GameObject screen3;

        [Header("Blanks")]
        [SerializeField] InputField hydrogen;
        [SerializeField] InputField carbon;
        [SerializeField] InputField linear;
        [SerializeField] InputField trigonalPlanar;
        [SerializeField] InputField bent;
        [SerializeField] InputField tetrahedral;
        [SerializeField] InputField trigonalPyramidal;
        [SerializeField] InputField trigonalBipyramidal;
        [SerializeField] InputField seesaw;
        [SerializeField] InputField tshaped;
        [SerializeField] InputField octahedral;
        [SerializeField] InputField squarePyramidal;
        [SerializeField] InputField squarePlanar;
        [SerializeField] InputField wavelength;
        [SerializeField] InputField lightType;

        public GameObject computerScreenUI;
        private bool hasInteracted = false;
        private bool check = false;

        [SerializeField] private InputManager playerMovementScript;
        [SerializeField] private InteractionController interactionControllerScript;
        [SerializeField] GameObject player;

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
        public void Start()
        {
            computerScreenUI.SetActive(false);
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(false);
            playerMovementScript = player.GetComponent<InputManager>();
            interactionControllerScript = player.GetComponent<InteractionController>();
        }

        public void Interact()
        {
            if (!hasInteracted)
            {
                computerScreenUI.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0f;
                screen1.SetActive(true);
                screen2.SetActive(false);
                screen3.SetActive(false);
                graph.SetActive(false);
                DisableMovement();
            }
            else
            {
                objectInteractMessage = "Already Completed.";
            }
        }

        public void Check1()
        {
            string userInput1 = hydrogen.text.Trim().ToLower();
            string userInput2 = carbon.text.Trim().ToLower();

            if (userInput1 == "5" && userInput2 == "3")
            {
                graph.SetActive(true);
                check = true;
            }
            else
            {
                return;
            }
        }

        public void Submit1()
        {
            if (check == true)
            {
                screen1.SetActive(false);
                screen2.SetActive(true);
                screen3.SetActive(false);
            }
            else
            {
                return;
            }
        }

        public void Check2()
        {
            string userInput3 = linear.text.Trim().ToLower();
            string userInput4 = trigonalPlanar.text.Trim().ToLower();
            string userInput5 = bent.text.Trim().ToLower();
            string userInput6 = tetrahedral.text.Trim().ToLower();
            string userInput7 = trigonalPyramidal.text.Trim().ToLower();
            string userInput8 = trigonalBipyramidal.text.Trim().ToLower();
            string userInput9 = seesaw.text.Trim().ToLower();
            string userInput10 = tshaped.text.Trim().ToLower();
            string userInput11 = octahedral.text.Trim().ToLower();
            string userInput12 = squarePyramidal.text.Trim().ToLower();
            string userInput13 = squarePlanar.text.Trim().ToLower();
            Debug.Log($"Check2 Inputs: {userInput3}, {userInput4}, {userInput5}, {userInput6}, {userInput7}, {userInput8}, {userInput9}, {userInput10}, {userInput11}, {userInput12}, {userInput13}");

            if (userInput3 == "0" && userInput4 == "1" && userInput5 == "4" &&
                userInput6 == "3" && userInput7 == "1" && userInput8 == "0" &&
                userInput9 == "0" && userInput10 == "0" && userInput11 == "0" &&
                userInput12 == "0" && userInput13 == "0")
            {
                screen1.SetActive(false);
                screen2.SetActive(false);
                screen3.SetActive(true);
            }
            else
            {
                return;
            }
        }

        public void Check3()
        {
            string userInput14 = wavelength.text.Trim().ToLower();
            string userInput15 = lightType.text.Trim().ToLower();

            if (userInput14 == "1283" && userInput15 == "infrared light")
            {
                screen1.SetActive(false);
                screen2.SetActive(false);
                screen3.SetActive(false);
                Cursor.visible = false;
                computerScreenUI.SetActive(false);
                Time.timeScale = 1f;
                Cursor.lockState = CursorLockMode.Locked;
                objectInteractMessage = "Completed.";
                hasInteracted = true;
                EnableMovement();
            }
            else
            {
                return;
            }
        }            
    }
}