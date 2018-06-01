using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerModel))]
public class PlayerViewSidescroller : MonoBehaviour
{

    private Animator animator;
    private PlayerModel playerModel; 
    public int directionX = 1;
    public int directionY = 0;
    public bool isMoving = false;

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
        //Vector3 direction = playerModel.GetFacingDirection();
        animator.SetFloat("DirectionX", directionX);
        animator.SetFloat("DirectionY", directionY);

        //if (direction != Vector3.zero)
        //{
        //    animator.SetFloat("DirectionX", direction.x);
        //    animator.SetFloat("DirectionY", direction.y);
        //}
        animator.SetBool("isMoving", isMoving);
        //animator.SetBool("isMoving", playerModelTopDown.IsMoving());
    }
}