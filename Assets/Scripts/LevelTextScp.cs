using UnityEngine;
using TMPro;

public class LevelTextScp : MonoBehaviour
{

    private void OnEnable()
    {
        GetComponent<TMP_Text>().text = "LEVEL " + (PlayerPrefs.GetInt("level") + 1);

    }

  

}
