using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;


namespace Snake_Game
{
    public partial class GamePlay : Form
    {
        private List<List<Circle>> Snake;

        private Circle food = new Circle();

        int max_X_pos;
        int max_Y_pos;

        Queue<Direction> dirs;

        public GamePlay()
        {
            InitializeComponent();

            Snake = new List<List<Circle>>();

            //Snake.Add(new List<Circle>());

            new Settings();     //Linking the Settings Class to this form;

            max_X_pos = pbCanvas.Size.Width / Settings.Width;
            max_Y_pos = pbCanvas.Size.Height / Settings.Height;

            dirs = new Queue<Direction>();

            Game_Timer.Interval = 1000 / Settings.Speed;
            Game_Timer.Tick += Update_Screen;
            Game_Timer.Start();


            //axWindowsMediaPlayer1.URL = "C:/Users/Randhawa/Desktop/Stuff/Super Mario Bros. - Overworld Theme.mp3";

            //while (!Input.Key_Press(Keys.Enter))
            //{
            //    int i;
            //}
            Start_Game();

            //  Start_Game();
        }

        // --------------------------- DFS Start --------------------------------------
        
        bool DFS_Explore_Rec(List<List<int>> Map, int Pr, int Pc, Stack<Circle> Path)
        {

            if (Pr < 1 || Pr >= max_Y_pos || Pc < 1 || Pc >= max_X_pos) 
                return false;
          
            if (food.x == Pr && food.y == Pc )
            {
                //Circle p = new Circle (Pr, Pc);
                Circle p = new Circle()
                {
                    x = Pr,
                    y = Pc
                };

                Path.Push(p);
                return true;
            }
            if (Map[Pr][Pc] == 4)
                return false;
            Map[Pr][Pc] = 4;
            bool Found = DFS_Explore_Rec(Map, Pr, Pc + 1, Path) ||
                DFS_Explore_Rec(Map, Pr, Pc - 1, Path) ||
                DFS_Explore_Rec(Map, Pr + 1, Pc, Path) ||
                DFS_Explore_Rec(Map, Pr - 1, Pc, Path);
            if (Found)
            {
                Circle p = new Circle()
                {
                    x = Pr,
                    y = Pc
                };

                Path.Push(p);
            }
            return Found;
        }

        bool Find_Path_DFS(List<List<int>> Map, Stack<Circle> Path)
        {                  
            int Pr = Snake[1][0].x, Pc = Snake[1][1].y;
            return DFS_Explore_Rec(Map, Pr, Pc, Path);
        }

        void DFS()
        {
            List<List<int>> Map = new List<List<int>>();
            for (int i=0; i< max_Y_pos; i++)
            {
                Map.Add(new List<int>());

                for (int j = 0; j < max_X_pos; j++)
                    Map[i].Add(new int());
            }

            Stack<Circle> path = new Stack<Circle>();
            Find_Path_DFS(Map, path);

            //Stack<Circle> Straight_path = new Stack<Circle>();

            //for (int i = path.Count; i > 0; i--)
            //{
            //    Straight_path.Push(path.Peek());
            //    path.Pop();
            //}

            while (dirs.Count != 0)
            {
                dirs.Dequeue();
            }

            Circle p;
            Circle temp_head = new Circle { x = Snake[1][0].x, y = Snake[1][0].y };
            if(path.Count > 0)
                path.Pop();     // *IMPORTANT* : Doing one time for removing Snake Head position from Path.

            for (int i = path.Count; i > 0; i--)
            {
                p = path.Peek();
                path.Pop();

                if (temp_head.x+1 == p.x && temp_head.y == p.y)         //  =>
                {
                    dirs.Enqueue(Direction.Right);
                }
                else if (temp_head.x-1 == p.x && temp_head.y == p.y)    //   <=
                {
                    dirs.Enqueue(Direction.Left);

                }
                else if (temp_head.x == p.x && temp_head.y+1 == p.y)      //  \/
                {
                    dirs.Enqueue(Direction.Down);

                }
                else if (temp_head.x == p.x && temp_head.y-1 == p.y)      //      /\
                {
                    dirs.Enqueue(Direction.Up);

                }
                temp_head = p;
            }
        }

        // -------------------------------- DFS End ---------------------------------


        // --------------------------- BFS Start -----------------------------------

