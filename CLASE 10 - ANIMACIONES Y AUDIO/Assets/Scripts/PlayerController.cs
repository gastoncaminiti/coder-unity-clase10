using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int lifePlayer = 3;
    [SerializeField] private string namePlayer = "Mr. Blue";
    [SerializeField] private float cameraAxisX = -90f;
    [SerializeField] private float speedPlayer = 1f;
    [SerializeField] private Vector3 swordPosition = new Vector3(0, 0, 0.3f);
    [SerializeField] private GameObject swordPlayer;
    // Start is called before the first frame update
    void Start()
    {
        swordPlayer.GetComponent<SwordController>().SetSwordName("Espadon 9000");
        swordPlayer.transform.position = transform.position + swordPosition;
        swordPlayer.transform.localScale = transform.localScale;
    }
    void Update()
    {
      Move();
      RotatePlayer();
    }
    private void Move()
    {
        float ejeHorizontal = Input.GetAxisRaw("Horizontal");
        float ejeVertical = Input.GetAxisRaw("Vertical");
        transform.Translate(speedPlayer * Time.deltaTime * new Vector3(ejeHorizontal, 0, ejeVertical));
    }
    private void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion angulo   = Quaternion.Euler(0, cameraAxisX, 0);
        transform.localRotation = angulo;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag("Generator"))
        {
            Destroy(other.gameObject);
        }
    }
}
