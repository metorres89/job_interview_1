# WordFinder

Repository created for a Job Interview Challenge (2021-03-16).

# Objective

The objective of this challenge is not necessarily just to solve the problem ​ but to
evaluate your software development skills, code quality, analysis, creativity, and resourcefulness
as a potential future colleague. Please share the necessary artifacts you would provide to your
colleagues in a real​ -world professional setting to best evaluate your work.

Presented with a character matrix and a large stream of words, your task is to create a Class
that searches the matrix to look for the words from the word stream. Words may appear
horizontally, from left to right, or vertically, from top to bottom. In the example below, the word
stream has four words and the matrix contains only three of those words ("chill", "cold" and
"wind"):

The search code must be implemented as a class with the following interface:

    public class WordFinder
    {
        public WordFinder(IEnumerable<string> matrix) 
        {
        //code
        }
        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            //code
        }
    }

The WordFinder constructor receives a set of strings which represents a character matrix. The
matrix size does not exceed 64x64, all strings contain the same number of characters. 

The "Find" method should return the top 10 most repeated words from the word stream found in the
matrix. If no words are found, the "Find" method should return an empty set of strings. ​ If any
word in the word stream is found more than once within the STREAM, the search results
should count it only once.

Due to the size of the word stream, the code should be implemented in a ​ high performance
fashion both in terms of efficient algorithm and utilization of system resources. Where possible,
please include your analysis and evaluation.

# Analysis

To search for text there are two different approaches: looking for text in a char comparison basis or using optimized tools like Regular Expressions.

In this sample project both are present.

WordFinder class was provided with two different methods:

1. Find: which internally uses the "CharBasedFrequency" method. This method calculates the occurences of a single word in the char matrix using char by char comparison algorithm. It's not very optimised but I took some precautions to skip loops for some cases like when the word doesn't fit in the remaining space of the vertical or horizontal array.

2. Find2: which internally uses the "RegExBasedFrequency" method, which calculates the occurences of a single word in the char matrix but using the word as a Regular Expression pattern and transforming the row or column of the char matrix to a string in order to use the pattern.

Both ways return the same results but they differ in the performance.

# Evaluation

To evaluate the performance of both methods I used the System.Diagnostics.Stopwatch class which is helpful to measure the milliseconds it takes a function to execute.

Sample Code:

    Console.WriteLine("Find!");
    var watch = System.Diagnostics.Stopwatch.StartNew();
    mostFrequent = wf.Find(wordsToFind);
    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;
    foreach(string word in mostFrequent)
        Console.WriteLine($"word: {word}");
    Console.WriteLine($"Find Took {elapsedMs} milliseconds!\n");

# Results

Both methods are returning the same resuls but they differ for some milliseconds.

