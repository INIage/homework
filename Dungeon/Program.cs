using static System.Net.Mime.MediaTypeNames;

var Description = 0;

var Forward = 1;
var Left = 2;
var Right = 3;
var Backward = 4;
var Up = 5;
var Down = 6;

var WALL = "WALL";
var FLOOR = "FLOOR";
var CEILING = "CEILING";
var DOOR = "DOOR";
var EXIT = "EXIT";
var STAIRS = "STAIRS";

var dungeon = new string[][,][]
{
    // floor 1
    new string[,][]
    {
        {
            new string[] // (1, 3)
            {
                "",
                
                   WALL,
                WALL, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 3)
            {
                "Steps up to the main hall",

                   WALL,
                WALL, WALL,
                   DOOR,

                STAIRS,
                FLOOR,
            },
            new string[] // (3, 3)
            {
                "",
                
                   WALL,
                WALL, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
        },
        {
            new string[] // (1, 2)
            {
                "",
                
                   WALL,
                WALL, DOOR,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 2)
            {
                "I feel like the exit is near.",
                
                   DOOR,
                DOOR, DOOR,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 2)
            {
                "Yea, the metal door. It seems it does not closed.",
                
                   WALL,
                DOOR, EXIT,
                   DOOR,

                CEILING,
                FLOOR,
            },
        },
        {
            new string[] // (1, 1)
            {
                "Corner but nothing more.",
                
                   DOOR,
                WALL, DOOR,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 1)
            {
                "It is not here",
                
                   DOOR,
                DOOR, DOOR,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 1)
            {
                "Exit should be close",
                
                   DOOR,
                DOOR, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
        },
    },
    
    // floor 2
    new string[,][]
    {
        {
            new string[] // (1, 3)
            {
                "It looks like a main hall with opend doors everywhere.",

                   WALL,
                WALL, DOOR,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 3)
            {
                "Steps down to another floor",

                   WALL,
                DOOR, DOOR,
                   DOOR,

                CEILING,
                STAIRS,
            },
            new string[] // (3, 3)
            {
                "It looks like a main hall with opend doors everywhere.",

                   WALL,
                DOOR, WALL,
                   DOOR,

                CEILING,
                FLOOR,
            },
        },
        {
            new string[] // (1, 2)
            {
                "It looks like a main hall with opend doors everywhere.",

                   DOOR,
                WALL, DOOR,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 2)
            {
                "It looks like a main hall with opend doors everywhere.",

                   DOOR,
                DOOR, DOOR,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 2)
            {
                "It looks like a main hall with opend doors everywhere.",

                   DOOR,
                DOOR, WALL,
                   DOOR,

                CEILING,
                FLOOR,
            },
        },
        {
            new string[] // (1, 1)
            {
                "Stairs up to a floor where is your bed waiting for you.",
                
                   DOOR,
                WALL, DOOR,
                   WALL,

                STAIRS,
                FLOOR,
            },
            new string[] // (2, 1)
            {
                "It looks like a main hall with opend doors everywhere.",
                
                   DOOR,
                DOOR, DOOR,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 1)
            {
                "It looks like a main hall with opend doors everywhere.",

                   DOOR,
                DOOR, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
        },
    },

    // floor 3
    new string[,][]
    {
        {
            new string[] // (1, 3)
            {
                "Corridor from a room where you woke up.",

                   WALL,
                WALL, DOOR,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 3)
            {
                "Corridor from a room where you woke up.",

                   WALL,
                DOOR, DOOR,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 3)
            {
                "Corridor from a room where you woke up.",

                   WALL,
                DOOR, WALL,
                   DOOR,

                CEILING,
                FLOOR,
            },
        },
        {
            new string[] // (1, 2)
            {
                "Corridor from a room where you woke up.",

                   DOOR,
                WALL, WALL,
                   DOOR,

                CEILING,
                FLOOR,
            },
            new string[] // (2, 2)
            {
                "",

                   WALL,
                WALL, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 2)
            {
                "Corridor from a room where you woke up.",

                   DOOR,
                WALL, WALL,
                   DOOR,

                CEILING,
                FLOOR,
            },
        },
        {
            new string[] // (1, 1)
            {
                "The steirs down to the main floor.",
                
                   DOOR,
                WALL, WALL,
                   WALL,

                CEILING,
                STAIRS,
            },
            new string[] // (2, 1)
            {
                "",
                
                   WALL,
                WALL, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
            new string[] // (3, 1)
            {
                "The room. Bed standing at the back wall and door waiting for you to open it.",
                
                   DOOR,
                WALL, WALL,
                   WALL,

                CEILING,
                FLOOR,
            },
        },
    },
};

var x = 2;
var y = 2;
var floor = 2;

var message = "";

var win = false;

while (!win)
{
    var room = dungeon[floor][x, y];

    var forward = room[Forward];
    var left = room[Left];
    var backward = room[Backward];
    var right = room[Right];
    var up = room[Up];
    var down = room[Down];

    Console.Clear();

    Console.Write(
@$"
[{room[Description]}]

        [{forward}]
          ↑           ↑ [{up}]
 [{left}] <- -> [{right}]
          ↓           ↓ [{down}]
        [{backward}]


[W] - forward;
[A] - left;
[S] - back;
[D] - right;
[E] - use stairs;

{message}
");

    message = "";

    Console.Write("> ");
    var input = Console.ReadLine();

    switch (input?.ToUpper())
    {
        case "W":
            if (forward == DOOR)
            {
                x -= 1;
                break;
            }
            if (forward == EXIT)
            {
                win = true;
                break;
            }
            message = "your head crushed to a wall";
            break;
        case "A":
            if (left == DOOR)
            {
                y -= 1;
                break;
            }
            if (left == EXIT)
            {
                win = true;
                break;
            }
            message = "your left sholders scratch a wall";
            break;
        case "S":
            if (backward == DOOR)
            {
                x += 1;
                break;
            }
            if (backward == EXIT)
            {
                win = true;
                break;
            }
            message = "your back feels a wall behind";
            break;
        case "D":
            if (right == DOOR)
            {
                y += 1;
                break;
            }
            if (right == EXIT)
            {
                win = true;
                break;
            }
            message = "your right hand puts to a wall";
            break;
        case "E":
            if(up == STAIRS)
            {
                floor += 1;
                break;
            }
            if(down == STAIRS)
            {
                floor -= 1;
                break;
            }
            message = "there is no stairs";
            break;
        default:
            break;
    }
}

Console.Clear();

Console.WriteLine($"You found the exit! {Environment.NewLine}");
Console.WriteLine("press any key to exit");

Console.ReadKey();

Console.Clear();

Environment.Exit(0);