            // ---------------------------
        void BFS_Path_Finder(List<List<int>> Map)
        {
            Queue<Circle> Qp = new Queue<Circle>();
            Queue<Stack<Circle>> Qpaths = new Queue<Stack<Circle>>();

            int Px = Snake[1][0].x, Py= Snake[1][0].y;
            Circle pp = new Circle();          // the trace of the pen - PenPosition
            pp.x = Px; pp.y = Py;

            Qp.Enqueue(pp);

            Stack<Circle> S = new Stack<Circle>();
            Qpaths.Enqueue(S);
            while (Qp.Count != 0)
            {
                pp = Qp.Dequeue();
                S = Qpaths.Dequeue();
                int nx = pp.x, ny = pp.y;
                if (nx >= 0 && nx < max_X_pos && ny >= 0 && ny < max_Y_pos && pp.x == food.x && pp.y== food.y)
                {
                    while (dirs.Count != 0)
                    {
                        dirs.Dequeue();
                    }

                    Circle p;
                    Circle temp_head = new Circle { x = Snake[1][0].x, y = Snake[1][0].y };

                    S.Push(pp);
                    Stack<Circle> Straight_path = new Stack<Circle>();

                    while (S.Count != 0) 
                    {
                        Straight_path.Push(S.Peek());
                        S.Pop();
                    }

                    while (Straight_path.Count != 0)
                    {
                        p = Straight_path.Peek();
                        Straight_path.Pop();

                        if (temp_head.x + 1 == p.x && temp_head.y == p.y)         //  =>
                        {
                            dirs.Enqueue(Direction.Right);
                        }
                        else if (temp_head.x - 1 == p.x && temp_head.y == p.y)    //   <=
                        {
                            dirs.Enqueue(Direction.Left);

                        }
                        else if (temp_head.x == p.x && temp_head.y + 1 == p.y)      //  \/
                        {
                            dirs.Enqueue(Direction.Down);

                        }
                        else if (temp_head.x == p.x && temp_head.y - 1 == p.y)      //      /\
                        {
                            dirs.Enqueue(Direction.Up);

                        }
                        temp_head = p;
                    }
                    return;
                }

                if (nx >= 0 && nx < max_X_pos && ny >= 0 && ny < max_Y_pos && Map[pp.y][pp.x] != 4)
                {
                    S.Push(pp);
                    //Position cpp;
                    Map[ny][nx] = 4;

                    pp = new Circle();
                    pp.y = ny; pp.x = nx + 1;   //  ===>
                    Qp.Enqueue(pp);
                    Stack<Circle> temp = new Stack<Circle>(new Stack<Circle>(S));     // ClonedStack
                    Qpaths.Enqueue(temp);

                    pp = new Circle();
                    pp.y = ny - 1; pp.x = nx;   //  ^
                    Qp.Enqueue(pp);
                    temp = new Stack<Circle>(new Stack<Circle>(S));     // ClonedStack
                    Qpaths.Enqueue(temp);

                    pp = new Circle();
                    pp.y = ny; pp.x = nx - 1;   //  <===
                    Qp.Enqueue(pp);
                    temp = new Stack<Circle>(new Stack<Circle>(S));     // ClonedStack
                    Qpaths.Enqueue(temp);

                    pp = new Circle();
                    pp.y = ny + 1; pp.x = nx;   //  \/
                    Qp.Enqueue(pp);
                    temp = new Stack<Circle>(new Stack<Circle>(S));     // ClonedStack
                    Qpaths.Enqueue(temp);
                }
            }
            int x = 10;
            x--;
        }

        void BFS()
        {
            List<List<int>> Map = new List<List<int>>();
            for (int i = 0; i < max_Y_pos; i++)
            {
                Map.Add(new List<int>());

                for (int j = 0; j < max_X_pos; j++)
                    Map[i].Add(new int());
            }

            BFS_Path_Finder(Map);
        }

        // --------------------------- BFS End--------------------------------------


