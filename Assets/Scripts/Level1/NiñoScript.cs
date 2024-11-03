using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class NiñoScript : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject eventSystem;
    
    private DialogueManager dialogueManager;
    private ButtonsBehaviourScript buttonsBehaviourScript;

    public GameObject regaderaInventario;
    public GameObject florInventario;

    public bool haveFlower = false;
    public bool isLooking = false;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        buttonsBehaviourScript = gameManager.GetComponent<ButtonsBehaviourScript>();
        animator = this.GetComponent<Animator>();
        dialogueManager = eventSystem.GetComponent<DialogueManager>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        // MIRAR
        if (buttonsBehaviourScript.GetLookButton())
        {
            if (florInventario.activeSelf)
            {
                haveFlower = true;
                animator.SetBool("haveFlower", true);
                isLooking = true;
                animator.SetBool("isLooking", true);

                florInventario.SetActive(false);

                dialogueManager.messages = new string[] { "¡Qué bonita flor! Gracias" };
                dialogueManager.StartMessage();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }
            else
            {
                dialogueManager.messages = new string[] { "Son todas muy bonitas" };
                isLooking = true;
                animator.SetBool("isLooking", true);

                dialogueManager.StartMessage();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }

        }
        // USAR
        if (buttonsBehaviourScript.GetUseButton())
        {
            dialogueManager.messages = new string[] { "No puedes usarme" };
            dialogueManager.StartMessage();
            buttonsBehaviourScript.HabilitarTodosLosBotones();
        }
        // COGER
        if (buttonsBehaviourScript.GetGrabButton())
        {
            dialogueManager.messages = new string[] { "No puedes cogerme" };
            dialogueManager.StartMessage();
            buttonsBehaviourScript.HabilitarTodosLosBotones();
        }
    }
}
