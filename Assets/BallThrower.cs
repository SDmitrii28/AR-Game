using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab;
    public float throwForce = 500f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward+ new Vector3(0,0,1) * throwForce);
    }
}
