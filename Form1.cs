using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Assignment2
{

    public partial class Assign2Form : Form
    {
        /*
         * Enum definitions
         */
        public enum ItemType
        {
            Helmet, Neck, Shoulders, Back, Chest,
            Wrist, Gloves, Belt, Pants, Boots,
            Ring, Trinket
        };

        public enum Race { Orc, Troll, Tauren, Forsaken };
        public enum PlayerClass
        {
            Warrior, Mage, Druid, Priest, Warlock, Rogue, Paladin, Hunter, Shaman
        };
        public enum GuildType
        {
            Casual, Questing, Mythic, Raiding, PVP
        };

        /*
         * Global variables
         */
        private static uint MAX_ILVL = 360;
        private static uint MAX_PRIMARY = 200;
        private static uint MAX_STAMINA = 275;
        private static uint MAX_LEVEL = 60;
        private static uint GEAR_SLOTS = 14;
        private static uint MAX_INVENTORY_SIZE = 20;

        /*
         * Storage for Guilds, Items, and Players
         */
        private static Dictionary<uint, Guild> Guilds = new Dictionary<uint, Guild>();
        private static Dictionary<uint, Item> Items = new Dictionary<uint, Item>();
        private static Dictionary<uint, Player> Players = new Dictionary<uint, Player>();

        /*
         * Input file paths
         *
         * You Might have to alter the path if you have the input files located in a different folder than I do.
         * Mine are in the same folder where the Assign1.cs file is located in VS.
         */
        private static string guildsFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\guilds.txt";
        private static string itemsFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\equipment.txt";
        private static string playersFile = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "\\players.txt";
        //finds the player specified by the user
        public static uint FindPlayer(Dictionary<uint, Player> Players)
        {
            //asks the user for the name of the player
            Console.Write("\nPlease enter player name: ");
            String playername = Console.ReadLine();
            Console.WriteLine();
            uint key = 2147483647;

            //checks through the player list for someone by that name
            foreach (KeyValuePair<uint, Player> pair in Players)
            {
                if ((pair.Value).Name == playername)
                    key = pair.Key;
            }

            //if it doesn't exist it returns the error code I decided on because it's the max 32 bit int
            //I also don't throw exceptions here just so you can keep trying/using the menu rather than 
            //having to relaunch.
            if (key == 2147483647)
            {
                Console.WriteLine("\nPlayer under that name not found.");
                return key;
            }

            //returns the key of the related player if they exist.
            return key;
        }

        //finds the guild specified by the user
        public static uint[] FindGuild(Dictionary<uint, Guild> Guilds, string gName)
        {
            //asks the user for the guild name   
            uint[] key = new uint[5];
            for (int x = 0; x < 5; x++)
                key[x] = 2147483647;
            int i = 0;
            //searches the guild list for a guild by name
            foreach (KeyValuePair<uint, Guild> pair in Guilds)
            {
                if (pair.Value.guildName == gName)
                {
                    key[i] = pair.Key;
                    i++;
                }
            }

            //returns and says that the guild couldn't be found.
            if (key[i] == 2147483647)
            {
                return key;
            }

            //returns the guild key
            return key;
        }

        //find the item specified by the user
        public static uint FindItem(Dictionary<uint, Item> Items)
        {
            //asks the user for the item name
            Console.WriteLine("\nPlease enter the name of the Item you would like to equip.");
            String itemName = Console.ReadLine();
            uint key = 2147483647;

            //searches the guild list for a guild by name
            foreach (KeyValuePair<uint, Item> pair in Items)
            {
                if (pair.Value.Name == itemName)
                    key = pair.Key;
            }

            //returns and says that the item couldn't be found.
            if (key == 2147483647)
            {
                Console.WriteLine("\nItem under that name not found.");
                return key;
            }

            //returns the item key
            return key;
        }

        /*
         * Method to read and load data from input files
         */
        public static void LoadData()
        {
            //Read in data from Guilds file
            var lines = File.ReadLines(guildsFile);
            foreach (var line in lines)
            {
                //Seperate on tabs and add to dict of Guilds
                string[] s = line.Split('\t');
                string[] s1 = s[1].Split('-');
                Guilds.Add((Convert.ToUInt32(s[0])), new Guild(s1[0], s1[1].Trim()));
            }

            //Read in data from Items file
            lines = File.ReadLines(itemsFile);
            foreach (var line in lines)
            {
                //Seperate on tabs and add to dict of Items
                string[] s = line.Split('\t');
                Item item = new Item(Convert.ToUInt32(s[0]), s[1], (ItemType)Convert.ToUInt32(s[2]), Convert.ToUInt32(s[3]),
                                 Convert.ToUInt32(s[4]), Convert.ToUInt32(s[5]), Convert.ToUInt32(s[6]), s[7]);
                Items.Add(item.Id, item);
            }

            //Read in data from Players file
            lines = File.ReadLines(playersFile);
            foreach (var line in lines)
            {
                //Seperate on tabs and add to dict of Players
                string[] s = line.Split('\t');
                // Build the Gear array for the Player
                uint[] ar = new uint[MAX_INVENTORY_SIZE];
                /*for (int i = 0, x = 7; i < (MAX_INVENTORY_SIZE - 6); i++, x++)
                {
                    ar[i] = Convert.ToUInt32(s[x]);
                }*/
                Player player = new Player(Convert.ToUInt32(s[0]), s[1].Trim(), (Race)Convert.ToUInt32(s[2]), (PlayerClass)Convert.ToUInt32(s[3]), Convert.ToUInt32(s[4]),
                                   Convert.ToUInt32(s[5]), Convert.ToUInt32(s[6]), ar);
                Players.Add(player.Id, player);
            }
        }

        /*
         *  This is the definition of the Player class along with an Icomparable interface
         */
        public class Player : IComparable
        {
            /*
            * Player Attributes
            */
            private uint _id;
            private string _name;
            private Race _race;
            private uint _level;
            private uint _exp;
            private uint _guildID;
            private uint[] _gear;
            private PlayerClass _playerclass;
            private List<uint> _inventory;
            string _role = "";
            bool firstRingNext = true;
            bool firstTrinkNext = true;

            /*
             * Default Constructor for Player Class
             */
            public Player()
            {
                _id = 0;
                _name = "";
                _race = 0;
                _level = 0;
                _exp = 0;
                _guildID = 0;
                _playerclass = 0;
                _gear = new uint[GEAR_SLOTS];
                _inventory = new List<uint>();
            }

            /*
             * Custom Constructor for Player Class
             */
            public Player(uint id, string name, Race race, PlayerClass playerclass, uint level, uint exp, uint guildID, uint[] gear)
            {
                _id = id;
                _name = name;
                _race = race;
                _level = level;
                _exp = exp;
                _guildID = guildID;
                _gear = new uint[GEAR_SLOTS];
                //If passed in gear arrray is not empty, copy it into Player gear array
                if (gear != null)
                    Array.Copy(gear, gear.GetLowerBound(0), _gear, _gear.GetLowerBound(0), GEAR_SLOTS);
                _inventory = new List<uint>();
                _playerclass = playerclass;
            }
            /*
             *Role property
             */
            public string Role
            {
                get => _role;
                set => _role = value;
            }

            /*
             * Id Property
             */
            public uint Id
            {
                get => _id;
            }

            /*
             * Name Property
             */
            public string Name
            {
                get => _name;
            }

            /*
             * Player type Property
             */
            public Race Race
            {
                get => _race;

            }

            /*
             * Level property
             */
            public uint Level
            {
                get => _level;
                set
                {
                    if (value < 0 || value > MAX_LEVEL)
                        throw new ArgumentOutOfRangeException($"Player level must be between 1 and " + MAX_LEVEL);
                    else
                        _level = value;
                }
            }

            /*
             * Experience property
             */
            public uint Exp
            {
                get => _exp;
                set
                {
                    //Add assigned exp value to Players exp value
                    _exp += value;

                    //Check to see if new exp amount is over threshhold to level up
                    if (_level < MAX_LEVEL)
                        LevelUp(_exp);
                }
            }
            //Guild ID Property
            public uint GuildID
            {
                get => _guildID;
                set => _guildID = value;
            }
            //Public Class Property
            public PlayerClass Playerclass
            {
                get => _playerclass;
                set => _playerclass = value;
            }

            /*
             * Method to handle leveling up a player
             */
            public void LevelUp(uint exp)
            {
                //Calculate required xp for level up
                uint expRequired = _level * 1000;

                while (exp >= expRequired && _level < MAX_LEVEL)
                {
                    if (_level < MAX_LEVEL)
                    {
                        //Increment level and subtract required amount from awarded amount
                        _level++;
                        Console.Write("\n" + this.Name + " has reached level " + _level + "!");
                        exp -= expRequired;
                    }
                    //Calculate new required amount for next iteration
                    expRequired = _level * 1000;
                }
            }

            /*
             * Method to equip (add) gear to players 
             */
            public void EquipGear(uint newGearID)
            {
                //if item and player exist, equip item id to corresponding slot in player gear array
                uint itype = (uint)Items[newGearID].Type;

                //make sure player meets required level for item
                if (this.Level < Items[newGearID].Requirement)
                {
                    //console message instead of exception so that level requirements don't break program and allow user to try again
                    Console.WriteLine("\n" + this.Name + " does not meet required level for " + Items[newGearID].Name + ".\n");
                    return;
                }

                //check if item is ring or trinket, if so then special case
                if ((itype == 10) || (itype == 11))
                {
                    switch (itype)
                    {
                        case 10:
                            if (firstRingNext || this._gear[itype] == 0)
                            {
                                if (this._gear[itype] != 0)
                                    this._inventory.Add(this._gear[itype]);
                                this._gear[itype] = newGearID;
                                firstRingNext = false;
                                break;
                            }
                            else
                            {
                                if (this._gear[itype + 1] != 0)
                                    this._inventory.Add(this._gear[itype + 1]);
                                this._gear[itype + 1] = newGearID;
                                firstRingNext = true;
                                break;

                            }

                        case 11:
                            if (firstTrinkNext || this._gear[itype + 1] == 0)
                            {
                                if (this._gear[itype + 1] != 0)
                                    this._inventory.Add(this._gear[itype + 1]);
                                this._gear[itype + 1] = newGearID;
                                firstTrinkNext = false;
                                break;
                            }
                            else
                            {
                                if (this._gear[itype + 2] != 0)
                                    this._inventory.Add(this._gear[itype + 2]);
                                this._gear[itype + 2] = newGearID;
                                firstTrinkNext = true;
                                break;
                            }
                    }
                }
                //Add to only slot if not special case
                else
                {
                    if (this._gear[itype] != 0)
                        this._inventory.Add(this._gear[itype]);
                    this._gear[itype] = newGearID;
                }
                Console.WriteLine("\n" + this.Name + " is now equipped with " + Items[newGearID].Name + "!");
            }

            /*
             * Method to unequip (remove) gear from players
             */
            public void UnequipGear(uint gearSlot)
            {
                //Special case (ring)
                if (gearSlot == 10)
                {
                    //Check if ring 1 is empty
                    if (this[gearSlot] == 0)
                    {
                        //Check if ring 2 is empty, if both empty do nothing
                        if (this[gearSlot + 1] == 0)
                            Console.WriteLine("There was nothing in that slot. Nothing has changed.");

                        //If trinket 1 empty, unequip trinket 2
                        else
                        {
                            this._inventory.Add(this[gearSlot + 1]);
                            Console.WriteLine("\n" + Items[this._gear[gearSlot + 1]].Name + " was removed from player and added to inventory");
                            this[gearSlot + 1] = 0;
                        }
                    }

                    //No special case
                    else
                    {
                        this._inventory.Add(this[gearSlot]);
                        Console.WriteLine("\n" + Items[this._gear[gearSlot]].Name + " was removed from player and added to inventory");
                        this[gearSlot] = 0;
                    }
                }

                //Special case (trinket)
                else if (gearSlot == 11)
                {
                    //Check if trinket 1 is empty
                    if (this[gearSlot + 1] == 0)
                    {
                        //Check if trinket 2 is empty, if both empty do nothing
                        if (this[gearSlot + 2] == 0)
                            Console.WriteLine("There was nothing in that slot. Nothing has changed.");

                        //If trinket 1 empty, uneqip trinket 2
                        else
                        {
                            this._inventory.Add(this[gearSlot + 2]);
                            Console.WriteLine("\n" + Items[this._gear[gearSlot + 2]].Name + " was removed from player and added to inventory");
                            this[gearSlot + 2] = 0;
                        }
                    }

                    //If trinket 1 not empty, unequip trinket 1
                    else
                    {
                        this._inventory.Add(this[gearSlot + 1]);
                        Console.WriteLine("\n" + Items[this._gear[gearSlot + 1]].Name + " was removed from player and added to inventory");
                        this[gearSlot + 1] = 0;
                    }
                }

                //No special case
                else
                {
                    //Unequip item 
                    if (this[gearSlot] != 0)
                    {
                        this._inventory.Add(this[gearSlot]);
                        Console.WriteLine("\n" + Items[this._gear[gearSlot]].Name + " was removed from player and added to inventory");
                        this[gearSlot] = 0;
                    }
                    else
                    {
                        Console.WriteLine("\nThere was nothing in that slot. Nothing has changed.");
                    }
                }
            }

            /*
             * Indexer for the Players Gear array
             */
            public uint this[uint i]
            {
                get { return _gear[i]; }
                set { _gear[i] = value; }
            }

            /*
             * IComparable interface for the Player Class
             */
            public int CompareTo(object obj)
            {
                //Make sure object not null
                if (obj == null)
                    return 1;

                //Compare by name if valid Player object
                if (obj is Player toCompare)
                    return this.Name.CompareTo(toCompare.Name);
                else
                    throw new ArgumentException("Object is not a Player");
            }

            /*
             * toString method for the Player class
             */
            public override String ToString()
            {
                string message = "Name: " + String.Format("{0,-12}", _name) + "\tRace: " + _race + "\tLevel: " + _level;
                return _guildID == 0 ? message : message + "\tGuild: " + Guilds[GuildID].guildName;

            }
        }

        /*
         *  This is the definition of the Item class along with an Icomparable interface
         */
        public class Item : IComparable
        {
            //The Count variable so that we can keep track of how many items there are
            public static int Count = 0;
            //the id variable that can only be changed in the constuctor and then the public property with on a get method
            private readonly uint id;
            public uint Id
            {
                get { return id; }

            }

            //The name of the item as well as the public property for accessing the String or changing it.
            private String name;
            public String Name
            {
                //just very simple get and set methods
                get => name;
                set => name = value;
            }

            //the itemType as well as the public property for accessing the itemType
            private ItemType type;
            public ItemType Type
            {
                //simple get method
                get => type;
                //The set method here checks to make sure that the Item type is somewhere between Helmet and Trinket
                //and throws an acception if the argument given is out of the given range
                set
                {
                    if (value < 0 || value > ItemType.Trinket)
                        throw new ArgumentOutOfRangeException($"{nameof(value)} must be between 0 and 12");
                    //otherwise changes the item type
                    type = value;
                }
            }

            //the item level of the item and the public property for accessing it.
            private uint ilvl;
            public uint Ilvl
            {
                //simple get method
                get => ilvl;
                set
                {
                    //checks to make sure that the item level that is given is between 0 and the given max item level
                    //if the item level is not in that range it throws an acception.
                    if (value < 0 || value > MAX_ILVL)
                        throw new ArgumentOutOfRangeException($"The item level must be between 0 and " + MAX_ILVL);
                    //otherwise changes the value of ilvl
                    ilvl = value;
                }
            }

            //The primary number(I am unsure of what this actually is at this point) and the public property of it
            private uint primary;
            public uint Primary
            {
                //simple get method
                get => primary;
                set
                {
                    //checks to make sure that the primary value is between 0 and the given Max primary value and
                    //throws an exception if it is not it throws an exception stating that it is not in the range
                    if (value < 0 || value > MAX_PRIMARY)
                        throw new ArgumentOutOfRangeException($"The primary value must be between 0 and " + MAX_PRIMARY);
                    //or it just changes the value of primary.
                    primary = value;
                }
            }

            //the stamina cost of using the weapon(I am assuming that is what stamina is in reference to?) and it's property
            private uint stamina;
            public uint Stamina
            {
                //simple get method
                get => stamina;
                set
                {
                    //checks to make sure that the value of the stamina is between 0 and the given max stamina cost
                    //and throws an exception if it is not.
                    if (value < 0 || value > MAX_STAMINA)
                        throw new ArgumentOutOfRangeException($"the stamina value must be between 0 and " + MAX_STAMINA);
                    //or just changes the value.
                    stamina = value;
                }
            }

            //The level requirment of the item and it's public property
            private uint requirement;
            public uint Requirement
            {
                //simple get method for the requirement
                get => requirement;
                set
                {
                    //checks to make sure that the requirement level is between 0 and the max level and throws an exception if it is not
                    if (value < 0 || value > MAX_LEVEL)
                        throw new ArgumentOutOfRangeException($"The level requirement must be between 0 and " + MAX_LEVEL);
                    //or changes the value of requirement.
                    requirement = value;
                }
            }

            //The flavor text and it's public property
            private String flavor;
            public String Flavor
            {
                //very simple set and get methods for this property
                get => flavor;
                set => flavor = value;
            }
            //the override for ToString that just prints out all of the item stats.
            public override String ToString()
            {
                return "(" + Type + ") " + Name + " |" + Ilvl + "| " + "--" + Requirement + "--" + "\n\t" + "\"" + Flavor + "\"";
            }
            //The default constructor that just sets everything to 0 or null and adds one to Count
            //side note both of the constructors use the properties to access everything minus id
            public Item()
            {
                id = 0;
                Name = "";
                Type = 0;
                Ilvl = 0;
                Primary = 0;
                Stamina = 0;
                Requirement = 0;
                Flavor = "";
                Count++;
            }

            //Constructor for when you want to set all the item class members and then adds one to Count
            public Item(uint nid, String nname, ItemType ntype, uint nilvl, uint nprimary, uint nstamina, uint nreq, String nflavor)
            {
                id = nid;
                Name = nname;
                Type = ntype;
                Ilvl = nilvl;
                Primary = nprimary;
                Stamina = nstamina;
                Requirement = nreq;
                Flavor = nflavor;
                Count++;
            }

            //IComparable Interface Compare to override
            public int CompareTo(object obj)
            {
                //checks if the second item is null and then returns 500 simply for debugging purposes it will still get caught because it is greater than 0
                if (obj == null) return 500;
                //sets otheritem equal to the passed in item typecasted as an item
                Item otherItem = obj as Item;
                //checks if the typecasting failed if it did then it throws an exception and if not it just compares the names.
                if (otherItem != null)
                    return this.Name.CompareTo(otherItem.Name);
                else
                    throw new ArgumentException("Object is not an Item");
            }
        }
        //Guild class to be used in the guild dictionary
        public class Guild
        {
            public string guildName;
            public string serverName;
            public GuildType guildType;
            public Guild(string GuildName, string ServerName, GuildType Guildtype = 0)
            {
                guildName = GuildName;
                serverName = ServerName;
                guildType = Guildtype;
            }
        }
        public Assign2Form()
        {
            InitializeComponent();
            LoadData();
            //prints out a list of guilds
            foreach (KeyValuePair<uint, Guild> pair in Guilds)
            {
                listBox1.Items.Add(String.Format("{0} {1}", pair.Value.guildName, ("[" + pair.Value.serverName + "]").PadLeft(40 - pair.Value.guildName.Length)));
                if (Servercombo.FindStringExact(pair.Value.serverName) == -1)
                    Servercombo.Items.Add(pair.Value.serverName);
            }
            //prints out a list of players
            foreach (KeyValuePair<uint, Player> pair in Players)
                listBox2.Items.Add(String.Format("{0} {1," + (20 - pair.Value.Name.Length) + "} {2:00}", pair.Value.Name, pair.Value.Playerclass, pair.Value.Level));
            Servercombo.SelectedIndex = 0;
            //adds all the possible types of guilds to the dropdown box
            GuildTypeBox.Items.Add("Casual");
            GuildTypeBox.Items.Add("Questing");
            GuildTypeBox.Items.Add("Mythic");
            GuildTypeBox.Items.Add("Raiding");
            GuildTypeBox.Items.Add("PVP");
            GuildTypeBox.SelectedIndex = 0;
            //adding the classes to the class dropdown
            ClassBox.Items.Add("Warrior");
            ClassBox.Items.Add("Mage");
            ClassBox.Items.Add("Druid");
            ClassBox.Items.Add("Priest");
            ClassBox.Items.Add("Warlock");
            ClassBox.Items.Add("Rogue");
            ClassBox.Items.Add("Paladin");
            ClassBox.Items.Add("Hunter");
            ClassBox.Items.Add("Shaman");
            //adding the races to the race dropdown
            RaceBox.Items.Add("Orc");
            RaceBox.Items.Add("Troll");
            RaceBox.Items.Add("Tauren");
            RaceBox.Items.Add("Forsakken");
        }

        private void PrintGuildRoster_Click(object sender, EventArgs e)
        {
            int printed = 0;
            // Check for a guilds selection, return if none
            if (listBox1.SelectedIndex == -1)
            {
                OutputBox.Items.Add("Please select a guild from the list.");
                return;
            }

            string[] nameMatch = listBox1.SelectedItem.ToString().Split('[');
            string[] serverMatch = nameMatch[1].Split(']');
            OutputBox.Items.Add("Guild Listing for " + nameMatch[0].Trim() + "\t[" + nameMatch[1]);
            OutputBox.Items.Add(new String('-', 70));

            // Check for valid match on guild name and server name
            foreach (KeyValuePair<uint, Player> pair in Players)
            {
                if (Guilds[pair.Value.GuildID].guildName == nameMatch[0].Trim() && Guilds[pair.Value.GuildID].serverName == serverMatch[0])
                {
                    OutputBox.Items.Add("Name: " + pair.Value.Name.PadRight(22, ' ') + "Race: " + Convert.ToString(pair.Value.Race).PadRight(15, ' ') + "Level: " + Convert.ToString(pair.Value.Level).PadRight(10, ' ') +
                                        "Guild: " + Guilds[pair.Value.GuildID].guildName + "-" + Guilds[pair.Value.GuildID].serverName);
                    printed++;                    
                }                                 
            }

            // If no members, print message
            if (printed == 0)
                OutputBox.Items.Add("There are currently no members in " + nameMatch[0].Trim() + "-" + serverMatch[0].Trim());
        }

        private void DisbandGuild_Click(object sender, EventArgs e)
        {
            // Check for a guilds selection, return if none
            if (listBox1.SelectedIndex == -1)
            {
                OutputBox.Items.Add("Please select a guild from the list.");
                return;
            }
            
            //splits up the guild and server name from the selected item in listbox1
            string[] nameMatch = listBox1.SelectedItem.ToString().Split('[');
            string[] serverMatch = nameMatch[1].Split(']');
            OutputBox.Items.Add("Guild Listing for " + nameMatch[0].Trim() + "\t[" + nameMatch[1]);
            OutputBox.Items.Add(new String('-', 70));
            
            uint guildID = 0;          
            //finds the guild id based on the name and server name
            foreach (KeyValuePair<uint, Guild> pair in Guilds)
            {
                if (pair.Value.guildName == nameMatch[0].Trim() && pair.Value.serverName == serverMatch[0])
                {
                    guildID = pair.Key;
                }
            }

            // Check for valid match on guild name and server name match and then removes those players from the guild
            foreach (KeyValuePair<uint, Player> pair in Players)
                if (pair.Value.GuildID == guildID)
                        pair.Value.GuildID = 0;

            //adds a message saying that guild has been disbanded
            OutputBox.Items.Add("The Guild " + Guilds[guildID].guildName + "on " + Guilds[guildID].serverName + " has been disbanded");

            //removes the guild from the list and then the box where it is listed
            if (guildID != 0)
                Guilds.Remove(guildID);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.SelectedIndex = -1;
        }

        private void JoinGuild_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button doesn't do anything yet.");
        }

        private void LeaveGuild_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This button doesn't do anything yet.");
        }

        // Button to filter players and guilds
        private void ApplySearchCriteria_Click(object sender, EventArgs e)
        {
            // Check if text boxes are both empty, if so do nothing
            if (textBox4.Text == "" && textBox3.Text == "")
            { 
                OutputBox.Items.Add("Please enter a search term to use this feature.");
                return;
            }

            // Otherwise print new lists based on search term(s)
            else
            {
                // Check for entry in player search term
                if (textBox4.Text != "")
                {
                    listBox2.Items.Clear();
                    // Populate the list
                    foreach (KeyValuePair<uint, Player> pair1 in Players)
                        if (pair1.Value.Name.StartsWith(textBox4.Text[0].ToString()))
                            listBox2.Items.Add(String.Format("{0} {1," + (20 - pair1.Value.Name.Length) + "} {2:00}", pair1.Value.Name, pair1.Value.Playerclass, pair1.Value.Level));                      

                    // If list is empty, reprint all players
                    if (listBox2.Items.Count == 0)
                    {
                        OutputBox.Items.Add("No match was found for entered player " + textBox4.Text);
                        foreach (KeyValuePair<uint, Player> pair2 in Players)
                            listBox2.Items.Add(String.Format("{0} {1," + (20 - pair2.Value.Name.Length) + "} {2:00}", pair2.Value.Name, pair2.Value.Playerclass, pair2.Value.Level));
                    }
                }

                // Check for entry in guild search term
                if (textBox3.Text != "")
                {
                    listBox1.Items.Clear();
                    // Populate the list
                    foreach (KeyValuePair<uint, Guild> pair1 in Guilds)
                        if (pair1.Value.serverName == textBox3.Text)
                            listBox1.Items.Add(String.Format("{0} {1}", pair1.Value.guildName, ("[" + pair1.Value.serverName + "]").PadLeft(40 - pair1.Value.guildName.Length)));

                    // If list is empty, reprint all guilds
                    if (listBox1.Items.Count == 0)
                    {
                        OutputBox.Items.Add("No match was found for entered server " + textBox3.Text);
                        foreach (KeyValuePair<uint, Guild> pair2 in Guilds)
                            listBox1.Items.Add(String.Format("{0} {1}", pair2.Value.guildName, ("[" + pair2.Value.serverName + "]").PadLeft(40 - pair2.Value.guildName.Length)));
                    }
                }
            }
        }
        // Reset the player list when player search term box cleared out
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                listBox2.Items.Clear();
                foreach (KeyValuePair<uint, Player> pair in Players)
                    listBox2.Items.Add(String.Format("{0} {1," + (20 - pair.Value.Name.Length) + "} {2:00}", pair.Value.Name, pair.Value.Playerclass, pair.Value.Level));
            }

        }
        // Reset the guild list when guild search term box cleared out
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                listBox1.Items.Clear();
                foreach (KeyValuePair<uint, Guild> pair in Guilds)
                    listBox1.Items.Add(String.Format("{0} {1}", pair.Value.guildName, ("[" + pair.Value.serverName + "]").PadLeft(40 - pair.Value.guildName.Length)));
            }
        }
                 
        //the button that adds a player
        private void AddPlayer_Click(object sender, EventArgs e)
        {
            //tests to make sure all the fields are filled in
            if (PlayerNameBox.TextLength == 0)
            {
                MessageBox.Show("Please enter a player name.");
                return;
            }
            if (RaceBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a race.");
                return;
            }
            if (ClassBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Class.");
                return;
            }
            if (RoleBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a Role.");
                return;
            }
            //checks to see if the player name is taken if so makes them change it
            if (FindPlayerName(Players, PlayerNameBox.Text.Trim()) != 2147483647)
            {
                MessageBox.Show("A player with that name already exists, please try another one.");
                return;
            }
            //creates a random key to assign the guild
            Random generator = new Random();
            uint r = (uint)generator.Next(0, 999999);
            //if it manages to get a key that already exists it trys again
            while (Players.ContainsKey(r))
                r = (uint)generator.Next(0, 999999);
            //makes an empty gear array for the constructor
            uint[] gear;
            gear = new uint[MAX_INVENTORY_SIZE];
            for (int i = 0; i < MAX_INVENTORY_SIZE; i++)
                gear[i] = 0;
            //creates the new player object and then adds it to the dictionary and then also adds it to the printing list.
            Players.Add(r, new Player(r, PlayerNameBox.Text.Trim(), (Race)RaceBox.SelectedIndex, (PlayerClass)ClassBox.SelectedIndex, 1, 0, 0, gear));
            listBox2.Items.Add(String.Format("{0} {1," + (20 - Players[r].Name.Length) + "} {2:00}", Players[r].Name, Players[r].Playerclass, Players[r].Level));
            //resets all the fields
            PlayerNameBox.Clear();
            RoleBox.SelectedIndex = -1;
            RaceBox.SelectedIndex = -1;
            ClassBox.SelectedIndex = -1;
        }
        //checks through the player dictionary based soley on a given name
        private uint FindPlayerName(Dictionary<uint, Player> Players, string pname)
        {
            //asks the user for the Player name   
            uint key = 2147483647;
            //searches the guild list for a Player by name
            foreach (KeyValuePair<uint, Player> pair in Players)
            {
                if (pair.Value.Name == pname)
                {
                    key = pair.Key;
                }
            }

            //returns and says that the Player couldn't be found.
            if (key == 2147483647)
            {
                return key;
            }

            //returns the Player key
            return key;
        }

        //the button to add a guild to the guild list.
        private void AddGuild_Click(object sender, EventArgs e)
        {
            //checks to see if the text box is empty
            if (GuildNameBox.TextLength == 0)
            {
                //if it is empty it asks the user to enter something and then returns
                MessageBox.Show("Please enter a guild name.");
                return;
            }
            //checks to see if the guild name already exists
            uint[] temp = FindGuild(Guilds, GuildNameBox.Text);
            for (uint i = 0; temp[i] != 2147483647; i++)
            {
                //if the name already exists it checks to see if it exists on the desired server
                if (Guilds[temp[i]].serverName.CompareTo(Servercombo.Text) == 0)
                {
                    //if it does it tells you and then returns
                    MessageBox.Show("A guild with that name on this server already exists.");
                    return;
                }
            }
            //creates a random key to assign the guild
            Random generator = new Random();
            uint r = (uint)generator.Next(0, 999999);
            //if it manages to get a key that already exists it trys again
            while (Guilds.ContainsKey(r))
                r = (uint)generator.Next(0, 999999);
            //adds the guild to the guild list and then adds it to the printed guild list.
            Guilds.Add(r, new Guild(GuildNameBox.Text.Trim(), Servercombo.Text, (GuildType)GuildTypeBox.SelectedIndex));
            listBox1.Items.Add(String.Format("{0} {1}", Guilds[r].guildName, ("[" + Guilds[r].serverName + "]").PadLeft(40 - Guilds[r].guildName.Length)));
            GuildNameBox.Clear();
            Servercombo.SelectedIndex = 0;
            GuildTypeBox.SelectedIndex = 0;
        }

        private void ClassBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ClassBox.SelectedIndex)
            {
                //Warrior case
                case 0:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Tank");
                    RoleBox.Items.Add("Dps");
                    break;
                //Mage case
                case 1:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Dps");
                    RoleBox.SelectedIndex = 0;
                    break;
                //Druid case
                case 2:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Tank");
                    RoleBox.Items.Add("Dps");
                    RoleBox.Items.Add("Healer");
                    break;
                //Priest
                case 3:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Healer");
                    RoleBox.Items.Add("Dps");
                    break;
                //Warlock
                case 4:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Dps");
                    RoleBox.SelectedIndex = 0;
                    break;
                //Rogue
                case 5:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Dps");
                    RoleBox.SelectedIndex = 0;
                    break;
                //Paladin
                case 6:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Tank");
                    RoleBox.Items.Add("Healer");
                    RoleBox.Items.Add("Dps");
                    break;
                //Hunter
                case 7:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Dps");
                    RoleBox.SelectedIndex = 0;
                    break;
                //Shaman
                case 8:
                    RoleBox.Items.Clear();
                    RoleBox.Items.Add("Healer");
                    RoleBox.Items.Add("Dps");
                    break;
                default:
                    break;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] s = listBox2.SelectedItem.ToString().Split(' ');
            uint key = FindPlayerName(Players, s[0]);
            OutputBox.Items.Add(Players[key]);
        }    
    }
}
