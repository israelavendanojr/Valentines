using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    Collider2D col;
    [Header("Ground Check")]
    [SerializeField] public LayerMask ground;
    [SerializeField] public float groundCheckDist;
    private void Awake()
    {
        col = GetComponent<Collider2D>();
    }
    public bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.Raycast
            (col.bounds.center, Vector2.down, groundCheckDist, ground);
        return raycastHit.collider != null;
    }
}
