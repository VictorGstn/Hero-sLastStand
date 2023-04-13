using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
 
    [SerializeField] Transform target;
    [SerializeField] GameObject healthdrop;
    GameObject targetGameObject;
    Character targetCharacter;
    [SerializeField]float speed;
    Rigidbody2D rgbd2d ;
    private Animator animator;
    private bool died=false;
    private float timer = 0;
    private float timeValue = 0;
    [SerializeField] float upgradeTime;
    [SerializeField] float upgradeMult;
    [SerializeField] float hp;
    [SerializeField] float damage ;
    [SerializeField] float experience_reward;
    [SerializeField] float dropchance;

    AudioSource audioSource;
    void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        targetGameObject = target.gameObject;
        animator = GetComponent<Animator>();

        audioSource = GetComponent<AudioSource>();

    }

    private void Start()
    {
        Physics2D.IgnoreCollision(targetGameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timeValue += Time.deltaTime;
        Vector3 direction = (target.position - transform.position).normalized;
        rgbd2d.velocity = direction * speed;
        bool flipped = direction.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector2(0f, flipped ? 180f : 0f));
        if (died)
        {
            speed = 0;
            timer += Time.deltaTime;
            if (timer >= 0.25f)
            {
                Destroy(gameObject);
                timer = 0;
            }
        }

        if(timeValue > upgradeTime)
        {
            hp *= upgradeMult;
            damage *= upgradeMult;
            experience_reward *= 1.2f;
            timeValue = 0;
        }
        
    }

    private void OnCollisionStay2D(Collision2D collider)
    {
        if(collider.gameObject == targetGameObject)
        {
            Attack();
        }

    }

    private void Attack()
    {
        //Debug.Log("attack2");
        if (targetCharacter != null )
        {
           //Debug.Log("attack");
            targetCharacter.TakeDamage(damage);
        } else
        {
            targetCharacter = targetGameObject.GetComponent<Character>();
        }
    }
    public void EnemyTakeDamage(float damage)
    {
        hp -= damage;
        animator.SetTrigger("Hit");
        if (hp <= 0)
        {
            targetGameObject.GetComponent<Level>().AddExperience(experience_reward);
            died = true;
            audioSource.Play();
            int random = Random.Range(0, 100);
            if (healthdrop != null && random <= dropchance) 
            {
                Vector2 spawnPosition = gameObject.transform.position;
                GameObject healthSpawned = Instantiate(healthdrop);
                healthSpawned.transform.position = spawnPosition;
            }
        }
    }
}
