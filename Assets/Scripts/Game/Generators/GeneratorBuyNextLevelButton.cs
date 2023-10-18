using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Composant lié à un bouton d'UI permettant d'acheter,
/// si possible, le prochain niveau d'un générateur lié.
/// </summary>
public class GeneratorBuyNextLevelButton : MonoBehaviour
{
    /// <summary>
    /// Générateur lié à ce bouton.
    /// </summary>
    public Generator generator;

    /// <summary>
    /// Bouton d'UI dont on doit détecter le clic.
    /// </summary>
    public Button buyButton;

    /// <summary>
    /// Champ texte affichant le nom du générateur.
    /// </summary>
    public TMP_Text generatorName;

    /// <summary>
    /// Champ texte affichant le coût d'achat du prochain
    /// niveau du générateur.
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
    /// Méthode d'écoute du changement du nombre de chaises
    /// possédées par lea joueur.euse.
    /// </summary>
    void OnChairCountChanged(double newAmount)
    {
        buyButton.interactable = newAmount >= generator.NextLevelCost;
    }

    /// <summary>
    /// Méthode d'écoute du clic sur le bouton lié.
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