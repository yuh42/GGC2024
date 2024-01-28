using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{
    public List<Sprite> sprites;
    public RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        StartCoroutine(Animation_Coro());
    }

    IEnumerator Animation_Coro()
    {
        int index = 0;
        while (true)
        {
            image.texture = sprites[index].texture;
            yield return new WaitForSeconds(0.75f);
            index = (index + 1) % sprites.Count;
        }
    }
}
