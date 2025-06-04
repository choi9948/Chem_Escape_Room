using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

namespace DefaultNamespace
{
    public class DoorKnobInteraction : MonoBehaviour, IInteractable
    {
        public string InteractMessage => objectInteractMessage;
        private bool hasInteracted = false;
        private PlayerPickUpDrop playerPickUpDrop;

        [SerializeField] GameObject knob;

        [SerializeField] string objectInteractMessage;

        private void Transition()
        {
            SceneManager.LoadScene(1);
        }

        private void Start()
        {
            playerPickUpDrop = GameObject.FindWithTag("Player").GetComponent<PlayerPickUpDrop>();
        }
    


        public void Interact()
        {
            if (!hasInteracted)
            {

                if (playerPickUpDrop != null && playerPickUpDrop.GetGrabbedObject() != null && playerPickUpDrop.GetGrabbedObject().gameObject==knob)//if holding object
                {
                    Transition();
                    objectInteractMessage = "Door Opened";
                    hasInteracted = true;
                }
                else
                {
                    objectInteractMessage = "Missing door knob.";
                }
            }
            else
            {
                objectInteractMessage = "Already Pressed.";
            }
        }
        
    }
}