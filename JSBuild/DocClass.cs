using System;
using System.Collections.Generic;
using System.Text;

namespace JSBuild
{
    class DocClass
    {
        string Name = "";
        string Author = "";
        string Extends = "";
        string Description = "";
        List<DocEvent> Events = new List<DocEvent>();
        List<DocMethod> Methods = new List<DocMethod>();
        List<DocProp> Props = new List<DocProp>();
    }

    class DocEvent{
        string Name = "";
        string Description = "";
        List<DocProp> Params = new List<DocProp>();
    }

    class DocMethod
    {
        string Name = "";
        string Description = "";
        List<DocProp> Params = new List<DocProp>();
    }

    class DocProp 
    {
        string Name = "";
        string Description = "";
        string Type = "";
    }
}
