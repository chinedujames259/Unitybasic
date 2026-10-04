using UnityEngine;


public class Player : MonoBehaviour
{
    [SerializeField]private Transform groundCheckTransform = null;
     [SerializeField]private LayerMask playerMask;
    private bool jumpKeyWasPressed;
    private float horizontalInput;
    private Rigidbody rigidbodyComponent;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbodyComponent =  GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if space key is pressed
        if(Input.GetKeyDown(KeyCode.Space))
        {
           jumpKeyWasPressed = true;
        }
    horizontalInput = Input.GetAxis("Horizontal");
    }
//  FixedUpdate is called once every physic update
    private void FixedUpdate()
    {
         rigidbodyComponent.linearVelocity = new Vector3(horizontalInput, rigidbodyComponent.linearVelocity.y,0);
        if(Physics.OverlapSphere(groundCheckTransform.position,0.1f,playerMask).Length == 0)
        {
            return;
        }
         if(jumpKeyWasPressed)
        {
            rigidbodyComponent.AddForce(Vector3.up *7,ForceMode.VelocityChange);
            jumpKeyWasPressed = false;
        }
       
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.layer == 9)
        {
            Destroy(other.gameObject);
        }
    }
}
