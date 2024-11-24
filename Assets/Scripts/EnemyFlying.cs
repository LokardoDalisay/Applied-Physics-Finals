using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlying : MonoBehaviour
{
    public float speed = 5f;
    public GameObject player;
    public Transform last_pos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer() // 
    {
        Vector3 enemy_pos = new Vector3(player.transform.position.x, 0, transform.position.z);
        Vector3 player_pos = new Vector3(transform.position.x, 0, transform.position.z);
        float attack_distance = Vector3.Distance(enemy_pos, player_pos);
        float dot = enemy_pos.x * player_pos.x + enemy_pos.y * player_pos.y;
        float angle = Mathf.Acos(dot / (enemy_pos.magnitude * player_pos.magnitude));
        Vector3 enemy_to_player = player_pos - enemy_pos;

        if (attack_distance <= 5) //move towards the player
        {        
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); // chase the player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle); // rotate to player
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, last_pos.position, speed * Time.deltaTime);
        }
    }
}
