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

            List<string> wordsToFind = new List<string>(){
                //"Laborum", "irure", "ea", "LA", "Excepteur", "excepteur", "eee", "jacinto", "lorem", "ipsum", "dolor"
                "Lorem", "ipsum","dolor","sit","amet","consectetur","adipiscing","elit","sed","do","eiusmod","tempor","incididunt","ut","labore","et","dolore","magna","aliqua","Ut","enim","ad","minim","veniam","quis","nostrud","exercitation","ullamco","laboris","nisi","ut","aliquip","ex","ea","commodo","consequat","Duis","aute","irure","dolor","in","reprehenderit","in","voluptate","velit","esse","cillum","dolore","eu","fugiat","nulla","pariatur","Excepteur","sint","occaecat","cupidatat","non","proident","sunt","in","culpa","qui","officia","deserunt","mollit","anim","id","est","laborum"
            };
            IEnumerable<string> mostFrequent;
            
            Console.WriteLine("char matrix[,] content:\n");
            wf.PrintMatrix(); //debug purpose only

            Console.WriteLine("\n1. Find (char based algorithm)");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            mostFrequent = wf.Find(wordsToFind);
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("1. Top 10 words:");
            foreach(string word in mostFrequent)
                Console.WriteLine($"\t{word}");
            Console.WriteLine($"1. Find took {elapsedMs} milliseconds!\n");

            Console.WriteLine();

            Console.WriteLine("2. Find2 (regex based algorithm)");
            watch = System.Diagnostics.Stopwatch.StartNew();
            mostFrequent = wf.Find2(wordsToFind);
            watch.Stop();
            elapsedMs = watch.ElapsedMilliseconds;
            Console.WriteLine("2. Top 10 words:");
            foreach(string word in mostFrequent)
                Console.WriteLine($"\t{word}");
            Console.WriteLine($"2. Find2 took {elapsedMs} milliseconds!\n");
        }
    }
}
