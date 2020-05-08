This solution uses a 24-hour clock
My interpretation of between in this case is an exlusive index "between 10 and 12" only covers the hours 10 and 11; 12 signifies a new hour

First create a Shift. This represents the proper work hours for a babysitter.
Then create a FamilyRate. FamilyRates keep track of pay by the hour
Finally, use the Shift to calculate the pay rate. 

I created the FamilyRate and Shift classes separately.
My intention is that in the future, one might have different hours and want to 
maintain separate shifts without having to re-enter the rates set per families.
