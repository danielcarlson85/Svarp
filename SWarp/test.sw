{nummers}'6'

(Om)<nummers!=5>@(KörMetod){Sluta}@

(KörMetod){Räkna}

(MetodStart):Räkna
	(SkrivUt)'Inne i Räkna metoden'
	{nummers}'10*2343'
	(RäknaUtVariabel){nummers}
	(SkrivUtVariabel){nummers}
(MetodStop)

{namn}(LäsIn)'Vad heter du? '



(MetodStart):Sluta
	(SkrivUt)'Inne i sluta sdfasdfdsmetoden'
	{namn}(LäsInklTitel)'Vad heter du? '
	{ålder}(LäsInklTitel)'Hur gammal är du?'
	{nummers}'5+5'
	(RäknaUtVariabel){nummers}
	(SkrivUtVariabel){nummers}
(MetodStop)


(SåLänge){1<200}@(SkrivUtVariabel){nummers}@

{nummers}'5+5'
(RäknaUtVariabel){nummers}
(SkrivUtVariabel){nummers}

--Detta är en kommentar
(SåLänge){1<200} @(SkrivUt)'Hello World!'@
{namn}(LäsInklTitel)'Vad heter du? '
{ålder}(LäsInklTitel)'Hur gammal är du?'
(SkrivUtVariabelOchText){namn}'Välkommen '
(SkrivUtVariabelOchText){ålder}'Du är '
{nummers}'5+5'
(RäknaUtVariabel){nummers}
(SkrivUtVariabel){nummers}
(SkrivUt)'Hej'
{variabelNamn}(LäsInklTitel)'Detta skrivs ut också när du gör en Läs: '
(SkrivUtVariabel){variabelNamn}

{nummers}'uppdaterade variabeln'
(SkrivUtVariabel){nummers}
(SkrivUt)'hej'
(RäknaUt)'4+4'
(SkrivUtVariabel){nummers}
{variabel1}(LäsInklTitel)'hej'
{variabel6}'Daniel'
(SkrivUtVariabelOchText){variabel6}'hej '
(SkrivUtVariabel){nummers}
(RäknaUt)'22+22'
{variabel2}'Detta är värdet i variabeln'
(SkrivUtVariabel){variabel2}
(RäknaUt)'34*44'
(LäsInklTitel)'Vad heter du? '{var1}
(SkrivUtVariabelOchText)'Hej '{var1}
{nummers}(LäsInklTitel)'Räkna ut: '
(SkrivUtVariabelOchText){nummers}'Detta skrivs ut också'
(SkrivUtVariabel){nummers}