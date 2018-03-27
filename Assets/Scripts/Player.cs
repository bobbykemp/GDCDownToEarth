using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player.cs
 * 
 * Created By: Charlie Shin
 * Created On: 2017 Nov 10
 * Last Edited By: Charlie Shin
 * Last Edited On: 2017 Nov 11
 * 
 */

[AddComponentMenu("GDC/Character/Player")]
public class Player : Character
{
    /* Private Variables */
    private bool hasJumped; // For double jumping
    private Item[] items; // For item slots
    private int curr_holding = 0; // Currently holding item

    /* Getter and Setter */
    public bool DoubleJumped
    {
        get { return hasJumped; }
        set { hasJumped = value; }
    }

    public int Holding
    {
        get { return curr_holding; }
        set { curr_holding = value; }
    }

    /* Unity Functions */
    public override void Awake()
    {
        base.Awake();
        Chartype = CharType.PLAYER;
    }

    public void Update()
    {
        // If player is taking cover, leave cover first
        Move(); // Move check
        DoubleJump(); // Jump check
        // If cover is near, take cover
        // If slot number is changed, change item
    }

    /* Functions */
    public void DoubleJump()
    {
        // Check keyboard input for jump
        // If player is grounded, jump once
        // If player is not grounded and hasn't double jumped, jump once
        // Change double jump flag to true
    }

    public void TakeCover()
    {
        // Play animation to enter cover
    }

    public void LeaveCover()
    {
        // Play animation to leave cover
    }

    public override void Damage(Character attacker)
    {
        base.Damage(attacker);
    }

    public override void Attack(Character target)
    {
        // Also add flag to check if player is in cover or not (Don't attack if player is in cover)
        if(target.Chartype == CharType.ENEMY) // Attack if and only if target is enemy
            base.Attack(target);
    }

    public void Use()
    {
        if(Equipped is Consumable) // Is player holding consumable?
        {
            Consumable item = Equipped as Consumable;
            Health = Health + item.HealthVal; // Add health
            item.Quantity--; // Remove one
            if (item.Quantity < 1) // Have we used all item?
                items[Holding] = null; // Whatever item in that index turn into null
        }
    }

    public override void Move()
    {
        // Check keyboard input
        base.Move();
    }

}
