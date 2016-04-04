using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyPrefab;
    public float width = 10f;
    public float height = 5f;
    public float moveSpeed = 2f;
    public float spawnDelay = 10f;
    private bool movingRight = false;

    float xmin;
    float xmax;
	// Use this for initialization
	void Start () {
        float distance = transform.position.z - Camera.main.transform.position.z;
        Vector3 leftMost = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightMost = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, distance));
        xmin = leftMost.x;
        xmax = rightMost.x;

        SpawnUntilFull();
	}

    void SpawnEnemies()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = Instantiate(enemyPrefab, child.transform.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = child;
        }
    }

    void SpawnUntilFull()
    {
        Transform nextFreePosition = NextPositionFree();
        if (nextFreePosition) { 
            GameObject enemy = Instantiate(enemyPrefab, nextFreePosition.position, Quaternion.identity) as GameObject;
            enemy.transform.parent = nextFreePosition;
        }

        if (nextFreePosition) { 
            Invoke("SpawnUntilFull", spawnDelay); 
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (!movingRight)
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        float rightEdgoeOfFormat = transform.position.x + (width/2);
        float leftEdgoeOfFormat = transform.position.x - (width/2) ;
        if(leftEdgoeOfFormat <= xmin )
        {
            movingRight = false;
        }
	    else if (rightEdgoeOfFormat >= xmax)
	    {
            movingRight = true;
	    }

        if (AllMembersDead())
        {
            SpawnUntilFull();
        }
	}

    Transform NextPositionFree()
    {
        foreach (Transform childPositioninGameObject in transform)
        {
            if (childPositioninGameObject.childCount == 0)
            {
                return childPositioninGameObject;
            }

        }

        return null;
    }

    private bool AllMembersDead()
    {
        foreach (Transform childPositioninGameObject in transform)
        {
            if(childPositioninGameObject.childCount > 0)
            {
                return false;
            }
                   
        }

        return true;
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(width,height,0));
    }
}
