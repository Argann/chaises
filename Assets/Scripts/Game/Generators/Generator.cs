using System;
using System.Collections;
using UnityEngine;

/// <summary>
/// G�n�re un certain nombre de chaises �
/// intervalles r�guliers.
/// </summary>
public class Generator : MonoBehaviour
{
    /// <summary>
    /// Asset contenant toutes les donn�es de game design
    /// du g�n�rateur.
    /// </summary>
    public GeneratorAsset Asset;

    /// <summary>
    /// Niveau actuel du g�n�rateur.
    /// 0 �quivaut � la d�sactivation du g�n�rateur.
    /// </summary>
    public int CurrentLevel { get; private set; }

    /// <summary>
    /// Co�t (en chaises) pour passer le g�n�rateur
    /// au niveau sup�rieur.
    /// </summary>
    public double NextLevelCost => Asset.StartPrice * ((CurrentLevel * 3) + 1);

    /// <summary>
    /// Nombre de chaises g�n�r�es � chaque cycle
    /// par ce g�n�rateur.
    /// </summary>
    public double ChairsGeneratedPerCycle => Asset.ChairsEarnedFirstLevel * (CurrentLevel * Asset.ChairsEarnedLevelMultiplier);

    /// <summary>
    /// Coroutine de g�n�ration de chaises.
    /// </summary>
    private Coroutine _generationCoroutine;

    /// <summary>
    /// Ev�nement appel� � chaque fois que ce g�n�rateur
    /// passe au niveau sup�rieur.
    /// </summary>
    public event Action OnLevelBought;

    /// <summary>
    /// Permet, si possible, de passer le g�n�rateur au
    /// niveau sup�rieur en d�pensant le bon nombre de
    /// chaises.
    /// </summary>
    public void BuyNextLevel()
    {
        if (!ChairCounter.Instance.CanSpendChairs(NextLevelCost))
        {
            return;
        }

        ChairCounter.Instance.SpendChairs(NextLevelCost);

        CurrentLevel++;

        OnLevelBought?.Invoke();

        if (CurrentLevel == 1)
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
    /// Coroutine tr�s simple de g�n�ration de chaises.
    /// </summary>
    /// <returns></returns>
    IEnumerator GenerateChairs()
    {
        while (true)
        {
            yield return new WaitForSeconds(Asset.Delay);

            ChairCounter.Instance.EarnChairs(ChairsGeneratedPerCycle);
        }
    }
}
