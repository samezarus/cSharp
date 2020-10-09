using System;
using System.Collections.Generic;

public class ocTable
{
    public string dbTableName { get; set; }
    public string ocTableName { get; set; }
    public string ocTableMeta { get; set; }
    public string ocTableAppointment { get; set; }
    public string confID { get; set; }
    public List<ocField> fields { get; set; }
    public ocTable()
    {
        fields = new List<ocField>();
    }
}