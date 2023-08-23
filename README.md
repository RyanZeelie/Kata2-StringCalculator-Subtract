# Kata2-StringCalculator-Subtract

Requirements
1. Create a simple String calculator with a method int Subtract(string numbers)
- a. The method can take 0, 1 or 2 numbers, and will return their (negative) sum (for an empty string it will return 0) for example "" or "1" or "1,2" should return 0, -1 and -3 respectively
- b. Start with the simplest test case of an empty string and move to 1 and 2 numbers
- c. Remember to solve things as simply as possible so that you force yourself to write tests you did not think about
- d. Remember to refactor after each passing test
2. Allow the Subtract method to handle an unknown amount of numbers
3. Allow the Subtract method to handle new lines between numbers (instead of commas).
- a. the following input is ok: "1\n2,3" (will equal -6)
- b. the following input is NOT ok: "1,\n" (not need to prove it - just clarifying)
4. Support different delimiters
- a. to change a delimiter, the beginning of the string will contain a separate line that looks like this: "##[delimiter]\n[numbers...]" for example "##;\n1;2" should return -3 where the default delimiter is ';'. b. the first line is optional. all existing scenarios should still be supported
5. Calling Subtract with a negative number is presumed to be an error, and should be corrected by you, assume a negative number is actually positive
- a. E.g: 10,-2 should return -12 (not -8)
Additional
1. Numbers bigger than 1000 should throw an exception
- a. If multiple numbers are bigger than 1000, return all of them in the message
2. Delimiters can be of any length with the following format: "##[delimiter]\n" for example: "##[***]\n1***2***3" should return -6
3. Allow multiple delimiters like this: "##[delim1][delim2]\n" for example "##[*] [%] \n1*2%3" should return -6
4. Make sure you can also handle multiple delimiters with length longer than one char
5. Letters can also be provided in place of numbers 0 through 9
- a. 'a' has value 0, 'b' is 1, 'c' is 2....j' is 9
- b. If 'k' or any subsequent letters are provided, silently ignore them and continue calculating the sum of any remaining valid input
- c. E.g: "a,b" should equal -1; "b,c" should equal -3; "i,j,k" should equal-17
6. Allow the identification of delimiter separators by supplying a delimiter-character start flag "<" and end flag ">", just before the character, and at the beginning of the string For example: a. <(>)##(*)\n1*2*3 should return -6
- b. <( denotes that that start of the delimiter is (
- c. >) denotes that the end of the delimiter is)
- d. ## denotes the start of a custom delimiter as per 4.1
- e. <{>}##{%} \n2%3%4 should return -9
- f. <[>}##[::}\n3::4::5 should return -12
- g. <>><##>&<\n4&5&6 should return -15
7. Ensure 6 works with multiple delimiters, with a delimiter length > 1