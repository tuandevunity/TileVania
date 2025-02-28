using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScencePersist : MonoBehaviour
{
    // Start is called before the first frame update
    private static ScencePersist instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void ResetScenePersist()
    {
        Destroy(gameObject);
    }
}
