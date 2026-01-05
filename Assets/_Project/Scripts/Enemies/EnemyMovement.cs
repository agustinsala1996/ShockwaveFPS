using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null)
            return;

        Vector3 direction = (player.position - transform.position).normalized;
        direction.y = 0f; // evita que vuele o se incline

        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}