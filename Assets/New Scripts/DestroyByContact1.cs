using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact1 : MonoBehaviour
{
    public GameObject asteroidExplosion, playerExplosion;
    private GameController1 gameController;

    public int scoreValue;

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController1>();
        }
        else {
            Debug.Log("Cannot find 'GameController'");
        }
    }
    private void OnTriggerEnter(Collider other) {

        if (other.tag == "Boundary1") {
            return;
        }
        // Debug.Log(other.name);
        Instantiate(asteroidExplosion, transform.position, transform.rotation);
        gameController.AddScore(scoreValue);
        if (other.tag == "Player1") {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
