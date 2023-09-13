using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Week_1_Assignment___Dungeon_Crawler
{
    public class DataHandler
    {
        List<Room> allRooms;
        List<Item> allItems;
        List<Trap> allTraps;

        public List<Room> GetRoomData { get { return allRooms; } }
        public List<Item> GetItemData { get { return allItems; } }
        public List<Trap> GetTrapData { get { return allTraps; } }

        public DataHandler()
        {
            allRooms = new List<Room>();
            allItems = new List<Item>();
            allTraps = new List<Trap>();

            CreateTraps();
            CreateRooms();
            CreateItems();
        }

        public Room GetRoom(int id)
        {
            foreach (Room r in allRooms)
                if (id == r.GetID) return r;

            return null;
        }
        public Trap GetTrap(int id)
        {
            foreach(Trap t in allTraps)
                if (id == t.GetID) return t;
            return null;
        }
        void CreateTraps()
        {
            string file = "Trap_Data";
            string root = "Trap-data/Trap";

            foreach (XmlElement r in GetList(file, root))
            {
                int id = Convert.ToInt32(r.ChildNodes[0].InnerText);
                string n = r.ChildNodes[1].InnerText;
                string def = r.ChildNodes[2].InnerText;
                string hint = r.ChildNodes[3].InnerText;
                string dis = r.ChildNodes[4].InnerText;
                string failed = r.ChildNodes[5].InnerText;
                string i = r.ChildNodes[6].InnerText;

                allTraps.Add(new Trap(id, n, def, hint, dis, failed, i));
            }
        }
        void CreateRooms()
        {
            string file = "Room_Data";
            string root = "Room-data/Room";

            foreach (XmlElement r in GetList(file, root))
            {
                int id = Convert.ToInt32(r.ChildNodes[0].InnerText);
                string n = r.ChildNodes[1].InnerText;
                string d = r.ChildNodes[2].InnerText;

                int nR = Convert.ToInt32(r.ChildNodes[3].InnerText);
                int sR = Convert.ToInt32(r.ChildNodes[4].InnerText);
                int eR = Convert.ToInt32(r.ChildNodes[5].InnerText);
                int wR = Convert.ToInt32(r.ChildNodes[6].InnerText);
                Trap T = GetTrap(Convert.ToInt32(r.ChildNodes[7].InnerText));

                allRooms.Add(new Room(id, n, d, nR, sR, eR, wR, T));
            }
        }
        void CreateItems()
        {
            string file = "Item_Data";
            string root = "Item-data/Item";


            foreach (XmlElement i in GetList(file, root))
            {
                string n = i.ChildNodes[0].InnerText;
                string d = i.ChildNodes[1].InnerText;
                int location = Convert.ToInt32(i.ChildNodes[2].InnerText);

                Item temp = new Item(n, d);
                allItems.Add(temp);
                allRooms[location].loot.Add(temp);
            }
        }


        XmlNodeList GetList(string file, string rootName)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load($"../../data/{file}.xml");

            XmlNode root = doc.DocumentElement;
            return root.SelectNodes($"/{rootName}");
        }
    }
}
