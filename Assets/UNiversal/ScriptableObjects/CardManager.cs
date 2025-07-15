using UnityEngine;
using System.Collections.Generic;
using System.Collections;

/*public class CardManager : MonoBehaviour
{
    public List<CardData> cardData;
    public Card cardPrefab;
    public List<Card> cardsInHand;
    public int handCount = 4;

    public CardData GetCard(CardID _cardID) => cardData.Find(x => x.cardID == _cardID);

    private void BuildDeck()
    {
        ListX.DestroyList(cardsInHand);
        ListX.ShuffleList(cardData);

        for(int i=0; i < cardData.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(i + 2, 0, 0), transform.rotation);
            newCard.GetComponent<Card>().Initialize(cardData[i]);
            cardsInHand.Add(newCard.GetComponent<Card>());
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
            BuildDeck();
    }
}*/
