using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class RedEyes : Item
{
    bool bOnDestroy = false;
    public override void OnClick()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetComponent<CircleCollider2D>().enabled = false;
        if (Level1Manager.Instance.DestroyEye())
        {
            ReadyDestroy();
            return;
        }
        Level1Manager.Instance.OnEyesDestroyEvent += ReadyDestroy;

    }

    void ReadyDestroy()
    {
        Destroy(gameObject, 0.8f);
        bOnDestroy = true;
    }

    private void Update()
    {
        if (bOnDestroy)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.1f, 0.1f, 1), Time.deltaTime/0.2f);
        }

    }
}
