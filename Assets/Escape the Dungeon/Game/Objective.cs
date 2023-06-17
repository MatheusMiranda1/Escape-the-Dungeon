using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    private bool keycollected;

    // Start is called before the first frame update
    void Start()
    {
        keycollected = false;
    }

    public string keyTag = "Key";
    public string ExitTag = "Finish";
    public GameObject Zombie1;
    public GameObject Zombie2;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(keyTag))
        {
            keycollected = true;
            Zombie1.SetActive(true);
            Zombie2.SetActive(true);
        }

        if (other.CompareTag(ExitTag))
        {
            if(keycollected)
            {
                SceneManager.LoadScene("Menu");
                Debug.Log("You Win!");
            }
        }
    }
}
