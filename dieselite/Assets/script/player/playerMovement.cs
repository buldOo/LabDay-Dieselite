using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;
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
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

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

        Vector3 mouse = Input.mousePosition;

        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.localPosition);

        Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
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


}
