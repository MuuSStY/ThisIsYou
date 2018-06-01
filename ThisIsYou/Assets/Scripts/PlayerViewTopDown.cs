using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
//[RequireComponent(typeof(PlayerModelTopDown))]
public class PlayerViewTopDown : MonoBehaviour {

    private Animator animator;
    private PlayerModel playerModel; 
	
	void Start () {
        animator = GetComponent<Animator>();
        playerModel = GetComponent<PlayerModel>();
	}
	
    
	void Update () {
        UpdateFacingDirection();
	}

    void UpdateFacingDirection()
    {
        //Vector3 direction = playerModel.GetFacingDirection();
        animator.SetFloat("DirectionX", 1);
        animator.SetFloat("DirectionY", 1);

        //if (direction != Vector3.zero)
        //{
        //    animator.SetFloat("DirectionX", direction.x);
        //    animator.SetFloat("DirectionY", direction.y);
        //}

        //animator.SetBool("isMoving", playerModelTopDown.IsMoving());
    }
}
