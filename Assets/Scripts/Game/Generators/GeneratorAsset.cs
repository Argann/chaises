using UnityEngine;

/// <summary>
/// Asset regroupant toutes les données de
/// game design d'un générateur de chaises.
/// </summary>
[CreateAssetMenu(fileName = "New Chair Generator", menuName = "Chairs/Generator")]
public class GeneratorAsset : ScriptableObject
{
    /// <summary>
    /// Nom du générateur.
    /// </summary>
    public string DisplayName;

    /// <summary>
    /// Prix du premier niveau du générateur.
    /// </summary>
    public double StartPrice;

    /// <summary>
    /// Cadence (en secondes) de génération de chaises
    /// du générateur.
    /// </summary>
    public float Delay;

    /// <summary>
    /// Au premier niveau du générateur, détermine
    /// le nombre de chaises générées à chaque cycle.
    /// </summary>
    public double ChairsEarnedFirstLevel;

    /// <summary>
    /// Multiplicateur appliqué à chaque niveau de 
    /// générateur sur le nombre de chaises générées.
    /// </summary>
    public double ChairsEarnedLevelMultiplier;
}