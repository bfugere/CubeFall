using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public float minX = -2.6f;
    public float maxX = 2.6f;
    public float minY = -8.0f;

    private bool outOfBounds;

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }
    
    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x < minX)
            temp.x = minX; 
        
        if (temp.x > maxX)
            temp.x = maxX;

        transform.position = temp;

        if (temp.y <= minY)
            if (!outOfBounds)
            {
                outOfBounds = true;
                SoundManager.instance.DeathSound();
                GameManager.instance.RestartGame();
            }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "TopSpike")
        {
            transform.position = new Vector2(1000f, 1000f);
            SoundManager.instance.DeathSound();
            GameManager.instance.RestartGame();
        }
    }
}
