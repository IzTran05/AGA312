using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public List<CardData> cardData;

    public CardData GetCard(CardID _cardID) => cardData.Find(x => x.cardID == _cardID);
}
