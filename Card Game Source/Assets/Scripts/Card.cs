using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CARDS
{
    [CreateAssetMenu(fileName = "basic card",menuName = "Card/Card Básico")]
    public class Card : ScriptableObject
    {
        public string cardName;
        public string description;
        public int cost;
        public Sprite art;

    }
}
