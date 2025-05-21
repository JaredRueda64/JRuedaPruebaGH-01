using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightHandController : MonoBehaviour
{

    [Space(20)]
    [Header("Referencias de los componentes del control Derecho ::::: RightController - Grab")]
    [Space(10)]

    public XRRayInteractor xrRayInteractor_grab;

    [Space(20)]
    [Header("Referencias de los componentes del control derecho::::: RightController - Teleport")]
    [Space(10)]
    public XRRayInteractor xrRayInteractor_teleport;

    [Space(20)]
    [Header("Referencia XR Default Input Action ::::: JoyStick - Sector Norte")]
    [Space(10)]
    public InputActionReference JoyStickSectorNorte;

    private void Awake()
    {
        xrRayInteractor_teleport.enabled = false;
    }
    private void JoyStickArribaPresionado(InputAction.CallbackContext context)
    {
        xrRayInteractor_grab.enabled = false;
        xrRayInteractor_teleport.enabled = true;
    }

    private void JoyStickArribaLiberado(InputAction.CallbackContext context) => Invoke("JoyStickArribaLiberado_Invoke", 0.01f);

    private void JoyStickArribaLiberado_Invoke()
    {
        xrRayInteractor_grab.enabled = true;
        xrRayInteractor_teleport.enabled = false;
    }

    private void OnEnable()
    {
        JoyStickSectorNorte.action.performed += JoyStickArribaPresionado;
        JoyStickSectorNorte.action.canceled += JoyStickArribaLiberado;
    }
    private void OnDisable()
    {
        JoyStickSectorNorte.action.performed -= JoyStickArribaPresionado;
        JoyStickSectorNorte.action.canceled -= JoyStickArribaLiberado;
    }
}