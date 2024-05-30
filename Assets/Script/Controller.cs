using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Controller : MonoBehaviour
{
    public float walkSpeed, walkAnimationSpeed, dashPower;

    public Animator animator;
    public new Rigidbody rigidbody;

    //public Weapon longRangeWeapon;
    //public Weapon meleeWeapon;


    Vector3 translation;

    bool canDash;
    void Start()
    {
        canDash = true;
        rigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        //StartCoroutine(LongRangeWeapon());
    }

    void Update()
    {

        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        float speed = walkSpeed;
        float animSpeed = walkAnimationSpeed;


        translation = Vector3.forward * (vertical * Time.deltaTime);
        translation += Vector3.right * (horizontalMove * Time.deltaTime);
        translation *= speed;
        transform.Translate(translation, Space.World);

        if (Input.GetKey(KeyCode.LeftShift) && canDash)
        {
            canDash = false;
            StartCoroutine(Dash());
        }

        animator.SetFloat("Vertical", vertical, 0.1f, Time.deltaTime);
        animator.SetFloat("Horizontal", horizontalMove, 0.1f, Time.deltaTime);
        animator.SetFloat("WalkSpeed", animSpeed);



        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));

        /*//���� ����
        if (Input.GetMouseButton(1))
        {
            if(meleeWeapon.MeleeAttack())
                animator.SetTrigger("MeleeAttack");
        }
        //���Ÿ� ����
        if (Input.GetMouseButton(0))
        {
            longRangeWeapon.LongRangeAttack();
        }*/

    }

    IEnumerator Dash()
    {
        rigidbody.AddForce(translation * dashPower, ForceMode.Impulse);
        yield return new WaitForSeconds(0.5f); // �뽬 ���� �ð�
        rigidbody.velocity = Vector3.zero;
        canDash = true;
    }

    /*
    IEnumerator LongRangeWeapon()
    {
        while(Input.GetMouseButton(0))
        {
            longRangeWeapon.LongRangeAttack(transform);
            yield return null;
        }

    }
    */

}
