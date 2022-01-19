using System;
using static Carte;

//namespace classes
//{
    public class CompteBancaire
    {
        public int numCompte { get; }
        public Carte maCarte { get; set; }
        public double solde { get; set; }

        public CompteBancaire()
        {

        }
        public CompteBancaire(int numCompte, double soldeInitial, Carte maCarte)
        {
            this.numCompte = numCompte;
            this.solde = soldeInitial;
            this.maCarte = maCarte; 
        }

        //public CompteBancaire(int numCompte, double soldeInitial, Carte maCarte)
        //{
        //    this.numCompte = numCompte;
        //    this.solde = soldeInitial;
        //    this.maCarte = maCarte;
        //}

        public void depot(double amount)
        {
            solde += amount;
        }

        public void retrait(double amount )
        {
            solde -= amount;
        }
}
//}