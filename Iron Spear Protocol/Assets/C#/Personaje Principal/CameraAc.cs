using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAc : MonoBehaviour
{
    Transform player;
    public float yDistance = 6f;
    public float yMovement = 12f;

    public float xDistance = 11f;
    public float xMovement = 22f;

    public Vector2 cameraOrigin;
    public Vector3 cameraDestination;

    public float movementTime = 0.5f;
    public bool isMoving;

    // EnemySceneCont enemySceneControl;
    void Start()
    {
        player = FindObjectOfType<SierraPlayer>().transform;
        //enemySceneControl = FindObjectOfType<EnemySceneCont>();
    }

    void Update()
    {
        if (!isMoving)
        {
            if (player.position.y - transform.position.y >= yDistance)
            {
                cameraDestination += new Vector3(0f, yMovement, 0f);
                StartCoroutine(MoveCamera());
            }
            else if (transform.position.y - player.position.y >= yDistance)
            {
                cameraDestination -= new Vector3(0f, yMovement, 0f);
                StartCoroutine(MoveCamera());

            }
            else if (player.position.x - transform.position.x >= xDistance)
            {
                cameraDestination += new Vector3(xMovement, 0f, 0f);
                StartCoroutine(MoveCamera());

            }
            else if (transform.position.x - player.position.x >= xDistance)
            {
                cameraDestination -= new Vector3(xMovement, 0f, 0f);
                StartCoroutine(MoveCamera());

            }
        }
    }

    IEnumerator MoveCamera()
    {
        isMoving = true;
        var currentPos = transform.position;
        var t = 0f;

        //enemySceneControl.StopAllEnemies(currentPos);
        while (t < 1)
        {
            t += Time.deltaTime / movementTime;
            transform.position = Vector3.Lerp(currentPos, cameraDestination, t);
            transform.position = new Vector3(transform.position.x, transform.position.y, currentPos.z);
            yield return null;
        }
        isMoving = false;
        //transform.position = new Vector3(cameraDestination.x, cameraDestination.y, currentPos.z);
        //enemySceneControl.ResetPositionAllEnemies(currentPos);
        //enemySceneControl.ActivateAllEnemies(cameraDestination);
    }
}
