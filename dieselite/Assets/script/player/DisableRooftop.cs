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

    public float zoomSpeed = 0.00001f;
    public float targetOrtho;
    public float smoothSpeed = 0.01f;
    public float minOrtho = 1.0f;
    public float maxOrtho = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rooftop = tilemap.GetComponent<TilemapRenderer>();
        tilemapCollider2D = tilemap.GetComponent<TilemapCollider2D>();

        this.targetOrtho = Camera.main.orthographicSize;
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

            this.targetOrtho -= this.zoomSpeed;
            this.targetOrtho = Mathf.Clamp(this.targetOrtho, this.minOrtho, this.maxOrtho);
            Camera.main.orthographicSize = Mathf.MoveTowards(
            Camera.main.orthographicSize,
            this.targetOrtho,
            this.smoothSpeed * Time.deltaTime);

        }
        else {

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