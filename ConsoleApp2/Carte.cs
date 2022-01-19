using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Carte{

    public int numCarte { get; private set; }

    public int pin { get; private set; }

    //private List<CompteBancaire> listeCompteBancaires = new List<CompteBancaire>();

    //public Carte(int numCarte, int pin, List<CompteBancaire> listeCompteBancaires)
    //{
    //    this.numCarte = numCarte;
    //    this.pin = pin;
    //    this.listeCompteBancaires = listeCompteBancaires;
    //}

    public Carte()
    {

    }
    public Carte(int numCarte, int pin)
    {
       this.numCarte = numCarte;
       this.pin = pin;
    }


}

