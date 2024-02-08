using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Boss
{
    private const string HorizontalAttack = "HorizontalAttack";
    [SerializeField] private Transform head;
    [Range(0, 100)]
    [SerializeField] private float moveSpeed;

    protected override void Start()
    {
        base.Start();
        StartCoroutine(nameof(BossPattern));
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        head.transform.Translate(new Vector3(-h, v, 0) * Time.deltaTime * moveSpeed);
    }

    private IEnumerator BossPattern()
    {
        StartCoroutine(nameof(HorizontalAttackPattern));
        yield return null;
    }

    IEnumerator HorizontalAttackPattern()
    {
        //GameObject dangerObject1 = Instantiate(bossPatternData[0].danger);
        //GameObject dangerObject2 = Instantiate(bossPatternData[0].danger);
        //dangerObject2.transform.position = new Vector3(0, 0, -3);
        //WaitForSeconds attackWait = new(2);
        //yield return attackWait;
        //Destroy(dangerObject1);
        //Destroy(dangerObject2);

        while (true)
        {
            for (int i = 0; i <= bossPatternData[0].movePos.Count - 1; i++)
            {
                Debug.Log(i);
                if (Vector3.Distance(head.transform.position, bossPatternData[0].movePos[i].position) > 0.5f)
                {
                    head.transform.position = Vector3.Lerp(head.transform.position, bossPatternData[0].movePos[i].position, Time.deltaTime * moveSpeed);
                    yield return null;
                }
            }
        }
    }
}
