using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject crosshair;
    public LayerMask SolidObjectsLayer;
    public LayerMask InteracteblaLayer;
    public LayerMask crate;


    public AudioClip runningSounds;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    private AudioSource Audio_running;
    private Camera theCam;

    private void Start()
    {
        Debug.Log("start");
        theCam = Camera.main;
    }

    private void Awake()
    { 
        animator = GetComponent<Animator>();
        Audio_running = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Cursor.visible = false;

        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                var targetPosition = transform.position;
                targetPosition.x += input.x;
                targetPosition.y += input.y;

                if (IsWalkable(targetPosition))
                {
                    StartCoroutine(Move(targetPosition));
                    Audio_running.PlayOneShot(runningSounds);
                }

            }

       
        }

        animator.SetBool("isMoving", isMoving);

        faceMouse();
    }

    IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;

        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, SolidObjectsLayer | InteracteblaLayer | crate) != null)
        {
            return false;
        }

        return true;
    }

    void faceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
        crosshair.transform.position = new Vector2(mousePosition.x, mousePosition.y);
    }
}
