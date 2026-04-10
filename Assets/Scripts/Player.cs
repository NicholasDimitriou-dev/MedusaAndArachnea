using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float groundAcceleration = 15f;
    public float apexHeight = 4.5f;
    public float apexTime = .5f;
    Vector2 _velocity;
    Quaternion facingRight;
    Quaternion facingLeft;
    void Start()
    {
        facingRight = Quaternion.Euler(0f,90f,0f);
        facingLeft = Quaternion.Euler(0f,270f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0f;
        if(Keyboard.current.dKey.isPressed) direction += 1f;
        if(Keyboard.current.aKey.isPressed) direction -= 1f;
        bool jumpPressedThisFrame = Keyboard.current.wKey.wasPressedThisFrame;
        bool jumpHeld = Keyboard.current.wKey.isPressed;

        float gravityMod = 1f;

        if (IsGrounded())
        {
            if (direction!= 0f)
            {
                if (Mathf.Sign(direction) != Mathf.Sign(_velocity.x))
                {
                    _velocity.x = 0f;
                }
                _velocity.x += direction*groundAcceleration * Time.deltaTime;
                _velocity.x = Mathf.Clamp(_velocity.x,-walkSpeed,walkSpeed);

                transform.rotation = (direction >0f) ? facingRight : facingLeft;
            }
            else
            {
                _velocity.x = Mathf.MoveTowards(_velocity.x,0f,groundAcceleration*Time.deltaTime);
            }
            if (jumpPressedThisFrame)
            {
                _velocity.y = 2f*apexHeight/apexTime;
            }
        }
        else
        {
            if (!jumpHeld)
            {
                gravityMod = 2f;
            }
        }

        if (!IsGrounded())
        {
            float gravity = 2f*apexHeight/(apexTime*apexTime);
            _velocity.y -= gravity*gravityMod*Time.deltaTime;
        }
        
       
        float deltaX = _velocity.x*Time.deltaTime;
        float deltaY = _velocity.y*Time.deltaTime;
        Vector3 deltaPosition = new Vector3(deltaX,deltaY,0f);
        transform.position += deltaPosition;
        Mathf.Clamp(transform.position.y,0.5f,1000f);
        
    }

    private bool IsGrounded()
    {
        if(transform.position.y <= 0.5f){
            Vector3 groundedPosition = new Vector3(transform.position.x,0.5f,transform.position.z);
            transform.position = groundedPosition;
            return true;
        }
        return false;   
         
    }

}
