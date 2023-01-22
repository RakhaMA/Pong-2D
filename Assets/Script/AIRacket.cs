using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    Rigidbody2D rb;

    [Header("Npc Setting")]
    public float speed;
    public float delayMove;

    private bool isMoveAI; // Check apakah raket bergerak atau tidak
    private float randomPos; // -1 ke 1
    private bool isSingleTake;
    private bool isUp;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameData.instance.isSinglePlayer)
        {
            // ! = invert == False
            if (!isMoveAI && !isSingleTake)
            {
                Debug.Log("kepanggil");

                StartCoroutine("DelayAIMove");
                isSingleTake = true;
            }

            if (isMoveAI)
            {
                MoveAI();
            }
        }
    }

    private IEnumerator DelayAIMove()
    {
        yield return new WaitForSeconds(delayMove); // menunggu waktu dari delayMove yg kita setting
        randomPos = Random.Range(-1f, 1f);

        if (transform.position.y < randomPos)
        {
            isUp = true;
        }
        else
        {
            isUp = false;
        }

        isSingleTake = false;
        isMoveAI = true;
    }

    private void MoveAI()
    {
        // ! = invert == False
        if (!isUp) // Raket ke arah bawah
        {
            rb.velocity = new Vector2(0, -1) * speed; // Velocity = Acc -> Vector2 x=0, y=-1
            if (transform.position.y <= randomPos) //posisi raket apakah sudah sampai di posisi random yg baru
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }

        if (isUp)
        {
            rb.velocity = new Vector2(0, 1)* speed;
            if(transform.position.y >= randomPos)
            {
                rb.velocity = Vector2.zero;
                isMoveAI = false;
            }
        }
    }
}
