using UnityEngine;
using UnityEngine.InputSystem;

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
            this.GetComponent<Rigidbody>().detectCollisions = true;

        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Rigidbody>().detectCollisions = false;
        }

        activateAction.action.performed += ActivateSword;
    }

    void OnDestroy()
    {
        activateAction.action.performed -= ActivateSword;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void ActivateSword(InputAction.CallbackContext context)
    {
        swordActive = !swordActive;

        if (swordActive)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
            this.GetComponent<Rigidbody>().detectCollisions = true;

            if (onSound)
            {
                offSound.Stop();
                onSound.Play();
            }
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Rigidbody>().detectCollisions = false;

            if (offSound)
            {
                onSound.Stop();
                offSound.Play();
            }
        }

    }
}
