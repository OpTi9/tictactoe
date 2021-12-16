// class managing the gameTTT logic
public class GameTTT {

  public static void gameLogic(int gameType, TicTacToeField game) {
    while(!game.isVictory(1) && !game.isVictory(2) && !game.isDraw()) {
      int x = 0;
      int y = 0;
      bool isParsed;

      Console.Clear();
      game.drawField();

      // ask player for a move
      if(game.isPlayer1Turn){
        Console.WriteLine("Player 1: Enter your move");
      } else {
        Console.WriteLine("Player 2: Enter your move");
      }

      if(gameType != 2) {
        Console.WriteLine("Input x (1-3):");
        // try to parse the input
        isParsed = int.TryParse(Console.ReadLine(), out x);
        if(!isParsed) {
          // input is not an integer, try again
          continue;
        }

        // check if x and y are in range
        if(!isParsed || x <= 0 || x > game.field.GetLength(0)) {
          Console.WriteLine("Invalid move!");
          Console.WriteLine("Press any key to try again");
          Console.ReadKey();
          continue;
        }

      }

      Console.WriteLine("Input y:");
      // try to parse the input
      isParsed = int.TryParse(Console.ReadLine(), out y);
      if(!isParsed) {
        // input is not an integer, try again
        continue;
      }
      // check if y in range
      if(!isParsed || y <= 0 || y > game.field.GetLength(1)) {
        Console.WriteLine("Invalid move!");
        Console.WriteLine("Press any key to try again");
        Console.ReadKey();
        continue;
      }

      // check if the field is empty
      if(!game.isEmpty(x-1, y-1)) {
        Console.WriteLine("Field is already occupied!");
        Console.WriteLine("Press any key to try again");
        Console.ReadKey();
        continue;
      }

      // make turn
      if(game.isPlayer1Turn) {
        // player 1 turn
        game.makeTurn(x-1, y-1, 1);
      } else {
        // player 2 turn
        game.makeTurn(x-1, y-1, 2);
      }

      // switch player turn
      game.isPlayer1Turn = !game.isPlayer1Turn;
      // last print in case gameTTT end
      game.drawField();

    }
  }

  static void Main(string[] args) {
    // 1 - tic tac toe, 2 - connect 4
    int gameMode = 0;
    // is user gameTTT mode input valid
    bool isGameMode;

    // make sure user enters a valid gameTTT mode
    while (gameMode != 1 && gameMode != 2) {
      Console.Clear();
      Console.WriteLine("1. Play tic tac toe");
      Console.WriteLine("2. Play connect 4");
      Console.WriteLine("____________________");
      Console.Write("Enter game mode: ");
      isGameMode = int.TryParse(Console.ReadLine(), out gameMode);
      if(!isGameMode || gameMode < 1 || gameMode > 2) {
        Console.WriteLine("Invalid input, press any key to try again");
        Console.ReadKey();
        continue;
      }
    }

    // select a gameTTT mode
    switch (gameMode) {
      // tic tac toe gameTTT mode
      case 1:
        // create a new field with a given size
        TicTacToeField gameTTT = new TicTacToeField(3,3);
        gameLogic(gameMode, gameTTT);
        break;
      // connect four gameTTT mode
      case 2:
        // create a new field with a given size
        Connect4Field gameConnect4 = new Connect4Field(4,7);
        gameLogic(gameMode, gameConnect4);
        break;
    }


  }
}