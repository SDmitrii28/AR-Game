using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public GameObject ballPrefab;
    public float throwForce = 500f;
    public BasketPlacer _basketPlacer;
    void Update()
    {
        if (_basketPlacer.basketPlaced && Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * throwForce);
    }
}
