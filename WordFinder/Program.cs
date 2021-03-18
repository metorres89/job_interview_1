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

            List<string> wordsToFind = new List<string>(){"Laborum", "irure", "ea", "LA", "Excepteur", "excepteur", "eee", "jacinto", "lorem", "ipsum", "dolor"};
            IEnumerable<string> mostFrequent;

            wf.PrintMatrix(); //debug purpose only
            
            Console.WriteLine("Find!");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            mostFrequent = wf.Find(wordsToFind);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            foreach(string word in mostFrequent)
                Console.WriteLine($"word: {word}");
            Console.WriteLine($"Find Took {elapsedMs} milliseconds!\n");

            Console.WriteLine("Find2!");
            watch = System.Diagnostics.Stopwatch.StartNew();
            mostFrequent = wf.Find2(wordsToFind);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            foreach(string word in mostFrequent)
                Console.WriteLine($"word: {word}");
            Console.WriteLine($"Find2 Took {elapsedMs} milliseconds!\n");
        }
    }
}
