using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchWeapon : MonoBehaviour
{
    private Animator animator;
    private int WeaponEquiped;

    public int maxWeapon;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(WeaponEquiped);
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetInteger("WeaponEquiped", WeaponEquiped);

        if (Input.GetKeyDown(KeyCode.A) && WeaponEquiped < maxWeapon)
        {
            WeaponEquiped += 1;
            Debug.Log(WeaponEquiped);

        } else if (Input.GetKeyDown(KeyCode.R) && WeaponEquiped > 0) {
            WeaponEquiped -= 1;
            Debug.Log(WeaponEquiped);
        }
    }
}
