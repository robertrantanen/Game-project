using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private bool dead = false;

    public AudioSource dedSound;

    void Update()
    {
        if (transform.position.y < -2f && !dead)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy body"))
        {
            //GetComponent<MeshRenderer>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<PlayerMovement>().enabled = false;
            transform.eulerAngles = new Vector3(-90, transform.eulerAngles.y, transform.eulerAngles.z);
            GetComponent<Animator>().SetBool("Jump", true);
            //transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
            //transform.GetChild(1).GetComponent<MeshRenderer>().enabled = false;

            Die();
        }
    }

    private void Die()
    {
        Invoke(nameof(ReloadLevel), 1.5f);
        dead = true;
        dedSound.Play();
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