Console Output:

    _charMatrix[,] Content:

    LaborumtemporexercitationetjeniamAmetnisivelitvelitfugiatfugiatm
    ollitestadfugiatDuisirurerearehenderitaliquamagnacupidatatsuntma
    gnadoutLaborisnullaconsequacproidentdofugiatanimAnimelitquismoll
    itenimcillumullamcopariaturiostrudUllamcomagnaoccaecatidestexqui
    sestametdolorequisetexEnimvnniamvoluptateveniamutadquipariaturVe
    litdoloreconsequatnostrudqutexcepteuradesseveniamconsequatetquiR
    eprehenderitquielitidvelitcolpalaborismagnaadipisicingLoremlabor
    ecommododolorreprehenderitExincididuntestlaborumlaboreutduispari
    aturlaborumLoremminimsitlaborisvoluptateestenimProidentenimlabor
    emollitanimlaborumametlaboredositIpsumquisreprehenderitcupidatat
    voluptatedeseruntofficiaincupidatatconsequatlaborecillumconsecte
    turduisConsecteturreprehenderitsitvelitdeseruntdeserunteiusmodmi
    nimcupidatatlaborumdeseruntCillumesseessedeseruntnullaenimetirur
    efugiatenimLaboredoloraliquipelitminimexcepteurproidentquinondol
    orAliquipetcommodonostrudadipisicingutLoremadipisicingveniamExer
    citationelitlaboresintnoncojmodoametduisnostruddodosintutFugiata
    dvoluptateipsumesseetproideatexcepteurveniamquielitvelitnullaLor
    emLaboremagnaquisnisiadanimcrurenullavelitquisvoluptateestEsseve
    litmagnaexercitationquicommidoquialiquipipsumduiscillumipsumexen
    imnullaNisialiqualaborumincndiduntenimaliquipelitelitoccaecatDol
    ordolorproidentdolorlaborectlpaquiofficiacupidatatduisadipisicin
    gculpaUllamcodolorevelitnuloaconsequatullamcoeteaullamcoaliquipC
    illumlaborumutvelitproidentsintametincididuntaliquipirurenonocca
    ecatLaborealiquaametdoloresseexercitationlaborisinLoremlaborumni
    siexercitationcupidatatirureauteconsequattemporfugiatdeseruntTem
    poripsumnullanisiquivelitPariaturnonaliquipautefugiatlaborisSint
    elitreprehenderitvelitdoAliquaquislaborumveniamipsumvelitlaboris
    temporDolorexenimtemporvelitincididunteuineueaconsequatmollitcom
    modoetculpaAliquautofficiaessequiscillumreprehenderitetelitquiss
    itexnullanisienimTemporaliquaadipisicingdolorevelitelitofficiaex
    cepteurMinimquinostrudaliquipvelitduislaborumnullacommodooccaeca
    tofficiaconsecteturCommodoadipisicingmagnareprehenderiteiusmodLo
    remconsecteturminimadipisicingeaenimincididuntnisiDeseruntvelitm
    ollitexercitationreprehenderitvoluptateenimessefugiatadipisicing
    ipsumUllamcoaliquipduisdolorexminimenimpariaturlaborisveniamutNu
    llamagnasuntLoremeaesseadofficiaidduisnonofficialaborismagnaEnim
    consequateuirureirurefugiatMinimcommododoexproidentsintsinttempo
    rmollitvelitlaboremagnaconsequatLoremanimIncididuntvoluptateveni
    amfugiatirureIrurequideseruntadconsecteturdoloreoccaecatelitulla
    mconisiutElijacintopmollitvelitconsecteturveniamculpanisiminimex
    voluptateexExcepteurduisquisvelitconsequatquireprehenderitesseno
    nincididuntanimdolorLoremoccaecatnisifugiatlaboreincididuntvolup
    tatepariaturmagnaQuiexculpaconsequatenimdeseruntLoremaliquaeiusm
    odenimreprehenderitLaborumnisieiusmodlaborumsuntnostrudanimaliqu
    anostrudadvelitEstcommodomagnaeuadipisicingetnonSuntduisvelitexn
    ullaetofficiaesseaddolorelaboreirureoccaecatSintaliquaexcepteure
    xcepteurconsequatlaborumsuntexcepteurmagnadoullamcoofficiaametad
    ipisicingexercitationLaborumtemporexercitationetveniamAmetnisive
    litvelitfugiatfugiatmollitestadfugiatDuisirurereprehenderitaliqu
    amagnacupidatatsuntmagnadoutLaborisnullaconsequatproidentdofugia
    tanimAnimelitquismollitenimcillumullamcopariaturnostrudUllamcoma
    gnaoccaecatidestexquisestametdolorequisetexEnimveniamvoluptateve
    niamutadquipariaturVelitdoloreconsequatnostrudquiexcepteuradesse
    veniamconsequatetquiReprehenderitquielitidvelitculpalaborismagna
    adipisicingLoremlaborecommododolorreprehenderitExincididuntestla
    borumlaboreutduispariaturlaborumLoremminimsitlaborisvoluptateest
    enimProidentenimlaboremollitanimlaborumametlaboredositIpsumquisr
    eprehenderitcupidatatvoluptatedeseruntofficiaincupidatatconsequa
    tlaborecillumconsecteturduisConsecteturreprehenderitsitvelitdese
    runtdeserunteiusmodminimcupidatatlaborumdeseruntCillumesseessede
    seruntnullaenimetirurefugiatenimLaboredoloraliquipelitminimexcep
    teurproidentquinondolorAliquipetcommodonostrudadipisicingutLorem
    adipisicingveniamExercitationelitlaboresintnoncommodoametduisnos
    truddodosintutFugiatadvoluptateipsumesseetproidentexcepteurvenia
    
    Find!
    (ea,45)
    (dolor,18)
    (irure,9)
    (excepteur,7)
    (ipsum,7)
    (Laborum,3)
    (jacinto,3)
    (eee,2)
    (Excepteur,1)
    (LA,0)
    
    word: ea
    word: dolor
    word: irure
    word: excepteur
    word: ipsum
    word: Laborum
    word: jacinto
    word: eee
    word: Excepteur
    word: LA
    
    Find Took 19 milliseconds!

    Find2!
    (ea,45)
    (dolor,18)
    (irure,9)
    (excepteur,7)
    (ipsum,7)
    (Laborum,3)
    (jacinto,3)
    (eee,2)
    (Excepteur,1)
    (LA,0)
    word: ea
    word: dolor
    word: irure
    word: excepteur
    word: ipsum
    word: Laborum
    word: jacinto
    word: eee
    word: Excepteur
    word: LA
    Find2 Took 11 milliseconds!

As you can see Find2 (Regex based) took 11 milliseconds and Find (char comparison based) took 19 milliseconds.

This difference can be caused by the nature of the Frequency algorithm used inside Find method. 

Since this is a function based on char by char comparison inside the matrix it's using two nested loops that elevates the complexity of the algorithm.

In the other hand the Find2 uses the RegexBasedFrequency algorithm which only has one loop and uses Range, Select and ToArray to transform the characters in vertical and horizontal lines in the matrix to a single string to be searched by the RegEx pattern.