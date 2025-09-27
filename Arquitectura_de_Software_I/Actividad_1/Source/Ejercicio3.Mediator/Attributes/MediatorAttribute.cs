namespace Ejercicio3.Attributes;

/// <summary>
/// Atributo que marca un método como handler de mensajes en el mediador.
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class MediatorHandlerAttribute : Attribute
{
    /// <summary>
    /// Tipo de mensaje que maneja este método.
    /// </summary>
    public string MessageType { get; }

    /// <summary>
    /// Descripción del handler.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Inicializa una nueva instancia del atributo MediatorHandler.
    /// </summary>
    /// <param name="messageType">Tipo de mensaje que maneja.</param>
    /// <param name="description">Descripción del handler.</param>
    public MediatorHandlerAttribute(string messageType, string description = "")
    {
        MessageType = messageType;
        Description = description;
    }
}

/// <summary>
/// Atributo que marca una clase como participante del mediador.
/// </summary>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class MediatorParticipantAttribute : Attribute
{
    /// <summary>
    /// Nombre del participante en el mediador.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Inicializa una nueva instancia del atributo MediatorParticipant.
    /// </summary>
    /// <param name="name">Nombre del participante.</param>
    public MediatorParticipantAttribute(string name = "")
    {
        Name = name;
    }
}

/// <summary>
/// Atributo que marca una propiedad como configurable en el mediador.
/// </summary>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class MediatorPropertyAttribute : Attribute
{
    /// <summary>
    /// Nombre de la propiedad en el contexto del mediador.
    /// </summary>
    public string PropertyName { get; }

    /// <summary>
    /// Indica si la propiedad es requerida.
    /// </summary>
    public bool IsRequired { get; }

    /// <summary>
    /// Inicializa una nueva instancia del atributo MediatorProperty.
    /// </summary>
    /// <param name="propertyName">Nombre de la propiedad.</param>
    /// <param name="isRequired">Indica si es requerida.</param>
    public MediatorPropertyAttribute(string propertyName = "", bool isRequired = false)
    {
        PropertyName = propertyName;
        IsRequired = isRequired;
    }
}
