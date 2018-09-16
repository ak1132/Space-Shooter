using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour {

    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    private void Start()
    {
        GameObject gameObject = GameObject.FindWithTag("GameController");
        if(gameObject!=null)
        {
            gameController = gameObject.GetComponent<GameController>();
        }
        if(gameController == null)
        {
            Debug.Log("Cannot find the game controller script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Boundary")
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.gameOver();
        }
        gameController.addScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
