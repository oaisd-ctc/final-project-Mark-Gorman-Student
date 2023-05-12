using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FoldoutMenu : MonoBehaviour
{

    [SerializeField] List<Transform> waypoints;
    [SerializeField] float speed;
    [SerializeField] bool hidden = false;
    [SerializeField] GameObject hello;
    bool arrived = false;

    public void FollowPath()
    {
        EventSystem.current.SetSelectedGameObject(null);
        if (!hidden)
        {
            float delta = speed * Time.deltaTime;
            while (!arrived)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[1].position, delta);
                if (transform.position == waypoints[1].position)
                {
                    arrived = true;
                    hello.transform.localScale = new Vector3(-1, -1, 1);
                }
            }
            arrived = false;
            hidden = true;
        }
        else if (hidden)
        {
            float delta = speed * Time.deltaTime;
            while (!arrived)
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[0].position, delta);
                if (transform.position == waypoints[0].position)
                {
                    arrived = true;
                    hello.transform.localScale = new Vector3(1, 1, 1);
                }
            }
            arrived = false;
            hidden = false;
        }
    }
}
