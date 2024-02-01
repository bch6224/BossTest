using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonMoveMent : MonoBehaviour
{
    #region º¯¼ö
    [SerializeField] private float moveInterval;
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<Transform> movePosList = new();
    private Transform[] bodys;
    #endregion

    private void Awake()
    {
        bodys = GetComponentsInChildren<Transform>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        for (int i = bodys.Length - 1; i > 1; i--)
        {
            Vector3 childPos = bodys[i].position;
            Vector3 parentsPos = bodys[i - 1].position;

            Vector3 dir = childPos - parentsPos;
            dir.Normalize();
            //Debug.Log(Vector3.Distance(bodys[i].position, bodys[i - 1].position));

            if (Vector3.Distance(childPos, parentsPos) > moveInterval)
            {
                bodys[i].transform.LookAt(parentsPos);
                bodys[i].position = Vector3.Lerp(childPos, parentsPos, moveSpeed * Time.deltaTime);
            }

        }
    }
}
