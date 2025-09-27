using System.Reflection;

namespace Ejercicio_1.Models;

/// <summary>
/// Clase de utilidades para trabajar con enums y sus descripciones
/// </summary>
public static class EnumHelper
{
    /// <summary>
    /// Obtiene la descripción de un valor de enum usando reflexión
    /// </summary>
    public static string GetDescripcion<T>(T enumValue) where T : Enum
    {
        var field = enumValue.GetType().GetField(enumValue.ToString());
        var attribute = field?.GetCustomAttribute<DescripcionEnumAttribute>();
        return attribute?.Descripcion ?? enumValue.ToString();
    }

    /// <summary>
    /// Obtiene todas las descripciones de un enum
    /// </summary>
    public static Dictionary<T, string> GetTodasLasDescripciones<T>() where T : Enum
    {
        var resultado = new Dictionary<T, string>();
        var tipo = typeof(T);
        var valores = Enum.GetValues(tipo).Cast<T>();

        foreach (var valor in valores)
        {
            var field = tipo.GetField(valor.ToString());
            var attribute = field?.GetCustomAttribute<DescripcionEnumAttribute>();
            resultado[valor] = attribute?.Descripcion ?? valor.ToString();
        }

        return resultado;
    }

    /// <summary>
    /// Convierte una descripción de vuelta a su valor de enum
    /// </summary>
    public static T ParseDescripcion<T>(string descripcion) where T : Enum
    {
        var tipo = typeof(T);
        var valores = Enum.GetValues(tipo).Cast<T>();

        foreach (var valor in valores)
        {
            var field = tipo.GetField(valor.ToString());
            var attribute = field?.GetCustomAttribute<DescripcionEnumAttribute>();
            if (attribute?.Descripcion == descripcion)
            {
                return valor;
            }
        }

        throw new ArgumentException($"No se encontró un valor de enum para la descripción: {descripcion}");
    }
}
