using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class Outfitter : MonoBehaviour
{
    private List<SpriteResolver> resolvers;
    private CharacterType charType;

    private enum CharacterType
    {
        Ork,
        Bandit
    }

    private void Awake()
    {
        resolvers = GetComponentsInChildren<SpriteResolver>().ToList();
    }

    private void Start()
    {
        ChangeOutfit();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            charType = charType == CharacterType.Ork ? CharacterType.Bandit : CharacterType.Ork;
            ChangeOutfit();
        }
    }

    private void ChangeOutfit()
    {
        foreach (SpriteResolver resolver in resolvers) 
        {
            resolver.SetCategoryAndLabel(resolver.GetCategory(), charType.ToString());

            if (resolver.GetCategory() == "Weapon")
            {
                resolver.gameObject.SetActive(resolver.GetLabel() == "Bandit");
            }

            Sprite sprite = resolver.spriteLibrary.GetSprite(resolver.GetCategory(), resolver.GetLabel());
        }
    }
}
