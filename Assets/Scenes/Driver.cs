using Unity.VisualScripting;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 6f;
    [SerializeField] float slowDownFactor = 4f;
    [SerializeField] float speedUpFactor = 9f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Collision detected with: " + other.gameObject.name);
            moveSpeed = slowDownFactor; // Slow down on collision
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("SpeedBoost"))
        {
            Debug.Log("Speed Boost Activated: " + other.gameObject.name);
            moveSpeed = speedUpFactor; // Speed up on trigger
        }
        else if (other.CompareTag("Package") || other.CompareTag("Customer"))
        {
            moveSpeed = 6f; // Reset speed when picking up a package or coming across a customer
            
        }
    }
}
