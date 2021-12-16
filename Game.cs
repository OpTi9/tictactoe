public class GameTTT {
  static void Main(string[] args) {
    // 1 - tic tac toe, 2 - connect 4
    int gameMode = 0;
    // is user game mode input valid
    bool isGameMode;

    // make sure user enters a valid game mode
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

    GameLogic game = new GameLogic();

    switch (gameMode) {
      // tic tac toe gameTTT mode
      case 1:
        // create a new field with a given size
        TicTacToeField gameTTT = new TicTacToeField(3,3);
        game.play(gameMode, gameTTT);
        //(gameMode, gameTTT);
        break;
      // connect four gameTTT mode
      case 2:
        // create a new field with a given size
        Connect4Field gameConnect4 = new Connect4Field(4,7);
        game.play(gameMode, gameConnect4);
        break;
    }


  }
}