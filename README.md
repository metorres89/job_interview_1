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

To search for text there are mainly two different approaches, looking for text in a char comparison basis or using optimized tools like Regular Expressions.

In this sample project both ways are used.

**WordFinder** class was provided with two different methods:

1. **Find**: which internally uses the **CharBasedFrequency** method. This method calculates the occurences of a single word in the char matrix using char by char comparison algorithm. It's not very optimized, but I took some precautions to skip loops for some cases, like when the word doesn't fit in the remaining positions of the vertical or horizontal array.

2. **Find2**: which internally uses the **RegExBasedFrequency** method, which does the same as the previous one but using the word as a Regular Expression pattern and transforming the row or column of the char matrix to a string in order to use that pattern.

Both ways return the same results but they differ in performance.

# Evaluation

To evaluate the performance of both methods I used the **System.Diagnostics.Stopwatch** class which is helpful to measure the milliseconds it takes a statement execute.

I created a Console program to execute many **Find** and **Find2** invokations with increasing wordstreams. I did it that way to test if there are any performance differences when it looks for just one word or many.

The program was compiled in release mode using the command:
    
    dotnet publish -c release -r linux-x64 --self-contained

Because of this, I assume that the compilation did additional optimizations to make it run faster.

**Stopwatch sample code**:

    Console.Write("\n[Find] (char based algorithm): ");
    var watch = System.Diagnostics.Stopwatch.StartNew();
    mostFrequent = wf.Find(wordsToFind.Take(attempts + 1));
    watch.Stop();
    var elapsedMs = watch.ElapsedMilliseconds;
    Console.WriteLine("\n[Find] Top 10 words: ");
    foreach(string word in mostFrequent)
        Console.Write($"{word},");
    Console.WriteLine($"\n[Find] took {elapsedMs} milliseconds!\n");

# Results

Both methods are returning the same results but they differ for some milliseconds. Also there are some differences in the performance when we add more words in the wordstream.

| Wordstream size | Find (char comparison)<br>Elapsed time in ms | Find2 (regex)<br>Elapsed time in ms |
|:---------------:|:-------------------------:|:-------------------------:|
|1                |27                          |10                          |
|2                |1                          |0                          |
|3                |0                          |1                          |
|4                |0                          |2                          |
|5                |0                          |1                          |
|6                |0                          |2                          |
|7                |0                          |3                          |
|8                |0                          |2                          |
|9                |0                          |2                          |
|10                |0                          |2                          |
|11                |0                          |4                          |
|12                |0                          |3                          |
|13                |1                          |3                          |
|14                |1                          |6                          |
|15                |1                          |6                          |
|16                |1                          |7                          |
|17                |1                          |5                          |
|18                |1                          |4                          |
|19                |1                          |8                          |
|20                |1                          |5                          |

**Observations**

* Based on the information on the chart, we can see that only in the first execution at the start of the program the **Find** method performs worst that the **Find2**. This could be related to the **release mode** optimizations I mentioned before.

* From the first 20 iterations it seems that the runtime execution is optimized to perform better in the case of the **Find** method which is based on simple char comparisson and the use of the internal char matrix.

* **Find2** method, which is transforming the rows and columns of the internal char matrix to a string, in order to make use of regular expressions, it's having a slower performance, maybe because of the constant instantiation and destruction of those strings or single dimensional char arrays and also the RegEx instances.

* **Bigger wordstreams**: at the end of the Console execution, the last invokations are made passing a 69 length wordstream. At this point **Find** is taking 4 milliseconds, on the other hand **Find2** is taking 16 milliseconds.

