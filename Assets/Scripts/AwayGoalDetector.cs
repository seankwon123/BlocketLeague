using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwayScoringWall : MonoBehaviour
{
    [SerializeField] private string ballTag = "Ball"; // Set this to match your ball's tag

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ballTag))
        {
            // Ball has hit the wall, increment the score
            ScoreManager.Instance.IncrementAwayScore();
            Debug.Log("AWAY GOAL");
            
            StartCoroutine(WaitABit());

            ResetManager.Instance.ResetPositions();
        }
    }


    IEnumerator WaitABit()
    {
        yield return new WaitForSeconds(2.0f);
    }

}