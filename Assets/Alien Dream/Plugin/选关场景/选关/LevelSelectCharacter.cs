using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LevelSelectCharacter : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject smallBubbles;
    private LevelSelectBubble bubble {get { return LevelSelectBubble.instance;}}

    public int LevelIndex;
    public Sprite emojiSprite;

    private Vector3 GetBubblePos() { return transform.GetChild(0).position; }

    public void OnPointerClick(PointerEventData eventData)
    {
        LevelManager.Instance.ChangeLevel(LevelIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        bubble.image.enabled = true;
        bubble.emojiImage.enabled = true;
        bubble.transform.position = GetBubblePos();
        bubble.emojiImage.sprite = emojiSprite;
        smallBubbles.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        bubble.image.enabled = false;
        bubble.emojiImage.enabled = false;
        smallBubbles.SetActive(false);
    }
}
