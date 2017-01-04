### Overview

Feel free to change any part of the existing implementation that you like. 
It is currently implemented just enough to satisfy the test scenarios that have been laid out. 
This is not intended to be an all encompassing solution. Add as many other classes and tests as you like. 
Corrections should be suggested for the following circumstances:

### Part I - Ownership by a proper single noun

* Proper nouns suffixed with "s", followed by a noun, need an apostrophe before the "s".
* Proper nouns suffixed with "s", preceded by "is", need an apostrophe before the "s".

NOTE: There are fully implemented unit tests for these scenarios. You just need to make them pass.

### Part II - Contractions

* isnt, wont, and doesnt need apostrophes

NOTE: There are no preexisting unit tests for this part. Please author these tests as you see fit.

### Part III - Regular nouns do not need apostrophes

* common mistakes recognition

NOTE: There are fully implemented unit tests for these scenarios. You just need to make them pass.

### Summary

Your goal is to implement the "CorrectionFinder" class to accomodate the logic described above.  To this end, some tools have been laid out for you.  Specifically, the Dictionary class will tell you the type of of a word.  Noun, plural noun, etc...  At least to the extent of the text that is in the existing unit tests.  All you really need to do is find a way to read the text, analyze it, and report the right "corrections".  Your solution will be evaluated on it's design first and implementation second.  Meaning, what kind of classes you create and what responsibilities you give them say as much to us as the implementation details.

### Tools

This example was written in Visual Studio 2015.  A compatible free version can be found here: https://www.visualstudio.com/en-us/products/visual-studio-community-vs


