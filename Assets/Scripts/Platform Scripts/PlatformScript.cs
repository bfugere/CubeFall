using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float boundY = 6f;

    public bool speedPlatformLeft;
    public bool speedPlatformRight;
    public bool isBreakable;
    public bool isSpike;
    public bool isPlatform;

    private Animator animator;

    private void Awake()
    {
        if (isBreakable)
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 temp = transform.position;
        temp.y += moveSpeed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= boundY)
        {
            gameObject.SetActive(false);
        //    Object.Destroy(gameObject);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.5f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
            if (isSpike)
            {
                target.transform.position = new Vector2(1000f, 1000f);
                SoundManager.instance.GameOverSound();
                GameManager.instance.RestartGame();
            }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (isBreakable)
            {
                SoundManager.instance.LandSound();
                animator.Play("Break");
            }
            if (isPlatform)
                SoundManager.instance.LandSound();
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if (target.gameObject.tag == "Player")
        {
            if (speedPlatformLeft)
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-1f);
            if (speedPlatformRight)
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(1f);
        }
    }
}
