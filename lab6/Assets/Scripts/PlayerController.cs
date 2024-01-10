using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float m_speed = 5f;
    Transform m_transform;
    public GameObject m_pongBallPrefab;
    void Start() {
        m_transform = GetComponent<Transform>();
    }

	void Update () {
        // TODO move input into a different component at some point

        float deltaX = 0f;
        if (Input.GetKey(KeyCode.A)) {
            deltaX -= 1f;
        }

        if (Input.GetKey(KeyCode.D)) {
            deltaX += 1f;
        }

        m_transform.Translate(new Vector3(deltaX, 0f, 0f) * Time.deltaTime * m_speed);
	}
    void FixedUpdate() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Instantiate(m_pongBallPrefab, m_transform.position, Quaternion.identity);
        }
    }
    
}
