7/21/2024

- This program parses a scoresheet with input regarding a tennis game. The scoresheet is a boolean array in which points are listed using Player A as reference, i.e true means that Player A won that point and false means player A lost that point which inmediately provides the same information for Player B.

- The Tiebreak functionality has not been coded yet.

- Some improvements can be made like turning the result into an enum to avoid magical strings or improving the ProcessSet() method so it tells a story rather than having all the processing logic inside it.

- The test input has not been optimized to really exercise the code. Extreme cases may break the program at this point.

- A test framework and the correspoiding test classes have not been created yet.