using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int maxStamina = 100;                     // The amount of stamina the player has to run
    int currentStamina;                       // The player's current stamina to run
    int currentHealth;                        // The player's current health value
    int maxHealth = 100;                      // Maximum Health Value.
    bool isSprinting = false;                 // Is the player currently running?
    bool canSprint = true;                    // Is the player currently able to run?
    bool hasJumped = false;                   // Has the player jumped?
    bool hasDoubleJumped = false;             // Has the player double jumped?
    float lastRechargeTime = 1;               // The last time Stamina recharged
    float movementSpeed = 0.125f;             // Base Movement Speed
    float runSpeed = 0.125f;                  // Increase to Movement Speed while Running
    float staminaRechargeDelay;               // The time between recharges for Stamina
    float jumpForce = 1000f;
	bool isMoving;


    // Assign current health and stamina to max value.
    private void Awake()
    {
        currentStamina = maxStamina;
        currentHealth = maxHealth;
    }
    // Reset the jump booleans when hitting the ground.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            hasDoubleJumped = false;
            hasJumped = false;
        }
    }

	public bool getMoving(){
		return isMoving;
	}

    void Update ()
    {
		isMoving = false;
        // Recharge stamina by one point after the delay time.
        if ((currentStamina < maxStamina) && (Time.time > (lastRechargeTime + staminaRechargeDelay)))
        {
            currentStamina++;
            lastRechargeTime = Time.time;
        }
        // If the player has no stamina, reduce movement speed to a walk and set both isSprinting and canSprint to false
        if (currentStamina <= 0)
        {
            if (isSprinting)
            {
                movementSpeed -= runSpeed;
            }
            isSprinting = false;
            canSprint = false;
        }
        // Reset canSprint to true if the player has stamina
        if ((!canSprint) && (currentStamina > 0))
        {
            canSprint = true;
        }
        // Limit the currentStamina to not exceed maxStamina
        if (currentStamina >= maxStamina)
        {
            currentStamina = maxStamina;
        }
        // Start sprinting when Left Shift is pressed
        if ((Input.GetKeyDown(KeyCode.LeftShift)) && (canSprint))
        {
            movementSpeed += runSpeed;
            isSprinting = true;
        }
        // Stop sprinting when Left Shift is released
        if ((Input.GetKeyUp(KeyCode.LeftShift)) && (canSprint))
        {
            if (isSprinting)
            {
                movementSpeed -= runSpeed;
            }
            isSprinting = false;
        }
        // Move left when A is pressed
        if (Input.GetKey(KeyCode.A))
        {
            Move(Vector2.left);
        }
        // Move right when D is pressed
        if (Input.GetKey(KeyCode.D))
        {
            Move(Vector2.right);
        }
        // Jump when the Space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
	}
    // Move the current movement speed in a direction
    void Move(Vector2 dir)
    {
		isMoving = true;
        transform.Translate(dir * movementSpeed);
        if (isSprinting)
        {
            currentStamina--;
        }
    }
    // Jump the current jump force upwards
    void Jump()
    {
        if (!hasJumped)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
            hasJumped = true;
            return;
        }
        else if (hasJumped && !hasDoubleJumped)
        {
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
            hasDoubleJumped = true;
            return;
        }
    }
    // Take damage from an external source
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
		//Turn the screen red

    }
    // Heal health from an external source
    public void Heal(int health)
    {
        currentHealth += health;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    // Die when health reaches 0
    public void Die()
    {

    }
}
