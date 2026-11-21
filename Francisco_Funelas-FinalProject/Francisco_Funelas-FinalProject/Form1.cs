namespace Francisco_Funelas_FinalProject
{
    public partial class Form1 : Form
    {
        private Label[,] grid;
        private Button[,] keyboard;
        private int currRow, currCol;
        private int formWidth, formHeight;

        public Form1()
        {
            InitializeComponent();
            grid = new Label[6, 5];
            keyboard = new Button[3, 10];
            currRow = 0;
            currCol = 0;
            formWidth = this.ClientSize.Width;
            formHeight = this.ClientSize.Height;
            CreateGrid();
            CreateKeyboard();
        }

        private void CreateGrid()
        {
            int size = 50;
            int padding = 10;
            int leftMargin = (formWidth - (5 * size + 4 * padding)) / 2;
            int topMargin = 150; // temp value

            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    Label letter = new Label();

                    letter.Width = size;
                    letter.Height = size;
                    letter.Left = leftMargin + (c * (size + padding));
                    letter.Top = topMargin + (r * (size + padding));
                    letter.BackColor = Color.White;
                    letter.Text = "";
                    letter.TextAlign = ContentAlignment.MiddleCenter;

                    grid[r, c] = letter;
                    this.Controls.Add(letter);
                }
            }
        }

        private void CreateKeyboard()
        {
            string[] keys =
            {
                "QWERTYUIOP",
                "ASDFGHJKL",
                "ZXCVBNM"
            };

            int size = 40;
            int padding = 5;
            int topMargin = 550;

            for (int r = 0; r < 3; r++)
            {
                int rowWidth = keys[r].Length * (size + padding) - padding;
                int leftMargin = (formWidth - rowWidth) / 2;

                for (int c = 0; c < keys[r].Length; c++)
                {
                    Button key = new Button();
                    key.Text = keys[r][c].ToString();
                    key.Width = size;
                    key.Height = size;
                    key.Left = leftMargin + c * (size + padding);
                    key.Top = topMargin + r * (size + padding);
                    key.BackColor = Color.White;
                    key.Click += keyboard_Click;

                    keyboard[r, c] = key;
                    this.Controls.Add(key);
                }
            }

            int lastRowWidth = keys[2].Length * (size + padding) - padding;
            int lastRowMargin = (formWidth - lastRowWidth) / 2;

            Button backspace = new Button();
            backspace.Text = "⌫";
            backspace.Width = 60;
            backspace.Height = size;
            backspace.Left = lastRowMargin - 60 - padding;
            backspace.Top = topMargin + 2 * (size + padding);
            backspace.Click += backspace_Click;

            Button enter = new Button();
            enter.Text = "⏎";
            enter.Width = 60;
            enter.Height = size;
            enter.Left = lastRowMargin + lastRowWidth + padding;
            enter.Top = topMargin + 2 * (size + padding);
            enter.Click += enter_Click;

            this.Controls.Add(backspace);
            this.Controls.Add(enter);
        }

        private void keyboard_Click(object sender, EventArgs e)
        {
            Button key = (Button)sender;

            if (currCol < 5)
            {
                grid[currRow, currCol].Text = key.Text;
                currCol++;
            }
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (currCol > 0)
            {
                currCol--;
                grid[currRow, currCol].Text = "";
            }
        }

        private void enter_Click(object sender, EventArgs e)
        {
            if (currCol == 5)
            {
                currRow++;
                currCol = 0;
            }
            // need to add right/wrong word and check guess + recoloring
        }
    }
}
