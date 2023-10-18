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
    [SerializeField]
    private Generator _generator;

    /// <summary>
    /// Bouton d'UI dont on doit d�tecter le clic.
    /// </summary>
    [SerializeField]
    private Button _buyButton;

    /// <summary>
    /// Champ texte affichant le nom du g�n�rateur.
    /// </summary>
    [SerializeField]
    private TMP_Text _generatorName;

    /// <summary>
    /// Champ texte affichant le co�t d'achat du prochain
    /// niveau du g�n�rateur.
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
    /// M�thode d'�coute du changement du nombre de chaises
    /// poss�d�es par lea joueur.euse.
    /// </summary>
    void OnChairCountChanged(double newAmount)
    {
        _buyButton.interactable = newAmount >= _generator.NextLevelCost;
    }

    /// <summary>
    /// M�thode d'�coute du clic sur le bouton li�.
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