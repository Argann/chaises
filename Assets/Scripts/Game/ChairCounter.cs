using System;
/// <summary>
/// Singleton permettant de compter le nombre de 
/// chaises obtenues par le.a joueur.euse, ainsi
/// que d'en gagner et d'en dépenser.
/// </summary>
public class ChairCounter
{
    /// <summary>
    /// Instance statique de singleton.
    /// </summary>
    private static ChairCounter _instance;

    /// <summary>
    /// Accès en lazy-loading à l'instance de
    /// singleton.
    /// </summary>
    public static ChairCounter Instance
    {
        get
        {
            _instance ??= new ChairCounter();
            return _instance;
        }
    }

    /// <summary>
    /// Nombre de chaises actuellement possédées par
    /// le.a joueur.euse.
    /// </summary>
    public double Count { get; private set; }

    /// <summary>
    /// Evènement devant être appelé à chaque fois que
    /// le nombre de chaises possédées change.
    /// </summary>
    public event Action<double> CountChanged;

    /// <summary>
    /// Ajoute un nombre de chaises données au compteur.
    /// </summary>
    /// <param name="amount">
    /// Nombre de chaises à obtenir.
    /// </param>
    public void EarnChairs(double amount)
    {
        Count += amount;

        CountChanged?.Invoke(Count);
    }

    /// <summary>
    /// Détermine si le.a joueur.euse possède suffisament
    /// de chaises pour en dépenser un certain montant.
    /// <br/>
    /// Pour le dépenser réellement, utiliser 
    /// <see cref="SpendChairs(double)"/>.
    /// </summary>
    /// <param name="amount">
    /// Montant de chaises à comparer au compteur.
    /// </param>
    public bool CanSpendChairs(double amount) 
        => Count >= amount;

    /// <summary>
    /// Retire un nombre de chaises données au compteur.
    /// </summary>
    /// <param name="amount">
    /// Nombre de chaises à dépenser.
    /// </param>
    public void SpendChairs(double amount)
    {
        Count -= amount;

        CountChanged?.Invoke(Count);
    }
}
