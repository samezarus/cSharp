using System;
using System.Collections.Generic;

public class ocField
{
    public string dbFieldName { get; set; }
    public string ocFieldName { get; set; }
    public string ocFieldMeta { get; set; }
    public string ocFieldType { get; set; }
    public List<ocTable> references { get; set; }
}