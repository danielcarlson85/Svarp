﻿(SåLänge){1<200000}@(SkrivUtVariabel){nummers}@

MetodStart:Räkna
	teste{namn}(LäsInklTitel)"Vad heter du? "
	test{ålder}(LäsInklTitel)"Hur gammal är du?"
	teset{nummers}"5+5"
	(SåLänge){1<200000}@(SkrivUtVariabel){nummers}@
MetodStop


MetodStart:Sluta
	{namn}(LäsInklTitel)"Vad heter du? "
	{ålder}(LäsInklTitel)"Hur gammal är du?"
	{nummers}"5+5"
MetodStop

{nummers}"5+5"
--(RäknaUtVariabel){nummers}
--(SkrivUtVariabel){nummers}

--Detta är en kommentar







--(SåLänge){1<200000} @(SkrivUt)"Hello World!"@

--{namn}(LäsInklTitel)"Vad heter du? "
--{ålder}(LäsInklTitel)"Hur gammal är du?"
--(SkrivUtVariabelOchText){namn}"Välkommen "
--(SkrivUtVariabelOchText){ålder}"Du är "
--{nummers}"5+5"
--(RäknaUtVariabel){nummers}
--(SkrivUtVariabel){nummers}


--(SkrivUt)"Hej"
--{variabelNamn}(LäsInklTitel)"Detta skrivs ut också när du gör en Läs: "
--(SkrivUtVariabel){variabelNamn}

--{nummers}"uppdaterade variabeln"
--(SkrivUtVariabel){nummers}
--(SkrivUt)"hej"
--(RäknaUt)"4+4"
--(RäknaUtVariable){nummers}
--(SkrivUtVariabel){nummers}
--{variabel1}(LäsInklTitel)"hej"
--{variabel6}"Daniel"
--(SkrivUtVariabelOchText){variabel6}"hej "
--(SkrivUtVariabel){nummers}
--(RäknaUt)"22+22"
--{variabel2}"Detta är värdet i variabeln"
--(SkrivUtVariabel){variabel2}
--(RäknaUt)"34*44"
--(LäsInklTitel)"Vad heter du? "{var1}
--(SkrivUtVariabelOchText)"Hej "{var1}
--{nummers}(LäsInklTitel)"Räkna ut: "
--(RäknaUtVariabel){nummers}
--(SkrivUtVariabelOchText){nummers}"Detta skrivs ut också"
--(SkrivUtVariabel){nummers}