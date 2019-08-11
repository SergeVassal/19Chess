﻿using System;
using System.Runtime.Serialization;

/// <summary>
/// Interface, which must be implemented by every serialize of response data.
/// </summary>
public interface IDataSerializer
{
    /// <summary>
    /// Deserializes the string to the specified .NET type.
    /// </summary>
    /// <param name="serializedData">The serialized string data to deserialize.</param>
    /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
    /// <exception cref="SerializationException">Thrown when an error occurs during Json serialization or deserialization.</exception>
    /// <returns>The deserialized object from the string.</returns>
    T Deserialize<T>(string serializedData);

    /// <summary>
    /// Deserializes the string to the specified .NET type.
    /// </summary>
    /// <param name="serializedData">The serialized string data to deserialize.</param>
    /// <param name="type">The type of the object to deserialize.</param>
    /// <exception cref="SerializationException">Thrown when an error occurs during Json serialization or deserialization.</exception>
    /// <returns>The deserialized object from the string.</returns>
    object Deserialize(string serializedData, Type type);

    /// <summary>
    /// Serializes the specified object to a string.
    /// </summary>
    /// <param name="obj">The object to serialize.</param>
    /// <exception cref="SerializationException">Thrown when an error occurs during Json serialization or deserialization.</exception>
    /// <returns>A string representation of the object.</returns>
    string Serialize(object obj);
}