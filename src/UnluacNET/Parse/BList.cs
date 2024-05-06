// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class BList<T>(BInteger length, List<T> values) : IBObject
    where T : IBObject
{
    private readonly List<T> m_values = values;

    public BInteger Length { get; private set; } = length;

    public T this[int index] => this.m_values[index];

    public T[] AsArray()
        => this.m_values.AsParallel().ToArray();
}
