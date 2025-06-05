using UnityEngine;

namespace DefaultNamespace
{
    public class Computer1 : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;

        public GameObject computerScreenUI;
        private bool hasInteracted = false;

        public void Interact()
        {

            if (!hasInteracted)
            {
                hasInteracted = true;
                computerScreenUI.SetActive(true);
                Cursor.visible = true;
                Time.timeScale = 0f;
            }
            else
            {
                objectInteractMessage = "Already Completed.";
            }
        }
    }
}
