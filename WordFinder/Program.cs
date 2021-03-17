using System;
using System.Collections.Generic;

namespace WordFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> myList = new List<string>();

            List<string> wordMatrix = new List<string>(){
                "LaborumtemporexercitationetjeniamAmetnisivelitvelitfugiatfugiatm",
                "ollitestadfugiatDuisirurerearehenderitaliquamagnacupidatatsuntma",
                "gnadoutLaborisnullaconsequacproidentdofugiatanimAnimelitquismoll",
                "itenimcillumullamcopariaturiostrudUllamcomagnaoccaecatidestexqui",
                "sestametdolorequisetexEnimvnniamvoluptateveniamutadquipariaturVe",
                "litdoloreconsequatnostrudqutexcepteuradesseveniamconsequatetquiR",
                "eprehenderitquielitidvelitcolpalaborismagnaadipisicingLoremlabor",
                "ecommododolorreprehenderitExincididuntestlaborumlaboreutduispari",
                "aturlaborumLoremminimsitlaborisvoluptateestenimProidentenimlabor",
                "emollitanimlaborumametlaboredositIpsumquisreprehenderitcupidatat",
                "voluptatedeseruntofficiaincupidatatconsequatlaborecillumconsecte",
                "turduisConsecteturreprehenderitsitvelitdeseruntdeserunteiusmodmi",
                "nimcupidatatlaborumdeseruntCillumesseessedeseruntnullaenimetirur",
                "efugiatenimLaboredoloraliquipelitminimexcepteurproidentquinondol",
                "orAliquipetcommodonostrudadipisicingutLoremadipisicingveniamExer",
                "citationelitlaboresintnoncojmodoametduisnostruddodosintutFugiata",
                "dvoluptateipsumesseetproideatexcepteurveniamquielitvelitnullaLor",
                "emLaboremagnaquisnisiadanimcrurenullavelitquisvoluptateestEsseve",
                "litmagnaexercitationquicommidoquialiquipipsumduiscillumipsumexen",
                "imnullaNisialiqualaborumincndiduntenimaliquipelitelitoccaecatDol",
                "ordolorproidentdolorlaborectlpaquiofficiacupidatatduisadipisicin",
                "gculpaUllamcodolorevelitnuloaconsequatullamcoeteaullamcoaliquipC",
                "illumlaborumutvelitproidentsintametincididuntaliquipirurenonocca",
                "ecatLaborealiquaametdoloresseexercitationlaborisinLoremlaborumni",
                "siexercitationcupidatatirureauteconsequattemporfugiatdeseruntTem",
                "poripsumnullanisiquivelitPariaturnonaliquipautefugiatlaborisSint",
                "elitreprehenderitvelitdoAliquaquislaborumveniamipsumvelitlaboris",
                "temporDolorexenimtemporvelitincididunteuineueaconsequatmollitcom",
                "modoetculpaAliquautofficiaessequiscillumreprehenderitetelitquiss",
                "itexnullanisienimTemporaliquaadipisicingdolorevelitelitofficiaex",
                "cepteurMinimquinostrudaliquipvelitduislaborumnullacommodooccaeca",
                "tofficiaconsecteturCommodoadipisicingmagnareprehenderiteiusmodLo",
                "remconsecteturminimadipisicingeaenimincididuntnisiDeseruntvelitm",
                "ollitexercitationreprehenderitvoluptateenimessefugiatadipisicing",
                "ipsumUllamcoaliquipduisdolorexminimenimpariaturlaborisveniamutNu",
                "llamagnasuntLoremeaesseadofficiaidduisnonofficialaborismagnaEnim",
                "consequateuirureirurefugiatMinimcommododoexproidentsintsinttempo",
                "rmollitvelitlaboremagnaconsequatLoremanimIncididuntvoluptateveni",
                "amfugiatirureIrurequideseruntadconsecteturdoloreoccaecatelitulla",
                "mconisiutElijacintopmollitvelitconsecteturveniamculpanisiminimex",
                "voluptateexExcepteurduisquisvelitconsequatquireprehenderitesseno",
                "nincididuntanimdolorLoremoccaecatnisifugiatlaboreincididuntvolup",
                "tatepariaturmagnaQuiexculpaconsequatenimdeseruntLoremaliquaeiusm",
                "odenimreprehenderitLaborumnisieiusmodlaborumsuntnostrudanimaliqu",
                "anostrudadvelitEstcommodomagnaeuadipisicingetnonSuntduisvelitexn",
                "ullaetofficiaesseaddolorelaboreirureoccaecatSintaliquaexcepteure",
                "xcepteurconsequatlaborumsuntexcepteurmagnadoullamcoofficiaametad",
                "ipisicingexercitationLaborumtemporexercitationetveniamAmetnisive",
                "litvelitfugiatfugiatmollitestadfugiatDuisirurereprehenderitaliqu",
                "amagnacupidatatsuntmagnadoutLaborisnullaconsequatproidentdofugia",
                "tanimAnimelitquismollitenimcillumullamcopariaturnostrudUllamcoma",
                "gnaoccaecatidestexquisestametdolorequisetexEnimveniamvoluptateve",
                "niamutadquipariaturVelitdoloreconsequatnostrudquiexcepteuradesse",
                "veniamconsequatetquiReprehenderitquielitidvelitculpalaborismagna",
                "adipisicingLoremlaborecommododolorreprehenderitExincididuntestla",
                "borumlaboreutduispariaturlaborumLoremminimsitlaborisvoluptateest",
                "enimProidentenimlaboremollitanimlaborumametlaboredositIpsumquisr",
                "eprehenderitcupidatatvoluptatedeseruntofficiaincupidatatconsequa",
                "tlaborecillumconsecteturduisConsecteturreprehenderitsitvelitdese",
                "runtdeserunteiusmodminimcupidatatlaborumdeseruntCillumesseessede",
                "seruntnullaenimetirurefugiatenimLaboredoloraliquipelitminimexcep",
                "teurproidentquinondolorAliquipetcommodonostrudadipisicingutLorem",
                "adipisicingveniamExercitationelitlaboresintnoncommodoametduisnos",
                "truddodosintutFugiatadvoluptateipsumesseetproidentexcepteurvenia"
            };

            WordFinder wf = new WordFinder(wordMatrix);

            List<string> wordsToFind = new List<string>(){"Laborum", "irure", "ea", "LA", "Excepteur", "eee", "jacinto"};
            IEnumerable<string> mostFrequent;

            var watch = System.Diagnostics.Stopwatch.StartNew();
            // the code that you want to measure comes here


            wf.PrintMatrix(); //debug purpose

            Console.WriteLine("Find1!");
            mostFrequent = wf.Find(wordsToFind);
            foreach(string word in mostFrequent)
                Console.WriteLine($"word: {word}");

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            Console.WriteLine($"Find1 Took {elapsedMs} milliseconds!\n");

            watch = System.Diagnostics.Stopwatch.StartNew();

            Console.WriteLine("Find2!");
            mostFrequent = wf.Find2(wordsToFind);
            foreach(string word in mostFrequent)
                Console.WriteLine($"word: {word}");

            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine($"Find2 Took {elapsedMs} milliseconds!\n");
        }
    }
}
