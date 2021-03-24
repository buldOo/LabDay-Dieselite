using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletColision : MonoBehaviour
{
    public LayerMask solid;
    public LayerMask layerRooftop;
    public LayerMask interactable;
    private Vector2 input;

    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(gameObject);

        } else {

        }
    }

    private bool isInRooftop(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.3f, layerRooftop | solid | interactable ) != null)
        {
            return true;
        }

        return false;
    }
}
