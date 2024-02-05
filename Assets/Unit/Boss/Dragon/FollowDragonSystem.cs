using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDragonSystem : MonoBehaviour
{
    #region º¯¼ö
    [SerializeField] private float moveInterval;
    [SerializeField] private float followSpeed;
    private Transform[] bodys;
    #endregion

    private void Awake()
    {
        bodys = GetComponentsInChildren<Transform>();
    }

    private void FixedUpdate()
    {
        BossAnim();
    }

    private void BossAnim()
    {
        for (int i = bodys.Length - 1; i > 1; i--)
        {
            Vector3 childPos = bodys[i].position;
            Vector3 parentsPos = bodys[i - 1].position;

            if (Vector3.Distance(childPos, parentsPos) > moveInterval)
            {
                bodys[i].transform.LookAt(parentsPos);
                bodys[i].position = Vector3.Lerp(childPos, parentsPos, followSpeed * Time.deltaTime);
            }

        }
    }
}
