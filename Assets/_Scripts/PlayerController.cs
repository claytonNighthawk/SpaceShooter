using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary {
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    private Rigidbody rb;
    private AudioSource fireSound;
    private float nextFire;

    public float speed;
    public float tilt;
    public Boundary boundary;
    public float fireRate;
    public GameObject shot;
    public Transform shotSpawner;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
        fireSound = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetButton("Jump") && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawner.position, Quaternion.identity);
            fireSound.Play();
        }
    }

    void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.velocity = speed * movement;

        Vector3 bounds = new Vector3(
            (Mathf.Clamp(rb.position.x, boundary.xMin, boundary.xMax)), 
            0.0f, 
            (Mathf.Clamp(rb.position.z, boundary.zMin, boundary.zMax)));
        rb.position = bounds;

        rb.rotation = Quaternion.Euler(0.5f * (rb.velocity.z * tilt), 0.0f, (rb.velocity.x * -tilt));


    }
}