        private void Update_Screen(object sender, EventArgs e)
        {
            if (Settings.Is_Game_Over == true)
            {
                if (Input.Key_Press(Keys.Enter))
                {
                    Start_Game();
                }
            }
            else
            {
                if (Input.Key_Press(Keys.Right) && Settings.direction_1 != Direction.Left)
                {
                    Settings.direction_1 = Direction.Right;
                }
                else if (Input.Key_Press(Keys.Left) && Settings.direction_1 != Direction.Right)
                {
                    Settings.direction_1 = Direction.Left;
                }
                else if (Input.Key_Press(Keys.Up) && Settings.direction_1 != Direction.Down)
                {
                    Settings.direction_1 = Direction.Up;
                }
                else if (Input.Key_Press(Keys.Down) && Settings.direction_1 != Direction.Up)
                {
                    Settings.direction_1 = Direction.Down;
                }

                // For Snake 2

                if (dirs.Count != 0)
                {
                    Direction temp = dirs.Dequeue();
                    switch (temp)
                    {
                        case Direction.Right:
                            if (Settings.direction_2 == Direction.Left)
                            {
                                Settings.direction_2 = Direction.Up;  // Checking 2 November, 2020

                                AI();
                               // Settings.direction_2 = Direction.Down;
                                //dirs.Enqueue(temp);
                            }
                            else
                                Settings.direction_2 = temp;

                            break;
                        case Direction.Left:
                            if (Settings.direction_2 == Direction.Right)
                            {
                                Settings.direction_2 = Direction.Up;  // Checking 2 November, 2020

                                AI();

                                // Settings.direction_2 = Direction.Left;
                                // dirs.Enqueue(temp);
                            }
                            else
                                Settings.direction_2 = temp;
                            break;
                        case Direction.Up:
                            if (Settings.direction_2 == Direction.Down)
                            {
                                Settings.direction_2 = Direction.Right;  // Checking 2 November, 2020

                                AI();

                                // Settings.direction_2 = Direction.Left;
                                //    dirs.Enqueue(temp);
                            }
                            else
                                Settings.direction_2 = temp;
                            break;
                        case Direction.Down:
                            if (Settings.direction_2 == Direction.Up)
                            {
                                Settings.direction_2 = Direction.Right;  // Checking 2 November, 2020

                                AI();

                                //  Settings.direction_2 = Direction.Left;
                                // dirs.Enqueue(temp);
                            }
                            else
                                Settings.direction_2 = temp;
                            break;
                    }
                }

                if(!Is_Head_Collision())
                    Move_Players_Snakes();
              
            }
            pbCanvas.Invalidate();  //Refresh the Picture Box and Update the Graphics on it
        }

        bool Is_Head_Collision()
        {
            if (Snake[0][0].x == Snake[1][0].x && Snake[0][0].y == Snake[1][0].y)
            {
                if (Settings.Score_1 > Settings.Score_2)
                {
                    Result.Text = "Player 1 Ate Player 2!";
                    // Die(1);
                }
                else if (Settings.Score_1 < Settings.Score_2)
                {
                    Result.Text = "Player 2 Ate Player 1!";
                    //Die(0);
                }
                else
                {
                    Result.Text = "Both Died!";
                   // Die(1);
                }
                Result.Visible = true;
                End.Visible = true;

                Settings.Is_Game_Over = true;
                return true;

                // Die(1);
                // Game_Timer.Tick += Update_Screen;

                Settings.Is_Game_Over = true;
            }   
            
            return false;
        }

