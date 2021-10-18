(KörMetod) => {NamnetPåMetoden}


(MetodStart):NamnetPåMetoden
	{namn}(Läs) 'Vad heter du? '
	{ålder}(Läs) 'Hur gammal är du?'
	{nummers} '5+5'
	(Skriv) {nummers}
(MetodStop)


























--{variabelNamn} <= 'hej vad heter sdfsd'
--(Skriv) => {variabelNamn}
--
--
--{variabelName1} <= '23'
--{variabelName2} <= '2'
--{variabelNameOperator} <= '/'
--
--	{variabelNameSumma} <= (Räkna) => {variabelName1}{variabelName2}{variabelNameOperator}
--	(Skriv) => {variabelNameSumma}
--
--{variabelName2} <= '2'
--{variabelName1} <= '23'
--{variabelNameOperator} <= '/'
--
--	(Skriv) => 'hej vad heter du?'
--
--
--{nummer1} <= (Läs) <= 'Skriv in första nummret här: '
--
--{variabelName1} <= '23'
--{variabelName2} <= '2'
--{variabelNameOperator} <= '/'
--{variabelNameSumma} <= (Räkna) => {variabelName1}{variabelName2}{variabelNameOperator}
--
--(Räkna) => '12+23'
--(Räkna) => '12-323'
--(Räkna) => '12*23'
--(Räkna) => '23/12'
--
--








--(Skriv) => {variabelNameSumma}


--
--
--{namn}(LäsIn)
--{namn2}(LäsIn)'Hej'
--
--{variabelName1}'23'
--
--
--(SkrivUt)'hej'
--(SkrivUt)'hej'{variabelName1}
--(SkrivUt){variabelName1}



--{nummer1} <= (Läs) <= 'Skriv in första nummret här: '


--{nummer2}(LäsInklTitel)'Skriv in andra nummret här: '
--{operator}(LäsInklTitel)'Skriv vad du vill göra här: '


--{variabelName1}'23'
--{variabelName2}'2'
--{variabelNameOperator}'/'
--{variabelNameSumma}(RäknaUtAllaVariabler){variabelName1}{variabelName2}{variabelNameOperator}
--
--(SkrivUtVariabel){variabelNameSumma}




--{nummer1}'23'
--{nummer2}'2'
--{operator}'+'
--{summa}(RäknaUtAllaVariabler){nummer1}{nummer2}{operator}
--(SkrivUtVariabel){summa}