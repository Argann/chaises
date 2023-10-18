using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Composant li� � un bouton d'UI permettant d'acheter,
/// si possible, le prochain niveau d'un g�n�rateur li�.
/// </summary>
public class GeneratorBuyNextLevelButton : MonoBehaviour
{
    /// <summary>
    /// G�n�rateur li� � ce bouton.
    /// </summary>
    public Generator generator;

    /// <summary>
    /// Bouton d'UI dont on doit d�tecter le clic.
    /// </summary>
    public Button buyButton;

    /// <summary>
    /// Champ texte affichant le nom du g�n�rateur.
    /// </summary>
    public TMP_Text generatorName;

    /// <summary>
    /// Champ texte affichant le co�t d'achat du prochain
    /// niveau du g�n�rateur.
    /// </summary>
    public TMP_Text nextLevelCost;

    private void Start()
    {
        generatorName.text = generator.Asset.DisplayName;
        nextLevelCost.text = generator.NextLevelCost.ToString();
        buyButton.interactable = ChairCounter.Instance.CanSpendChairs(generator.NextLevelCost);
    }

    private void OnEnable()
    {
        ChairCounter.Instance.CountChanged += OnChairCountChanged;
        buyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ChairCounter.Instance.CountChanged -= OnChairCountChanged;
        buyButton.onClick.RemoveListener(OnButtonClick);
    }

    /// <summary>
    /// M�thode d'�coute du changement du nombre de chaises
    /// poss�d�es par lea joueur.euse.
    /// </summary>
    void OnChairCountChanged(double newAmount)
    {
        buyButton.interactable = newAmount >= generator.NextLevelCost;
    }

    /// <summary>
    /// M�thode d'�coute du clic sur le bouton li�.
    /// </summary>
    void OnButtonClick()
    {
        if (!ChairCounter.Instance.CanSpendChairs(generator.NextLevelCost))
        {
            return;
        }

        generator.BuyNextLevel();
        nextLevelCost.text = generator.NextLevelCost.ToString();
    }
}