// Class managing the game field and actions.
public class TicTacToeField {

    // array of the game field
    public int[,] field;
    // bool used to check whose turn it is
    public bool isPlayer1Turn = true;

    // Constructor that accepts the size of the field
    public TicTacToeField(int x, int y) {
        // Create the field array
        this.field = new int[x, y];
        // Fill the field with 0
        for (int i = 0; i < x; i++) {
            for (int j = 0; j < y; j++) {
                this.field[i, j] = 0;
            }
        }
    }

    // Checks if the field is empty.
    public virtual bool isEmpty(int x, int y) {
        if (this.field[x, y] == 0) {
            return true;
        } else {
            return false;
        }
    }
    // Make a turn on a selected field
    public virtual void makeTurn(int x, int y, int player) {
        if (isEmpty(x, y)) {
            this.field[x, y] = player;
        } else {
            Console.WriteLine("Field is already taken!");
        }
    }
    // Check if the same player filled an entire row
    public virtual bool isRowCompleted(int x, int player) {
        for (int i = 0; i < this.field.GetLength(1); i++) {
            if (this.field[x, i] != player) {
                // row is not completed
                return false;
            }
        }
        // the row is completed
        return true;
    }
    // Check if the same player filled an entire column
    public bool isColumnCompleted(int y, int player) {
        for (int i = 0; i < this.field.GetLength(0); i++) {
            if (this.field[i, y] != player) {
                // column is not completed
                return false;
            }
        }
        // the column is completed
        return true;
    }
    // check if the same player filled an entire diagonal
    public virtual bool isDiagonalCompleted(int player, int diagonal) {
        switch (diagonal) { 
            case 1:
                for (int i = 0; i < this.field.GetLength(0); i++)
                {
                    // check first diagonal
                    if (this.field[i, i] != player)
                    {
                        // diagonal is not completed
                        return false;
                    }
                }
                // diagonal is completed
                return true;
            case 2:
                for (int i = 0; i < this.field.GetLength(0); i++) {
                    // check second diagonal
                    if (this.field[i, this.field.GetLength(0) - i - 1] != player)
                    {
                        // diagonal is not completed
                        return false;
                    }
                }
                // diagonal is completed
                return true;
        }
        return false;
    }


    // check if a player has won the game
    public virtual bool isVictory(int player) {
        for (int i = 0; i < this.field.GetLength(0); i++) {
            // check if the same player filled an entire row or column
            if (isRowCompleted(i, player) || isColumnCompleted(i, player)) {
                // Player has won
                Console.WriteLine("Player " + player + " has won!");
                return true;
            }
        }
        // check if the same player filled an entire diagonal
        if (isDiagonalCompleted(player,1) || isDiagonalCompleted(player, 2)) {
            // Player has won
            Console.WriteLine("Player " + player + " has won!");
            return true;
        }
        // No one has won
        return false;
    }

    // check if no one has won the game
    public bool isDraw() {
        for (int i = 0; i < this.field.GetLength(0); i++) {
            for (int j = 0; j < this.field.GetLength(1); j++) {
                // check if there are any empty fields
                if (isEmpty(i, j)) {
                    // game is not draw
                    return false;
                }
            }
        }
        // game is draw
        Console.WriteLine("Game is draw!");
        return true;
    }

    // function used to print the field in the console, 0 is empty, 1 is player 1, 2 is player 2
    public void drawField() {
        for (int i = 0; i < this.field.GetLength(0); i++) {
            //Console.WriteLine(" _  _  _");
            for (int j = 0; j < this.field.GetLength(1); j++) {
                switch (this.field[i, j]) {
                    case 0:
                        Console.Write("[" + " " + "]");
                        break;
                    case 1:
                        Console.Write("[" + "x" + "]");
                        break;
                    case 2:
                        Console.Write("[" + "o" + "]");
                        break;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}