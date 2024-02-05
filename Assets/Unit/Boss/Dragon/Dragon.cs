using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Boss
{
    [SerializeField] private GameObject head;
    [Range(0, 10)]
    [SerializeField] private float moveSpeed;
    [SerializeField] private List<Transform> movePos = new();
    [SerializeField] private List<Vector3> attackRange = new();

    [SerializeField] private float moveWaitTime;
    private WaitForSeconds moveWait;

    [SerializeField] private GameObject danger;

    protected override void Start()
    {
        base.Start();
        moveWait = new WaitForSeconds(moveWaitTime);
        StartCoroutine(nameof(BossPattern));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, attackRange[0]);
    }

    private IEnumerator BossPattern()
    {
        //while (true)
        //{
        yield return StartCoroutine(HorizontalAttack());
        //}
    }

    private IEnumerator HorizontalAttack()
    {
        Debug.Log("HorizontalAttack");
        GameObject spawnDanger = Instantiate(danger);
        spawnDanger.transform.position = transform.position;
        spawnDanger.transform.localScale = attackRange[0];
        yield return moveWait;

        float t = 0;

        Vector3 currentPos = head.transform.position;

        while (true)
        {
            float time = t / moveSpeed;
            for (int i = 0; i < movePos.Count - 1; i++)
            {
                Vector3 nextPos = movePos[i + 1].position;
                if (Vector3.Distance(transform.position, nextPos) > 0.5f)
                {
                    head.transform.position = Vector3.Lerp(currentPos, nextPos, time);
                    t += Time.deltaTime;
                    yield return null;
                }
                else
                {
                    currentPos = movePos[i].position;
                }
            }
            yield return null;
        }
    }
}
