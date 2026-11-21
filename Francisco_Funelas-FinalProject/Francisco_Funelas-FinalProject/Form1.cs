using System.Diagnostics.Metrics;
using System.Drawing.Text;
using System.Text;
using System.Xml;

namespace Francisco_Funelas_FinalProject
{
    public partial class Form1 : Form
    {
        private Label[,] grid;
        private Button[,] keyboard;
        private int currRow, currCol;
        private string correctWord;
        private XmlDocument answerDoc, validWordDoc;
        private bool winner;
        private int formWidth, formHeight;
        private Dictionary<char, Button> keyButtons = new Dictionary<char, Button>();
        private Color colorCorrect = ColorTranslator.FromHtml("#6aaa64");
        private Color colorPresent = ColorTranslator.FromHtml("#c9b458");
        private Color colorAbsent = ColorTranslator.FromHtml("#787c7e");


        public Form1()
        {
            InitializeComponent();
            grid = new Label[6, 5];
            keyboard = new Button[3, 10];
            currRow = 0;
            currCol = 0;
            answerDoc = new XmlDocument();
            answerDoc.Load("answers.xml");
            validWordDoc = new XmlDocument();
            validWordDoc.Load("validwords.xml");
            correctWord = SelectWord();
            winner = false;
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
            int topMargin = 150;

            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    Label letter = new Label();

                    letter.Width = size;
                    letter.Height = size;
                    letter.Left = leftMargin + (c * (size + padding));
                    letter.Top = topMargin + (r * (size + padding));
                    letter.Font = new Font("Segoe UI", 18, FontStyle.Bold);
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
                    keyButtons[keys[r][c]] = key;
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

        private string SelectWord()
        {
            XmlNode root = answerDoc.DocumentElement;
            XmlNodeList options = root.ChildNodes;
            Random r = new Random();
            int i = r.Next(options.Count);
            // Delete later:
            MessageBox.Show(options[i].InnerText);
            return options[i].InnerText;
        }

        private bool IsValid(string s)
        {
            XmlNode root = validWordDoc.DocumentElement;
            XmlNodeList words = root.ChildNodes;

            foreach (XmlNode word in words)
            {
                if (word.InnerText.Equals(s.ToLower())) return true;
            }

            return false;
        }

        private void ColorLabel(string s)
        {
            int[] alphabet = new int[26];

            foreach (char letter in correctWord.ToUpper()) alphabet[letter - 'A']++;

            for (int i = 0; i < 5; i++)
            {
                if (s[i] == char.ToUpper(correctWord[i]))
                {
                    grid[currRow, i].BackColor = colorCorrect;
                    grid[currRow, i].ForeColor = Color.White;
                    UpdateKeyColor(s[i], colorCorrect);
                    alphabet[s[i] - 'A']--;
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (s[i] == char.ToUpper(correctWord[i]))
                {
                    continue;
                }

                int j = s[i] - 'A';
                if (alphabet[j] > 0)
                {
                    grid[currRow, i].BackColor = colorPresent;
                    grid[currRow, i].ForeColor = Color.White;
                    UpdateKeyColor(s[i], colorPresent);
                    alphabet[j]--;
                }

                else
                {
                    grid[currRow, i].BackColor = colorAbsent;
                    grid[currRow, i].ForeColor = Color.White;
                    UpdateKeyColor(s[i], colorAbsent);
                }
            }
        }

        private void UpdateKeyColor(char letter, Color newColor)
        {
            if (!keyButtons.TryGetValue(letter, out Button? btn)) return;

            if (btn.BackColor == colorCorrect) return;
            if (btn.BackColor == colorPresent && newColor == colorAbsent) return;

            btn.BackColor = newColor;
            btn.ForeColor = Color.White;
        }

        private void AddLetter(string letter)
        {
            if (winner || currRow >= 6) return;
            if (currCol < 5)
            {
                grid[currRow, currCol].Text = letter;
                currCol++;
            }
        }

        private void DeleteLetter()
        {
            if (winner || currRow >= 6) return;
            if (currCol > 0)
            {
                currCol--;
                grid[currRow, currCol].Text = "";
            }
        }

        private void SubmitGuess()
        {

            if (winner) return;
            if (currRow >= 6) return;
            if (currCol < 5) return;

            string guess = "";
            for (int i = 0; i < 5; i++)
            {
                guess += grid[currRow, i].Text;
            }

            if (!IsValid(guess)) return;
            ColorLabel(guess);

            if (guess.Equals(correctWord.ToUpper())) winner = true;

            currRow++;
            currCol = 0;

            if (currRow >= 6)
            {
                MessageBox.Show("You have run out of attempts. The word was " + correctWord + ".");
            }
        }

        private void keyboard_Click(object sender, EventArgs e) => AddLetter(((Button)sender).Text);
        private void backspace_Click(object sender, EventArgs e) => DeleteLetter();
        private void enter_Click(object sender, EventArgs e) => SubmitGuess();

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData >= Keys.A && keyData <= Keys.Z)
            {
                AddLetter(keyData.ToString());
                return true;
            }
            if (keyData == Keys.Back)
            {
                DeleteLetter();
                return true;
            }
            if (keyData == Keys.Enter)
            {
                SubmitGuess();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            currRow = 0;
            currCol = 0;
            winner = false;
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    grid[r, c].Text = "";
                    grid[r, c].BackColor = Color.White;
                }
            }
            correctWord = SelectWord();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (!winner && currRow < 6)
            {
                MessageBox.Show("Finish the game first before sharing!");
                return;
            }

            StringBuilder sb = new StringBuilder();
            string score = winner ? currRow.ToString() : "X";
            sb.AppendLine($"Wordle {score}/6");
            sb.AppendLine();

            for (int r = 0; r < currRow; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    Color bg = grid[r, c].BackColor;
                    if (bg == colorCorrect) sb.Append("🟩");
                    else if (bg == colorPresent) sb.Append("🟨");
                    else sb.Append("⬛");
                }
                sb.AppendLine();
            }
            Clipboard.SetText(sb.ToString());
            MessageBox.Show("Results copied to clipboard!");
        }
    }
}
