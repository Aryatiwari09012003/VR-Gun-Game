using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;     

public class EnemyBehaviour : GazePointer
{
    public GameObject particleEffect;
    public Animator enemyModel;
    public float speed;
    Vector3 endpos;

    // Start is called before the first frame update
    void Start()
    {
        endpos = 0.5f * (transform.position - Vector3.zero).normalized;
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.MoveTowards(transform.position, endpos, speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            Attack();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        PlayerManager.currentscore += 100;
        Death();
    }

    public void Death()
    {
        particleEffect.SetActive(true);
        particleEffect.transform.SetParent(null);
        Destroy(gameObject);
    }

    public void Attack()
    {
       enemyModel.SetTrigger("attack");
        PlayerManager.health -= 0.1f;
    }
}
