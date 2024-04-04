using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite appleSprite;
    [SerializeField] private Sprite blueberrySprite;

    private bool isApple;

    public void Destroy()
    {
        GameManager.Destroy(gameObject);
    }

    public void DeleteNote()
    {
        GameManager.instance.CalculateScore(isApple);
        Destroy();
    }

    public void SetSprite(bool isApple)
    {
        this.isApple = isApple;
        spriteRenderer.sprite = isApple ? appleSprite : blueberrySprite;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