        private void Move_Players_Snakes()
        {
            bool flag = true;

            // First for First Snake
            for (int i = Snake[0].Count - 1; i >= 0; i--)
            {
                if (i == 0)    // if Head
                {
                    switch (Settings.direction_1)
                    {
                        case Direction.Right:
                            Snake[0][i].x++;
                            break;

                        case Direction.Left:
                            Snake[0][i].x--;
                            break;

                        case Direction.Up:
                            Snake[0][i].y--;
                            break;

                        case Direction.Down:
                            Snake[0][i].y++;     // y increases as going down.
                            break;
                    }
                    flag = Is_Head_Collision();
                    if(flag)
                    {
                        break;
                    }

                    //Restricting Snake from Leaving Canvas
                    int max_X_pos = pbCanvas.Size.Width / Settings.Width;
                    int max_Y_pos = pbCanvas.Size.Height / Settings.Height;

                    if (Snake[0][i].x < 0 || Snake[0][i].x > max_X_pos      // Checking Wall Collision
                        || Snake[0][i].y < 0 || Snake[0][i].y > max_Y_pos)
                    {
                        Die(0);
                    }

                    //Checking Collision with Itself
                    for (int j = 1; j < Snake[0].Count; j++)
                    {
                        if (Snake[0][j].x == Snake[0][i].x && Snake[0][j].y == Snake[0][i].y)
                        {
                            Die(0);
                        }
                    }

                    if (!flag) 
                    {
                        //Checking Collision with Snake 2
                        for (int j = 1; j < Snake[1].Count; j++)
                        {
                            if (Snake[1][j].x == Snake[0][i].x && Snake[1][j].y == Snake[0][i].y)
                            {
                                Die(0);
                            }
                        }
                    }

                    //Detecting Food Eating
                    if (Snake[0][0].x == food.x && Snake[0][0].y == food.y)
                    {
                        Eat(0);
                    }
                }
                else
                {
                    Snake[0][i].x = Snake[0][i - 1].x;      // Snake[0][0] : Head
                    Snake[0][i].y = Snake[0][i - 1].y;
                }
            }

            if (!flag)
            {
                // For Second Snake
                for (int i = Snake[1].Count - 1; i >= 0; i--)
                {
                    if (i == 0)    // if Head
                    {
                        switch (Settings.direction_2)
                        {
                            case Direction.Right:
                                Snake[1][i].x++;
                                break;

                            case Direction.Left:
                                Snake[1][i].x--;
                                break;

                            case Direction.Up:
                                Snake[1][i].y--;
                                break;

                            case Direction.Down:
                                Snake[1][i].y++;     // y increases as going down.
                                break;
                        }

                        flag = Is_Head_Collision();
                        //Restricting Snake from Leaving Canvas
                        int max_X_pos = pbCanvas.Size.Width / Settings.Width;
                        int max_Y_pos = pbCanvas.Size.Height / Settings.Height;

                        if (Snake[1][i].x < 0 || Snake[1][i].x > max_X_pos
                            || Snake[1][i].y < 0 || Snake[1][i].y > max_Y_pos)
                        {
                            Die(1);
                        }

                        //Checking Collision with Itself
                        for (int j = 1; j < Snake[1].Count; j++)
                        {
                            if (Snake[1][j].x == Snake[1][i].x && Snake[1][j].y == Snake[1][i].y)
                            {
                                Die(1);
                            }
                        }

                        if (!flag)
                        {
                            //Checking Collision with Snake 1
                            for (int j = 1; j < Snake[0].Count; j++)
                            {
                                if (Snake[0][j].x == Snake[1][i].x && Snake[0][j].y == Snake[1][i].y)
                                {
                                    Die(1);
                                }
                            }
                        }

                        //Detecting Food Eating
                        if (Snake[1][0].x == food.x && Snake[1][0].y == food.y)
                        {
                            Eat(1);
                        }
                    }
                    else
                    {
                        Snake[1][i].x = Snake[1][i - 1].x;
                        Snake[1][i].y = Snake[1][i - 1].y;
                    }
                }
            }
        }
 

        //private void Score_l1_Click(object sender, KeyEventArgs e)
        //{

        //}

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            //the Key Down Event will Trigger the change state from the Input the class
            Input.Change_State(e.KeyCode, true);
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            //the Key Up Event will Trigger the change state from the Input the class
            Input.Change_State(e.KeyCode, false);
        }

