using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{
    int speed = 10;
    int SpaceCount = 10;
    int powercount;
    int enemycount;

    public Text GameScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        powercount = GameObject.FindGameObjectsWithTag("Power").Length;
        enemycount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if(powercount == 0)
        {
            Debug.Log("Going OVER to new SCENE NOW! When the power up is all taken.");
            SceneManager.LoadScene("WinScene");
        }

        if (enemycount == 0)
        {
            SceneManager.LoadScene("EndScene");
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if ( Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpaceCount--;
            GameScore.GetComponent<Text>().text = ("Game Score : " + SpaceCount.ToString());

            if(SpaceCount == 0)
            {
                Debug.Log("Going OVER to new SCENE NOW!");
                SceneManager.LoadScene("EndScene");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Power"))
        {
            powercount --;
            SpaceCount += 1; ;
            GameScore.GetComponent<Text>().text = ("Game Score : " + SpaceCount.ToString());
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }
}
