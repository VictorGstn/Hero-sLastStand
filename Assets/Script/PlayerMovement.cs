using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rgbd2;
    Vector3 movement_vector;
    [SerializeField] float initspeed;
    [SerializeField] float dashspeed;
    private float speed;
    public float delay = 0.3f;
    private bool moveblock;
    public float upgradeSpeed = 1.1f;
    private Animator animator;

    AudioSource audioSourceDash;
    AudioSource audioSourceSwing;

    private GameObject attackArea = default;
    private bool attacking = false;
    private bool dashing = false;
    private float timeToAttack = 0.01f;
    private float timer = 0f;
    bool flipped = false;
    private void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false);
        audioSourceSwing = attackArea.GetComponent<AudioSource>();
        audioSourceDash = gameObject.GetComponent<AudioSource>();
        
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rgbd2 = GetComponent<Rigidbody2D>();
        movement_vector = new Vector3();
        speed = initspeed;
        
    }

    // Update is called once per frameS
    void Update()
    {
        if (!moveblock)
        {
            if (attacking)
            {
                timer += Time.deltaTime;
                if (timer >= timeToAttack)
                {
                    timer = 0;
                    attacking = false;
                    attackArea.SetActive(attacking);
                }
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Attack();
            }
            else if (dashing)
            {
                speed = initspeed * dashspeed;
                timer += Time.deltaTime;
                if (timer >= 0.25f)
                {
                    timer = 0;
                    speed = initspeed;
                    dashing = false;
                }
            }
            else if (Input.GetMouseButtonDown(1))
            {
                Dash();
            }
            if (!moveblock)
            {
                movement_vector.x = Input.GetAxis("Horizontal");
                movement_vector.y = Input.GetAxis("Vertical");
                animator.SetFloat("Speed", Mathf.Abs(movement_vector.magnitude));
                if (movement_vector.x < 0)
                {
                    flipped = true;
                }
                if (movement_vector.x > 0)
                {
                    flipped = false;
                }
                this.transform.rotation = Quaternion.Euler(new Vector2(0f, flipped ? 180f : 0f));
                if (movement_vector != null)
                {
                    rgbd2.velocity = movement_vector.normalized * speed;
                }
            }
        }
    }

    private void Dash()
    {
        dashing = true;
        audioSourceDash.Play();

    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetTrigger("Attack");
        audioSourceSwing.Play();
        moveblock = true;
        rgbd2.velocity = Vector3.zero;
        StartCoroutine(BlockMovement());
    }


    private IEnumerator BlockMovement()
    {
        yield return new WaitForSeconds(0.6f);
        moveblock = false;
    }

    public void AddSpeed()
    {
        initspeed *= upgradeSpeed;
    }
 
}
