using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Crack : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        [SerializeField] string objectInteractMessage;

        [SerializeField] GameObject tnt;
        private bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;

        private void Transition()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        private void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }
    
        public void Interact()
        {
            if (!hasInteracted)
            {

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject==tnt)//if holding object
                {
                    Transition();
                    objectInteractMessage = "TNT exploded";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing TNT.";
                }
            }
            else
            {
                objectInteractMessage = "Already Pressed.";
            }
        }
    }
}