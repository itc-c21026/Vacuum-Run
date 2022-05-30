using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicInstantiate : MonoBehaviour
{
    public GameObject SoundPrefab;
    void Update()
    {
        if (Input.GetKeyDown("s"))//このif文の中身とか変えたり、Instantiateのとこだけとかここからコピペして使ってね
        {
            Instantiate(SoundPrefab, new Vector3(0, 0, 0),
                    Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
