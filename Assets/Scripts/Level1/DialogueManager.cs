using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public TextMeshProUGUI dialogos;
    public TextMeshProUGUI mensajes;

    public string[] dialogues;
    public string[] messages;

    public float letterDelay = 0.05f; // Delay entre cada letra
    private Coroutine typingCoroutine;


    void Start()
    {
        StartCoroutine(StartWithDelay()); // Inicia una corutina con retraso
    }
    private IEnumerator StartWithDelay()
    {
        yield return new WaitForSeconds(1); // Espera un segundo
        StartMessage(); // Comienza el mensaje
        StartDialogue(); // Comienza el diálogo
    }

    // añadir 3 dialogos en el array de dialogos
    public void StartDialogue()
    {
        typingCoroutine = StartCoroutine(TypeDialogue());
    }
    public void StartMessage()
    {
        typingCoroutine = StartCoroutine(TypeMessage());
    }
    IEnumerator TypeDialogue()
    {
        foreach (string dialogue in dialogues)
        {
            dialogos.text = ""; // Limpia el texto
            foreach (char letter in dialogue)
            {
                dialogos.text += letter; // Agrega letra por letra
                yield return new WaitForSeconds(letterDelay);
            }
        }
        // despues de 3 segundos se limpia el mensaje
        yield return new WaitForSeconds(2);
        dialogos.text = "";
    }

    IEnumerator TypeMessage()
    {
        foreach (string message in messages)
        {
            mensajes.text = ""; // Limpia el texto
            foreach (char letter in message)
            {
                mensajes.text += letter; // Agrega letra por letra
                yield return new WaitForSeconds(letterDelay); // Espera un tiempo
            }
        }
        // despues de 3 segundos se limpia el mensaje
        yield return new WaitForSeconds(2);
        mensajes.text = "";
    }
}
