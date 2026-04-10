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
    Vector2 _velocity;
    Quaternion facingRight;
    Quaternion facingLeft;
    private CharacterController controller;
    private KeyControl up;
    private KeyControl down;
    private KeyControl left;
    private KeyControl right;
    private KeyControl dash;
    private KeyControl interact;
    private ButtonControl controllerUp;
    private ButtonControl controllerDown;
    private ButtonControl controllerLeft;
    private ButtonControl controllerRight;
    private ButtonControl controllerDash;
    private ButtonControl controllerInteract;

    public Character character;
    void Awake()
    {
        if (character == Character.Arachnea)
        {
            up = Keyboard.current.upArrowKey;
            down = Keyboard.current.downArrowKey;
            left = Keyboard.current.leftArrowKey;
            right = Keyboard.current.rightArrowKey;
            dash = Keyboard.current.rightShiftKey;
            interact = Keyboard.current.enterKey;
            // controllerUp = Gamepad.current.buttonNorth;
            // controllerDown = Gamepad.current.buttonSouth;
            // controllerLeft = Gamepad.current.buttonWest;
            // controllerRight = Gamepad.current.buttonEast;
            // controllerDash = Gamepad.current.rightShoulder;
            // controllerInteract = Gamepad.current.rightTrigger;
        }
        else
        {
            up = Keyboard.current.wKey;
            down = Keyboard.current.sKey;
            left = Keyboard.current.aKey;
            right = Keyboard.current.dKey;
            dash = Keyboard.current.leftShiftKey;
            interact = Keyboard.current.eKey;
            // controllerUp = Gamepad.current.dpad.up;
            // controllerDown = Gamepad.current.dpad.down;
            // controllerLeft = Gamepad.current.dpad.left;
            // controllerRight = Gamepad.current.dpad.right;
            // controllerDash = Gamepad.current.leftShoulder;
            // controllerInteract = Gamepad.current.leftTrigger;
        }
    }
    void Start()
    {
        
        controller = GetComponent<CharacterController>();
        facingRight = Quaternion.Euler(0f,90f,0f);
        facingLeft = Quaternion.Euler(0f,270f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0f;
        // if(right.isPressed||controllerRight.isPressed) direction += 1f;
        // if(left.isPressed||controllerLeft.isPressed) direction -= 1f;
        // bool jumpPressedThisFrame = up.wasPressedThisFrame||controllerUp.wasPressedThisFrame;
        // bool jumpHeld = up.isPressed||controllerUp.isPressed;
        if(right.isPressed) direction += 1f;
        if(left.isPressed) direction -= 1f;
        bool jumpPressedThisFrame = up.wasPressedThisFrame;
        bool jumpHeld = up.isPressed;

        float gravityMod = 1f;

        if (controller.isGrounded)
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

        if (!controller.isGrounded)
        {
            float gravity = 2f*apexHeight/(apexTime*apexTime);
            _velocity.y -= gravity*gravityMod*Time.deltaTime;
        }
       
        float deltaX = _velocity.x*Time.deltaTime;
        float deltaY = _velocity.y*Time.deltaTime;
        Vector3 deltaPosition = new Vector3(deltaX,deltaY,0f);
        transform.position += deltaPosition;
        controller.Move(deltaPosition);
    }

}
