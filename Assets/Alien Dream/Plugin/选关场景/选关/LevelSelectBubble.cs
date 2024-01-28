using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectBubble : MonoBehaviour
{
    public List<Sprite> sprites;

    public Image image;
    public Image emojiImage;

    public static LevelSelectBubble instance {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        image.enabled = false;
        emojiImage.enabled = false;
        StartCoroutine(Animation_Coro());
    }

    IEnumerator Animation_Coro()
    {
        int index = 0;
        while (true)
        {
            image.sprite = sprites[index];
            yield return new WaitForSeconds(0.5f);

            // random sprite but not the same as previous one
            while(true){
                int newIndex = Random.Range(0, sprites.Count);
                if (newIndex != index)
                {
                    index = newIndex;
                    break;
                }
            }
        }
    }
}
