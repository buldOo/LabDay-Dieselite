using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
    public GameObject crosshairs;
    public LayerMask SolidObjectsLayer;
    public LayerMask InteracteblaLayer;
    public AudioClip runningSounds;
    private Animator animator;
    private AudioSource Audio_running;

    private Camera theCam;

    private void Start()
    {
        theCam = Camera.main;
    }

    private void Awake()
    { 
        animator = GetComponent<Animator>();
        Audio_running = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(!isMoving)
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
        if (Physics2D.OverlapCircle(targetPos, 0.3f, SolidObjectsLayer | InteracteblaLayer) != null)
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

        crosshairs.transform.position = mousePosition;

        transform.up = direction;
    }
}
