using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class Player : MonoBehaviour{
    public enum Character
    {
        Arachnea,
        Medusa,
    } 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float groundAcceleration = 15f;
    public float apexHeight = 4.5f;
    public float apexTime = .5f;
    public float gravityMod = 1f;
    public bool isOnWall = false;
    public bool faceRight = true;
    Vector2 _velocity;
    Quaternion facingRight;
    Quaternion facingLeft;
    public float direction;
    private CharacterController controller;
    private InputAction up;
    private InputAction down;
    private InputAction left;
    private InputAction right;
    private InputAction dash;
    private InputAction interact;
    private Controls controls;
    


    public Character character;
    void Awake()
    {
        controls = new Controls();
        controls.Player.Enable();
        if (character == Character.Arachnea)
        {
            up = controls.Player.ArachneaJump;
            down = controls.Player.ArachneaDrop;
            left = controls.Player.ArachneaWalkLeft;
            right = controls.Player.ArachneaWalkRight;
            dash = controls.Player.ArachneaDash;
            interact = controls.Player.ArachneaInteract;
        }
        else
        {
            up = controls.Player.MedusaJump;
            down = controls.Player.MedusaDrop;
            left = controls.Player.MedusaWalkLeft;
            right = controls.Player.MedusaWalkRight;
            dash = controls.Player.MedusaDash;
            interact = controls.Player.MedusaInteract;
        }
    }
    void Start()
    {
        

        controller = GetComponent<CharacterController>();
        facingRight = Quaternion.Euler(0f,0f,0f);
        facingLeft = Quaternion.Euler(0f,180f,0f);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        float direction = 0f;
        if(right.IsPressed()) direction += 1f;
        if(left.IsPressed()) direction -= 1f;
        bool jumpPressedThisFrame = up.WasPressedThisFrame();
        bool jumpHeld = up.IsPressed();


        if (!isOnWall)
        {
            if (controller.isGrounded)
            {
                if (direction!= 0f)
                {
                    if (Mathf.Sign(direction) != Mathf.Sign(_velocity.x))
                    {
                        _velocity.x = 0f;
                        faceRight = !faceRight;
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

            if (!controller.isGrounded);
            {
                float gravity = 2f*apexHeight/(apexTime*apexTime);
                _velocity.y -= gravity*gravityMod*Time.deltaTime;
            }
        }
        else
        {
            if (down.IsPressed())
            {
                _velocity.y = -4f;
            }else if (up.IsPressed())
            {
                _velocity.y = 4f;
            }else{
                _velocity.y = 0f;
             }
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
        }
        
       
        float deltaX = _velocity.x*Time.deltaTime;
        float deltaY = _velocity.y*Time.deltaTime;
        Vector3 deltaPosition = new Vector3(0f,deltaY,deltaX);
        transform.position += deltaPosition;
        controller.Move(deltaPosition);
        if (interact.IsPressed())
        {
            Interact();
        }
    }
    

    public virtual void Interact()
    {
        Debug.Log("not supposed to print");
    }
}
