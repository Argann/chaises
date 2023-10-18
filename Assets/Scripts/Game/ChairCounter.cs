using System;
/// <summary>
/// Singleton permettant de compter le nombre de 
/// chaises obtenues par le.a joueur.euse, ainsi
/// que d'en gagner et d'en d�penser.
/// </summary>
public class ChairCounter
{
    /// <summary>
    /// Instance statique de singleton.
    /// </summary>
    private static ChairCounter _instance;

    /// <summary>
    /// Acc�s en lazy-loading � l'instance de
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
    /// Nombre de chaises actuellement poss�d�es par
    /// le.a joueur.euse.
    /// </summary>
    public double Count { get; private set; }

    /// <summary>
    /// Ev�nement devant �tre appel� � chaque fois que
    /// le nombre de chaises poss�d�es change.
    /// </summary>
    public event Action<double> CountChanged;

    /// <summary>
    /// Ajoute un nombre de chaises donn�es au compteur.
    /// </summary>
    /// <param name="amount">
    /// Nombre de chaises � obtenir.
    /// </param>
    public void EarnChairs(double amount)
    {
        Count += amount;

        CountChanged?.Invoke(Count);
    }

    /// <summary>
    /// D�termine si le.a joueur.euse poss�de suffisament
    /// de chaises pour en d�penser un certain montant.
    /// <br/>
    /// Pour le d�penser r�ellement, utiliser 
    /// <see cref="SpendChairs(double)"/>.
    /// </summary>
    /// <param name="amount">
    /// Montant de chaises � comparer au compteur.
    /// </param>
    public bool CanSpendChairs(double amount) 
        => Count >= amount;

    /// <summary>
    /// Retire un nombre de chaises donn�es au compteur.
    /// </summary>
    /// <param name="amount">
    /// Nombre de chaises � d�penser.
    /// </param>
    public void SpendChairs(double amount)
    {
        Count -= amount;

        CountChanged?.Invoke(Count);
    }
}
