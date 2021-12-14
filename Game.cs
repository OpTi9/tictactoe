// class managing the gameTTT logic
public class GameTTT {
  static void Main(string[] args) {
    // 1 - tic tac toe, 2 - connect 4
    int gameTTTMode = 0;
    // is user gameTTT mode input valid
    bool isGameTTTMode;

    // make sure user enters a valid gameTTT mode
    while (gameTTTMode != 1 && gameTTTMode != 2) {
      Console.Clear();
      Console.WriteLine("1. Play tic tac toe");
      Console.WriteLine("2. Play connect 4");
      Console.WriteLine("____________________");
      Console.Write("Enter game mode: ");
      isGameTTTMode = int.TryParse(Console.ReadLine(), out gameTTTMode);
      if(!isGameTTTMode || gameTTTMode < 1 || gameTTTMode > 2) {
        Console.WriteLine("Invalid input, press any key to try again");
        Console.ReadKey();
        continue;
      }
    }

    // select a gameTTT mode
    switch (gameTTTMode) {
      // tic tac toe gameTTT mode
      case 1:
        // create a new field with a given size
        TicTacToeField gameTTT = new TicTacToeField(3,3);

        //play the gameTTT while at least one gameTTT ending condition is not fulfilled
        while(!gameTTT.isVictory(1) && !gameTTT.isVictory(2) && !gameTTT.isDraw()) {
          Console.Clear();
          // show the field
          gameTTT.drawField();
          
          int x, y;
          bool isParsed;

          // ask player for a move
          if(gameTTT.isPlayer1Turn){
            Console.WriteLine("Player 1: Enter your move");
          } else {
            Console.WriteLine("Player 2: Enter your move");
          }

          Console.WriteLine("Input x (1-3):");
          // try to parse the input
          isParsed = int.TryParse(Console.ReadLine(), out x);
          if(!isParsed) {
            // input is not an integer, try again
            continue;
          }

          Console.WriteLine("Input y (1-3):");
          // try to parse the input
          isParsed = int.TryParse(Console.ReadLine(), out y);
          if(!isParsed) {
            // input is not an integer, try again
            continue;
          }

          // check if x and y are in range
          if(x <= 0 || x > gameTTT.field.GetLength(0) || y <= 0 || y > gameTTT.field.GetLength(1)) {
            Console.WriteLine("Invalid move!");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            continue;
          }
          // check if the field is empty
          if(gameTTT.field[x-1,y-1] != 0) {
            Console.WriteLine("Field is already occupied!");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            continue;
          }

          // make turn
          if(gameTTT.isPlayer1Turn) {
            // player 1 turn
            gameTTT.makeTurn(x-1, y-1, 1);
          } else {
            // player 2 turn
            gameTTT.makeTurn(x-1, y-1, 2);
          }
          // switch player turn
          gameTTT.isPlayer1Turn = !gameTTT.isPlayer1Turn;
          // last print in case gameTTT end
          gameTTT.drawField();
        }
        break;
      // connect four gameTTT mode
      case 2:
        // create a new field with a given size
        Connect4Field gameConnect4 = new Connect4Field(4,7);
        //play the gameTTT while at least one gameTTT ending condition is not fulfilled
        while(!gameConnect4.isVictory(1) && !gameConnect4.isVictory(2) && !gameConnect4.isDraw()) {
          Console.Clear();
          // show the field
          gameConnect4.drawField();
          int y;
          bool isParsed;

          // ask player for a move
          if(gameConnect4.isPlayer1Turn) {
            Console.WriteLine("Player 1: Enter your move");
          } else {
            Console.WriteLine("Player 2: Enter your move");
          }

          Console.WriteLine("Input y (1-7):");
          // try to parse the input
          isParsed = int.TryParse(Console.ReadLine(), out y);
          
          // check if x and y are in range
          if(!isParsed || y <= 0 || y > gameConnect4.field.GetLength(1)) {
            Console.WriteLine("Invalid move!");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            continue;
          }
          
          // check if the field is empty
          if(!gameConnect4.isEmpty(0, y-1)) {
            Console.WriteLine("No space left!");
            Console.WriteLine("Press any key to try again");
            Console.ReadKey();
            continue;
          }

          // make turn
          if(gameConnect4.isPlayer1Turn) {
            // player 1 turn
            gameConnect4.makeTurn(0, y-1, 1);
          } else {
            // player 2 turn
            gameConnect4.makeTurn(0, y-1, 2);
          }

          // switch player turn
          gameConnect4.isPlayer1Turn = !gameConnect4.isPlayer1Turn;
          // last print in case gameTTT end
          gameConnect4.drawField();

        }

        break;
    }


  }
}