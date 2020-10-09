using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System;

public class ocTables
{
    public List<string> confs { get; set; }
    public List<ocTable> tables { get; set; }
    public ocTables()
    {
        confs = new List<string>();
        tables = new List<ocTable>();
    }
    public void load_tables(string fullFilePath)
    {
        string contentFile = @fullFilePath;

        if (File.Exists(contentFile))
        {
            string[] lines = System.IO.File.ReadAllLines(contentFile);

            bool headFl = true;
            bool getConfId = true;

            foreach (string line in lines)
            {
                if (headFl)
                {
                    headFl = false;
                }
                else
                {
                    string[] array = line.Split('#');
                    if (array.Length > 0)
                    {
                        ocTable item = new ocTable();
                        item.dbTableName = array[0];
                        item.ocTableName = array[1];
                        item.ocTableMeta = array[2];
                        item.ocTableAppointment = array[3];
                        item.confID = array[4];

                        if (getConfId)
                        {
                            
                            if (confs.Count == 0)
                            {
                                confs.Add(item.confID);
                            }
                            else
                            {
                                int ndx = confs.IndexOf(item.confID);

                                if (ndx != -1)
                                {
                                    confs.Add(item.confID);
                                }

                            }

                            getConfId = false;
                        }

                        tables.Add(item);
                    }
                }
            }
        }
    }
    public void load_fields(string fullFilePath)
    {
        string contentFile = @fullFilePath;

        if (File.Exists(contentFile))
        {
            string[] lines = System.IO.File.ReadAllLines(contentFile);

            bool headFl = true;
            foreach (string line in lines)
            {
                if (headFl)
                {
                    headFl = false;
                }
                else
                {
                    string[] array = line.Split('#');
                    if (array.Length > 0)
                    {                        
                        ocField item = new ocField();
                        item.dbTableName = array[0];
                        item.dbFieldName = array[1];
                        item.ocFieldName = array[2];
                        item.ocFieldMeta = array[3];
                        item.ocFieldType = array[4];
                        item.confID = array[5];

                        List<string> refs = new List<string>();
                        if (item.ocFieldType != "" && item.ocFieldType.IndexOf(".") != -1)
                        {
                            string[] a = item.ocFieldType.Split(';');
                            foreach (string r in array)
                            {
                                refs.Add(r);
                            }
                        }

                        foreach (ocTable table in tables)
                        {   
                            if (item.confID == table.confID)
                            {
                                if (item.dbTableName == table.dbTableName)
                                {
                                    table.fields.Add(item);
                                }

                                if (refs.Count > 0)
                                {
                                    foreach (string r in refs)
                                    {
                                        if (r == table.ocTableName && item.dbTableName != table.dbTableName)
                                        {
                                            item.references.Add(table);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}