using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DisableRooftop : MonoBehaviour
{
    public Tilemap tilemap;
    public LayerMask layerRooftop;

    private TilemapRenderer rooftop;
    private TilemapCollider2D tilemapCollider2D;
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
        rooftop = tilemap.GetComponent<TilemapRenderer>();
        tilemapCollider2D = tilemap.GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        var targetPosition = transform.position;
        targetPosition.x += input.x;
        targetPosition.y += input.y;

        if (isInRooftop(targetPosition))
        {
            rooftop.enabled = false;

        } else {

            rooftop.enabled = true;
        }
    }

    private bool isInRooftop(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, layerRooftop) != null)
        {
            return true;
        }

        return false;
    }
}