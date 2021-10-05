using UnityEngine;
using UnityEngine.InputSystem;

public class Laser : MonoBehaviour
{
    public float speed = 5.0f;
    public InputActionProperty resetActionRight;
    public InputActionProperty resetActionLeft;

    private Vector3 initialPosition = Vector3.zero;
    private Quaternion initialRotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = this.transform.localPosition;
        initialRotation = this.transform.localRotation;

        resetActionRight.action.performed += ResetLaser;
        resetActionLeft.action.performed += ResetLaser;

        // physics code
        Vector3 velocity = this.transform.rotation * new Vector3(0, speed, 0);
        this.GetComponent<Rigidbody>().velocity = velocity;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

    void OnDestroy()
    {
        resetActionRight.action.performed -= ResetLaser;
        resetActionLeft.action.performed -= ResetLaser;
    }

    // Update is called once per frame
    void Update()
    {
        // non-physics code
        //Vector3 currentPosition = this.transform.localPosition;
        //currentPosition.z -= speed * Time.deltaTime;
        //this.transform.localPosition = currentPosition;
    }

    private void ResetLaser(InputAction.CallbackContext context)
    {
        // reset the position and rotation
        this.transform.localPosition = initialPosition;
        this.transform.localRotation = initialRotation;

        // physics code
        Vector3 velocity = this.transform.rotation * new Vector3(0, speed, 0);
        this.GetComponent<Rigidbody>().velocity = velocity;
        this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        // reenable the laser
        this.GetComponent<MeshRenderer>().enabled = true;
        this.GetComponent<Rigidbody>().detectCollisions = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<LaserSword>())
        {
            // if the laser hit the sword, reflect it
            Quaternion newRotation = Quaternion.LookRotation((transform.localPosition - initialPosition).normalized) * initialRotation;
            this.GetComponent<Rigidbody>().rotation = newRotation;
            this.GetComponent<Rigidbody>().velocity = newRotation * new Vector3(0, speed, 0);
            this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        else
        {
            // if it hit something else, make it invisible and disable collision detection
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<Rigidbody>().detectCollisions = false;
        }
    }
}
