using System.Collections.Generic;
using System.Drawing.Drawing2D;

public class ocTables
{   
    public List<ocTable> items { get; set; }
    public ocTables()
    {
        
    }

    public void load_tables(string tableFile)
    {
        string[] lines = System.IO.File.ReadAllLines(@tableFile);

        foreach (string line in lines)
        {
            string[] array = line.Split('#');
            ocTable table = new ocTable();
            table.dbTableName = array[0];
            table.ocTableName = array[1];
            table.ocTableMeta = array[2];
            table.ocTableAppointment = array[3];
            table.confID = array[4];
        }
    }
}