﻿using System;
using System.Collections.Generic;
using System.Linq;

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

            for(int attempts = 0; attempts < wordsToFind.Count(); attempts++)
            {
                Console.WriteLine($"[#{attempts}] Execute Find with just {attempts + 1} word/s:");

                Console.Write("\n[Find] (char based algorithm): ");
                var watch = System.Diagnostics.Stopwatch.StartNew();
                mostFrequent = wf.Find(wordsToFind.Take(attempts + 1));
                watch.Stop();
                var elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("\n[Find] Top 10 words: ");
                foreach(string word in mostFrequent)
                    Console.Write($"{word},");
                Console.WriteLine($"\n[Find] took {elapsedMs} milliseconds!\n");

                Console.Write("\n[Find2] (regex based algorithm): ");
                watch = System.Diagnostics.Stopwatch.StartNew();
                mostFrequent = wf.Find2(wordsToFind.Take(attempts + 1));
                watch.Stop();
                elapsedMs = watch.ElapsedMilliseconds;
                Console.WriteLine("\n[Find2] Top 10 words: ");
                foreach(string word in mostFrequent)
                    Console.Write($"{word},");
                Console.WriteLine($"\n[Find2] took {elapsedMs} milliseconds!\n");

            }
        }
    }
}
