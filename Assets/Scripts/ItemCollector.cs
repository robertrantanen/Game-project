using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    int coins = 0;
    public Text coinsText;
    public Text goalText;
    public AudioSource collectionSound;
    public int maximum = 0;

    void Start()
    {
        coinsText.text = "Food: " + coins + " / " + maximum;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coins++;
            coinsText.text = "Food: " + coins + " / " + maximum;
            collectionSound.Play();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Goal")
        {
            if (coins >= maximum)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                goalText.text = "Not enough food!";
                Invoke("setEmpty", 5.0f);
            }
        }
    }


    void setEmpty()
    {
        goalText.text = "";
    }


}
