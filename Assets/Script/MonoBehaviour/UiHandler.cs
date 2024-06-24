using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class UiHandler : MonoBehaviour
{
    // Gameplay Related Ui

    [Header("=== GameplayButtons ===")]
    [SerializeField] Button NewDeal;

    [Header("=== Card ===" )]
    [SerializeField] public GameObject Card_0;
    [SerializeField] public GameObject Card_1;
    [SerializeField] public GameObject Card_2;

    [Header("=== Deck Text===")]
    [SerializeField] public TextMeshProUGUI deckText;
    
    [Header("=== Deal Times Text===")]
    [SerializeField] public TextMeshProUGUI dealTimes;

    [Header("=== Card Phase Ui ===")]
    [SerializeField] public GameObject CardPhaseUI;

    [Space]
    [Space]
    [Space]

    // Visual Related Ui 
    [Header("=== Card Image ===" )]
    public List<Image> AllCardImage;
    [SerializeField] Image CardImage_0;
    [SerializeField] Image CardImage_1;
    [SerializeField] Image CardImage_2;

    [Header("=== Card Name ===")]
    public List<TextMeshProUGUI> AllTmp;
    [SerializeField] TextMeshProUGUI CardTmp_0;
    [SerializeField] TextMeshProUGUI CardTmp_1;
    [SerializeField] TextMeshProUGUI CardTmp_2;

    [Header("=== Card Rarity Image ===")]
    public List<Image> AllCardRarityImage;
    [SerializeField] Image CardRarity_0;
    [SerializeField] Image CardRarity_1;
    [SerializeField] Image CardRarity_2;

    [Header("=== Card TextBox ===")]
    public List<GameObject> AllTextBox;
    [SerializeField] public GameObject TextBox_0;
    [SerializeField] public GameObject TextBox_1;
    [SerializeField] public GameObject TextBox_2;

    [Header("=== Card Text===")]
    public List<TextMeshProUGUI> AllDescription;
    [SerializeField] TextMeshProUGUI Description_0;
    [SerializeField] TextMeshProUGUI Description_1;
    [SerializeField] TextMeshProUGUI Description_2;

    [Space]
    [Space]
    [Space]

  
   


   
    

    // Debug Related Ui
    [Header("=== Debug State ===")]
    [SerializeField] public TextMeshProUGUI DebugGameState;


    // DeckHandler Reference // 
    [SerializeField] DeckHandler deckHandler;
  

    void Start()
    {
        AllCardImage = new List<Image>
        {
            CardImage_0,
            CardImage_1,
            CardImage_2,
        };

        AllTmp = new List<TextMeshProUGUI>
        {
            CardTmp_0,
            CardTmp_1,
            CardTmp_2,
        };

        AllCardRarityImage = new List<Image>
        {
            CardRarity_0,
            CardRarity_1,
            CardRarity_2,
        };

        AllTextBox = new List<GameObject>
        {
            TextBox_0,
            TextBox_1,
            TextBox_2,
        };

        AllDescription = new List<TextMeshProUGUI>
        {
            Description_0,
            Description_1,
            Description_2,
        };


    }

    void Update()
    {
      
    }


    public void DisplayingCardsUi()
    {

        for (int i = 0 ; i < AllCardImage.Count; i++)
        {
            AllCardImage[i].sprite = deckHandler.Maindeck.CardsInDeck[i].CardVisual;
            AllTmp[i].text = deckHandler.Maindeck.CardsInDeck[i].Name;
            AllDescription[i].text = deckHandler.Maindeck.CardsInDeck[i].Description;
            GetRarityImage(deckHandler.Maindeck.CardsInDeck[i].CardRarity, AllCardRarityImage[i]);  
        }
    }
    public void GetRarityImage(Rarity _rarity , Image sr)
    {
        switch(_rarity)
        {
            default
                : sr.sprite = GameAsset.GetInstance().Star;
                break;
            case Rarity.Normal
                :
                sr.sprite = GameAsset.GetInstance().NomralIcon;
                break;
            case Rarity.Rare
                :
                sr.sprite = GameAsset.GetInstance().RareIcon;
                break;
            case Rarity.SuperRare
                :
                sr.sprite = GameAsset.GetInstance().SuperRareIcon;
                break;
        };
    }

}
