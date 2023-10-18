using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// Composant d'UI affichant le nombre de
/// chaises générées par secondes.
/// </summary>
public class ChairsGeneratedPerSecondTextDisplayer : MonoBehaviour
{
    /// <summary>
    /// Champ texte devant contenir le nombre de chaises
    /// générées par secondes.
    /// </summary>
    [SerializeField]
    private TMP_Text _text;
    
    /// <summary>
    /// Liste des générateurs disponibles dans le jeu.
    /// </summary>
    [SerializeField]
    List<Generator> _generators;

    private void Start()
    {
        RefreshText();
    }

    private void OnEnable()
    {
        foreach (Generator generator in _generators)
        {
            generator.OnLevelBought += RefreshText;
        }
    }

    private void OnDisable()
    {
        foreach (Generator generator in _generators)
        {
            generator.OnLevelBought -= RefreshText;
        }
    }

    /// <summary>
    /// Recalcule le nombre total de chaises générées
    /// par seconde et modifie le texte pour l'afficher
    /// au joueur.euse.
    /// </summary>
    void RefreshText()
    {
        double chairsPerSecond = 0;

        foreach (Generator generator in _generators)
        {
            chairsPerSecond += generator.ChairsGeneratedPerCycle / generator.Asset.Delay;
        }

        _text.text = $"+{chairsPerSecond} chaises / seconde";
    }
}
