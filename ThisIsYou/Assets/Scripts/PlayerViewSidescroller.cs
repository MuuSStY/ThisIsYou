using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerModel))]
public class PlayerViewSidescroller : MonoBehaviour
{

    private Animator animator;
    private PlayerModel playerModel;
    public int directionX = 1;
    public bool isMoving = false;
    public bool isJumping = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerModel = GetComponent<PlayerModel>();
    }


    void Update()
    {
        UpdateFacingDirection();
    }

    void UpdateFacingDirection()
    {
        directionX = playerModel.GetFacingDirection();

        if (directionX != 0)
        {
            animator.SetFloat("DirectionX", directionX);
        }

        isMoving = playerModel.IsMoving();
        isJumping = playerModel.IsJumping();
        animator.SetBool("isMoving", isMoving);
        animator.SetBool("isJumping", isJumping);

        if (playerModel.IsDead())
        {
            animator.SetTrigger("Death Trigger");
        }
        // if (playerModel.HasWon())
        // {
        //     animator.SetTrigger("Victory Trigger");
        // }
    }
}