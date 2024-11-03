using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ButtonsBehaviourScript : MonoBehaviour
{
    public Button BtnMirar;
    public Button BtnUsar; 
    public Button BtnCoger;

    private bool useButton = false; //Booleano del boton de usar
    private bool lookButton = false; //Booleano del boton de mirar
    private bool grabButton = false; //Booleano del boton de coger

    // Colores de los botones
    public Color colorDeshabilitado = Color.gray;
    private Color colorHabilitado = new Color(0f, 0.992f, 0f);

    public bool GetUseButton()
    {
        return useButton;
    }
    public bool GetLookButton()
    {
        return lookButton;
    }
    public bool GetGrabButton()
    {
        return grabButton;
    }

    // Boton Mirar
    public void UseButtonMirar()
    {
        if (!lookButton)
        {
            lookButton = true;
            DeshabilitarBotonesMenos(BtnMirar);
        }
        else
        {
            lookButton = false;
            HabilitarTodosLosBotones();
        }
    }
    // Boton Usar
    public void UseButtonUsar()
    {
        if (!useButton)
        {
            useButton = true;
            DeshabilitarBotonesMenos(BtnUsar);
        }
        else
        {
            useButton = false;
            HabilitarTodosLosBotones();
        }
    }
    // Boton Coger
    public void UseButtonCoger()
    {
        if (!grabButton)
        {
            grabButton = true;
            DeshabilitarBotonesMenos(BtnCoger);
        }
        else
        {
            grabButton = false;
            HabilitarTodosLosBotones();
        }
    }
    public void DeshabilitarBotonesMenos(Button botonPulsado)
    {
        BtnMirar.interactable = botonPulsado == BtnMirar;
        BtnUsar.interactable = botonPulsado == BtnUsar;
        BtnCoger.interactable = botonPulsado == BtnCoger;
    }

    // Resetea todos los botones
    public void HabilitarTodosLosBotones()
    {
        BtnMirar.interactable = true;
        BtnUsar.interactable = true;
        BtnCoger.interactable = true;
        lookButton = false;
        useButton = false;
        grabButton = false;
    }

    // Se ejecuta al principio
    void Start()
    {
        HabilitarTodosLosBotones();
    }
}