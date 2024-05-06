// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class TableSet(int line, Expression table, Expression index, Expression value, bool isTable, int timestamp) : Operation(line)
{
    private readonly Expression m_table = table;
    private readonly Expression m_index = index;
    private readonly Expression m_value = value;
    private readonly bool m_isTable = isTable;
    private readonly int m_timestamp = timestamp;

    public override Statement Process(Registers r, Block block)
    {
        // .isTableLiteral() is sufficient when there is debugging info
        // TODO: Fix the commented out section screwing up tables
        if (this.m_table.IsTableLiteral /*&& (m_value.IsMultiple || m_table.IsNewEntryAllowed)*/)
        {
            this.m_table.AddEntry(new TableLiteral.Entry(this.m_index, this.m_value, !this.m_isTable, this.m_timestamp));
            return null;
        }

        return new Assignment(new TableTarget(this.m_table, this.m_index), this.m_value);
    }
}
