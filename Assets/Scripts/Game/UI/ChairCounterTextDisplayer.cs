using TMPro;
using UnityEngine;

/// <summary>
/// Composant d'UI chargé d'afficher via un composant TMPro
/// le nombre de chaises possédées par le.a joueur.euse.
/// </summary>
public class ChairCounterTextDisplayer : MonoBehaviour
{
    /// <summary>
    /// Champ TMPro à modifier à chaque fois que le compteur
    /// de chaises est modifié.
    /// </summary>
    [SerializeField]
    private TMP_Text _text;

    private void OnEnable()
    {
        ChairCounter.Instance.CountChanged += OnChairCountChanged;
    }

    private void OnDisable()
    {
        ChairCounter.Instance.CountChanged -= OnChairCountChanged;
    }

    /// <summary>
    /// Méthode d'écoute appelée automatiquement lorsque le
    /// nombre de chaises possédées est modifié.
    /// </summary>
    private void OnChairCountChanged(double newAmount)
    {
        _text.text = newAmount.ToString();
    }
}