This solution uses a 24-hour clock
My interpretation of "between" in this case is an exlusive index; "between 10 and 12" only covers the hours 10 and 11; 12 signifies a new hour

First create a Shift. This represents the proper work hours for a babysitter.
Then create a FamilyRate. FamilyRates keep track of pay by the hour
Finally, use the Shift to calculate the pay rate. 

I created the FamilyRate and Shift classes separately.
My intention is that in the future, one might have different hours and want to 
maintain separate shifts without having to re-enter the rates set per families.

---

This solution uses NUnit testing framework. You can run the exe and it will print output of the kata's calculations. You can run it without debug mode as there is a Console.ReadLine() at the end to pause the application. You will see the following output:

BabySitting Calculator Output
Family A pays $15 per hour before 11pm, and $20 per hour the rest of the night
Full Shift:        $190
17 thru 22:        $90
23 thru  3:        $100
1 hour shift @ 17: $15
1 hour shift @ 23: $20

Family B pays $12 per hour before 10pm, $8 between 10 and 12, and $16 the rest of the night
Full Shift:        $124
17 thru 21:        $60
22 thru 23:        $0
 0 thru  3:        $64
1 hour shift @ 17: $12
1 hour shift @ 22: $0
1 hour shift @  0: $16

Family C pays $21 per hour before 9pm, then $15 the rest of the night
Full Shift:        $189
17 thru 21:        $99
22 thru 23:        $30
 0 thru  3:        $60
1 hour shift @ 17: $21
1 hour shift @ 22: $15
1 hour shift @  0: $15
