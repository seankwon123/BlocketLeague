using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetManager : MonoBehaviour
{
    public static ResetManager Instance;

    [SerializeField] private GameObject car1;
    [SerializeField] private GameObject car2;
    [SerializeField] private GameObject ball;

    private Vector3 carStartPosition;
    private Vector3 ballStartPosition;
    private Quaternion carStartRotation;
    private Quaternion ballStartRotation;

    private Vector3 car2StartPosition;
    private Quaternion car2StartRotation;


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
        if (car1 != null) carStartPosition = car1.transform.position;
        if (ball != null) ballStartPosition = ball.transform.position;
        if (car1 != null) carStartRotation = car1.transform.rotation;
        if (ball != null) ballStartRotation = ball.transform.rotation;

        if (car2 != null) car2StartPosition = car2.transform.position;
        if (car2 != null) car2StartRotation = car2.transform.rotation;

    }

    public void ResetPositions()
    {
        if (car1 != null)
        {
            car1.transform.position = carStartPosition;
            car1.transform.rotation = carStartRotation;
            Rigidbody2D carRb = car1.GetComponent<Rigidbody2D>();
            if (carRb != null)
            {
                carRb.velocity = Vector2.zero;
                carRb.angularVelocity = 0f;
            }
        }

        if (car2 != null)
        {
            car2.transform.position = car2StartPosition;
            car2.transform.rotation = car2StartRotation;
            Rigidbody2D carRb = car2.GetComponent<Rigidbody2D>();
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