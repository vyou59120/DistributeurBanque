using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CompteBancaire;

//namespace ConsoleApp2
//{
//internal class DistributeurBanque
    public class DistributeurBanque
    {
        private List<CompteBancaire> listeCompteBancaires = new List<CompteBancaire>();

    public DistributeurBanque(List<CompteBancaire> listeCompteBancaires)
    {
        this.listeCompteBancaires = listeCompteBancaires;
    }

    public bool checkAccount(CompteBancaire compteBancaire)
    {
       return this.listeCompteBancaires.Contains(compteBancaire);
        //return this.listeCompteBancaires.Find(compteBancaire);
    }

    public bool checkPin(List<Carte> listeCartes, int numCarte, int pin)
    {
        //Carte maCarte = new Carte(numCarte, pin);
        bool response = false;
        foreach (Carte carte in listeCartes)
        {
            if (carte.numCarte == numCarte && carte.pin == pin)
            {
                response = true;
            }
        }
        return response;

        //return listeCartes.Contains(maCarte);
    }

    private bool contains(CompteBancaire compteBancaire, Carte carte)
    {
        bool response = false;
        foreach (CompteBancaire compte in this.listeCompteBancaires)
        {
            if (compte.maCarte == compteBancaire.maCarte) {
                response = true;
            } 
        }
        return response;
    }

    private Carte retrieveCarte(List<Carte> listeCartes, int numCarte)
    {
        Carte response = new Carte();
        foreach (Carte carte in listeCartes)
        {
            if (carte.numCarte == numCarte)
            {
                response =  carte;
            }
        }
        return response;
    }

    private CompteBancaire retrieveCompteBancaire(List<CompteBancaire> listeCompteBancaires, Carte carte)
    {
        CompteBancaire compte = new CompteBancaire();
        foreach (CompteBancaire compteBancaire in listeCompteBancaires)
        {
            if (compteBancaire.maCarte == carte)
            {
                compte = compteBancaire;
            }
        }
        return compte;
    }

    static void Main()
    {
        Carte carte1 = new Carte(11, 1111);
        Carte carte2 = new Carte(22, 2222);
        Carte carte3 = new Carte(33, 3333);

        Carte carte4 = new Carte(44, 4444);

        List<Carte> listeCartes = new List<Carte>()
        {
            carte1, carte2,carte3,carte4
        };

        CompteBancaire CompteBancaire1 = new CompteBancaire(00000000001, 200.5, carte1);
        CompteBancaire CompteBancaire2 = new CompteBancaire(00000000002, 100, carte2);
        CompteBancaire CompteBancaire3 = new CompteBancaire(00000000003, 20000, carte3);

        CompteBancaire CompteBancaire4 = new CompteBancaire(00000000004, 15000, carte4);

        List<CompteBancaire> listeCompteBancaires = new List<CompteBancaire>()
        {
            CompteBancaire1, CompteBancaire2,CompteBancaire3
        };

        DistributeurBanque monDistributeurBanque = new DistributeurBanque(listeCompteBancaires);

        string numCarte = "";
        string pin = "";
        int numCarte2 = 0;
        int pin2 = 0;
        string response = "";
        string montant = "";
        string montant2 = "";
        double montantFinal = 0;
        bool isInt = false;
        bool isDouble = false;
        double temp = 0;
        double montantTemp= 0;
        Carte maCarte = new Carte();
        CompteBancaire monCompte = new CompteBancaire();

        do
        {
            do
            {
                Console.Write("Enter votre numéro de carte : ");
                numCarte = Console.ReadLine();
                isInt = int.TryParse(numCarte, out numCarte2);

            } while (numCarte == "" || !isInt);



            do
            {
                Console.Write("Enter votre numéro de pin : ");
                pin = Console.ReadLine();
                isInt = int.TryParse(pin, out pin2);

            } while (pin == "" || !isInt);

            if (monDistributeurBanque.checkPin(listeCartes, numCarte2, pin2) == false)
            {
                Console.WriteLine("Votre carte n'est pas reconnue");
            }
            else
            {
                maCarte = monDistributeurBanque.retrieveCarte(listeCartes, numCarte2);
                monCompte = monDistributeurBanque.retrieveCompteBancaire(listeCompteBancaires, maCarte);
            }

        } while (monDistributeurBanque.checkPin(listeCartes, numCarte2, pin2) == false);


        do
        {
            Console.Write("Voulez vous faire un retrait('R') ou un dépôt('D') ?" );
            response = Console.ReadLine();

        } while (response == "" || (response != "R" && response != "D"));

        do
        {
            Console.Write("Quel est le montant : ");
            montant = Console.ReadLine();
            isDouble = Double.TryParse(montant, out montantFinal);

        } while (montant == "" || !isDouble);

        if (response == "R")
        {
            while (monCompte.solde < montantFinal) { 
                do
                {
                    Console.Write("Vous n'avez pas assez d'argent, quel est le nouveau montant montant ? : ");
                    montant2 = Console.ReadLine();
                    isDouble = Double.TryParse(montant2, out montantFinal);

                } while (montant2 == "" || !isDouble);
            }

            if (monCompte.solde >= montantFinal)
            {
                monCompte.retrait(montantFinal);
                Console.WriteLine("Vous avez effectué un retrait de : " + montantFinal);
                Console.WriteLine("Votre nouveau solde est de : " + monCompte.solde);
            }
            
        }
        else
        {
            monCompte.depot(montantFinal);
            Console.WriteLine("Vous avez effectué un dépôt de : " + montantFinal);
            Console.WriteLine("Votre nouveau solde est de : " + monCompte.solde);
        }

        //Console.WriteLine(monDistributeurBanque.checkAccount(CompteBancaire1));
        //Console.WriteLine(monDistributeurBanque.checkAccount(CompteBancaire4));

        //Console.WriteLine(monDistributeurBanque.listeCompteBancaires[0].solde);
        //monDistributeurBanque.listeCompteBancaires[0].depot(1000);
        //Console.WriteLine(monDistributeurBanque.listeCompteBancaires[0].solde);

        //Console.WriteLine(monDistributeurBanque.ToString());
        //Console.WriteLine(monDistributeurBanque.listeCompteBancaires[0].maCarte.numCarte);
    }
}
//}
