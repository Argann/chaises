using UnityEngine;
using UnityEngine.VFX;

/// <summary>
/// Déclenche un feedback visuel basé sur un 
/// VFX graph à chaque clic.
/// </summary>
public class ClickFeedback : MonoBehaviour
{
    /// <summary>
    /// Effet visuel de feedback lorsque l'on clique sur 
    /// le bouton.
    /// </summary>
    [SerializeField]
    private VisualEffect _vfxClickFeedback;

    /// <summary>
    /// Element chargé de capter les clics des joueur.euses.
    /// </summary>
    [SerializeField]
    private GainChairsOnClick _buttonToListen;

    private void OnEnable()
    {
        _buttonToListen.OnClick += OnClick;
    }

    private void OnDisable()
    {
        _buttonToListen.OnClick -= OnClick;
    }

    /// <summary>
    /// Méthode appelée lorsque le joueur gagne des
    /// chaises en cliquant.
    /// </summary>
    void OnClick()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosition.z = 0;
        _vfxClickFeedback.SetVector3("SpawnPosition", worldPosition);
        _vfxClickFeedback.Play();
    }
}