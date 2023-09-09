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

        public List<Room> GetRoomData { get { return allRooms; } }
        public List<Item> GetItemData { get; }

        public DataHandler()
        {
            allRooms = new List<Room>();
            allItems = new List<Item>();

            CreateRooms();
        }

        public Room GetRoom(int id)
        {
            foreach (Room r in allRooms)
                if (id == r.GetID) return r;

            return null;
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
                int nT = Convert.ToInt32(r.ChildNodes[7].InnerText);
                int sT = Convert.ToInt32(r.ChildNodes[8].InnerText);
                int eT = Convert.ToInt32(r.ChildNodes[9].InnerText);
                int wT = Convert.ToInt32(r.ChildNodes[10].InnerText);

                allRooms.Add(new Room(id,n,d,nR,sR,eR,wR,nT,sT,eT,wT));
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
