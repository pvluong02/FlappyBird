using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public bool enableSpawnerPipe;

    public GameObject PipePrefab;
    public Transform MainCamera;
    private float countDown;
    public float timeDuration;

    public float distaceLimit = 5f;
    public float distace;


    private void Awake()
    {
        enableSpawnerPipe = false;
        countDown = timeDuration;
    }


    private void Update()
    {
        Despawnning();
        Spawner();
    }

    private void Spawner()
    {
        if(enableSpawnerPipe == true)
        {
            countDown -= Time.deltaTime;
            if (countDown <= 0)
            {
                Instantiate(PipePrefab, new Vector2(4, Random.Range(-1.40f, 1.47f)), Quaternion.identity);
                countDown = timeDuration;
            }
        }
    }

    private void DespawnObject()
    {
        Destroy(PipePrefab);
    }

    private void Despawnning()
    {
        if (!this.canDespawn())
        {
            this.DespawnObject();
        }
    }
    private bool canDespawn()
    {
        this.distace = Vector3.Distance(PipePrefab.transform.position, MainCamera.position);
        if (this.distace > distaceLimit)
        {
            return true;
        } return false;
    }

}
