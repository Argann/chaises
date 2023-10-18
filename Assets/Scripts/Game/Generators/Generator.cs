using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// Génère un certain nombre de chaises à
/// intervalles réguliers.
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>
    /// Asset contenant toutes les données de game design
    /// du générateur.
    /// </summary>
    [SerializeField]
    private GeneratorAsset _asset;

    /// <summary>
    /// Asset contenant toutes les données de game design
    /// du générateur.
    /// </summary>
    public GeneratorAsset Asset => _asset;

    /// <summary>
    /// Niveau actuel du générateur.
    /// 0 équivaut à la désactivation du générateur.
    /// </summary>
    private int _currentLevel;

    /// <summary>
    /// Coût (en chaises) pour passer le générateur
    /// au niveau supérieur.
    /// </summary>
    public double NextLevelCost => _asset.StartPrice * ((_currentLevel * 3) + 1);

    /// <summary>
    /// Nombre de chaises générées à chaque cycle
    /// par ce générateur.
    /// </summary>
    public double ChairsGeneratedPerCycle => _asset.ChairsEarnedFirstLevel * (_currentLevel * _asset.ChairsEarnedLevelMultiplier);

    /// <summary>
    /// Coroutine de génération de chaises.
    /// </summary>
    private Coroutine _generationCoroutine;

    /// <summary>
    /// Evènement appelé à chaque fois que ce générateur
    /// passe au niveau supérieur.
    /// </summary>
    public event Action OnLevelBought;

    /// <summary>
    /// Permet, si possible, de passer le générateur au
    /// niveau supérieur en dépensant le bon nombre de
    /// chaises.
    /// </summary>
    public void BuyNextLevel()
    {
        if (!ChairCounter.Instance.CanSpendChairs(NextLevelCost))
        {
            return;
        }

        ChairCounter.Instance.SpendChairs(NextLevelCost);

        _currentLevel++;

        OnLevelBought?.Invoke();

        if (_currentLevel == 1)
        {
            _generationCoroutine = StartCoroutine(GenerateChairs());
        }
    }

    private void OnDisable()
    {
        if (_generationCoroutine != null)
            StopCoroutine(_generationCoroutine);
    }

    /// <summary>
    /// Coroutine très simple de génération de chaises.
    /// </summary>
    /// <returns></returns>
    IEnumerator GenerateChairs()
    {
        while (true)
        {
            yield return new WaitForSeconds(_asset.Delay);

            ChairCounter.Instance.EarnChairs(ChairsGeneratedPerCycle);
        }
    }
}
