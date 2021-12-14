// Class managing the connect 4 game, it inherits from the TicTacToeField class
public class Connect4Field : TicTacToeField
{
    // calling the base constructor
    public Connect4Field(int x, int y) : base(x, y) {
        // Initialize the board
    }

    public override bool isEmpty(int x, int y)
    {
        for (int i = 0; i < this.field.GetLength(0); i++) {
            if (this.field[i, y] == 0) {
                return true;
            }
        }
        return false;
    }

    public override void makeTurn(int x, int y, int player)
    {
        for (int i = this.field.GetLength(0) - 1; i >= 0; i--) {
            if (this.field[i, y] == 0) {
                this.field[i, y] = player;
                break;
            }
        }
    }

    // public override bool isDiagonalCompleted(int player, int diagonal)
    // {
        
    // }

    public override bool isVictory(int player)
    {
        for (int i = 0; i < this.field.GetLength(0); i++) {
            // check if the same player filled an entire row or column
            if (isRowCompleted(i, player) || isColumnCompleted(i, player)) {
                // Player has won
                Console.WriteLine("Player " + player + " has won!");
                return true;
            }
        }

        // if (isDiagonalCompleted(player,1)){
        //     return true;
        // }
        
        // No one has won
        return false;
    }

    public override bool isRowCompleted(int x, int player)
    {
        int counter = 0;
            for (int i = 0; i < this.field.GetLength(1); i++)
            {
                if (this.field[x, i] == player) {
                    counter++;
                } else {
                    counter = 0;
                }
                
                if (counter >= 4){
                    return true;
                }
            }
            return false;
    }

}