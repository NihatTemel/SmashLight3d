using UnityEngine;
using TMPro;

public class LevelTextScp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TMP_Text>().text = "LEVEL " + (PlayerPrefs.GetInt("level") + 1);
    }

}
