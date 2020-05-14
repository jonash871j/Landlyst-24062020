using System;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace MeatsStore__CSharp_03122019
{
    public class GameTable
    {
        private GameSystem gsys = new GameSystem();
        private Table gameTable = new Table();

        public GameTable(Table gameTable)
        {
            this.gameTable = gameTable;
        }

        // Used to show the gametable 
        public void ShowTable()
        {
            int count = 1;
            for (int y = 0; y < gsys.LengthRow; y++)
            {
                // Used to break from loop when count equals database row length
                if (count >= gsys.LengthRow)
                    break;

                TableRow row = new TableRow();
                for (int x = 0; x < 4; x++)
                {
                    // Used to break from loop when count equals database row length
                    if (count >= gsys.LengthRow)
                        break;

                    // Content
                    TableCell cell = new TableCell();
                    Label gameTitle = new Label();
                    Label gamePrice = new Label();
                    Label gameAmount = new Label();
                    Button btn = new Button();
                  
                    // Inline html
                    HtmlGenericControl gameBox1 = new HtmlGenericControl("<article class=\"gameBox\"");
                    HtmlGenericControl imageBox = new HtmlGenericControl("img src=\"../Resources/MeatsStore/Cover/gameCover.png\" width=\"128\" height=\"160\"");
                    HtmlGenericControl nextLine1 = new HtmlGenericControl("div");
                    HtmlGenericControl nextLine2 = new HtmlGenericControl("div");
                    HtmlGenericControl nextLine3 = new HtmlGenericControl("div");
                    HtmlGenericControl nextLine4 = new HtmlGenericControl("div");

                    // Sets data from database
                    gameTitle.Text = gsys.GameTable[count, 0];
                    gamePrice.Text = gsys.GameTable[count, 1] + " DKK";
                    gameAmount.Text = "x" + gsys.GameTable[count, 2];

                    // Button option
                    btn.Text = " Add ";
                    btn.ID = count.ToString();
                    btn.Click += new EventHandler(btn_Click);

                    // Adds content to cell
                    cell.Controls.Add(gameBox1);
                    cell.Controls.Add(gameTitle);
                    cell.Controls.Add(nextLine1);
                    cell.Controls.Add(imageBox);
                    cell.Controls.Add(nextLine2);
                    cell.Controls.Add(gamePrice);
                    cell.Controls.Add(nextLine3);
                    cell.Controls.Add(gameAmount);
                    cell.Controls.Add(nextLine4);
                    cell.Controls.Add(btn);

                    // Adds cell to colon
                    row.Cells.Add(cell);
                    count++;
                }
                // Adds new row
                gameTable.Rows.Add(row);
            }

            void btn_Click(object sender, EventArgs e)
            {
                int id = Convert.ToInt32((((Button)sender).ID));

                for (int i = 0; i < GlobalUser.GameBasket.Count; i++)
                    if (GlobalUser.GameBasket[i] == id)
                        return;

                 GlobalUser.GameBasket.Add(id);
            }
        }
    }
}