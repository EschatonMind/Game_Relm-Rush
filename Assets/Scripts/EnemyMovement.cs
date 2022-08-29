using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] ParticleSystem suicideparticells;
    [SerializeField] float Secondsbetweenspawns;
    // Use this for initialization
    void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

    IEnumerator FollowPath(List<Waypoint> path)
    {
        print("Starting patrol...");
        foreach (Waypoint waypoint in path)
        {
            transform.position = waypoint.transform.position;
            yield return new WaitForSeconds(Secondsbetweenspawns);
        }
        Selfdistruct();
    }
    private void Selfdistruct()
    {
        // important to instantiate before destroying this object
        var vfx = Instantiate(suicideparticells, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject); // the enemy
    }
}
