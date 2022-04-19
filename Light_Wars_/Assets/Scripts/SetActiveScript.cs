using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetActiveScript : MonoBehaviour
{
    public void ShowActive(GameObject obj)
    {
        obj.SetActive(true);
    }

    public void EndScreenLoad()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
