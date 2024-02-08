using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDragonSystem : MonoBehaviour
{
    #region º¯¼ö
    [SerializeField] private float moveInterval;
    [Range(0, 50)]
    [SerializeField] private float followSpeed;
    [SerializeField] private Transform[] bodys;
    #endregion

    private void FixedUpdate()
    {
        BossAnim();
    }

    private void BossAnim()
    {
        for (int i = 0; i < bodys.Length - 1; i++)
        {
            Vector3 parentPos = bodys[i].position;
            Vector3 childPos = bodys[i + 1].position;

            //bodys[i + 1].transform.LookAt(parentPos);
            //bodys[i + 1].transform.eulerAngles = new Vector3(transform.eulerAngles.x - 90, transform.eulerAngles.y - 90, transform.eulerAngles.z);
            if (Vector3.Distance(parentPos, childPos) > moveInterval)
            {
                bodys[i + 1].position = Vector3.Lerp(parentPos, childPos, followSpeed * Time.deltaTime);
            }
        }
    }
}
