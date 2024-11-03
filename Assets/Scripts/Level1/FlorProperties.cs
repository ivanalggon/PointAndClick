using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class FlorProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject eventSystem;
    public GameObject florInventario;
    public GameObject regaderaInventario;
    public GameObject regadera;
    

    public bool isActive = false;
    public bool isGrabbed = false;


    private DialogueManager dialogueManager;
    private ButtonsBehaviourScript buttonsBehaviourScript;

    private Animator animator;

    // Se ejecuta al principio
    void Start()
    {
        this.gameObject.SetActive(true);
        florInventario.SetActive(false);

        buttonsBehaviourScript = gameManager.GetComponent<ButtonsBehaviourScript>();
        animator = this.GetComponent<Animator>();
        dialogueManager = eventSystem.GetComponent<DialogueManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        // MIRAR
        if (buttonsBehaviourScript.GetLookButton())
        {

            if (!isActive)
            {
                dialogueManager.dialogues = new string[] { "Esta flor necesita un poco de agua" };
                dialogueManager.StartDialogue();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }
            else
            {
                dialogueManager.dialogues = new string[] { "¡Qué bonita flor! Voy a recogerla" };
                dialogueManager.StartDialogue();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }

        }

        // USAR
        if (buttonsBehaviourScript.GetUseButton())
        {
            if (isActive)
            {
                dialogueManager.messages = new string[] { "La flor ha crecido. ¡Voy a cogerla!" };
                dialogueManager.StartMessage();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }
            else
            {
                isActive = true;
                animator.SetBool("isUsed", true);
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }
        }

        // COGER
        if (buttonsBehaviourScript.GetGrabButton())
        {
            if (!isActive)
            {
                dialogueManager.dialogues = new string[] { "No se puede recoger, la flor necesita agua" };
                dialogueManager.StartDialogue();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }
            else
            {
                // Si la regadera está visible
                if (!isGrabbed && regadera.activeSelf)
                {
                    //ocultar la flor
                    this.gameObject.SetActive(false);

                    //meter la flor en el inventario
                    florInventario.SetActive(true);

                    isGrabbed = true;
                    animator.SetBool("isGrabbed", true);
                    dialogueManager.messages = new string[] { "¡Has recogido la flor!" };
                    buttonsBehaviourScript.HabilitarTodosLosBotones();
                }
                else
                {
                    dialogueManager.dialogues = new string[] { "Hay que regar la flor" };
                    dialogueManager.StartDialogue();
                    buttonsBehaviourScript.HabilitarTodosLosBotones();
                }
            }
        }
    }
}