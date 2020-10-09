using System;
using System.Collections.Generic;

public class ocField
{
    public string dbTableName { get; set; }
    public string dbFieldName { get; set; }
    public string ocFieldName { get; set; }
    public string ocFieldMeta { get; set; }
    public string ocFieldType { get; set; }
    public string confID { get; set; }
    public List<ocTable> references { get; set; }
    public ocField()
    {
        references = new List<ocTable>();
    }
}