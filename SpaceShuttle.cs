using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SpaceShuttle
{
    class SpaceShuttle
    {
        static void Eredmény(int sorszám, string szöveg)

        {
            string strSorszám = (sorszám == 0) ? null : $"{sorszám.ToString()}. feladat";
            Console.WriteLine($"{strSorszám} \n\t{szöveg}");
        }
        static void Main(string[] args)
        {
            //1.Készítsenprogramot akövetkező feladatokmegoldására, melynek forráskódjátSpaceShuttle néven mentse el!
            //2.Olvassabe akuldetesek.csv állománybanlévő adatokatés tároljael egyolyan adatszerkezetben, amia továbbifeladatok megoldásáraalkalmas!
            List<Küldetések> k = new List<Küldetések>();
            foreach (var i in File.ReadAllLines("kuldetesek.csv"))
            {
                k.Add(new Küldetések(i));
            }
            //3.Határozzameg ésírja kia képernyőrea mintaszerint, hogy hányszorküldtek avilágűrbe úrhajótaz Space Shuttle programkeretein belül!
            Eredmény(3, $"Összesen{k.Count} alkalommal indítottak űrhajót");
            //4.Határozzameg ésírja kia képernyőrea mintaszerint, hogy hányutast szállítottakösszesen aSpace Shuttleűrsiklói!
            int össz = 0;
            foreach (var i in k)
            {
                össz += i.LegénységSzáma;
            }
            Eredmény(4, $"{össz} utas indult az űrbe összesen");
            //5.Határozzameg ésírja kia képernyőrea mintaszerint, hogy hányalkalommal indítottakűrsiklót kevesebb, mint5fővel avilágűrbe!
            int alkalom = 0;
            foreach (var i in k)
            {
                if (i.LegénységSzáma < 5) alkalom++;
               
            }
            Eredmény(5, $"Összesen {alkalom} alkalommal küldtek kevesebb, mint 5 embert az űrbe ");
            //6. 2003.február1‐jén aFöldre valóvisszatérés közbena Columbiaűrsikló megsemmisült, nemvoltak túlélők.
            //   Határozza megés írjaki aképernyőre aminta szerint, hogyhány asztronautakísérte ela Columbiátutolsó útjára!
            Küldetések utolsó = null;
            foreach (var i in k)
            {
                if (i.Támaszpont=="nem landolt" && i.SiklóNeve=="Columbia")
                {
                    utolsó = i;
                }
            }
            Eredmény(6, $"{utolsó.LegénységSzáma} asztronauta volt a fedélzeten annak utolsó útján {utolsó.Visszatérés}-kor");
            //7.Határozzameg ésírja kia képernyőrea mintaszerint annakaz űrsiklónaka nevét,
            //  aküldetés kódjátés azűrben töltöttidőt órában, amikora leghosszabbideig
            //  volttávol aFöldtől űrhajó, amitSpace Shuttle program indított!
            //  Feltételezheti, hogy nemvolt kétilyen hosszúságúküldetés.
            Küldetések maxIdejű = null;
            double maxIdő = 0;
            foreach (var i in k)
            {
                if (i.ÓrákSzámaAzŰrben > maxIdő)
                {
                    maxIdejű = i;
                    maxIdő = i.ÓrákSzámaAzŰrben;
                }
            }
            Eredmény(7, $"A leghosszabb ideig a {maxIdejű.SiklóNeve} volt az űrben a \n\t" +
                $"{maxIdejű.KüldetésKód} számú küldetés során, összesen {maxIdejű.ÓrákSzámaAzŰrben} órát volt távol a földtől");

            //8.Kérjenbe egyévszámot!Határozzameg ésírja kia képernyőrea mintaszerint, hogy amegadott évben hány
            //  alkalommalindítottak űrsiklótútnak.Ha amegadott évbennem indultküldetés,
            //  az„Ebben az évben nemindult küldetés” szöveg jelenjenmeg.  
            Eredmény(8, null);
            Console.Write("\tÉvszám: ");
            int év = int.Parse(Console.ReadLine());
            int db = 0;
            foreach (var i in k)
            {
                if (i.KilövésDátuma.Year == év) db++;
               
            }
            string kiirando=(db == 0) ?  $"Ebben az évben nem indult küldetés" :  $"Ebben az évben {db} küldetés volt";
            Eredmény(0, kiirando);
            //9.Határozzameg ésírja kia képernyőrea mintaszerint, hogy alandolások hány%‐a történtaz Kennedy űrközponton. 
            int keneddyLandolas = 0;
            foreach (var i in k)
            {
                if (i.Támaszpont == "Kennedy") keneddyLandolas++;
                
            }
            Eredmény(9, $"A küldetések {(double)keneddyLandolas / k.Count:P}-a fejeződött be a Kennedy űrközpontban");
            //10.írjaki azursiklok.txt állománybaa mintaszerint, hogy melyikűrsikló összesenhány napottöltött azűrben!(Mindensikló nevecsak egyszerszerepeljen!)
            Dictionary<String, Double> statisztika = new Dictionary<string, double>();
            foreach (var i in k)
            {
                if (statisztika.ContainsKey(i.SiklóNeve))
                {
                    statisztika[i.SiklóNeve] += i.NapokSzámaAzŰrben;
                }
                else
                {
                    statisztika.Add(i.SiklóNeve, i.NapokSzámaAzŰrben);
                }
            }
            List<string> FájbaVele = new List<string>();
            foreach (var i in statisztika)
            {
                FájbaVele.Add($"{i.Key}\t{i.Value:F2}");
            }
            Eredmény(10, "Fájlba írás megtörtént");
            File.WriteAllLines("ursiklok.txt", FájbaVele);
            Console.ReadKey();
        }
    }
}
