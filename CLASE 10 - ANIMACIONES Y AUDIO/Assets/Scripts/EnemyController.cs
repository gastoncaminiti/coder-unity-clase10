using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speedEnemy = 3.0f;
    [SerializeField] private int    liveEnemy = 3;

    private GameObject player;
    private Rigidbody rbEnemy;

    void Start()
    {
        player = GameObject.Find("Player");
        rbEnemy = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Debug.Log("<color=#00FF00>FIX UPDATE: " + Time.deltaTime + "</color>");
        Vector3 playerDirection = GetPlayerDirection();
        rbEnemy.rotation = Quaternion.LookRotation(new Vector3(playerDirection.x, 0, playerDirection.z));
        rbEnemy.AddForce(playerDirection.normalized * speedEnemy);
        
    }

    private Vector3 GetPlayerDirection()
    {
        return player.transform.position - transform.position;
    }

}
