using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float jumpForce;
    private float _moveInput;

    private Rigidbody2D rb;

    private bool isGrounded;
    private bool isHittingCeiling;

    public Text keyText;

    public Transform ceilingCheck;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float maxJumpTime = 0.8f;
    private bool canJump = false;
    private float jumpHoldTime = 0.0f;
    private bool isJumping = false;

    private int keys = 0;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        isHittingCeiling = Physics2D.OverlapCircle(ceilingCheck.position, checkRadius*0.8f, whatIsGround);

        _moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(_moveInput * speed, rb.velocity.y);
    }

    // Update is called once per frame
    void Update() {
        if (isGrounded && !isJumping) {
            canJump = true;
            jumpHoldTime = 0.0f;
        } else {
            canJump = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            if (canJump) {
                canJump = false;
                isJumping = true;
            }
        }

        if(isJumping) {
            bool endJump = false;
            if (Input.GetKeyUp(KeyCode.UpArrow) || isHittingCeiling) {
                endJump = true;
            } else {
                jumpHoldTime += Time.deltaTime;
                if (jumpHoldTime < maxJumpTime) {
                    rb.velocity = Vector2.up * jumpForce;
                } else {
                    endJump = true;
                }
            }

            if (endJump) {
                isJumping = false;
                jumpHoldTime = 0.0f;
                rb.velocity = Vector2.up * 0;
            }
        }

    }

    public void AddKey() {
        keys++;
        
        if(keyText != null)
            keyText.text = $"Keys: {keys}";
    }

    public int KeyCount() => keys;

    public void Kill() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}   