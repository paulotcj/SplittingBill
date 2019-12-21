# SplittingBill
This application consumes a text input containing each participant expenses and output a split bill.

Problem:
Each participant will incur in (uneven) expenses during a certain event, and at the end of each event, the costs should be divided equally among the participants.

Solution:
 - At the end of each event, the individual costs of each participant should be added.
 - Then the grand total should be generated.
 - The bill then is divided into equal parts among the participants.
 - Then the 'due part' is the net cost that each individual will occur, it is the difference between <split bill> - <total already paid>. Positive values mean the participant need to pay the specific amount indicated, negative values mean the participant need to collect that specific value from other participants.
<br />
    Example:
        Participant 1 expenses:
            3.69
            7.15
		Participant 1 total expenses:
		    10.84
		-------------------------------	
        Participant 2 expenses:
            11.22
            9.99
		Participant 2 total expenses:
            21.21

	    -------------------------------
		Grand Total:
            32.05	
		Split Bill:
            16.025000	

        -------------------------------
		Participant 1 Due part:
            5.18500
		Participant 2 Due part:
            -5.18500


	(see the excel file for more examples)
	

	
Input:
 - Text file
 - Terminated with 0 (zero), either in the case of an empty file or after reading all data from an event
 - Format:
 <br />
	<number of participants event 1><br />
	<participant 1 with n receipts><br />
	<receipt 1><br />
	    ...<br />
	<receipt n><br />
	<participant 2 with n receipts><br />
	<receipt 1><br />
	    ...<br />
	<receipt n><br />
	...<br />
	<participant n with n receipts><br />
	<receipt 1><br />
	    ...<br />
	<receipt n><br />
	<number of participants event 2><br />
	    ...<br />
	
Example:<br />
<br />
3<br />
2<br />
21<br />
33<br />
4<br />
26<br />
25.1<br />
12<br />
14.03<br />
3<br />
15<br />
17<br />
11<br />
2<br />
2<br />
3.69<br />
7.15<br />
2<br />
11.22<br />
9.99<br />
0<br />
<br />
Details:<br />
3 ---------------> Event declaration with 3 participants<br />
    2 ----------->  First participant with 2 receipts<br />
        21 ------>   Receipt 1<br />
        33 ------>   Receipt 2<br />
    4 ----------->  Second participant with 4 receipts<br />
        26 ------>   Receipt 1<br />
        25.1 ---->   Receipt 2<br />
        12 ------>   Receipt 3<br />
        14.03 --->   Receipt 4<br />
    3 ----------->  Third participant with 3 receipts<br />
        15 ------>   Receipt 1<br />
        17 ------>   Receipt 2<br />
        11 ------>   Receipt 3<br />
2 ---------------> Event declaration with 2 participants<br />
    2 ----------->  First participant with 2 receipts<br />
        3.69 ---->   Receipt 1<br />
        7.15 ---->   Receipt 2<br />
    2 ----------->  Second participant with 2 receipts<br />
        11.22 --->   Receipt 1<br />
        9.99 ---->   Receipt 2<br />
0 ---------------> End of file<br />




Expected output:
 - Text file in the same directory as the input file with added extension of ".out", if the file was 
 'input.txt' the output will be 'input.txt.out'
 
With the example below the expected output should be:

$4.04<br />
($19.09)<br />
$15.04<br />
<br />
$5.19<br />
($5.19)<br />