# Full console output
<details>
  
  <summary>The program tests up to 69 words in a single run. Here is a sample of a complete console output: click to expand!</summary>
  
  ## Output
  
    char matrix[,] content:

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
    [#0] Execute Find with just 1 word/s:

    [Find] (char based algorithm): (Lorem,11),
    [Find] Top 10 words: 
    Lorem,
    [Find] took 22 milliseconds!


    [Find2] (regex based algorithm): (Lorem,11),
    [Find2] Top 10 words: 
    Lorem,
    [Find2] took 9 milliseconds!

    [#1] Execute Find with just 2 word/s:

    [Find] (char based algorithm): (Lorem,11),(ipsum,7),
    [Find] Top 10 words: 
    Lorem,ipsum,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (Lorem,11),(ipsum,7),
    [Find2] Top 10 words: 
    Lorem,ipsum,
    [Find2] took 0 milliseconds!

    [#2] Execute Find with just 3 word/s:

    [Find] (char based algorithm): (dolor,18),(Lorem,11),(ipsum,7),
    [Find] Top 10 words: 
    dolor,Lorem,ipsum,
    [Find] took 0 milliseconds!


    [Find2] (regex based algorithm): (dolor,18),(Lorem,11),(ipsum,7),
    [Find2] Top 10 words: 
    dolor,Lorem,ipsum,
    [Find2] took 1 milliseconds!

    [#3] Execute Find with just 4 word/s:

    [Find] (char based algorithm): (dolor,18),(sit,13),(Lorem,11),(ipsum,7),
    [Find] Top 10 words: 
    dolor,sit,Lorem,ipsum,
    [Find] took 0 milliseconds!


    [Find2] (regex based algorithm): (dolor,18),(sit,13),(Lorem,11),(ipsum,7),
    [Find2] Top 10 words: 
    dolor,sit,Lorem,ipsum,
    [Find2] took 1 milliseconds!

    [#4] Execute Find with just 5 word/s:

    [Find] (char based algorithm): (dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),
    [Find] Top 10 words: 
    dolor,sit,Lorem,amet,ipsum,
    [Find] took 0 milliseconds!


    [Find2] (regex based algorithm): (dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),
    [Find2] Top 10 words: 
    dolor,sit,Lorem,amet,ipsum,
    [Find2] took 2 milliseconds!

    [#5] Execute Find with just 6 word/s:

    [Find] (char based algorithm): (dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),
    [Find] Top 10 words: 
    dolor,sit,Lorem,amet,ipsum,consectetur,
    [Find] took 0 milliseconds!


    [Find2] (regex based algorithm): (dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),
    [Find2] Top 10 words: 
    dolor,sit,Lorem,amet,ipsum,consectetur,
    [Find2] took 2 milliseconds!

    [#6] Execute Find with just 7 word/s:

    [Find] (char based algorithm): (dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(adipiscing,0),
    [Find] Top 10 words: 
    dolor,sit,Lorem,amet,ipsum,consectetur,adipiscing,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(adipiscing,0),
    [Find2] Top 10 words: 
    dolor,sit,Lorem,amet,ipsum,consectetur,adipiscing,
    [Find2] took 3 milliseconds!

    [#7] Execute Find with just 8 word/s:

    [Find] (char based algorithm): (elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(adipiscing,0),
    [Find] Top 10 words: 
    elit,dolor,sit,Lorem,amet,ipsum,consectetur,adipiscing,
    [Find] took 0 milliseconds!


    [Find2] (regex based algorithm): (elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(adipiscing,0),
    [Find2] Top 10 words: 
    elit,dolor,sit,Lorem,amet,ipsum,consectetur,adipiscing,
    [Find2] took 3 milliseconds!

    [#8] Execute Find with just 9 word/s:

    [Find] (char based algorithm): (elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(sed,2),(adipiscing,0),
    [Find] Top 10 words: 
    elit,dolor,sit,Lorem,amet,ipsum,consectetur,sed,adipiscing,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(sed,2),(adipiscing,0),
    [Find2] Top 10 words: 
    elit,dolor,sit,Lorem,amet,ipsum,consectetur,sed,adipiscing,
    [Find2] took 2 milliseconds!

    [#9] Execute Find with just 10 word/s:

    [Find] (char based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(sed,2),(adipiscing,0),
    [Find] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,consectetur,sed,adipiscing,
    [Find] took 0 milliseconds!


    [Find2] (regex based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(sed,2),(adipiscing,0),
    [Find2] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,consectetur,sed,adipiscing,
    [Find2] took 2 milliseconds!

    [#10] Execute Find with just 11 word/s:

    [Find] (char based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(eiusmod,4),(sed,2),
    [Find] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,consectetur,eiusmod,sed,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(eiusmod,4),(sed,2),
    [Find2] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,consectetur,eiusmod,sed,
    [Find2] took 3 milliseconds!

    [#11] Execute Find with just 12 word/s:

    [Find] (char based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(tempor,5),(eiusmod,4),
    [Find] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,consectetur,tempor,eiusmod,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(consectetur,5),(tempor,5),(eiusmod,4),
    [Find2] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,consectetur,tempor,eiusmod,
    [Find2] took 3 milliseconds!

    [#12] Execute Find with just 13 word/s:

    [Find] (char based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(incididunt,7),(consectetur,5),(tempor,5),
    [Find] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,incididunt,consectetur,tempor,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (do,66),(elit,39),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(incididunt,7),(consectetur,5),(tempor,5),
    [Find2] Top 10 words: 
    do,elit,dolor,sit,Lorem,amet,ipsum,incididunt,consectetur,tempor,
    [Find2] took 3 milliseconds!

    [#13] Execute Find with just 14 word/s:

    [Find] (char based algorithm): (do,66),(elit,39),(ut,35),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(incididunt,7),(consectetur,5),
    [Find] Top 10 words: 
    do,elit,ut,dolor,sit,Lorem,amet,ipsum,incididunt,consectetur,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (do,66),(elit,39),(ut,35),(dolor,18),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(incididunt,7),(consectetur,5),
    [Find2] Top 10 words: 
    do,elit,ut,dolor,sit,Lorem,amet,ipsum,incididunt,consectetur,
    [Find2] took 3 milliseconds!

    [#14] Execute Find with just 15 word/s:

    [Find] (char based algorithm): (do,66),(elit,39),(ut,35),(dolor,18),(labore,14),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(incididunt,7),
    [Find] Top 10 words: 
    do,elit,ut,dolor,labore,sit,Lorem,amet,ipsum,incididunt,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (do,66),(elit,39),(ut,35),(dolor,18),(labore,14),(sit,13),(Lorem,11),(amet,9),(ipsum,7),(incididunt,7),
    [Find2] Top 10 words: 
    do,elit,ut,dolor,labore,sit,Lorem,amet,ipsum,incididunt,
    [Find2] took 4 milliseconds!

    [#15] Execute Find with just 16 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(labore,14),(sit,13),(Lorem,11),(amet,9),(ipsum,7),
    [Find] Top 10 words: 
    et,do,elit,ut,dolor,labore,sit,Lorem,amet,ipsum,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(labore,14),(sit,13),(Lorem,11),(amet,9),(ipsum,7),
    [Find2] Top 10 words: 
    et,do,elit,ut,dolor,labore,sit,Lorem,amet,ipsum,
    [Find2] took 4 milliseconds!

    [#16] Execute Find with just 17 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(labore,14),(sit,13),(Lorem,11),(dolore,10),(amet,9),
    [Find] Top 10 words: 
    et,do,elit,ut,dolor,labore,sit,Lorem,dolore,amet,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(labore,14),(sit,13),(Lorem,11),(dolore,10),(amet,9),
    [Find2] Top 10 words: 
    et,do,elit,ut,dolor,labore,sit,Lorem,dolore,amet,
    [Find2] took 4 milliseconds!

    [#17] Execute Find with just 18 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(magna,15),(labore,14),(sit,13),(Lorem,11),(dolore,10),
    [Find] Top 10 words: 
    et,do,elit,ut,dolor,magna,labore,sit,Lorem,dolore,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(magna,15),(labore,14),(sit,13),(Lorem,11),(dolore,10),
    [Find2] Top 10 words: 
    et,do,elit,ut,dolor,magna,labore,sit,Lorem,dolore,
    [Find2] took 5 milliseconds!

    [#18] Execute Find with just 19 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(magna,15),(labore,14),(sit,13),(Lorem,11),(dolore,10),
    [Find] Top 10 words: 
    et,do,elit,ut,dolor,magna,labore,sit,Lorem,dolore,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(magna,15),(labore,14),(sit,13),(Lorem,11),(dolore,10),
    [Find2] Top 10 words: 
    et,do,elit,ut,dolor,magna,labore,sit,Lorem,dolore,
    [Find2] took 5 milliseconds!

    [#19] Execute Find with just 20 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(magna,15),(labore,14),(sit,13),(Lorem,11),(dolore,10),
    [Find] Top 10 words: 
    et,do,elit,ut,dolor,magna,labore,sit,Lorem,dolore,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(magna,15),(labore,14),(sit,13),(Lorem,11),(dolore,10),
    [Find2] Top 10 words: 
    et,do,elit,ut,dolor,magna,labore,sit,Lorem,dolore,
    [Find2] took 6 milliseconds!

    [#20] Execute Find with just 21 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),(Lorem,11),
    [Find] Top 10 words: 
    et,do,elit,ut,dolor,enim,magna,labore,sit,Lorem,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),(Lorem,11),
    [Find2] Top 10 words: 
    et,do,elit,ut,dolor,enim,magna,labore,sit,Lorem,
    [Find2] took 6 milliseconds!

    [#21] Execute Find with just 22 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#22] Execute Find with just 23 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 1 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#23] Execute Find with just 24 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#24] Execute Find with just 25 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#25] Execute Find with just 26 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#26] Execute Find with just 27 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 8 milliseconds!

    [#27] Execute Find with just 28 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 8 milliseconds!

    [#28] Execute Find with just 29 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#29] Execute Find with just 30 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 8 milliseconds!

    [#30] Execute Find with just 31 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#31] Execute Find with just 32 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(dolor,18),(enim,18),(magna,15),(labore,14),(sit,13),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,dolor,enim,magna,labore,sit,
    [Find2] took 7 milliseconds!

    [#32] Execute Find with just 33 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),(labore,14),
    [Find] Top 10 words: 
    et,do,elit,ad,ut,ex,dolor,enim,magna,labore,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),(labore,14),
    [Find2] Top 10 words: 
    et,do,elit,ad,ut,ex,dolor,enim,magna,labore,
    [Find2] took 7 milliseconds!

    [#33] Execute Find with just 34 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 9 milliseconds!

    [#34] Execute Find with just 35 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 8 milliseconds!

    [#35] Execute Find with just 36 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 9 milliseconds!

    [#36] Execute Find with just 37 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 2 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 8 milliseconds!

    [#37] Execute Find with just 38 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 8 milliseconds!

    [#38] Execute Find with just 39 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 9 milliseconds!

    [#39] Execute Find with just 40 word/s:

    [Find] (char based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),(magna,15),
    [Find2] Top 10 words: 
    et,do,ea,elit,ad,ut,ex,dolor,enim,magna,
    [Find2] took 9 milliseconds!

    [#40] Execute Find with just 41 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find2] took 9 milliseconds!

    [#41] Execute Find with just 42 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find2] took 11 milliseconds!

    [#42] Execute Find with just 43 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find2] took 13 milliseconds!

    [#43] Execute Find with just 44 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(dolor,18),(enim,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,dolor,enim,
    [Find2] took 13 milliseconds!

    [#44] Execute Find with just 45 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find2] took 13 milliseconds!

    [#45] Execute Find with just 46 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find2] took 13 milliseconds!

    [#46] Execute Find with just 47 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find2] took 12 milliseconds!

    [#47] Execute Find with just 48 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),(dolor,18),
    [Find2] Top 10 words: 
    in,et,do,ea,elit,ad,ut,ex,velit,dolor,
    [Find2] took 12 milliseconds!

    [#48] Execute Find with just 49 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 14 milliseconds!

    [#49] Execute Find with just 50 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 13 milliseconds!

    [#50] Execute Find with just 51 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 14 milliseconds!

    [#51] Execute Find with just 52 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 3 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 10 milliseconds!

    [#52] Execute Find with just 53 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 11 milliseconds!

    [#53] Execute Find with just 54 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 11 milliseconds!

    [#54] Execute Find with just 55 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 11 milliseconds!

    [#55] Execute Find with just 56 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 11 milliseconds!

    [#56] Execute Find with just 57 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 11 milliseconds!

    [#57] Execute Find with just 58 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 11 milliseconds!

    [#58] Execute Find with just 59 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 12 milliseconds!

    [#59] Execute Find with just 60 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 12 milliseconds!

    [#60] Execute Find with just 61 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(elit,39),(ad,39),(ut,35),(ex,30),(velit,23),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,elit,ad,ut,ex,velit,
    [Find2] took 17 milliseconds!

    [#61] Execute Find with just 62 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find] took 7 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find2] took 18 milliseconds!

    [#62] Execute Find with just 63 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find] took 6 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find2] took 12 milliseconds!

    [#63] Execute Find with just 64 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find2] took 14 milliseconds!

    [#64] Execute Find with just 65 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find2] took 13 milliseconds!

    [#65] Execute Find with just 66 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),(ex,30),
    [Find2] Top 10 words: 
    in,et,do,eu,ea,qui,elit,ad,ut,ex,
    [Find2] took 13 milliseconds!

    [#66] Execute Find with just 67 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(id,67),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),
    [Find] Top 10 words: 
    in,et,id,do,eu,ea,qui,elit,ad,ut,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(id,67),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),
    [Find2] Top 10 words: 
    in,et,id,do,eu,ea,qui,elit,ad,ut,
    [Find2] took 14 milliseconds!

    [#67] Execute Find with just 68 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(id,67),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),
    [Find] Top 10 words: 
    in,et,id,do,eu,ea,qui,elit,ad,ut,
    [Find] took 5 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(id,67),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),
    [Find2] Top 10 words: 
    in,et,id,do,eu,ea,qui,elit,ad,ut,
    [Find2] took 13 milliseconds!

    [#68] Execute Find with just 69 word/s:

    [Find] (char based algorithm): (in,73),(et,70),(id,67),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),
    [Find] Top 10 words: 
    in,et,id,do,eu,ea,qui,elit,ad,ut,
    [Find] took 4 milliseconds!


    [Find2] (regex based algorithm): (in,73),(et,70),(id,67),(do,66),(eu,55),(ea,45),(qui,43),(elit,39),(ad,39),(ut,35),
    [Find2] Top 10 words: 
    in,et,id,do,eu,ea,qui,elit,ad,ut,
    [Find2] took 16 milliseconds!


</details>