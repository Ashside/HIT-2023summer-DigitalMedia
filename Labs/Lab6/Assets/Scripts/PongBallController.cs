using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PongBallController : MonoBehaviour
{
    [FormerlySerializedAs("speed")] public float m_speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, m_speed * Time.deltaTime, 0);
    }



    private void OnCollisionStay2D(Collision2D other)
    {
        //Add bouncing behaviour to your pongBall when it hits a block.
        if (other.gameObject.CompareTag("Block"))
        {
            Destroy(other.gameObject);
            m_speed = -m_speed;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            m_speed = -m_speed;
        }
        if (other.gameObject.CompareTag("Wall"))
        {
            m_speed = -m_speed;
        }
    }
    
    
}
