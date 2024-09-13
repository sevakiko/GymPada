using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Animator : MonoBehaviour
{
    [SerializeField] private Player1 player;

    private Animator animator;

    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        animator.SetBool("isWalkingForward", player.IsWalkingForward());
        animator.SetBool("isWalkingBackward", player.IsWalkingBackward());
    }
}
