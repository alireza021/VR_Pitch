using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyStart : MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="StartBall") {
            SceneManager.LoadScene(1);
            Debug.Log("start"); 
        }
    }
}
