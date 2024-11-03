using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class RegaderaProperties : MonoBehaviour, IPointerClickHandler
{
    public GameObject gameManager;
    public GameObject eventSystem;
    public GameObject regaderaInventario;

    private DialogueManager dialogueManager;
    private ButtonsBehaviourScript buttonsBehaviourScript;

    private Animator animator;

    // Se ejecuta al principio
    void Start()
    {
        this.gameObject.SetActive(true);
        regaderaInventario.SetActive(false);

        buttonsBehaviourScript = gameManager.GetComponent<ButtonsBehaviourScript>();
        animator = this.GetComponent<Animator>();
        dialogueManager = eventSystem.GetComponent<DialogueManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {

        // MIRAR
        if (buttonsBehaviourScript.GetLookButton())
        {
            dialogueManager.dialogues = new string[] { "Una regadera. Puede ser útil" };
            dialogueManager.StartDialogue();
            buttonsBehaviourScript.HabilitarTodosLosBotones();
        }

        // USAR
        if (buttonsBehaviourScript.GetUseButton())
        {
            // Si la regadera no está en el inventario
            if (!regaderaInventario.activeSelf)
            {
                dialogueManager.dialogues = new string[] { "Puedo coger esta regadera" };
                dialogueManager.StartDialogue();
                buttonsBehaviourScript.HabilitarTodosLosBotones();
            }
        }

        // COGER
        if (buttonsBehaviourScript.GetGrabButton())
        {
            buttonsBehaviourScript.HabilitarTodosLosBotones();

            regaderaInventario.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
