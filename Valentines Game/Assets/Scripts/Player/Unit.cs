using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Unit : MonoBehaviour
{
    [SerializeField] Tilemap groundTilemap, colTilemap;
    [SerializeField] SO_VectorValue spawnpoint;

    Rigidbody2D rb;
    GroundCheck groundCheck;
    [Space(10)]
    [SerializeField] float speed;
    float jumpForce;
    bool cannotMove;
    //[SerializeField] SimpleAudioEvent stepSfx;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheck = GetComponent<GroundCheck>();
    }
    private void Start()
    {
        transform.position = spawnpoint.position;
    }
    public void Move(Vector2 direction)
    {
        if (cannotMove || !doesTileExist(direction))
            return;

        StartCoroutine(CO_Speed());
        transform.position += (Vector3)direction;
        //stepSfx.Play();

        //Vector2 nextPosition = transform.position;
        //nextPosition += direction * speed * Time.deltaTime;
        //transform.position = nextPosition;
    }
    bool doesTileExist(Vector2 direction)
    {
        Vector3Int grisPos = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(grisPos) || colTilemap.HasTile(grisPos))
            return false;
        return true;
    }
    IEnumerator CO_Speed()
    {
        cannotMove = true;
        yield return new WaitForSeconds(speed);
        cannotMove = false;
    }
    public void Jump()
    {
        if (groundCheck.IsGrounded())
            rb.velocity = Vector2.up * jumpForce;
    }

    public void StopMovement()
    {
        cannotMove = true;
    }
    public void StartMovement()
    {
        cannotMove = false;
    }
}