        private void Update_Graphics(object sender, PaintEventArgs e)
        {
            //This is where we will see the Snake and its parts moving

            Graphics canvas = e.Graphics;

            if (Settings.Is_Game_Over == false)
            {
                Brush Snake_Color;

                // for Snake 1
                for (int i = 0; i < Snake[0].Count; i++)
                {
                    if (i == 0)
                    {
                        //Head Of Snake
                        Snake_Color = Brushes.Brown;
                    }
                    else
                    {
                         Snake_Color = Brushes.SandyBrown;
                    }
                    //Drawing
            

                    if (i == 0)
                    {
                        canvas.FillEllipse(Snake_Color, new Rectangle(Snake[0][i].x * Settings.Width - 1,
                        Snake[0][i].y * Settings.Height - 1,
                        Settings.Width + 2, Settings.Height + 2));
                    }

                    else if (i == Snake[0].Count - 1)
                    {
                        Snake_Color = Brushes.LightYellow;
                        canvas.FillEllipse(Snake_Color, new Rectangle(Snake[0][i].x * Settings.Width + 2,
                       Snake[0][i].y * Settings.Height + 2,
                        Settings.Width - 3, Settings.Height - 3));
                    }
                    else
                    {
                        canvas.FillEllipse(Snake_Color, new Rectangle(Snake[0][i].x * Settings.Width,
                        Snake[0][i].y * Settings.Height,
                        Settings.Width, Settings.Height));
                    }
                }


                // for Snake 2
                for (int i = 0; i < Snake[1].Count; i++)
                {
                    //if (i == 0)
                    //{
                    //    //Head Of Snake
                    //    Snake_Color = Brushes.CadetBlue;
                    //}
                    //else if (i==Snake[1].Count-1)
                    //{
                    //    Snake_Color = Brushes.LightBlue;
                    //}
                    //else
                    //{
                    //    Snake_Color = Brushes.CadetBlue;
                    //}
                    //Drawing


                    if (i == 0)
                    {
                        //Head Of Snake
                        Snake_Color = Brushes.CadetBlue;

                        canvas.FillEllipse(Snake_Color, new Rectangle(Snake[1][i].x * Settings.Width - 1,
                        Snake[1][i].y * Settings.Height - 1,
                        Settings.Width + 2, Settings.Height + 2));
                    }

                    else if (i == Snake[1].Count - 1)
                    {
                        //Tail Of Snake
                        Snake_Color = Brushes.LightBlue;

                        canvas.FillEllipse(Snake_Color, new Rectangle(Snake[1][i].x * Settings.Width + 2,
                        Snake[1][i].y * Settings.Height + 2,
                        Settings.Width - 3, Settings.Height - 3));
                    }
                    else
                    {
                        //Body Of Snake
                        Snake_Color = Brushes.CornflowerBlue;

                        canvas.FillEllipse(Snake_Color, new Rectangle(Snake[1][i].x * Settings.Width,
                        Snake[1][i].y * Settings.Height,
                        Settings.Width, Settings.Height));
                    }

                }

                //Food Circle showing
                //canvas.FillEllipse(Brushes.Red, new Rectangle(food.x * Settings.Width,
                //    food.y * Settings.Height,
                //     Settings.Width, Settings.Height));

                /// PictureBox pb1 = new PictureBox();
                // pb1.ImageLocation = "C:/Users/Randhawa/Desktop/Shots/Sberry.png";
                // pb1.SizeMode = PictureBoxSizeMode.AutoSize;

                System.Drawing.Image img;
                int pos = food.x + food.y;
                if (pos % 5 == 0)   // Strawberry
                {
                    img = System.Drawing.Image.FromFile("C:/Users/Randhawa/Desktop/AI/Snake_Game - VS Computer/Snake Game Sprites/Sberry.png");
                }
                else if (pos % 4 == 0)      // Orange
                    img = System.Drawing.Image.FromFile("C:/Users/Randhawa/Desktop/AI/Snake_Game - VS Computer/Snake Game Sprites/Orange.png");
                else if (pos % 3 == 0)      // Watermelon
                    img = System.Drawing.Image.FromFile("C:/Users/Randhawa/Desktop/AI/Snake_Game - VS Computer/Snake Game Sprites/WMelon.png");

                else if (pos % 2 == 0)      //Mango
                    img = System.Drawing.Image.FromFile("C:/Users/Randhawa/Desktop/AI/Snake_Game - VS Computer/Snake Game Sprites/Mango_1.png");
                else                       // Grapes    
                    img = System.Drawing.Image.FromFile("C:/Users/Randhawa/Desktop/AI/Snake_Game - VS Computer/Snake Game Sprites/Grapes_2.png");

                //     img = System.Drawing.Image.FromFile("C:/Users/Randhawa/Desktop/Shots/Sberry.png");
                img = (Image)new Bitmap(img, new Size(26, 26));
                //    /Bitmap objBitmap = new Bitmap(img, new Size(1, 1));


                //Size z = new Size(3,3);
                //Bitmap objBitmap = new Bitmap(img, z);
                Point p = new Point(food.x * Settings.Width, food.y * Settings.Height);

                canvas.DrawImage(img, p);
            }
            else
            {
                //When Game is Over
                string Game_Over = "Game Over \n\n Press Enter to Restart \n ";

                End.Text = Game_Over;
                End.Visible = true;
            }
        }

