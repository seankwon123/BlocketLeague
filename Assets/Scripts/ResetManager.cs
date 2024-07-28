using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static ResetManager Instance;

    [SerializeField] private GameObject car;
    [SerializeField] private GameObject ball;

    private Vector3 carStartPosition;
    private Vector3 ballStartPosition;
    private Quaternion carStartRotation;
    private Quaternion ballStartRotation;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            // DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Store the initial positions
        if (car != null) carStartPosition = car.transform.position;
        if (ball != null) ballStartPosition = ball.transform.position;
        if (car != null) carStartRotation = car.transform.rotation;
        if (ball != null) ballStartRotation = ball.transform.rotation;
    }

    public void ResetPositions()
    {
        if (car != null)
        {
            car.transform.position = carStartPosition;
            car.transform.rotation = carStartRotation;
            Rigidbody2D carRb = car.GetComponent<Rigidbody2D>();
            if (carRb != null)
            {
                carRb.velocity = Vector2.zero;
                carRb.angularVelocity = 0f;
            }
        }

        if (ball != null)
        {
            ball.transform.position = ballStartPosition;
            ball.transform.rotation = ballStartRotation;
            Rigidbody2D ballRb = ball.GetComponent<Rigidbody2D>();
            if (ballRb != null)
            {
                ballRb.velocity = Vector2.zero;
                ballRb.angularVelocity = 0f;
            }
        }
    }
}