using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_MultipleValuesResourceControlCS : System.Web.UI.UserControl
{
    private string _type;

    /// <summary>
    /// A modified CheckBoxList that renders an unordered list, instead of a table.
    /// </summary>
    protected class SemanticCheckBoxList : CheckBoxList
    {
        protected override void Render(HtmlTextWriter writer)
        {
            writer.WriteBeginTag("ul");

            writer.WriteAttribute("class", "rsCheckBoxList");

            writer.Write(HtmlTextWriter.TagRightChar);

            for (int i = 0; i < RepeatedItemCount; i++)
            {
                writer.RenderBeginTag(HtmlTextWriterTag.Li);
                RenderItem(ListItemType.Item, i, null, writer);
                writer.RenderEndTag();
            }

            writer.WriteEndTag("ul");
        }
    }

    protected Appointment Appointment
    {
        get
        {
            SchedulerFormContainer container = (SchedulerFormContainer)BindingContainer;
            return container.Appointment;
        }
    }

    protected RadScheduler Owner
    {
        get
        {
            return Appointment.Owner;
        }
    }

    protected SemanticCheckBoxList ResourceValue
    {
        get
        {
            return (SemanticCheckBoxList)FindControl("ResourceValue");
        }
    }

    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public object Value
    {
        get
        {
            return ExtractResourceValues();
        }

        set
        {

        }
    }

    [Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
    public string Label
    {
        get
        {
            return ResourceLabel.Text;
        }

        set
        {
            ResourceLabel.Text = value;
        }
    }

    [Bindable(BindableSupport.Yes, BindingDirection.OneWay)]
    public string Type
    {
        get
        {
            return _type;
        }

        set
        {
            _type = value;
        }
    }


    protected void Page_Load(object sender, EventArgs e)
    {
        SemanticCheckBoxList resourceValue = new SemanticCheckBoxList();
        resourceValue.ID = "ResourceValue";
        ResourceValuesPlaceHolder.Controls.Add(resourceValue);

        if (resourceValue.Items.Count == 0)
        {
            PopulateResources();
            MarkSelectedResources();
        }
    }

    /// <summary>
    /// Populates the resource options.
    /// </summary>
    private void PopulateResources()
    {
        foreach (Resource res in GetResources(Type))
        {
            ResourceValue.Items.Add(new ListItem(res.Text, SerializeResourceKey(res.Key)));
        }
    }

    /// <summary>
    /// Marks (selects) the resources currently associated with the appointment.
    /// </summary>
    private void MarkSelectedResources()
    {
        foreach (Resource res in Appointment.Resources.GetResourcesByType(Type))
        {
            ResourceValue.Items.FindByValue(SerializeResourceKey(res.Key)).Selected = true;
        }
    }

    /// <summary>
    /// Gets a list of the resources of the specified type.
    /// </summary>
    /// <param name="resType">Type of the resources to search for.</param>
    /// <returns>A list of the resources of the specified type.</returns>
    private IEnumerable<Resource> GetResources(string resType)
    {
        List<Resource> availableResources = new List<Resource>();
        IEnumerable<Resource> resources = Owner.Resources.GetResourcesByType(resType);

        foreach (Resource res in resources)
        {
            if (IncludeResource(res))
            {
                availableResources.Add(res);
            }
        }

        return availableResources;
    }

    /// <summary>
    /// Returns a boolean value, indicating if a resource should be included in the list.
    /// You can use this method to define your custom filtering logic.
    /// </summary>
    /// <param name="res">The resource to filter.</param>
    /// <returns>A boolean value, indicating if a resource should be included in the list.</returns>
    private bool IncludeResource(Resource res)
    {
        return res.Available || ResourceIsInUse(res);
    }

    /// <summary>
    /// Returns a boolean value, indicating if a resource is already assigned to the appointment.
    /// </summary>
    /// <param name="res">The resource to check.</param>
    /// <returns>A boolean value, indicating if a resource is already assigned to the appointment.</returns>
    private bool ResourceIsInUse(Resource res)
    {
        foreach (Resource appRes in Appointment.Resources)
        {
            if (res == appRes)
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Extracts the resource values from the CheckBoxList.
    /// </summary>
    /// <returns>
    /// Depending the number of selected resources it returns either
    /// a single key or an array of resource keys.
    /// </returns>
    private object ExtractResourceValues()
    {
        ArrayList resourceKeys = new ArrayList();
        foreach (ListItem li in ResourceValue.Items)
        {
            if (li.Selected && li.Value != "NULL")
            {
                resourceKeys.Add(DeserializeResourceKey(li.Value));
            }
        }

        switch (resourceKeys.Count)
        {
            case 0:
                return string.Empty;

            case 1:
                return resourceKeys[0];

            default:
                return resourceKeys.ToArray();
        }
    }

    /// <summary>
    /// Serializes a resource key using LosFormatter.
    /// </summary>
    /// <remarks>
    ///    The resource keys need to be serialized as they can be arbitrary objects.
    /// </remarks>
    /// <param name="key">The key to serialize.</param>
    /// <returns>The serialized key.</returns>
    private string SerializeResourceKey(object key)
    {
        LosFormatter output = new LosFormatter();
        StringWriter writer = new StringWriter();
        output.Serialize(writer, key);
        return writer.ToString();
    }

    /// <summary>
    /// Deserializes a resource key using LosFormatter.
    /// </summary>
    /// <remarks>
    ///    The resource keys need to be serialized as they can be arbitrary objects.
    /// </remarks>
    /// <param name="key">The key to deserialize.</param>
    /// <returns>The deserialized key.</returns>
    private object DeserializeResourceKey(string key)
    {
        LosFormatter input = new LosFormatter();
        return input.Deserialize(key);
    }
}