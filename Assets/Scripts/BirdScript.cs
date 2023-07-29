using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    // References
    public Rigidbody2D myRigibody;
    public float flapStrength = 7;
    public LogicScript logic;
    public bool alive = true;

    // Sounds
    public AudioSource jump;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        jump = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Space) == true || Input.GetMouseButtonDown(0)) && alive) {
            myRigibody.velocity = Vector2.up * flapStrength;
            jump.Play();
        }

        if ((transform.position.y < -5 || transform.position.y > 5) && alive) {
            logic.gameOver(alive);
            alive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver(alive);
        alive = false;
    }
}
