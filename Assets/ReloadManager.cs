using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 playerPosition;
    [SerializeField]
    private bool hasCheckpoint = false;

    private static ReloadManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(Vector3 checkpointPosition)
    {
        playerPosition = checkpointPosition;
        hasCheckpoint = true;
    }

    public void RestorePlayerPosition(Transform playerTransform)
    {
        if (hasCheckpoint)
        {
            playerTransform.position = playerPosition;
        }
    }
}
