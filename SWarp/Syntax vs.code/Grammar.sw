﻿Commandon:

SWarp --compile {SWarpfile.sw}    --compiles to SWarp.exe with the chosen file
SWarp -f {SWarpfile.sw}			  -- Runs the chosen file
SWarp.exe						  -- Runs the compiled executable



SWarp syntax
***********************************************************************************************************


Förklaringar:

(Metod)						Starta metoden och namnet på metoden
{Variabel}					Delklarera Variabel
'RowText'					Delklarera text till metod eller variabel
@Delegate@					Delklarera kod som ska köras i egna metoden
MetodStart:MetodNamn		Delklarera start av metod och namnet på metoden
MetodSlut					Slut av metoden

Metoder nu:

(MetodStart)
(MetodSlut)
(Räkna)
(Om)
(Skriv)
(Läs)
(SåLänge)



***********************************************************************************************************



- Skapa en variabel:
		{variabelName} = 'variabel text'



***********************************************************************************************************



- Räkna ut nummer på samma rad, och skriv resultatet på skärmen(Tillfälligt):
		(Räkna) = 'nummer1+nummer2'
		(Räkna) = 'nummer1-nummer2'
		(Räkna) = 'nummer1*nummer2'
		(Räkna) = 'nummer1/nummer2'

- Räkna ut nummer via variabel på en rad och spara i samma variabel(Tillfälligt):
		{variabelName} = 'nummer1+nummer2'
		(Räkna) = {variabelNamn}
		(SkrivUtVariabel) = {variabelName}


- Räkna ut flera olika variabler på olika rader och skriv ut på skärmen

{variabelName1} = '23'
{variabelName2} = '2'
{variabelNameOperator} = '/'

{variabelNameSumma} = (Räkna) = {variabelName1} {variabelName2} {variabelNameOperator}

(Skriv) = {variabelNameSumma}

		
***********************************************************************************************************



- Loopa med function:

		(SåLänge) = {1<200000} @(Skriv) = 'Hello World!'@



***********************************************************************************************************



- Läs text från användaren, sparas i variabeln {variabelNamn}
		{variabelNamn} = (Läs)

- Läs text från användaren med titeltext, sparas i variabeln {variabelNamn}
		{variabelNamn} = (Läs) = 'Detta skrivs ut också'



***********************************************************************************************************



- Skriv ut text på skärmen:
		(Skriv) = 'Detta är texten som kommer skrivas ut'

- Skriv ut variabel på skärmen
		(Skriv) = {variabelNamn}

- Skriv ut text och variabel på skärm
		(Skriv) = {variabelNamn} = 'Detta skrivs ut också'



***********************************************************************************************************



- Skapa en metod:

		MetodStart:NamnetPåMetoden
			{namn} = (LäsIn) = 'Vad heter du? '
			{ålder} = (LäsIn) = 'Hur gammal är du?'
			{nummers} = '5+5'
		MetodStop



***********************************************************************************************************



 - Kör den skapade metoden:

		(KörMetod) = {NamnetPåMetoden}



***********************************************************************************************************