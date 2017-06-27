using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Pages_ResourceControlCS : System.Web.UI.UserControl
{
    private string _type;


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


    [Bindable(BindableSupport.Yes, BindingDirection.TwoWay)]
    public object Value
    {
        get
        {
            if (ResourceValue.SelectedValue != "NULL")
            {
                return DeserializeResourceKey(ResourceValue.SelectedValue);
            }

            return "";
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
    public string Skin
    {
        get
        {
            return ResourceValue.Skin;
        }

        set
        {
            ResourceValue.Skin = value;
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
        if (ResourceValue.Items.Count == 0)
        {
            PopulateResources();
            MarkSelectedResource();
        }
    }

    /// <summary>
    /// Populates the resource options.
    /// </summary>
    private void PopulateResources()
    {
        foreach (Resource res in GetResources(Type))
        {
            ResourceValue.Items.Add(new RadComboBoxItem(res.Text, SerializeResourceKey(res.Key)));
        }
    }

    /// <summary>
    /// Marks (selects) the resource currently associated with the appointment.
    /// </summary>
    private void MarkSelectedResource()
    {
        ResourceValue.Items.Insert(0, new RadComboBoxItem("-", "NULL"));

        Resource res = Appointment.Resources.GetResourceByType(Type);
        if (res != null)
        {
            ResourceValue.SelectedValue = SerializeResourceKey(res.Key);
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
        IEnumerable<Resource> resources = Owner.Provider.GetResourcesByType(Owner, resType);

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