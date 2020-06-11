using System;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

public class BindHelper
{
  protected object src;
  protected string srcProp;
  protected object dest;
  protected string destProp;

  protected PropertyInfo srcPropInfo;
  protected PropertyInfo destPropInfo;

  public BindHelper(object src, 
       string srcProp, object dest, string destProp)
  {
    this.src=src;
    this.srcProp=srcProp;
    this.dest=dest;
    this.destProp=destProp;
  
    Type t1=src.GetType();
    Type t2=dest.GetType();

    // Get the PropertyInfo now 
    // rather than in the event handler.
    srcPropInfo=t1.GetProperty(srcProp);
    destPropInfo=t2.GetProperty(destProp);
  }

  public static void Bind(object obj1, string prop1,
                            object obj2, string prop2)
  {
    string event1=prop1+"Changed";
    string event2=prop2+"Changed";

    Type t1=obj1.GetType();
    Type t2=obj2.GetType();

    EventInfo ei1=t1.GetEvent(event1);
    EventInfo ei2=t2.GetEvent(event2);

    BindHelper bh=new BindHelper(obj1, prop1, obj2, prop2);

    // The signature of the event 
    // delegate must be of the form 
    // (object, EventArgs).
    // Although events don't have to be 
    // of this signature, this is a good
    // reason to comply with the .NET guidelines.

    // Unfortunately, .NET 1.1 does not 
    // handle event signatures that are 
    // derived from EventArgs when programatically 
    // adding a generic handler.
    // This "bug" is corrected in .NET 2.0!

    ei1.AddEventHandler(obj1, 
         new EventHandler(bh.SourceChanged));
    ei2.AddEventHandler(obj2, 
         new EventHandler(bh.DestinationChanged));

    bh.DestinationChanged(bh, EventArgs.Empty);
  }

  private void SourceChanged(object sender, EventArgs e)
  {
    object val=srcPropInfo.GetValue(src, null);
    destPropInfo.SetValue(dest, val, null);
  }

  private void DestinationChanged(object sender, 
                                         EventArgs e)
  {
    object val=destPropInfo.GetValue(dest, null);
    srcPropInfo.SetValue(src, val, null);
  }
}