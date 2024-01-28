using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComicPlayer : MonoBehaviour
{
    public List<Sprite> sprites;

    Image image_L;
    Image image_R;

    // Start is called before the first frame update
    void Start()
    {
        image_L = transform.Find("L").GetComponent<Image>();
        image_R = transform.Find("R").GetComponent<Image>();

        Debug.Assert(sprites.Count > 0);
        Debug.Assert(sprites.Count % 2 == 0);

        StartCoroutine(Play_Coro());
    }

    IEnumerator Play_Coro()
    {
        for(int i=0; i<sprites.Count; i+=2){
            image_L.color = new Color(1,1,1,0);
            image_R.color = new Color(1,1,1,0);

            image_L.sprite = sprites[i];
            image_R.sprite = sprites[i+1];

            const float SPEED = 2.0f;

            // tween L to 1.0a
            image_L.color = new Color(1,1,1,0);
            for(float t=0; t<1.0f; t+=Time.deltaTime * SPEED){
                image_L.color = new Color(1,1,1,t);
                yield return null;
            }

            // tween R to 1.0a
            image_R.color = new Color(1,1,1,0);
            for(float t=0; t<1.0f; t+=Time.deltaTime * SPEED){
                image_R.color = new Color(1,1,1,t);
                yield return null;
            }

            // wait for any key down
            while(!Input.anyKeyDown){
                yield return null;
            }
        }
        LevelManager.Instance.Jump(2);
    }
}
