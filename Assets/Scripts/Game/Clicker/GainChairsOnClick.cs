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
    /// Quantit� de chaises de base � gagner � chaque clic.
    /// </summary>
    [SerializeField]
    private double _amountToGain;

    /// <summary>
    /// Ev�nement appel� � chaque fois que quelqu'un 
    /// clique sur ce composant.
    /// </summary>
    public event Action OnClick;

    /// <summary>
    /// M�thode appel�e automatiquement par Unity lorsque
    /// l'on clique sur un composant associ� � ce script.
    /// <br/>
    /// Fait gagner un montant fixe de chaises, et invoque
    /// l'�v�nement <see cref="OnClick"/>.
    /// </summary>
    public void OnPointerDown(PointerEventData _)
    {
        ChairCounter.Instance.EarnChairs(_amountToGain);

        OnClick?.Invoke();
    }
}