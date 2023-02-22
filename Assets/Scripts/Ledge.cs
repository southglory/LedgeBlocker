using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Ledge : MonoBehaviour
{
    public int blockCount;
    public float blockSize;
    public int nowBlock;


    Block[] blocks;

    // Start is called before the first frame update
    void Start()
    {
        blocks = GetComponentsInChildren<Block>();
    }

    public void Align()
    {
        blockCount = blocks.Length;
        if (blockCount == 0 )
        {
            Debug.Log("Not founded Blocks!");
            return;
        }

        blockSize = blocks[0].GetComponentInChildren<BoxCollider>().transform.localScale.z;

        for (int index = 0; index < blockCount; index++)
        {
            blocks[index].transform.Translate(0, 0, index * blockSize * -1);
            blocks[index].Init();
        }
    }


    IEnumerator Move()
    {
        //float nextZ = transform.position.z + 2;
        //while (transform.position.z < nextZ)
        //{
        //    yield return null;
        //    transform.Translate(0, 0, Time.deltaTime * 15f);
        //}

        //transform.position = Vector3.forward  * nextZ;

        yield return new WaitForFixedUpdate();
        transform.position = Vector3.Lerp(transform.position, transform.position + Vector3.forward * 2f, 1);

        nowBlock = (nowBlock + 1) % blockCount;
    }

    public void Select(int selectType)
    {
        bool result = blocks[nowBlock].Check(selectType);

        if (result)
        {// 정답
            GameManager.Success();
            StartCoroutine(Move());
        }
        else
        {// 오답
            GameManager.Fail();
        }
    }
}
