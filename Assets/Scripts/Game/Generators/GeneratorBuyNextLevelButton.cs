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
    [SerializeField]
    private Generator _generator;

    /// <summary>
    /// Bouton d'UI dont on doit détecter le clic.
    /// </summary>
    [SerializeField]
    private Button _buyButton;

    /// <summary>
    /// Champ texte affichant le nom du générateur.
    /// </summary>
    [SerializeField]
    private TMP_Text _generatorName;

    /// <summary>
    /// Champ texte affichant le coût d'achat du prochain
    /// niveau du générateur.
    /// </summary>
    [SerializeField]
    private TMP_Text _nextLevelCost;

    private void Start()
    {
        _generatorName.text = _generator.Asset.DisplayName;
        _nextLevelCost.text = _generator.NextLevelCost.ToString();
        _buyButton.interactable = ChairCounter.Instance.CanSpendChairs(_generator.NextLevelCost);
    }

    private void OnEnable()
    {
        ChairCounter.Instance.CountChanged += OnChairCountChanged;
        _buyButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        ChairCounter.Instance.CountChanged -= OnChairCountChanged;
        _buyButton.onClick.RemoveListener(OnButtonClick);
    }

    /// <summary>
    /// Méthode d'écoute du changement du nombre de chaises
    /// possédées par lea joueur.euse.
    /// </summary>
    void OnChairCountChanged(double newAmount)
    {
        _buyButton.interactable = newAmount >= _generator.NextLevelCost;
    }

    /// <summary>
    /// Méthode d'écoute du clic sur le bouton lié.
    /// </summary>
    void OnButtonClick()
    {
        if (!ChairCounter.Instance.CanSpendChairs(_generator.NextLevelCost))
        {
            return;
        }

        _generator.BuyNextLevel();
        _nextLevelCost.text = _generator.NextLevelCost.ToString();
    }
}