        private void Start_Game()
        {

            Play.Visible = false;

            axWindowsMediaPlayer1.URL = "C:/Users/Randhawa/Desktop/AI/Snake_Game - VS Computer/Snake_Game/bin/Debug/Super Mario Bros. - Overworld Theme.wav";

            // axWindowsMediaPlayer1.URL= "C:/Users/Randhawa/Desktop/Stuff/Super Mario Bros. - Overworld Theme.mp3";
            // axWindowsMediaPlayer1.Ctlcontrols.play();

            //WMPLib.WindowsMediaPlayer audioPlayer = new WMPLib.WindowsMediaPlayer();

            //audioPlayer.URL = "C:/Users/Randhawa/DesktopStuff/snake_music.mp3";

            //player.SoundLocation = "snake_music.mp3";
            //audioPlayer.controls.play();

            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            // player.SoundLocation = "snake_music_w.wav";

            ///            player.SoundLocation = "Super Mario Bros. - Overworld Theme.wav";

            //         player.Play();


            //audioPlayer.controls.stop();

            //string filename = @"C:\Users\Randhawa\Desktop\Stuff\snake_music.mp3";
            //byte bt[]=File.Read

            // SoundPlayer myPlayer = new SoundPlayer(Snake_Game.Properties.Resources.snake_music);
            // myPlayer.PlayLooping();

            Target_Score.Text = Settings.Target.ToString();
            End.Visible = false;
            Result.Visible = false;
            new Settings();

            Snake.Add(new List<Circle>() );
            Snake.Add(new List<Circle>());


           // Snake.Clear();
            Snake[0].Clear();
            Snake[1].Clear();

            //Snake[0] = new List<List<Circle>> ;

            Circle head = new Circle { x = 20, y = 5 };
            Snake[0].Add(head);
            head = new Circle { x = 19, y = 5 };
            Snake[0].Add(head);


            Snake[1] = new List<Circle>();

            head = new Circle { x = 5, y = 5 };
            Snake[1].Add(head);
            head = new Circle { x = 4, y = 5 };
            Snake[1].Add(head);


            P1_Score.Text = Settings.Score_1.ToString();
            P2_Score.Text = Settings.Score_2.ToString();

            Generate_Food();

        }
        void AI()
        {
            //  DFS();
            BFS();
        }
        private void Generate_Food()
        {
            int max_X_pos = pbCanvas.Size.Width / Settings.Width;
            int max_Y_pos = pbCanvas.Size.Height / Settings.Height;
            Random rnd = new Random();

            food = new Circle { x = rnd.Next(2, max_X_pos-2), y = rnd.Next(2, max_Y_pos-2) };

            // For Computer (Second Player Snake) 
            AI();   
        }

        void Show_Victorian(int Player_no)
        {
            if (Player_no == 0)
            {
                Result.Text = "Player 1 Won!";
            }
            else
                Result.Text = "Player 2 Won!";

            Result.Visible = true;
            Settings.Is_Game_Over = true;

        }
        bool Is_Victory()
        {
            if (Settings.Score_1 >= Settings.Target)
            {
                Show_Victorian(0);
                return true;
            }
            else if (Settings.Score_2 >= Settings.Target)
            {
                Show_Victorian(1);
                return true;
            }
            return false;
        }

        private void Eat(int snake_no)
        {
            Food_music.URL = "coin_mp3.mp3";
            Food_music.Ctlcontrols.play();

            Circle body = new Circle
            {
                x = Snake[snake_no][Snake[snake_no].Count - 1].x,
                y = Snake[snake_no][Snake[snake_no].Count - 1].y
            };

            Snake[snake_no].Add(body);
           // Snake[snake_no].Add(body);

            if (snake_no == 0)
            {
                Settings.Score_1 += Settings.Points;
                P1_Score.Text = Settings.Score_1.ToString();
            }
            else if (snake_no == 1)
            {
                Settings.Score_2 += Settings.Points;
                P2_Score.Text = Settings.Score_2.ToString();
            }


            if(!Is_Victory())
                Generate_Food();
        }
        private void Die(int snake_no)
        {
            Settings.Is_Game_Over = true;

            Show_Victorian( (snake_no + 1) % 2);
        }

        private void Play_Click(object sender, EventArgs e)
        {
            
        }

        private void Clicked(object sender, MouseEventArgs e)
        {

        }

        private void Snake_GameLoad(object sender, EventArgs e)
        {
            //System.Media.SoundPlayer player = new System.Media.SoundPlayer();
            //WMPLib.WindowsMediaPlayer audioPlayer = new WMPLib.WindowsMediaPlayer();

            ////audioPlayer.URL = "C:/Users/Randhawa/Desktop/Stuff/snake_music.mp3";
            //audioPlayer.URL = @"snake_music.mp3";

            //audioPlayer.controls.play();
        }
    }
}
