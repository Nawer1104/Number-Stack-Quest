using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Block : MonoBehaviour
{
    public GameObject vfxFinish;

    public int uniqueId;

    private bool isClicked;

    public bool canClick;

    private void Awake()
    {
        isClicked = false;

        canClick = true;
    }

    private void OnMouseDown()
    {
        if (isClicked || !canClick) return;

        isClicked = true;

        List<Block> blockListWithId = GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].GetAListOfBlocksWithUniqueId(this.uniqueId);

        int numberToLoop = 4;

        if (blockListWithId.Count < 4)
            numberToLoop = blockListWithId.Count;

        for (int i = 0; i < numberToLoop; i++)
        {
            blockListWithId[i].PlayVfx();
            PlayVfx();
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(blockListWithId[i].gameObject);
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            gameObject.SetActive(false);
            blockListWithId[i].gameObject.SetActive(false);
        }

        GameManager.Instance.CheckLevelUp();
    }

    public void PlayVfx()
    {
        GameObject vfx = Instantiate(vfxFinish, transform.position, Quaternion.identity) as GameObject;
        Destroy(vfx, 1f);
    }
}
