using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallControls : MonoBehaviour
{
    //Instructions
    public GameObject quit;
    public GameObject instruc;
    public GameObject objective;
    //audio
    public AudioClip drop;
    public AudioClip bump;
    public AudioClip goal;
    AudioSource audio;

    //Physics & Score
    public manager manager;
    public int score;
    [SerializeField]
    public float movementSpeed = 6;
    [SerializeField]
    bool move = true;
    public float maxLeft = -12f;
    public float maxRight = 12f;
    public float forceRange = 5f;
    public float torque = 5f;
    public float reset = 7;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();   
    }
    void Update()
    {
        if(move)
        {
            
            Vector3 moveOffset = Vector3.zero;
            moveOffset.x = Input.GetAxis("Horizontal");
            moveOffset.x = moveOffset.x * Time.deltaTime * movementSpeed;
            //transform.position += moveOffset;

            //Set position and limits on x axis
            Vector3 position = transform.position + moveOffset;
            if (position.x > maxRight){position.x = maxRight;}
            if (position.x < maxLeft){position.x = maxLeft;}
            transform.position = position;


            //drop ball, add starting force and torque
            if (Input.GetKeyDown(KeyCode.Space))
            {
                quit.SetActive(false);
                instruc.SetActive(false);
                objective.SetActive(false);  
                audio.clip = drop;
                audio.Play();
                move = false;
                var rigidBod = GetComponent<Rigidbody>();
                rigidBod.isKinematic = false;
                rigidBod.AddForce(Random.Range(-forceRange, forceRange), 0, 0,ForceMode.Impulse);
                rigidBod.AddTorque(torque, 0, 0, ForceMode.Impulse);
            }

            // Display the score onscreen
            //print(score);
            Text currentScore = GameObject.Find("Canvas/Score").GetComponent<Text>();
            currentScore.text = "Score: " + score.ToString();
        }
        manager.getScore = score;

    }
    //Reset position upon hitting the floor
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "board")
        {
            //print("bump!");
            audio.clip = bump;
            audio.volume = 0.5f;
            audio.Play();
        }

        if(collision.gameObject.tag == "floor")
        {
            move = true;
           GetComponent<Rigidbody>().isKinematic = true;
            transform.position = new Vector3(0, reset, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);

        }
    }
    //Add score on trigger
    private void OnTriggerEnter(Collider collision)
    {
        audio.clip = goal;
        audio.Play();
        if (collision.gameObject.tag == "1000") { score += 1000; }
        if (collision.gameObject.tag == "500") { score += 500;}
        if (collision.gameObject.tag == "100") { score += 100;}
    }


    
}
