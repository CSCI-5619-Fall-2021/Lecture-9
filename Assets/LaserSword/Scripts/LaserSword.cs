using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.Controls;
//using UnityEngine.XR.Interaction.Toolkit.Inputs;

public class LaserSword : MonoBehaviour
{

    public bool swordActive = false;
    public InputActionProperty activateAction;
    public AudioSource onSound = null;
    public AudioSource offSound = null;

    // Start is called before the first frame update
    void Start()
    {
        if (swordActive)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }

        activateAction.action.performed += Activate;
    }

    void OnDestroy()
    {
        activateAction.action.performed -= Activate;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void Activate(InputAction.CallbackContext context)
    {
        swordActive = !swordActive;

        if (swordActive)
        {
            this.GetComponent<MeshRenderer>().enabled = true;

            if (onSound)
            {
                offSound.Stop();
                onSound.Play();
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;

            if (offSound)
            {
                onSound.Stop();
                offSound.Play();
            }
        }

    }
}
