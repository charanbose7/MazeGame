using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    public float horizontal;
    public float vertical;
    public Vector3 chutiya;
    public Text Score;
    public int score;
    private Renderer rend;
    public AudioSource CoinCollect;
    public AudioSource NegativePoint;
    public AudioSource Finish;
    void Start()
    {
        score = 0;
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        Score.text = score.ToString();
    }
    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Coin")
        {
            CoinCollect.Play();
            score++;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag=="Wall")
        {
            NegativePoint.Play();
            rend.material.color = Color.blue;
            score--;
        }
        if(collision.gameObject.tag=="Finish")
        {
            Finish.Play();
            SceneManager.LoadScene("Lv.2");
        }
    }
    
}

