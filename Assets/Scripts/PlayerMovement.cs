using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Animator anim;
    float speed, acceleration, stop, jumpPower;
    Vector2 velocity;
    Joystick joystick;
    JoystickJumpButton jumpButton;
    bool isJumping;
    

    int jumpLimit, jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 3;
        acceleration = 10;
        stop = 50;
        jumpPower = 100;
        jumpLimit = 3;
        jumpCount = 0;
        joystick = GameObject.FindObjectOfType<Joystick>();
        jumpButton = GameObject.FindObjectOfType<JoystickJumpButton>();
        FindObjectOfType<SliderControler>().SliderValue(jumpLimit, jumpCount);
      
    }

    // Update is called once per frame
    void Update()
    {
       // Platform Dependent Compilation
#if UNITY_EDITOR
        MoveControl(Input.GetAxisRaw("Horizontal"));
        Jump("space");

#else
        MoveControl(joystick.Horizontal);
        Jump(jumpButton.isClick, ref isJumping);      
#endif


    }
    void MoveControl(float moveInput)
    {

        Vector2 scale = transform.localScale;
        if (moveInput > 0)
        {
            MoveAnim("Walk", true, moveInput, speed, acceleration);
            scale.x = Mathf.Abs(scale.x);
        }
        else if (moveInput < 0)
        {
            MoveAnim("Walk", true, moveInput, speed, acceleration);
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else
        {
            MoveAnim("Walk", false, moveInput, speed, stop);
        }
        transform.Translate(velocity * Time.deltaTime);
        transform.localScale = scale;


    }
    void Jump(bool clickControl, ref bool isJumping)
    {
        
        if (clickControl == true && isJumping == false)
        {
            isJumping = true;
            BeginJump();
        }
        if (clickControl == false && isJumping == true)
        {
            isJumping = false;
            EndJump();
        }
    }
    void Jump(string buttonName)
    {
        if (Input.GetKeyDown(buttonName))
        {
            BeginJump();
        }
        if (Input.GetKeyUp(buttonName))
        {
            EndJump();
        }
    }
    void BeginJump()
    {

        if (jumpLimit > jumpCount)
        {
            rb2d.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            anim.SetBool("Jump", true);
            FindObjectOfType<SoundsControler>().SoundJump();

        }
    }
    void EndJump()
    {
        anim.SetBool("Jump", false);
        jumpCount++;
        FindObjectOfType<SliderControler>().SliderValue(jumpLimit, jumpCount);
    }
    void MoveAnim(string moveType, bool setActive, float moveInput, float speed, float acceleration)
    {
        velocity.x = Mathf.MoveTowards(velocity.x, moveInput * speed, acceleration * Time.deltaTime);
        anim.SetBool(moveType, setActive);
    }
    public void RestartJump()
    {
        jumpCount = 0;
        FindObjectOfType<SliderControler>().SliderValue(jumpLimit, jumpCount);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="DeathZone")
        {
            FindObjectOfType<GameControler>().GameFinish();
        }
    }
    public void GameOver()
    {
       
        Destroy(gameObject);
    }
}
