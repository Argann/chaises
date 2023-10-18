using System;
using UnityEngine;
using UnityEngine.EventSystems;

/// <summary>
/// Composant permettant de gagner des chaises 
/// quand on lui clique dessus.
/// </summary>
public class GainChairsOnClick : MonoBehaviour, IPointerDownHandler
{
    /// <summary>
    /// Quantité de chaises de base à gagner à chaque clic.
    /// </summary>
    [SerializeField]
    private double _amountToGain;

    /// <summary>
    /// Evènement appelé à chaque fois que quelqu'un 
    /// clique sur ce composant.
    /// </summary>
    public event Action OnClick;

    /// <summary>
    /// Méthode appelée automatiquement par Unity lorsque
    /// l'on clique sur un composant associé à ce script.
    /// <br/>
    /// Fait gagner un montant fixe de chaises, et invoque
    /// l'évènement <see cref="OnClick"/>.
    /// </summary>
    public void OnPointerDown(PointerEventData _)
    {
        ChairCounter.Instance.EarnChairs(_amountToGain);

        OnClick?.Invoke();
    }
}