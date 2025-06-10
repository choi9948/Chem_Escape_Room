using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Computer1 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;
 


        [Header("Screens")]
        [SerializeField] GameObject screen1;
        [SerializeField] GameObject screen2;
        [SerializeField] GameObject screen3;

        [Header("Blanks")]
        [SerializeField] InputField observation1;
        [SerializeField] InputField observation2;
        [SerializeField] InputField analysis1;
        [SerializeField] InputField analysis2;
        [SerializeField] InputField analysis3;
        [SerializeField] InputField analysis4;
        [SerializeField] InputField analysis5;
        [SerializeField] InputField analysis6;
        [SerializeField] InputField conclusion1;
        [SerializeField] InputField conclusion2;
        [SerializeField] InputField conclusion3;
        [SerializeField] InputField signature;

        [SerializeField]public GameObject computerScreenUI;

        private bool hasInteracted = false;

        public void Start()
        {
            computerScreenUI.SetActive(false);
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(false);
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
                screen3.SetActive(false);
            }
            else
            {
                screen1.SetActive(false);
                screen2.SetActive(false);
                screen3.SetActive(true);
            }
        }

        public void Check()
        {
            string userInput1 = observation1.text.Trim().ToLower();
            string userInput2 = observation2.text.Trim().ToLower();
            string userInput3 = analysis1.text.Trim().ToLower();
            string userInput4 = analysis2.text.Trim().ToLower();
            string userInput5 = analysis3.text.Trim().ToLower();
            string userInput6 = analysis4.text.Trim().ToLower();
            string userInput7 = analysis5.text.Trim().ToLower();
            string userInput8 = analysis6.text.Trim().ToLower();
            string userInput9 = conclusion1.text.Trim().ToLower();
            string userInput10 = conclusion2.text.Trim().ToLower();
            string userInput11 = conclusion3.text.Trim().ToLower();
            string userInput12 = signature.text.Trim().ToLower();

            if (userInput1 == "metal" &&
                userInput2 == "ejected" &&
                userInput3 == "wave" &&
                userInput4 == "particle" &&
                userInput5 == "kinetic energy" &&
                userInput6 == "electron" &&
                userInput7 == "intensity" &&
                userInput8 == "number" &&
                userInput9 == "planck's" &&
                userInput10 == "ionization energy" &&
                userInput11 == "e=hf" &&
                userInput12 == "albert einstein")
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

        public void OpenFile()
        {
            hasInteracted = true;
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(true);
        }

        public void Exit()
        {
           
            screen1.SetActive(false);
            screen2.SetActive(false);
            screen3.SetActive(false);
            Cursor.visible = false;
            computerScreenUI.SetActive(false);
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;

        }
    }
}
